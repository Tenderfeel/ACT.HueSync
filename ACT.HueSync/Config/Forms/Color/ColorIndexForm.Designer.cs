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
            this.DataGrid_LightSetting = new System.Windows.Forms.DataGridView();
            this.Btn_GetLightState = new System.Windows.Forms.Button();
            this.Label_GetStateInfo = new System.Windows.Forms.Label();
            this.Group_Trigger = new System.Windows.Forms.GroupBox();
            this.ComboBox_ZoneName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBox_Weather = new System.Windows.Forms.ComboBox();
            this.UpDown_StartTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel_Trigger = new System.Windows.Forms.Panel();
            this.Btn_SaveColorSetting = new System.Windows.Forms.Button();
            this.Label_SaveSetting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_LightSetting)).BeginInit();
            this.Group_Trigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_StartTime)).BeginInit();
            this.Panel_Trigger.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid_LightSetting
            // 
            this.DataGrid_LightSetting.AllowUserToAddRows = false;
            this.DataGrid_LightSetting.AllowUserToDeleteRows = false;
            this.DataGrid_LightSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_LightSetting.Location = new System.Drawing.Point(14, 41);
            this.DataGrid_LightSetting.Name = "DataGrid_LightSetting";
            this.DataGrid_LightSetting.RowTemplate.Height = 21;
            this.DataGrid_LightSetting.Size = new System.Drawing.Size(671, 181);
            this.DataGrid_LightSetting.TabIndex = 3;
            // 
            // Btn_GetLightState
            // 
            this.Btn_GetLightState.Location = new System.Drawing.Point(14, 12);
            this.Btn_GetLightState.Name = "Btn_GetLightState";
            this.Btn_GetLightState.Size = new System.Drawing.Size(149, 23);
            this.Btn_GetLightState.TabIndex = 4;
            this.Btn_GetLightState.Text = "Get Current Lights Setting";
            this.Btn_GetLightState.UseVisualStyleBackColor = true;
            this.Btn_GetLightState.Click += new System.EventHandler(this.Btn_GetLightState_Click_1);
            // 
            // Label_GetStateInfo
            // 
            this.Label_GetStateInfo.AutoSize = true;
            this.Label_GetStateInfo.Location = new System.Drawing.Point(172, 17);
            this.Label_GetStateInfo.Name = "Label_GetStateInfo";
            this.Label_GetStateInfo.Size = new System.Drawing.Size(39, 12);
            this.Label_GetStateInfo.TabIndex = 5;
            this.Label_GetStateInfo.Text = "Ready.";
            // 
            // Group_Trigger
            // 
            this.Group_Trigger.Controls.Add(this.ComboBox_ZoneName);
            this.Group_Trigger.Controls.Add(this.label4);
            this.Group_Trigger.Controls.Add(this.label3);
            this.Group_Trigger.Controls.Add(this.ComboBox_Weather);
            this.Group_Trigger.Controls.Add(this.UpDown_StartTime);
            this.Group_Trigger.Controls.Add(this.label2);
            this.Group_Trigger.Location = new System.Drawing.Point(0, 3);
            this.Group_Trigger.Name = "Group_Trigger";
            this.Group_Trigger.Size = new System.Drawing.Size(671, 56);
            this.Group_Trigger.TabIndex = 6;
            this.Group_Trigger.TabStop = false;
            this.Group_Trigger.Text = "Trigger";
            // 
            // ComboBox_ZoneName
            // 
            this.ComboBox_ZoneName.FormattingEnabled = true;
            this.ComboBox_ZoneName.Location = new System.Drawing.Point(417, 18);
            this.ComboBox_ZoneName.Name = "ComboBox_ZoneName";
            this.ComboBox_ZoneName.Size = new System.Drawing.Size(180, 20);
            this.ComboBox_ZoneName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Zone Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Weather";
            // 
            // ComboBox_Weather
            // 
            this.ComboBox_Weather.FormattingEnabled = true;
            this.ComboBox_Weather.Location = new System.Drawing.Point(200, 17);
            this.ComboBox_Weather.Name = "ComboBox_Weather";
            this.ComboBox_Weather.Size = new System.Drawing.Size(121, 20);
            this.ComboBox_Weather.TabIndex = 2;
            // 
            // UpDown_StartTime
            // 
            this.UpDown_StartTime.AutoSize = true;
            this.UpDown_StartTime.Location = new System.Drawing.Point(69, 17);
            this.UpDown_StartTime.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.UpDown_StartTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.UpDown_StartTime.Name = "UpDown_StartTime";
            this.UpDown_StartTime.Size = new System.Drawing.Size(56, 19);
            this.UpDown_StartTime.TabIndex = 1;
            this.UpDown_StartTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Time";
            // 
            // Panel_Trigger
            // 
            this.Panel_Trigger.Controls.Add(this.Label_SaveSetting);
            this.Panel_Trigger.Controls.Add(this.Btn_SaveColorSetting);
            this.Panel_Trigger.Controls.Add(this.Group_Trigger);
            this.Panel_Trigger.Location = new System.Drawing.Point(14, 228);
            this.Panel_Trigger.Name = "Panel_Trigger";
            this.Panel_Trigger.Size = new System.Drawing.Size(671, 102);
            this.Panel_Trigger.TabIndex = 7;
            this.Panel_Trigger.Visible = false;
            // 
            // Btn_SaveColorSetting
            // 
            this.Btn_SaveColorSetting.Location = new System.Drawing.Point(557, 65);
            this.Btn_SaveColorSetting.Name = "Btn_SaveColorSetting";
            this.Btn_SaveColorSetting.Size = new System.Drawing.Size(114, 23);
            this.Btn_SaveColorSetting.TabIndex = 7;
            this.Btn_SaveColorSetting.Text = "Save Color Setting";
            this.Btn_SaveColorSetting.UseVisualStyleBackColor = true;
            this.Btn_SaveColorSetting.Click += new System.EventHandler(this.Btn_SaveColorSetting_Click);
            // 
            // Label_SaveSetting
            // 
            this.Label_SaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_SaveSetting.Location = new System.Drawing.Point(10, 65);
            this.Label_SaveSetting.Name = "Label_SaveSetting";
            this.Label_SaveSetting.Size = new System.Drawing.Size(541, 23);
            this.Label_SaveSetting.TabIndex = 8;
            this.Label_SaveSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColorIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel_Trigger);
            this.Controls.Add(this.Label_GetStateInfo);
            this.Controls.Add(this.Btn_GetLightState);
            this.Controls.Add(this.DataGrid_LightSetting);
            this.Name = "ColorIndexForm";
            this.Size = new System.Drawing.Size(700, 379);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_LightSetting)).EndInit();
            this.Group_Trigger.ResumeLayout(false);
            this.Group_Trigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_StartTime)).EndInit();
            this.Panel_Trigger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.DataGridView DataGrid_LightSetting;
        private System.Windows.Forms.Button Btn_GetLightState;
        private System.Windows.Forms.Label Label_GetStateInfo;
        private System.Windows.Forms.GroupBox Group_Trigger;
        private System.Windows.Forms.Panel Panel_Trigger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBox_Weather;
        private System.Windows.Forms.NumericUpDown UpDown_StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBox_ZoneName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_SaveColorSetting;
        private System.Windows.Forms.Label Label_SaveSetting;
    }
}
