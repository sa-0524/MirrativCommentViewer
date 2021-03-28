using MirrativCommentViewer.Dto;
using System.Windows.Forms;

namespace MirrativCommentViewer.Control
{
    /// <summary>
    /// コメントパネル
    /// </summary>
    public partial class CommentPanel : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CommentPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dto">表示対象データ</param>
        public CommentPanel(CommentDto dto) : this()
        {
            lblName.Text = dto.user_name;
            lblMessage.Text = dto.comment;
            lblDate.Text = $"({dto.CreateDateText})";

            pboxIcon.ImageLocation = dto.profile_image_url;
            pboxIcon.Paint += DrawIcon;
        }

        /// <summary>
        /// アイコン描画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawIcon(object sender, PaintEventArgs e)
        {
            if (pboxIcon.Image != null)
            {
                e.Graphics.DrawImage(pboxIcon.Image, 0, 0, pboxIcon.Width, pboxIcon.Height);
            }
        }
    }
}
