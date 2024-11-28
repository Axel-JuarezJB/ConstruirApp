using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocios;

namespace Ejercicio_Ado.Net
{
    public partial class FrmAltaDiscos : Form
    {
        public FrmAltaDiscos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Discos disco = new Discos();
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                disco.Titulo = tbxTitulo.Text;
                disco.Canciones = int.Parse(tbxCanciones.Text);
                disco.URLimagenTapa = tbxImagen.Text;
                disco.Genero = (Estilos)cboDescripcion.SelectedItem;
                disco.Tipo = (TiposEdicion)cboEdicion.SelectedItem;
                negocio.agregarDisco(disco);
                MessageBox.Show("Agregado exitosamente");
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
                cboEdicion.DataSource = edicionNegocio.listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
