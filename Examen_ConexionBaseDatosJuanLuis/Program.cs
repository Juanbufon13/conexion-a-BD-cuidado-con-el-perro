using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_ConexionBaseDatosJuanLuis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cadena a la conexion base de datos
            String conexionString= "Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;User ID=nombre_usuario;Password=contraseña";
            //Consulta para el departamento "ADAM" 
            String seleccionQuery= "SELECT * FROM HR_DEPARTAMENTO WHERE COD_DEPARTAMENTO = 'ADAM'";
            //consulta para actualizar el campo COD_Departamento en HR Pago
            String actualizacionQuery= "UPDATE HR_PAGO SET COD_DEPARTAMENTO = 'ADAM'";

            try
            {
                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    //abrir la coneccion a la base de datos
                    connection.Open();

                    using (SqlCommand selectCommand = new SqlCommand(seleccionQuery, connection))
                    {
                        SqlDataReader reader = selectCommand.ExecuteReader();
                        if (reader.HasRows)
                        {
                            using (SqlCommand actualizarCommand=new SqlCommand(actualizacionQuery, connection))
                            {
                                actualizarCommand.ExecuteNonQuery();
                                Console.WriteLine("Actualizacion realizada con exito");
                            }

                        }
                        else
                        {
                            Console.WriteLine("No se encontro el departamento ADAM");
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);  
            }
            Console.ReadKey();


        }
    }
}
