using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVC_01.Models;
using MVC_01.Modulo;
using System.Data;


namespace MVC_01.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona

        PersonaDAO miPersona = new PersonaDAO();
        TipoDocDAO miTipoDoc = new TipoDocDAO();


        public ActionResult Index()
        {
            return View(miPersona.listado());
        }






        [HttpPost]
        public ActionResult Registrar(Persona p)
        {
            string mensaje = "";
            using (SqlConnection con = new SqlConnection("server = NASH-PC\SQLEXPRESS;database = CAPA01; user id=cibertec;password=sql"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_PERSONA_ADD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@TipoDoc", p.TipoDocumentoId);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido_Pa ", p.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@Apellid_Ma ", p.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Registro", p.Registro);
                    cmd.Parameters.AddWithValue("@Nacimiento ", p.Nacimiento);
                    cmd.Parameters.AddWithValue("@NroDoc", p.NroDocumento);
                    cmd.Parameters.AddWithValue("@Sueldo", p.Sueldo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    mensaje = "Se registró La Persona";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    con.Close();
                }
                return RedirectToAction("Mensaje", new { msg = mensaje });
            }

        }


        public ActionResult Mensaje(string msg)
        {
            ViewBag.mensaje = msg;
            return View();
        }






        public ActionResult Edit(int? id = null)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Persona reg = miPersona.listado().Where(x => x.Id == (int)id).FirstOrDefault();



            return View(reg);
        }


        /// 
        [HttpPost]
        public ActionResult Edit(Persona reg)
        {
            ViewBag.persona = new SelectList(miPersona.listado(), "Id", "TipoDocumentoId", reg.Id);

            if (!ModelState.IsValid) return View(reg);

            


            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                
                new SqlParameter("@TipoDoc", reg.TipoDocumentoId),
                new SqlParameter("@Nombre ", reg.Nombre),
                new SqlParameter("@Apellido_Pa ", reg.ApellidoPaterno),
                new SqlParameter("@Apellid_Ma", reg.ApellidoMaterno),
                new SqlParameter("@Nacimiento ", reg.Nacimiento),
                new SqlParameter("@NroDoc  ", reg.NroDocumento),
                new SqlParameter("@Sueldo  ", reg.Sueldo)

                
            };

            ViewBag.mensaje = miPersona.CRUD ("UPDATE_PERSONA", parametros, 1);



            return View(reg);
        }






    }
}












