namespace ACT.HueSync.Config.Forms
{
    partial class HueInitializeForm
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
            this.Panel_Steps = new System.Windows.Forms.FlowLayoutPanel();
            this.step1Group = new System.Windows.Forms.GroupBox();
            this.Text_BridgeId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Label_Step1 = new System.Windows.Forms.Label();
            this.List_SearchResult = new System.Windows.Forms.ListBox();
            this.Btn_SearchHue = new System.Windows.Forms.Button();
            this.Label_SearchInfo = new System.Windows.Forms.Label();
            this.Text_IpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.step2Group = new System.Windows.Forms.GroupBox();
            this.Label_ReClick = new System.Windows.Forms.Label();
            this.Label_RegistInfo = new System.Windows.Forms.Label();
            this.Label_Step2 = new System.Windows.Forms.Label();
            this.Btn_RegistHue = new System.Windows.Forms.Button();
            this.Text_HueAppKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel_Steps.SuspendLayout();
            this.step1Group.SuspendLayout();
            this.step2Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Steps
            // 
            this.Panel_Steps.Controls.Add(this.step1Group);
            this.Panel_Steps.Controls.Add(this.step2Group);
            this.Panel_Steps.Location = new System.Drawing.Point(0, 85);
            this.Panel_Steps.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Steps.Name = "Panel_Steps";
            this.Panel_Steps.Padding = new System.Windows.Forms.Padding(10);
            this.Panel_Steps.Size = new System.Drawing.Size(722, 286);
            this.Panel_Steps.TabIndex = 0;
            // 
            // step1Group
            // 
            this.step1Group.Controls.Add(this.Text_BridgeId);
            this.step1Group.Controls.Add(this.label5);
            this.step1Group.Controls.Add(this.Label_Step1);
            this.step1Group.Controls.Add(this.List_SearchResult);
            this.step1Group.Controls.Add(this.Btn_SearchHue);
            this.step1Group.Controls.Add(this.Label_SearchInfo);
            this.step1Group.Controls.Add(this.Text_IpAddress);
            this.step1Group.Controls.Add(this.label1);
            this.step1Group.Location = new System.Drawing.Point(13, 13);
            this.step1Group.Name = "step1Group";
            this.step1Group.Size = new System.Drawing.Size(325, 261);
            this.step1Group.TabIndex = 13;
            this.step1Group.TabStop = false;
            this.step1Group.Text = "Step1";
            // 
            // Text_BridgeId
            // 
            this.Text_BridgeId.Location = new System.Drawing.Point(143, 50);
            this.Text_BridgeId.Name = "Text_BridgeId";
            this.Text_BridgeId.ReadOnly = true;
            this.Text_BridgeId.Size = new System.Drawing.Size(176, 19);
            this.Text_BridgeId.TabIndex = 7;
            this.Text_BridgeId.TextChanged += new System.EventHandler(this.Text_BridgeId_TextChanged);
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
            // Label_Step1
            // 
            this.Label_Step1.AutoSize = true;
            this.Label_Step1.Location = new System.Drawing.Point(13, 25);
            this.Label_Step1.Name = "Label_Step1";
            this.Label_Step1.Size = new System.Drawing.Size(217, 12);
            this.Label_Step1.TabIndex = 5;
            this.Label_Step1.Text = "Get the ID and IP Address of Hue Bridge.";
            // 
            // List_SearchResult
            // 
            this.List_SearchResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.List_SearchResult.FormattingEnabled = true;
            this.List_SearchResult.ItemHeight = 12;
            this.List_SearchResult.Location = new System.Drawing.Point(3, 146);
            this.List_SearchResult.Name = "List_SearchResult";
            this.List_SearchResult.Size = new System.Drawing.Size(319, 112);
            this.List_SearchResult.TabIndex = 4;
            this.List_SearchResult.SelectedIndexChanged += new System.EventHandler(this.SearchResultList_SelectedIndexChanged);
            // 
            // Btn_SearchHue
            // 
            this.Btn_SearchHue.Location = new System.Drawing.Point(5, 108);
            this.Btn_SearchHue.Name = "Btn_SearchHue";
            this.Btn_SearchHue.Size = new System.Drawing.Size(143, 23);
            this.Btn_SearchHue.TabIndex = 2;
            this.Btn_SearchHue.Text = "Search Hue Bridge";
            this.Btn_SearchHue.UseVisualStyleBackColor = true;
            this.Btn_SearchHue.Click += new System.EventHandler(this.SearchHueBtn_Click);
            // 
            // Label_SearchInfo
            // 
            this.Label_SearchInfo.AutoSize = true;
            this.Label_SearchInfo.Location = new System.Drawing.Point(154, 113);
            this.Label_SearchInfo.Name = "Label_SearchInfo";
            this.Label_SearchInfo.Size = new System.Drawing.Size(39, 12);
            this.Label_SearchInfo.TabIndex = 3;
            this.Label_SearchInfo.Text = "Ready.";
            // 
            // Text_IpAddress
            // 
            this.Text_IpAddress.Location = new System.Drawing.Point(143, 77);
            this.Text_IpAddress.Name = "Text_IpAddress";
            this.Text_IpAddress.ReadOnly = true;
            this.Text_IpAddress.Size = new System.Drawing.Size(176, 19);
            this.Text_IpAddress.TabIndex = 1;
            this.Text_IpAddress.TextChanged += new System.EventHandler(this.Text_IpAddress_TextChanged);
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
            // step2Group
            // 
            this.step2Group.AutoSize = true;
            this.step2Group.Controls.Add(this.Label_ReClick);
            this.step2Group.Controls.Add(this.Label_RegistInfo);
            this.step2Group.Controls.Add(this.Label_Step2);
            this.step2Group.Controls.Add(this.Btn_RegistHue);
            this.step2Group.Controls.Add(this.Text_HueAppKey);
            this.step2Group.Controls.Add(this.label2);
            this.step2Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.step2Group.Location = new System.Drawing.Point(344, 13);
            this.step2Group.Name = "step2Group";
            this.step2Group.Padding = new System.Windows.Forms.Padding(0);
            this.step2Group.Size = new System.Drawing.Size(339, 261);
            this.step2Group.TabIndex = 14;
            this.step2Group.TabStop = false;
            this.step2Group.Text = "Step2";
            // 
            // Label_ReClick
            // 
            this.Label_ReClick.AutoSize = true;
            this.Label_ReClick.Location = new System.Drawing.Point(16, 77);
            this.Label_ReClick.Name = "Label_ReClick";
            this.Label_ReClick.Size = new System.Drawing.Size(271, 12);
            this.Label_ReClick.TabIndex = 13;
            this.Label_ReClick.Text = "After clicking the link button, click the button again.";
            this.Label_ReClick.Visible = false;
            // 
            // Label_RegistInfo
            // 
            this.Label_RegistInfo.AutoSize = true;
            this.Label_RegistInfo.Location = new System.Drawing.Point(168, 53);
            this.Label_RegistInfo.Name = "Label_RegistInfo";
            this.Label_RegistInfo.Size = new System.Drawing.Size(39, 12);
            this.Label_RegistInfo.TabIndex = 12;
            this.Label_RegistInfo.Text = "Ready.";
            // 
            // Label_Step2
            // 
            this.Label_Step2.AutoSize = true;
            this.Label_Step2.Location = new System.Drawing.Point(11, 22);
            this.Label_Step2.Name = "Label_Step2";
            this.Label_Step2.Size = new System.Drawing.Size(325, 12);
            this.Label_Step2.TabIndex = 11;
            this.Label_Step2.Text = "With the IP address selected, click the RegistApp button once.";
            // 
            // Btn_RegistHue
            // 
            this.Btn_RegistHue.Location = new System.Drawing.Point(16, 50);
            this.Btn_RegistHue.Name = "Btn_RegistHue";
            this.Btn_RegistHue.Size = new System.Drawing.Size(147, 23);
            this.Btn_RegistHue.TabIndex = 5;
            this.Btn_RegistHue.Text = "Regist App";
            this.Btn_RegistHue.UseVisualStyleBackColor = true;
            this.Btn_RegistHue.Click += new System.EventHandler(this.RegistHueBtn_Click);
            // 
            // Text_HueAppKey
            // 
            this.Text_HueAppKey.Location = new System.Drawing.Point(111, 106);
            this.Text_HueAppKey.Name = "Text_HueAppKey";
            this.Text_HueAppKey.ReadOnly = true;
            this.Text_HueAppKey.Size = new System.Drawing.Size(215, 19);
            this.Text_HueAppKey.TabIndex = 10;
            this.Text_HueAppKey.TextChanged += new System.EventHandler(this.Text_HueAppKey_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = " Application Key:";
            // 
            // HueInitializeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel_Steps);
            this.Name = "HueInitializeForm";
            this.Size = new System.Drawing.Size(700, 420);
            this.Panel_Steps.ResumeLayout(false);
            this.Panel_Steps.PerformLayout();
            this.step1Group.ResumeLayout(false);
            this.step1Group.PerformLayout();
            this.step2Group.ResumeLayout(false);
            this.step2Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Panel_Steps;
        private System.Windows.Forms.GroupBox step1Group;
        internal System.Windows.Forms.TextBox Text_BridgeId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Label_Step1;
        internal System.Windows.Forms.ListBox List_SearchResult;
        internal System.Windows.Forms.Button Btn_SearchHue;
        internal System.Windows.Forms.Label Label_SearchInfo;
        internal System.Windows.Forms.TextBox Text_IpAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox step2Group;
        internal System.Windows.Forms.Label Label_ReClick;
        private System.Windows.Forms.Label Label_RegistInfo;
        private System.Windows.Forms.Label Label_Step2;
        internal System.Windows.Forms.Button Btn_RegistHue;
        protected internal System.Windows.Forms.TextBox Text_HueAppKey;
        private System.Windows.Forms.Label label2;
    }
}
