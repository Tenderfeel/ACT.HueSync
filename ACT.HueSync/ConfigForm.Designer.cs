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
            this.RegistHueBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.HueAppKey = new System.Windows.Forms.TextBox();
            this.step2Group = new System.Windows.Forms.GroupBox();
            this.ReClickLabel = new System.Windows.Forms.Label();
            this.RegistInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.step1Group = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BridgeId = new System.Windows.Forms.TextBox();
            this.step2Group.SuspendLayout();
            this.step1Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hue Bridge IP Address:";
            // 
            // IpAddress
            // 
            this.IpAddress.Location = new System.Drawing.Point(143, 77);
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Size = new System.Drawing.Size(201, 19);
            this.IpAddress.TabIndex = 1;
            this.IpAddress.TextChanged += new System.EventHandler(this.IpAddress_Change);
            // 
            // SearchHueBtn
            // 
            this.SearchHueBtn.Location = new System.Drawing.Point(5, 108);
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
            this.SearchInfo.Location = new System.Drawing.Point(154, 113);
            this.SearchInfo.Name = "SearchInfo";
            this.SearchInfo.Size = new System.Drawing.Size(39, 12);
            this.SearchInfo.TabIndex = 3;
            this.SearchInfo.Text = "Ready.";
            // 
            // SearchResultList
            // 
            this.SearchResultList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SearchResultList.FormattingEnabled = true;
            this.SearchResultList.ItemHeight = 12;
            this.SearchResultList.Location = new System.Drawing.Point(3, 146);
            this.SearchResultList.Name = "SearchResultList";
            this.SearchResultList.Size = new System.Drawing.Size(396, 112);
            this.SearchResultList.TabIndex = 4;
            this.SearchResultList.SelectedIndexChanged += new System.EventHandler(this.SearchResultList_SelectedIndexChanged);
            // 
            // RegistHueBtn
            // 
            this.RegistHueBtn.Location = new System.Drawing.Point(16, 50);
            this.RegistHueBtn.Name = "RegistHueBtn";
            this.RegistHueBtn.Size = new System.Drawing.Size(147, 23);
            this.RegistHueBtn.TabIndex = 5;
            this.RegistHueBtn.Text = "Regist App";
            this.RegistHueBtn.UseVisualStyleBackColor = true;
            this.RegistHueBtn.Click += new System.EventHandler(this.RegistHueBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(20, 331);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(111, 23);
            this.ResetBtn.TabIndex = 8;
            this.ResetBtn.Text = "Reset Setting";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = " Application Key:";
            // 
            // HueAppKey
            // 
            this.HueAppKey.Location = new System.Drawing.Point(114, 110);
            this.HueAppKey.Name = "HueAppKey";
            this.HueAppKey.ReadOnly = true;
            this.HueAppKey.Size = new System.Drawing.Size(256, 19);
            this.HueAppKey.TabIndex = 10;
            // 
            // step2Group
            // 
            this.step2Group.Controls.Add(this.ReClickLabel);
            this.step2Group.Controls.Add(this.RegistInfo);
            this.step2Group.Controls.Add(this.label4);
            this.step2Group.Controls.Add(this.RegistHueBtn);
            this.step2Group.Controls.Add(this.HueAppKey);
            this.step2Group.Controls.Add(this.label2);
            this.step2Group.Location = new System.Drawing.Point(428, 47);
            this.step2Group.Name = "step2Group";
            this.step2Group.Size = new System.Drawing.Size(389, 261);
            this.step2Group.TabIndex = 11;
            this.step2Group.TabStop = false;
            this.step2Group.Text = "Step2";
            // 
            // ReClickLabel
            // 
            this.ReClickLabel.AutoSize = true;
            this.ReClickLabel.Location = new System.Drawing.Point(19, 80);
            this.ReClickLabel.Name = "ReClickLabel";
            this.ReClickLabel.Size = new System.Drawing.Size(271, 12);
            this.ReClickLabel.TabIndex = 13;
            this.ReClickLabel.Text = "After clicking the link button, click the button again.";
            this.ReClickLabel.Visible = false;
            // 
            // RegistInfo
            // 
            this.RegistInfo.AutoSize = true;
            this.RegistInfo.Location = new System.Drawing.Point(171, 56);
            this.RegistInfo.Name = "RegistInfo";
            this.RegistInfo.Size = new System.Drawing.Size(39, 12);
            this.RegistInfo.TabIndex = 12;
            this.RegistInfo.Text = "Ready.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "With the IP address selected, click the RegistApp button once.";
            // 
            // step1Group
            // 
            this.step1Group.Controls.Add(this.BridgeId);
            this.step1Group.Controls.Add(this.label5);
            this.step1Group.Controls.Add(this.label3);
            this.step1Group.Controls.Add(this.SearchResultList);
            this.step1Group.Controls.Add(this.SearchHueBtn);
            this.step1Group.Controls.Add(this.SearchInfo);
            this.step1Group.Controls.Add(this.IpAddress);
            this.step1Group.Controls.Add(this.label1);
            this.step1Group.Location = new System.Drawing.Point(20, 47);
            this.step1Group.Name = "step1Group";
            this.step1Group.Size = new System.Drawing.Size(402, 261);
            this.step1Group.TabIndex = 12;
            this.step1Group.TabStop = false;
            this.step1Group.Text = "Step1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Get the ID and IP Address of Hue Bridge.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Hue Bridge ID:";
            // 
            // BridgeId
            // 
            this.BridgeId.Location = new System.Drawing.Point(143, 50);
            this.BridgeId.Name = "BridgeId";
            this.BridgeId.Size = new System.Drawing.Size(201, 19);
            this.BridgeId.TabIndex = 7;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.step1Group);
            this.Controls.Add(this.step2Group);
            this.Controls.Add(this.ResetBtn);
            this.Name = "ConfigForm";
            this.Size = new System.Drawing.Size(864, 385);
            this.step2Group.ResumeLayout(false);
            this.step2Group.PerformLayout();
            this.step1Group.ResumeLayout(false);
            this.step1Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox IpAddress;
        internal System.Windows.Forms.Button SearchHueBtn;
        internal System.Windows.Forms.Label SearchInfo;
        internal System.Windows.Forms.ListBox SearchResultList;
        internal System.Windows.Forms.Button RegistHueBtn;
        internal System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox step2Group;
        private System.Windows.Forms.GroupBox step1Group;
        private System.Windows.Forms.Label label3;
        protected internal System.Windows.Forms.TextBox HueAppKey;
        private System.Windows.Forms.Label RegistInfo;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label ReClickLabel;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox BridgeId;
    }
}
