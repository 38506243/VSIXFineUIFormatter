namespace FineUICoder
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAutoSaveFile = new System.Windows.Forms.CheckBox();
            this.btFormat = new System.Windows.Forms.Button();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.rtbRazor = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAutoSaveFile);
            this.panel1.Controls.Add(this.btFormat);
            this.panel1.Controls.Add(this.btOpenFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 76);
            this.panel1.TabIndex = 0;
            // 
            // cbAutoSaveFile
            // 
            this.cbAutoSaveFile.AutoSize = true;
            this.cbAutoSaveFile.Location = new System.Drawing.Point(20, 49);
            this.cbAutoSaveFile.Name = "cbAutoSaveFile";
            this.cbAutoSaveFile.Size = new System.Drawing.Size(180, 16);
            this.cbAutoSaveFile.TabIndex = 2;
            this.cbAutoSaveFile.Text = "打开文件时自动格式化并保存";
            this.cbAutoSaveFile.UseVisualStyleBackColor = true;
            // 
            // btFormat
            // 
            this.btFormat.Location = new System.Drawing.Point(200, 20);
            this.btFormat.Name = "btFormat";
            this.btFormat.Size = new System.Drawing.Size(120, 23);
            this.btFormat.TabIndex = 1;
            this.btFormat.Text = "格式化";
            this.btFormat.UseVisualStyleBackColor = true;
            this.btFormat.Click += new System.EventHandler(this.BtFormat_Click);
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(20, 20);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(120, 23);
            this.btOpenFile.TabIndex = 0;
            this.btOpenFile.Text = "打开文件...";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.BtOpenFile_Click);
            // 
            // rtbRazor
            // 
            this.rtbRazor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRazor.Location = new System.Drawing.Point(0, 76);
            this.rtbRazor.Name = "rtbRazor";
            this.rtbRazor.Size = new System.Drawing.Size(720, 438);
            this.rtbRazor.TabIndex = 1;
            this.rtbRazor.Text = resources.GetString("rtbRazor.Text");
            this.rtbRazor.WordWrap = false;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 514);
            this.Controls.Add(this.rtbRazor);
            this.Controls.Add(this.panel1);
            this.Name = "MainFrm";
            this.Text = "FineUI格式化";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.RichTextBox rtbRazor;
        private System.Windows.Forms.Button btFormat;
        private System.Windows.Forms.CheckBox cbAutoSaveFile;
    }
}

