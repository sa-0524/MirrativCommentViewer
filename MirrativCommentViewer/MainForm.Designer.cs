
namespace MirrativCommentViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUrl = new System.Windows.Forms.Label();
            this.txbUrl = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panelComment = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(13, 13);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(28, 15);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "URL";
            // 
            // txbUrl
            // 
            this.txbUrl.Location = new System.Drawing.Point(47, 10);
            this.txbUrl.MaxLength = 256;
            this.txbUrl.Name = "txbUrl";
            this.txbUrl.Size = new System.Drawing.Size(206, 23);
            this.txbUrl.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(259, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "接続";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panelComment
            // 
            this.panelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelComment.Location = new System.Drawing.Point(10, 40);
            this.panelComment.Name = "panelComment";
            this.panelComment.Size = new System.Drawing.Size(320, 380);
            this.panelComment.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 431);
            this.Controls.Add(this.panelComment);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txbUrl);
            this.Controls.Add(this.lblUrl);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MirrativCommentViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txbUrl;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panelComment;
    }
}

