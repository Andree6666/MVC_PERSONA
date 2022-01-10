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
    public class TipoDocDAO
    {

        public IEnumerable<TipoDocumento> listado()
        {

            List<TipoDocumento> temporal = new List<TipoDocumento>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("USP_TIPODOC", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    TipoDocumento reg = new TipoDocumento()
                    {

                        Id = dr.GetInt32(0),
                        Abreviatura = dr.GetString(1),
                        Nombre = dr.GetString(2),
                        Activo = dr.GetBoolean(3),


                    };

                    temporal.Add(reg);  

                }

                dr.Close(); con.Close();

            }

            return temporal;



        }













    }
}