namespace ACT.HueSync
{
    partial class ConfigForm
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SearchHueBtn = new System.Windows.Forms.Button();
            this.SearchInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 1;
            // 
            // SearchHueBtn
            // 
            this.SearchHueBtn.Location = new System.Drawing.Point(216, 22);
            this.SearchHueBtn.Name = "SearchHueBtn";
            this.SearchHueBtn.Size = new System.Drawing.Size(143, 23);
            this.SearchHueBtn.TabIndex = 2;
            this.SearchHueBtn.Text = "Search Hue Bridge";
            this.SearchHueBtn.UseVisualStyleBackColor = true;
            this.SearchHueBtn.Click += new System.EventHandler(this.SearchHueBtn_Click);
            // 
            // SearchInfo
            // 
            this.SearchInfo.AutoSize = true;
            this.SearchInfo.Location = new System.Drawing.Point(214, 62);
            this.SearchInfo.Name = "SearchInfo";
            this.SearchInfo.Size = new System.Drawing.Size(39, 12);
            this.SearchInfo.TabIndex = 3;
            this.SearchInfo.Text = "Ready.";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SearchInfo);
            this.Controls.Add(this.SearchHueBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Size = new System.Drawing.Size(535, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Button SearchHueBtn;
        internal System.Windows.Forms.Label SearchInfo;
    }
}
