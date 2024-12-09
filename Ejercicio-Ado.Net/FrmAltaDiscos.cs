using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocios;
using System.Configuration;

namespace Ejercicio_Ado.Net
{
    public partial class FrmAltaDiscos : Form
    {
        private Discos disco = null;
        private OpenFileDialog archivo = null;
        public FrmAltaDiscos()
        {
            InitializeComponent();
        }
        public FrmAltaDiscos(Discos disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Discos disco = new Discos();
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if (disco == null)
                    disco = new Discos();

                disco.Titulo = tbxTitulo.Text;
                disco.Canciones = int.Parse(tbxCanciones.Text);
                disco.URLimagenTapa = tbxImagen.Text;
                disco.Genero = (Estilos)cboDescripcion.SelectedItem;
                //disco.Genero = new Estilos { id = (int)cboDescripcion.SelectedValue };
                disco.Tipo = (TiposEdicion)cboEdicion.SelectedItem;

                if (disco.Id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregarDisco(disco);
                    MessageBox.Show("Agregado exitosamente");
                }

                if(archivo != null && !(tbxImagen.Text.ToUpper().Contains("http")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Disco-Image"] + archivo.SafeFileName);
                
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void FrmAltaDiscos_Load(object sender, EventArgs e)
        {
            EstilosNegocio estilosNegocio = new EstilosNegocio();
            TiposEdicionNegocio edicionNegocio = new TiposEdicionNegocio();
            try
            {
                cboDescripcion.DataSource = estilosNegocio.listar();
                cboDescripcion.ValueMember = "IdEstilo";
                cboDescripcion.DisplayMember = "Descripcion";
                cboEdicion.DataSource = edicionNegocio.listar();
                cboEdicion.ValueMember = "IdTipoEdicion";
                cboEdicion.DisplayMember = "Descripcion";

                if(disco != null)
                {
                    tbxTitulo.Text = disco.Titulo;
                    tbxCanciones.Text = disco.Canciones.ToString();
                    tbxImagen.Text = disco.URLimagenTapa;
                    cargarImagen(disco.URLimagenTapa);
                    cboDescripcion.SelectedValue = disco.Genero.IdEstilo;
                    cboEdicion.SelectedValue = disco.Tipo.IdTipoEdicion;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbxImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDisco.Load(imagen);
            }
            catch (Exception)
            {

                pbxDisco.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void cboEdicion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                tbxImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                //guardar imagen
               File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Disco-Image"] + archivo.SafeFileName);
            }

        }
    }
}
