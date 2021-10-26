using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Datos.Admin;
using Datos.Models;

namespace AppWebVentas
{
    public partial class VistaVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarGrid();
            }
        }

        private void llenarGrid()
        {
            gridVendedores.DataSource = AdmVendedor.Listar();
            gridVendedores.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text)
            };

            int filasAfectadas = AdmVendedor.Insertar(vendedor);

            if (filasAfectadas>0)
            {
                llenarGrid();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDNI.Text,
                Comision = Convert.ToDecimal(txtComision.Text),
                Id = Convert.ToInt32(txtId.Text)
            };

            int filasAfectadas = AdmVendedor.Modificar(vendedor);

            if (filasAfectadas > 0)
            {
                llenarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdmVendedor.Eliminar(Id);

            if (filasAfectadas > 0)
            {
                llenarGrid();
            }
        }

        protected void btnTraerPorId_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);
            if (Id == 0)
            {
                llenarGrid();
            }
            else
            {
                DataTable tabla = AdmVendedor.TraerPorId(Id);
                gridVendedores.DataSource = tabla;
                gridVendedores.DataBind();
            }
        }

        protected void btnTraerPorComision_Click(object sender, EventArgs e)
        {
            decimal Comision = Convert.ToDecimal(txtComision.Text);

            DataTable tabla = AdmVendedor.TraerVendedores(Comision);
            gridVendedores.DataSource = tabla;
            gridVendedores.DataBind();
        }
    }
}