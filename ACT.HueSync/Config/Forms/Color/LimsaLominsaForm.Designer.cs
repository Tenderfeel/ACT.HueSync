namespace ACT.HueSync.Config.Forms
{
    partial class LimsaLominsaForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label_DataCount = new System.Windows.Forms.Label();
            this.DataGrid_LimsaLominsa = new System.Windows.Forms.DataGrid();
            this.colorDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weatherIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_LimsaLominsa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Limsa Lominsa";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Label_DataCount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGrid_LimsaLominsa);
            this.splitContainer1.Size = new System.Drawing.Size(703, 410);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 4;
            // 
            // Label_DataCount
            // 
            this.Label_DataCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_DataCount.Location = new System.Drawing.Point(97, 10);
            this.Label_DataCount.Name = "Label_DataCount";
            this.Label_DataCount.Size = new System.Drawing.Size(594, 12);
            this.Label_DataCount.TabIndex = 4;
            // 
            // DataGrid_LimsaLominsa
            // 
            this.DataGrid_LimsaLominsa.DataMember = "";
            this.DataGrid_LimsaLominsa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid_LimsaLominsa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.DataGrid_LimsaLominsa.Location = new System.Drawing.Point(0, 0);
            this.DataGrid_LimsaLominsa.Name = "DataGrid_LimsaLominsa";
            this.DataGrid_LimsaLominsa.ReadOnly = true;
            this.DataGrid_LimsaLominsa.Size = new System.Drawing.Size(703, 374);
            this.DataGrid_LimsaLominsa.TabIndex = 0;
            // 
            // colorIdDataGridViewTextBoxColumn
            // 
            this.colorIdDataGridViewTextBoxColumn.DataPropertyName = "ColorId";
            this.colorIdDataGridViewTextBoxColumn.HeaderText = "ColorId";
            this.colorIdDataGridViewTextBoxColumn.Name = "colorIdDataGridViewTextBoxColumn";
            // 
            // zoneNameDataGridViewTextBoxColumn
            // 
            this.zoneNameDataGridViewTextBoxColumn.DataPropertyName = "ZoneName";
            this.zoneNameDataGridViewTextBoxColumn.HeaderText = "ZoneName";
            this.zoneNameDataGridViewTextBoxColumn.Name = "zoneNameDataGridViewTextBoxColumn";
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            // 
            // weatherIdDataGridViewTextBoxColumn
            // 
            this.weatherIdDataGridViewTextBoxColumn.DataPropertyName = "WeatherId";
            this.weatherIdDataGridViewTextBoxColumn.HeaderText = "WeatherId";
            this.weatherIdDataGridViewTextBoxColumn.Name = "weatherIdDataGridViewTextBoxColumn";
            // 
            // LimsaLominsaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LimsaLominsaForm";
            this.Size = new System.Drawing.Size(703, 410);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_LimsaLominsa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource colorDataBindingSource;
        private System.Windows.Forms.Label Label_DataCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weatherIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGrid DataGrid_LimsaLominsa;
    }
}
