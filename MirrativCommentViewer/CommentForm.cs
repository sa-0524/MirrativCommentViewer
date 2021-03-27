using MirrativCommentViewer.Control;
using MirrativCommentViewer.Dao;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace MirrativCommentViewer
{
    /// <summary>
    /// コメントフォーム
    /// </summary>
    public partial class CommentForm : Form
    {
        /// <summary>
        /// 呼び出し元
        /// </summary>
        private MainForm parent;

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
        private DateTimeOffset latestDateTime;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent">呼び出し元</param>
        /// <param name="liveId">放送ID</param>
        public CommentForm(MainForm parent, string liveId)
        {
            InitializeComponent();

            this.parent = parent;

            timer = new Timer();
            timer.Tick += RecieveCommentsAsync;
            timer.Interval = Constants.RequestInterval;
            timer.Start();

            client = new HttpClient();
            dao = new CommentDao(client, liveId);
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
            timer.Dispose();

            client.Dispose();

            parent.Show();
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
                if (tmpLatest > latestDateTime)
                {
                    Controls.Clear();

                    var y = 0;
                    comments.ForEach(x =>
                    {
                        var obj = new CommentPanel(x);
                        obj.Location = new Point(Constants.CommentMargin, y);
                        obj.Size = new Size(Size.Width - 50, obj.Size.Height);
                        Controls.Add(obj);
                        y += obj.Size.Height;
                    });
                    latestDateTime = tmpLatest;
                }
            }
        }
    }
}
