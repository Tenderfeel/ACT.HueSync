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
            this.Tree_MainMenu = new System.Windows.Forms.TreeView();
            this.Panel_Content = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Tree_MainMenu
            // 
            this.Tree_MainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tree_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.Tree_MainMenu.Name = "Tree_MainMenu";
            treeNode1.Name = "Hue_Initialize";
            treeNode1.Text = "Hue Bridge Initialize";
            treeNode1.ToolTipText = "初期設定";
            treeNode2.Name = "Hue_Lights";
            treeNode2.Text = "Lights";
            treeNode3.Name = "Hue";
            treeNode3.Text = "Hue Setting";
            this.Tree_MainMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.Tree_MainMenu.Size = new System.Drawing.Size(164, 412);
            this.Tree_MainMenu.TabIndex = 14;
            // 
            // Panel_Content
            // 
            this.Panel_Content.AutoScroll = true;
            this.Panel_Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Panel_Content.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel_Content.Location = new System.Drawing.Point(167, 0);
            this.Panel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Content.Name = "Panel_Content";
            this.Panel_Content.Size = new System.Drawing.Size(725, 412);
            this.Panel_Content.TabIndex = 13;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Tree_MainMenu);
            this.Controls.Add(this.Panel_Content);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConfigForm";
            this.Size = new System.Drawing.Size(892, 412);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView Tree_MainMenu;
        internal System.Windows.Forms.Panel Panel_Content;
    }
}
