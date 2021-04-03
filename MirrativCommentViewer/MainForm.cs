using MirrativCommentViewer.Control;
using MirrativCommentViewer.Dao;
using MirrativCommentViewer.Dto;
using MirrativCommentViewer.Properties;
using MirrativCommentViewer.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace MirrativCommentViewer
{
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// テキスト読み上げサービス
        /// </summary>
        private TextSpeechService sppechService;

        /// <summary>
        /// コメント取得処理タイマ
        /// </summary>
        private Timer timer;

        /// <summary>
        /// HTTPクライアント
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// コメント取得Dao
        /// </summary>
        private CommentDao dao;

        /// <summary>
        /// 最新コメント日時
        /// </summary>
        private DateTimeOffset? latestDateTime;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            sppechService = new TextSpeechService();

            timer = new Timer();
            timer.Tick += RecieveCommentsAsync;
            timer.Interval = Constants.RequestInterval;

            client = new HttpClient();
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sppechService.Dispose();

            timer.Stop();
            timer.Dispose();

            client.Dispose();
        }

        /// <summary>
        /// 接続ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            timer.Stop();

            var url = txbUrl.Text;
            var matches = Constants.UrlPattern.Match(url);
            if (matches.Success)
            {
                var liveId = matches.Groups[1].Value;
                dao = new CommentDao(client, liveId);
                latestDateTime = null;
                timer.Start();
            }
            else
            {
                MessageBox.Show(Resources.ErrorInputUrl, Resources.ErrorCaptionInput);
            }
        }

        /// <summary>
        /// コメント受信処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RecieveCommentsAsync(object sender, EventArgs e)
        {
            var comments = await dao.GetCommentsAsync();
            if (comments != null)
            {
                var tmpLatest = comments.Max(x => x.CreateDateTime);
                if (!latestDateTime.HasValue || tmpLatest > latestDateTime)
                {
                    var latestComments = comments.OrderByDescending(x => x.CreateDateTime).
                        Take(Constants.CommentCount).ToList();

                    DrawComment(latestComments);

                    var newComments = latestComments.Where(x => x.CreateDateTime > latestDateTime).
                        OrderBy(x => x.CreateDateTime).Select(x => x.comment);
                    sppechService.Enqueue(newComments);

                    latestDateTime = tmpLatest;
                }
            }
        }

        /// <summary>
        /// コメント描画
        /// </summary>
        /// <param name="comments">コメント一覧</param>
        private void DrawComment(List<CommentDto> comments)
        {
            panelComment.Controls.Clear();

            var y = 0;
            comments.ForEach(x =>
            {
                var obj = new CommentPanel(x);
                obj.Location = new Point(Constants.CommentMargin, y);
                obj.Size = new Size(Size.Width, obj.Size.Height);
                panelComment.Controls.Add(obj);
                y += obj.Size.Height;
            });
        }
    }
}
