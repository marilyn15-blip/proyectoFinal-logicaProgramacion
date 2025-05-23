using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalLogica.BaseDatos;
using ProyectoFinalLogica.Entidad;

namespace ProyectoFinalLogica
{
    public partial class FormularioPrueba : Form
    {
        public FormularioPrueba()
        {
            InitializeComponent();
        }

        private void FormularioPrueba_Load(object sender, EventArgs e)
        {
            // Ejempplo de uso de clses de la base de datos

            RutaEntidad ruta = new RutaEntidad();
            ruta.LugarSalida = "Metapan";
            ruta.LugarLLegada = "Santa Ana";
            ruta.RutaID = 1;

            RutaDB rutaDB = new RutaDB();
            // Ejemplo crear
            rutaDB.Create(ruta);
            ruta.LugarLLegada = "San Salvador";

            //Ejemplo Update
            rutaDB.Update(ruta);

            //Ejemplo eliminar
            rutaDB.Delete(2);

            //Ejemplo listar todos
            List<RutaEntidad> rutas = rutaDB.GetAll();

            //Ejemplo listar por id 
            RutaEntidad rutaEntidad = rutaDB.GetById(1);
            Console.WriteLine("Hola Mundo");
        }
    }
}
