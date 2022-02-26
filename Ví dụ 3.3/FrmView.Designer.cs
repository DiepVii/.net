
namespace Ví_dụ_3._3
{
    partial class FrmView
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
            this.dgvDANHMUC = new System.Windows.Forms.DataGridView();
            this.lblDM = new System.Windows.Forms.Label();
            this.btnTroVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDANHMUC
            // 
            this.dgvDANHMUC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDANHMUC.Location = new System.Drawing.Point(222, 87);
            this.dgvDANHMUC.Name = "dgvDANHMUC";
            this.dgvDANHMUC.Size = new System.Drawing.Size(292, 228);
            this.dgvDANHMUC.TabIndex = 0;
            this.dgvDANHMUC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDANHMUC_CellContentClick);
            // 
            // lblDM
            // 
            this.lblDM.AutoSize = true;
            this.lblDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDM.ForeColor = System.Drawing.Color.Maroon;
            this.lblDM.Location = new System.Drawing.Point(286, 47);
            this.lblDM.Name = "lblDM";
            this.lblDM.Size = new System.Drawing.Size(51, 16);
            this.lblDM.TabIndex = 1;
            this.lblDM.Text = "label1";
            // 
            // btnTroVe
            // 
            this.btnTroVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.ForeColor = System.Drawing.Color.Maroon;
            this.btnTroVe.Location = new System.Drawing.Point(424, 349);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(75, 23);
            this.btnTroVe.TabIndex = 2;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // FrmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.lblDM);
            this.Controls.Add(this.dgvDANHMUC);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Name = "FrmView";
            this.Text = "Danh Sách";
            this.Load += new System.EventHandler(this.FrmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDANHMUC;
        private System.Windows.Forms.Label lblDM;
        private System.Windows.Forms.Button btnTroVe;
    }
}