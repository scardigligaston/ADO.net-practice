using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSQL
{
    public partial class Form1 : Form  //El objeto Ventana Form1 hereda de Form
    {
        public Form1()
        {
            InitializeComponent(); //Método que inicializa la ventana
        }

        private void Form1_Load(object sender, EventArgs e) //Evento de Carga del Form1
        {
            PokemonNegocio negocio = new PokemonNegocio(); // Instanciamos un objeto negocio de la clase PokemonNegocio,donde se encuentra nuestra lógica
            dgvPokemons.DataSource = negocio.listar(); //Accedemos al método de la clase PokemonNegocio, el método ejecuta toda la lógica para acceder y traer la información de nuestra base de datos 
        }
    }
}
