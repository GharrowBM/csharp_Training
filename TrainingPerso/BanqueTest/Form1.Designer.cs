namespace BanqueTest
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send = new System.Windows.Forms.Button();
            this.txtbox_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_fname = new System.Windows.Forms.Label();
            this.txtbox_fname = new System.Windows.Forms.TextBox();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.txtbox_phone = new System.Windows.Forms.TextBox();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstvw_datas = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(720, 46);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(322, 163);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "Envoyer";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txtbox_name
            // 
            this.txtbox_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_name.Location = new System.Drawing.Point(212, 48);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(392, 41);
            this.txtbox_name.TabIndex = 1;
            this.txtbox_name.Text = "          ";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(94, 51);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(93, 36);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Nom :";
            // 
            // lbl_fname
            // 
            this.lbl_fname.AutoSize = true;
            this.lbl_fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fname.Location = new System.Drawing.Point(53, 107);
            this.lbl_fname.Name = "lbl_fname";
            this.lbl_fname.Size = new System.Drawing.Size(134, 36);
            this.lbl_fname.TabIndex = 4;
            this.lbl_fname.Text = "Prénom :";
            // 
            // txtbox_fname
            // 
            this.txtbox_fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_fname.Location = new System.Drawing.Point(212, 107);
            this.txtbox_fname.Name = "txtbox_fname";
            this.txtbox_fname.Size = new System.Drawing.Size(392, 41);
            this.txtbox_fname.TabIndex = 3;
            this.txtbox_fname.Text = "          ";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_phone.Location = new System.Drawing.Point(94, 171);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(80, 36);
            this.lbl_phone.TabIndex = 6;
            this.lbl_phone.Text = "Tel. :";
            // 
            // txtbox_phone
            // 
            this.txtbox_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_phone.Location = new System.Drawing.Point(212, 168);
            this.txtbox_phone.Name = "txtbox_phone";
            this.txtbox_phone.Size = new System.Drawing.Size(392, 41);
            this.txtbox_phone.TabIndex = 5;
            this.txtbox_phone.Text = "          ";
            // 
            // name
            // 
            this.name.Text = "Nom";
            // 
            // fname
            // 
            this.fname.Text = "Prénom";
            this.fname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // phone
            // 
            this.phone.Text = "Téléphone";
            this.phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstvw_datas
            // 
            this.lstvw_datas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.fname,
            this.phone});
            this.lstvw_datas.HideSelection = false;
            this.lstvw_datas.Location = new System.Drawing.Point(59, 263);
            this.lstvw_datas.Name = "lstvw_datas";
            this.lstvw_datas.Size = new System.Drawing.Size(983, 677);
            this.lstvw_datas.TabIndex = 7;
            this.lstvw_datas.UseCompatibleStateImageBehavior = false;
            this.lstvw_datas.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 979);
            this.Controls.Add(this.lstvw_datas);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.txtbox_phone);
            this.Controls.Add(this.lbl_fname);
            this.Controls.Add(this.txtbox_fname);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txtbox_name);
            this.Controls.Add(this.btn_send);
            this.Name = "Form1";
            this.Text = "        ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtbox_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_fname;
        private System.Windows.Forms.TextBox txtbox_fname;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.TextBox txtbox_phone;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader fname;
        private System.Windows.Forms.ColumnHeader phone;
        private System.Windows.Forms.ListView lstvw_datas;
    }
}

