using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Libreria para declarar los objetos con los cuales vamos a establecer la conexión

namespace WinFormSQL
{
     class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            //Objetos de la libreria SqlClient para establecer conexion 
            //conexion 
            SqlConnection conexion = new SqlConnection(); 
            //comandos para las acciones 
            SqlCommand comandoConexion = new SqlCommand();
            //lector de los datos.Cuando se realice la lectura en esta variable vamos a capturar la instancia del objeto devuelto 
            SqlDataReader lecturaData; 

            //MANEJO DE EXCEPCIONES(errores en tiempo de ejecución) 

            try
            {
                //configurar cadena de conexion          servidor / base de datos /       seguridad   
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                //configurar comando, la consulta que vamos a inyectar en la base de datos 
                comandoConexion.CommandType = System.Data.CommandType.Text; //tipo de consulta 
                comandoConexion.CommandText = "Select Numero, Nombre, Descripcion from POKEMONS";//La consulta que inyectamos en la DB 
                //Indicar en que servidor vamos a ejecutar los comandos 
                comandoConexion.Connection = conexion; // Indicar al comando en que conexion ejecutar //conexion de línea 29 
                //Abrir conexion 
                conexion.Open();
                //Realizar la lectura. Ejecuta la lectura 
                lecturaData = comandoConexion.ExecuteReader(); //Devuelve un objeto, por lo tanto lo guardamos en la variable lecturaData
                //Ahora tenemos el objeto SqlDataReader con los datos traidos 

                //Debemos leer los datos de esa lecturaData 

                while (lecturaData.Read()) // Si hay registro a continuación devuelve TRUE, además va posicionando un puntero al siguiente registro si lo hubiera 
                {
                    //Instanciamos el objeto Pokemon y empezamos a cargar los datos en cada vuelta con cada registro
                    Pokemon aux = new Pokemon();
                    aux.Descripcion = (string)lecturaData["Descripcion"]; // lecturaData es la variable donde va a contener los datos
                    aux.Numero = lecturaData.GetInt32(0); //Dos maneras de acceder a esos datos, por indice en orden de la consulta realizada                                      
                    aux.Nombre = (string)lecturaData["Nombre"];  // o por medio de [ ] e indicamos el nombre del campo en la tabla.

                    //Agregamos ese objeto a la List<Pokemon> lista. En cada vuelta mientras siga habiendo registro por leer. 

                    lista.Add(aux);
                }
                //Cerramos la conexion 
                conexion.Close();

                return lista;
            }
            catch(Exception ex) //Capturamos una excepción en caso que lo hubiese. 
            { 
               throw ex; //throw lanza, el error 
            }



           
        }
    }
}
