using MirrativCommentViewer.Properties;
using System;
using System.Windows.Forms;

namespace MirrativCommentViewer
{
    /// <summary>
    /// メイン画面
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 接続ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            var url = txbUrl.Text;
            var matches = Constants.UrlPattern.Match(url);
            if (matches.Success)
            {
                var liveId = matches.Groups[1].Value;
                var commentForm = new CommentForm(this, liveId);
                commentForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(Resources.ErrorInputUrl, Resources.ErrorCaptionInput);
            }
        }
    }
}
