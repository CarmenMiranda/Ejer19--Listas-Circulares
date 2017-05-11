using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer19__Listas_circulares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Ruta ruta = new Ruta();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            Base baseNueva = new Base(nombre, minutos);

            ruta.agregar(baseNueva);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            Base baseNueva = new Base(nombre, minutos);

            ruta.agregarInicio(baseNueva);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Base baseABuscar = ruta.buscar(txtNombre.Text);
            if (baseABuscar != null)
                txtInformacion.Text = baseABuscar.ToString();
            else
                txtInformacion.Text = "La base no existe.";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string texto = ruta.reporte();
            if (texto == "")
                txtInformacion.Text = "No hay bases.";
            else
                txtInformacion.Text = texto;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool baseEliminada = ruta.eliminar(txtNombre.Text);
            if (baseEliminada)
                txtInformacion.Text = "Se ha eliminado la base.";
            else
                txtInformacion.Text = "Base no existente.";
        }

        private void btnInsertarDespues_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int minutos = Convert.ToInt32(txtMinutos.Text);
            Base baseNueva = new Base(nombre, minutos);
            bool baseInsertada = ruta.insertarDespuesDe(txtNombreDespues.Text, baseNueva);

            if (baseInsertada)
                txtInformacion.Text = "Se ha insertado después de: " + txtNombreDespues.Text;
            else
                txtInformacion.Text = "No se pudo insertar.";
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            DateTime horaInicial = dtpInicio.Value;
            DateTime horaFinal = dtpFin.Value;
            string recorrido = ruta.recorrido(txtNombreDespues.Text, horaInicial, horaFinal);

            if (recorrido != "")
                txtInformacion.Text = recorrido;
            else
                txtInformacion.Text = "No tiene la suficiente información";

        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            bool baseEliminada = ruta.eliminarInicio();
            if (baseEliminada)
                txtInformacion.Text = "Se ha eliminado la base.";
            else
                txtInformacion.Text = "No hay bases.";
        }

        private void btnEliminarFin_Click(object sender, EventArgs e)
        {
            bool baseEliminada = ruta.eliminarFin();
            if (baseEliminada)
                txtInformacion.Text = "Se ha eliminado la base.";
            else
                txtInformacion.Text = "No hay bases.";
        }
    }
}
