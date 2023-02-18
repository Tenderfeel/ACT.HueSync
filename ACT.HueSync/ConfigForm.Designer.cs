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
            this.IpAddress = new System.Windows.Forms.TextBox();
            this.SearchHueBtn = new System.Windows.Forms.Button();
            this.SearchInfo = new System.Windows.Forms.Label();
            this.SearchResultList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hue Bridge IP Address:";
            // 
            // IpAddress
            // 
            this.IpAddress.Location = new System.Drawing.Point(161, 24);
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Size = new System.Drawing.Size(201, 19);
            this.IpAddress.TabIndex = 1;
            this.IpAddress.TextChanged += new System.EventHandler(this.IpAddress_Change);
            // 
            // SearchHueBtn
            // 
            this.SearchHueBtn.Location = new System.Drawing.Point(35, 62);
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
            this.SearchInfo.Location = new System.Drawing.Point(184, 67);
            this.SearchInfo.Name = "SearchInfo";
            this.SearchInfo.Size = new System.Drawing.Size(39, 12);
            this.SearchInfo.TabIndex = 3;
            this.SearchInfo.Text = "Ready.";
            // 
            // SearchResultList
            // 
            this.SearchResultList.FormattingEnabled = true;
            this.SearchResultList.ItemHeight = 12;
            this.SearchResultList.Location = new System.Drawing.Point(37, 100);
            this.SearchResultList.Name = "SearchResultList";
            this.SearchResultList.Size = new System.Drawing.Size(325, 160);
            this.SearchResultList.TabIndex = 4;
            this.SearchResultList.SelectedIndexChanged += new System.EventHandler(this.SearchResultList_SelectedIndexChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SearchResultList);
            this.Controls.Add(this.SearchInfo);
            this.Controls.Add(this.SearchHueBtn);
            this.Controls.Add(this.IpAddress);
            this.Controls.Add(this.label1);
            this.Name = "ConfigForm";
            this.Size = new System.Drawing.Size(676, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox IpAddress;
        internal System.Windows.Forms.Button SearchHueBtn;
        internal System.Windows.Forms.Label SearchInfo;
        internal System.Windows.Forms.ListBox SearchResultList;
    }
}
