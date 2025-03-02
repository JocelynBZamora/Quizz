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
            if (!Get().Any())
            {
                SetPreguntas();
            }
            else
            {
                var p = Get();
                string a = string.Empty;
            }

        }
        public Dictionary<Preguntas,List<Respuestas>> Get()
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
