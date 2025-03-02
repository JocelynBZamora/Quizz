using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class DatosModel
    {

        //crea la bdd
        static string p = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizz-2.db");
        SQLiteConnection conn = new(p);

        public DatosModel()
        {
            conn.CreateTable<Respuestas>();
            conn.CreateTable<Preguntas>();
            if (!GetPreguntas().Any())
            {
                SetPreguntas();
            }
            else
            {
                var p = GetPreguntas();
                string a = string.Empty;
            }

        }
        public Dictionary<Seccion, List<Preguntas>> GetSeccion()
        {
            Dictionary<Seccion, List<Preguntas>> response = new();
            List<Seccion>seccions = new List<Seccion>();
            List<Preguntas>preguntas = new List<Preguntas>();
            //regresa todas la tabla de seccion
            foreach (var item in seccions)
            {
                response.Add(item, preguntas.Where(x => x.IdSeccion == item.Id).ToList());
            }
            return response;
        }
        public Dictionary<Preguntas,List<Respuestas>> GetPreguntas()
        {
            Dictionary<Preguntas, List<Respuestas>> response = new();
            List<Preguntas> preguntas = conn.Table<Preguntas>().ToList();
            List<Respuestas> respuestas = conn.Table<Respuestas>().ToList();
            //regresa toda la tabla de preguntas
            foreach (var item in preguntas)
            {
                response.Add(item, respuestas.Where(x => x.IdPregunta == item.Id).ToList());
            }
            return response;
        }
       
        /// <summary>
        /// crea las preguntas y respuestas y las inserta en las tablas
        /// </summary>
        public void SetPreguntas()
        {
            List<Preguntas> Lpreguntas = new List<Preguntas>();

            for (int a = 1; a <= 4; a++)
            {
                List<Respuestas> respuestas = new();

                Preguntas primeraPreg = new Preguntas()
                {
                    Id = a,
                    Pregunta = $"Pregunta {a}"


                };
                for (int i = 1; i <= 4; i++)
                {


                    respuestas.Add(new Respuestas()
                    {
                        Id = i,
                        Respuesta = $"Respuesta {i}",
                        IdPregunta = primeraPreg.Id
                    });

                }
                Lpreguntas.Add(new Preguntas()
                {
                    Id= primeraPreg.Id,
                    Pregunta = primeraPreg.Pregunta,
                    //respuestas = new List<Respuestas>(primeraPreg.respuestas)
                    
                });;
                conn.InsertAll(respuestas);
            }
            conn.InsertAll(Lpreguntas);
        }
    }
}
