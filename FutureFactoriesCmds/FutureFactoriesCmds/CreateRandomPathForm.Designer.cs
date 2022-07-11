namespace FutureFactoriesCmds
{
    partial class CreateRandomPathForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.RobotSelectCtrl = new Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NumPoints = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Robot:";
            // 
            // RobotSelectCtrl
            // 
            this.RobotSelectCtrl.KeepFaceEmphasizedWhenControlIsNotFocused = true;
            this.RobotSelectCtrl.ListenToPick = true;
            this.RobotSelectCtrl.Location = new System.Drawing.Point(130, 13);
            this.RobotSelectCtrl.Name = "RobotSelectCtrl";
            this.RobotSelectCtrl.Object = null;
            this.RobotSelectCtrl.PickAndClear = false;
            this.RobotSelectCtrl.PickLevel = Tecnomatix.Engineering.Ui.TxPickLevel.Component;
            this.RobotSelectCtrl.PickOnly = false;
            this.RobotSelectCtrl.ReadOnly = false;
            this.RobotSelectCtrl.Size = new System.Drawing.Size(150, 20);
            this.RobotSelectCtrl.TabIndex = 1;
            this.RobotSelectCtrl.ValidatorType = Tecnomatix.Engineering.Ui.TxValidatorType.Robot;
            this.RobotSelectCtrl.Picked += new Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl_PickedEventHandler(this.RobotSelectCtrl_Picked);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(13, 89);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(202, 89);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of Points:";
            // 
            // NumPoints
            // 
            this.NumPoints.Location = new System.Drawing.Point(130, 44);
            this.NumPoints.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumPoints.Name = "NumPoints";
            this.NumPoints.Size = new System.Drawing.Size(120, 20);
            this.NumPoints.TabIndex = 9;
            // 
            // CreateRandomPathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 125);
            this.Controls.Add(this.NumPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.RobotSelectCtrl);
            this.Controls.Add(this.label1);
            this.Name = "CreateRandomPathForm";
            this.Text = "CreateRandomPathForm";
            ((System.ComponentModel.ISupportInitialize)(this.NumPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Tecnomatix.Engineering.Ui.TxObjEditBoxCtrl RobotSelectCtrl;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumPoints;
    }
}