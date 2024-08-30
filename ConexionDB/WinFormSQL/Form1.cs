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
        //Atributos, que son las variables declaradas en una clase, para trabajar con los datos que recibimos

        private List<Pokemon> listapokemons = new List<Pokemon>(); //Instanciamos una lista, para almacenar los datos que recibimos de la clase PokemonNegocio
        // a traves del objeto instanciado cuya referencia almacenada esta en la variable negocio. 
        public Form1() //Constructor de la clase Form1 
        {
            InitializeComponent(); //Método que inicializa la ventana
        }

        //Los eventos son métodos especiales 
        private void Form1_Load(object sender, EventArgs e) //Evento de Carga del Form1
        {
            PokemonNegocio negocio = new PokemonNegocio(); // Instanciamos un objeto negocio de la clase PokemonNegocio,donde se encuentra nuestra lógica
            listapokemons = negocio.listar(); //Accedemos al método de la clase PokemonNegocio, el método ejecuta toda la lógica para acceder y traer la información de nuestra base de datos 
            dgvPokemons.DataSource = listapokemons;
            cargarImagen(listapokemons[0].UrlImagen); //Accedemos al atributo del primer objeto 

        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //Del objeto dgvPokemons accedemos al atributo CurrentRow:
            //que devuelve el estado de la fila actual.
            //Luego a DataBoundItem: que devuelve el objeto actual enlazado
            //con (Pokemon) forzamos que con seguridad que recibimos un objeto de tipo Pokemon
            //                  (casteo )    grilla  .fila actual. objeto enlazado;
            Pokemon seleccion = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen(seleccion.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBox.Load(imagen); 
            }
            catch(Exception)
            {
                pictureBox.Load("https://as1.ftcdn.net/v2/jpg/03/45/05/92/1000_F_345059232_CPieT8RIWOUk4JqBkkWkIETYAkmz2b75.jpg");
            }

        }
    }
}
