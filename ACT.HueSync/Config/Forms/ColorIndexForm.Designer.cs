namespace ACT.HueSync.Config.Forms
{
    partial class ColorIndexForm
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
            this.DataGrid_ColorSetting = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_ColorSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color Setting";
            // 
            // DataGrid_ColorSetting
            // 
            this.DataGrid_ColorSetting.AllowUserToAddRows = false;
            this.DataGrid_ColorSetting.AllowUserToDeleteRows = false;
            this.DataGrid_ColorSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_ColorSetting.Location = new System.Drawing.Point(14, 45);
            this.DataGrid_ColorSetting.Name = "DataGrid_ColorSetting";
            this.DataGrid_ColorSetting.RowTemplate.Height = 21;
            this.DataGrid_ColorSetting.Size = new System.Drawing.Size(671, 219);
            this.DataGrid_ColorSetting.TabIndex = 3;
            // 
            // ColorIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGrid_ColorSetting);
            this.Controls.Add(this.label1);
            this.Name = "ColorIndexForm";
            this.Size = new System.Drawing.Size(700, 379);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_ColorSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView DataGrid_ColorSetting;
    }
}
