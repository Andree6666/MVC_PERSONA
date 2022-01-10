using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVC_01.Models;

namespace MVC_01.Modulo
{
    public class PersonaDAO
    {

        public  IEnumerable<Persona> listado()
        {
            List<Persona> temporal = new List<Persona>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_PERSONA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Persona reg = new Persona() { 
                    Id = dr.GetInt32(0),
                    TipoDocumentoId = dr.GetInt32(1),
                    Nombre = dr.GetString(2),
                    ApellidoPaterno = dr.GetString(3),
                    ApellidoMaterno= dr.GetString(4),
                    Registro = dr.GetDateTime(5),
                    Nacimiento = dr.GetDateTime(6),
                    NroDocumento = dr.GetString(7),
                    Sueldo = dr.GetDecimal(8)

                };

                    temporal.Add(reg);


            }

                dr.Close(); con.Close();



            }

            return temporal;

        }

        public string CRUD(string sp, List<SqlParameter> parametros, int op)
        {
            string mensaje = "";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parametros.ToArray());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (op == 1)
                    {
                        mensaje = " registro actualizado";
                    }
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }
            return mensaje;
        }


        


    }
}