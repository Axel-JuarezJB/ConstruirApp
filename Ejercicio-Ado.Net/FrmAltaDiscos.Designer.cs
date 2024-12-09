namespace Ejercicio_Ado.Net
{
    partial class FrmAltaDiscos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCanciones = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.tbxTitulo = new System.Windows.Forms.TextBox();
            this.tbxCanciones = new System.Windows.Forms.TextBox();
            this.tbxImagen = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cboDescripcion = new System.Windows.Forms.ComboBox();
            this.lblEdicion = new System.Windows.Forms.Label();
            this.cboEdicion = new System.Windows.Forms.ComboBox();
            this.pbxDisco = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisco)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(115, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(33, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Titulo";
            // 
            // lblCanciones
            // 
            this.lblCanciones.AutoSize = true;
            this.lblCanciones.Location = new System.Drawing.Point(41, 72);
            this.lblCanciones.Name = "lblCanciones";
            this.lblCanciones.Size = new System.Drawing.Size(112, 13);
            this.lblCanciones.TabIndex = 1;
            this.lblCanciones.Text = "Numero de Canciones";
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Location = new System.Drawing.Point(55, 110);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(93, 13);
            this.lblImagen.TabIndex = 2;
            this.lblImagen.Text = "URL de la Imagen";
            // 
            // tbxTitulo
            // 
            this.tbxTitulo.Location = new System.Drawing.Point(154, 33);
            this.tbxTitulo.Name = "tbxTitulo";
            this.tbxTitulo.Size = new System.Drawing.Size(121, 20);
            this.tbxTitulo.TabIndex = 0;
            // 
            // tbxCanciones
            // 
            this.tbxCanciones.Location = new System.Drawing.Point(154, 69);
            this.tbxCanciones.Name = "tbxCanciones";
            this.tbxCanciones.Size = new System.Drawing.Size(121, 20);
            this.tbxCanciones.TabIndex = 1;
            // 
            // tbxImagen
            // 
            this.tbxImagen.Location = new System.Drawing.Point(154, 103);
            this.tbxImagen.Name = "tbxImagen";
            this.tbxImagen.Size = new System.Drawing.Size(121, 20);
            this.tbxImagen.TabIndex = 2;
            this.tbxImagen.Leave += new System.EventHandler(this.tbxImagen_Leave);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(78, 225);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(85, 146);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // cboDescripcion
            // 
            this.cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescripcion.FormattingEnabled = true;
            this.cboDescripcion.Location = new System.Drawing.Point(154, 138);
            this.cboDescripcion.Name = "cboDescripcion";
            this.cboDescripcion.Size = new System.Drawing.Size(121, 21);
            this.cboDescripcion.TabIndex = 3;
            // 
            // lblEdicion
            // 
            this.lblEdicion.AutoSize = true;
            this.lblEdicion.Location = new System.Drawing.Point(41, 182);
            this.lblEdicion.Name = "lblEdicion";
            this.lblEdicion.Size = new System.Drawing.Size(107, 13);
            this.lblEdicion.TabIndex = 11;
            this.lblEdicion.Text = "Descripcion (Edicion)";
            // 
            // cboEdicion
            // 
            this.cboEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEdicion.FormattingEnabled = true;
            this.cboEdicion.Location = new System.Drawing.Point(154, 174);
            this.cboEdicion.Name = "cboEdicion";
            this.cboEdicion.Size = new System.Drawing.Size(121, 21);
            this.cboEdicion.TabIndex = 4;
            this.cboEdicion.SelectedIndexChanged += new System.EventHandler(this.cboEdicion_SelectedIndexChanged);
            // 
            // pbxDisco
            // 
            this.pbxDisco.Location = new System.Drawing.Point(336, 33);
            this.pbxDisco.Name = "pbxDisco";
            this.pbxDisco.Size = new System.Drawing.Size(238, 215);
            this.pbxDisco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDisco.TabIndex = 14;
            this.pbxDisco.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(281, 100);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(23, 23);
            this.btnAgregarImagen.TabIndex = 15;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAltaDiscos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 291);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pbxDisco);
            this.Controls.Add(this.cboEdicion);
            this.Controls.Add(this.lblEdicion);
            this.Controls.Add(this.cboDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.tbxImagen);
            this.Controls.Add(this.tbxCanciones);
            this.Controls.Add(this.tbxTitulo);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.lblCanciones);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FrmAltaDiscos";
            this.Text = "Nuevo Disco";
            this.Load += new System.EventHandler(this.FrmAltaDiscos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDisco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCanciones;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.TextBox tbxTitulo;
        private System.Windows.Forms.TextBox tbxCanciones;
        private System.Windows.Forms.TextBox tbxImagen;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.ComboBox cboDescripcion;
        private System.Windows.Forms.Label lblEdicion;
        private System.Windows.Forms.ComboBox cboEdicion;
        private System.Windows.Forms.PictureBox pbxDisco;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}