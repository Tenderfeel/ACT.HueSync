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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Hue Bridge Initialize");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Lights");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Hue Setting", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Import");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("General");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Limsa Lominsa");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Color Setting", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.Tree_MainMenu = new System.Windows.Forms.TreeView();
            this.Panel_Content = new System.Windows.Forms.Panel();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Btn_Enabled = new System.Windows.Forms.Button();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.Panel_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree_MainMenu
            // 
            this.Tree_MainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.Tree_MainMenu.Name = "Tree_MainMenu";
            treeNode1.Name = "Hue_Initialize";
            treeNode1.Text = "Hue Bridge Initialize";
            treeNode1.ToolTipText = "初期設定";
            treeNode2.Name = "Hue_Lights";
            treeNode2.Text = "Lights";
            treeNode2.ToolTipText = "連携するライトを選択";
            treeNode3.Name = "Hue_Setting";
            treeNode3.Text = "Hue Setting";
            treeNode4.Name = "Color_Import";
            treeNode4.Text = "Import";
            treeNode5.Name = "Color_General";
            treeNode5.Text = "General";
            treeNode6.Name = "Color_LimsaLominsa";
            treeNode6.Text = "Limsa Lominsa";
            treeNode7.Name = "Color_Setting";
            treeNode7.Text = "Color Setting";
            this.Tree_MainMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7});
            this.Tree_MainMenu.Size = new System.Drawing.Size(147, 415);
            this.Tree_MainMenu.TabIndex = 14;
            // 
            // Panel_Content
            // 
            this.Panel_Content.AutoScroll = true;
            this.Panel_Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Content.Controls.Add(this.Label_Status);
            this.Panel_Content.Controls.Add(this.Btn_Enabled);
            this.Panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Content.Location = new System.Drawing.Point(0, 0);
            this.Panel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Content.Name = "Panel_Content";
            this.Panel_Content.Size = new System.Drawing.Size(549, 415);
            this.Panel_Content.TabIndex = 13;
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(128, 31);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(81, 12);
            this.Label_Status.TabIndex = 1;
            this.Label_Status.Text = "Load Settings...";
            // 
            // Btn_Enabled
            // 
            this.Btn_Enabled.Location = new System.Drawing.Point(36, 26);
            this.Btn_Enabled.Name = "Btn_Enabled";
            this.Btn_Enabled.Size = new System.Drawing.Size(75, 23);
            this.Btn_Enabled.TabIndex = 0;
            this.Btn_Enabled.Text = "Enable";
            this.Btn_Enabled.UseVisualStyleBackColor = true;
            this.Btn_Enabled.Click += new System.EventHandler(this.Btn_Enabled_Click);
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.Tree_MainMenu);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.Panel_Content);
            this.SplitContainer_Main.Size = new System.Drawing.Size(700, 415);
            this.SplitContainer_Main.SplitterDistance = 147;
            this.SplitContainer_Main.TabIndex = 15;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.SplitContainer_Main);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "ConfigForm";
            this.Size = new System.Drawing.Size(700, 415);
            this.Panel_Content.ResumeLayout(false);
            this.Panel_Content.PerformLayout();
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView Tree_MainMenu;
        internal System.Windows.Forms.Panel Panel_Content;
        private System.Windows.Forms.Button Btn_Enabled;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
    }
}
