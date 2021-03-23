
namespace MirrativCommentViewer
{
    partial class CommentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridComment = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridComment)).BeginInit();
            this.SuspendLayout();
            // 
            // gridComment
            // 
            this.gridComment.AllowUserToAddRows = false;
            this.gridComment.AllowUserToDeleteRows = false;
            this.gridComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.UserName,
            this.Message});
            this.gridComment.Location = new System.Drawing.Point(13, 13);
            this.gridComment.Name = "gridComment";
            this.gridComment.ReadOnly = true;
            this.gridComment.RowTemplate.Height = 25;
            this.gridComment.Size = new System.Drawing.Size(680, 360);
            this.gridComment.TabIndex = 0;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "CreateDate";
            this.Date.HeaderText = "投稿日時";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "user_name";
            this.UserName.HeaderText = "名前";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 120;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "comment";
            this.Message.HeaderText = "コメント";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 400;
            // 
            // CommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 386);
            this.Controls.Add(this.gridComment);
            this.Name = "CommentForm";
            this.Text = "コメント一覧";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommentForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gridComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}