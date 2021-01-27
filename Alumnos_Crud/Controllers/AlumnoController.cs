using Alumnos_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alumnos_Crud.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()  //Acción principal
        {
            try
            {
                using (var db = new AlumnoContext())
                {
                    //Muestro solo los alumnos mayores de 18 años
                    //List<Alumno> lista= db.Alumno.Where(a => a.Edad > 18).ToList();
                    return View(db.Alumno.ToList());
                }
            }
            catch (Exception )
            {

                throw;
            }
         
            //AlumnoContext db = new AlumnoContext();

            //Muetra la lista de alumnos
            //db.Alumno.ToList();

          
           

            //Devuelvo la lista de alumnos
           
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Creo un token que verifica que el formuario que se esta enviando es al que pertenece.
        public ActionResult Agregar(Alumno a)
        {
                        //Si el modelo que entra no es valido
            if (!ModelState.IsValid)   
                return View();

            //Con el try evito que la app se caiga
            try
            {
                //hago la conexión 
                using (AlumnoContext db = new AlumnoContext())
                {
                    a.FechaRegistro = DateTime.Now;
                    //Agregar un registro
                    db.Alumno.Add(a);
                    //Gurado los cambios
                    db.SaveChanges();

                    return Redirect("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Alumno -" + ex.Message);
                return View();
            }
           
        }
        public ActionResult Editar(int Id)
        {
            try
            {
                using (var db = new AlumnoContext())
                {
                    //where se puede usar en todos los casos, y el find se puede usar solo cuando existe una pk
                    //Alumno al = db.Alumno.Where(a => a.Id == id).FirstOrDefault();
                    Alumno al2 = db.Alumno.Find(Id);
                    return View(al2);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Alumno a)
        {
            try
            {
                using (var db = new AlumnoContext())
                {
                Alumno al = db.Alumno.Find(a.Id);
                    al.Nombre = a.Nombre;
                    al.Apellido = a.Apellido;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    //Guardar cambios
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        public ActionResult DetallesAlumno(int Id)
        {
               using (var db = new AlumnoContext())
                {
                    Alumno alu = db.Alumno.Find(Id);

                    return View(alu);
                }
                     
        }
        public ActionResult EliminarAlumno(int Id)
        {
            using (var db = new AlumnoContext())
            {
                Alumno alu = db.Alumno.Find(Id);
                db.Alumno.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}