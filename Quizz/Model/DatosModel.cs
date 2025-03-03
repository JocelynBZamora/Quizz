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
        static string p = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizz-1.5.db");
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
            List<Seccion> seccions = new List<Seccion>();
            List<Preguntas> preguntas = new List<Preguntas>();
            //regresa todas la tabla de seccion
            foreach (var item in seccions)
            {
                response.Add(item, preguntas.Where(x => x.IdSeccion == item.Id).ToList());
            }
            return response;
        }
        public Dictionary<Preguntas, List<Respuestas>> GetPreguntas()
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

        //public void setSecciones()
        //{
        //    List<Seccion> Lsecciones = new List<Seccion>();
        //    Lsecciones.Add(new Seccion()
        //    {
        //        NombreSec = "Ciencias Naturales"
        //    });
        //}
        public void SetPreguntas()
        {
            List<Preguntas> Lpreguntas = new List<Preguntas>();


            List<Respuestas> respuestas = new();

            ///Ciencias naturales Q&A

            Preguntas primeraPreg = new Preguntas()
            {
                Id = 1,
                Pregunta = "¿Cuál fisico descubrio la gravedad?",
                IdSeccion = 1,
                RespCorrecta = 1,



            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Isaac Newton",
                            IdPregunta = primeraPreg.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Galileo Galilei",
                            IdPregunta = primeraPreg.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Niels Bohr",
                            IdPregunta = primeraPreg.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Albert Einstein",
                            IdPregunta = primeraPreg.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = primeraPreg.Id,
                Pregunta = primeraPreg.Pregunta,
                //respuestas = new List<Respuestas>(primeraPreg.respuestas)

            }); ;
            Preguntas Pregu2 = new Preguntas()
            {
                Id = 2,
                IdSeccion = 1,
                Pregunta = "¿Cuál es el planeta más grande de nuestro sistema solar?",
                RespCorrecta = 3
            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Saturno",
                            IdPregunta = Pregu2.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Marte",
                            IdPregunta = Pregu2.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Jupiter",
                            IdPregunta = Pregu2.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Neptuno",
                            IdPregunta = Pregu2.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = Pregu2.Id,
                Pregunta = Pregu2.Pregunta,

            }); ;
            Preguntas Pregu3 = new Preguntas()
            {
                Id = 3,
                IdSeccion = 1,
                Pregunta = "¿Cuál es el símbolo químico del agua?",
                RespCorrecta = 3
            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"F",
                            IdPregunta = Pregu3.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"HO2",
                            IdPregunta = Pregu3.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"K",
                            IdPregunta = Pregu3.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"H2O",
                            IdPregunta = Pregu3.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = Pregu3.Id,
                Pregunta = Pregu3.Pregunta,

            }); ;
            Preguntas Pregu4 = new Preguntas()
            {
                Id = 4,
                IdSeccion = 1,
                Pregunta = "¿Cuál es el símbolo químico del oro?",
                RespCorrecta = 2
            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Pb",
                            IdPregunta = Pregu4.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Au",
                            IdPregunta = Pregu4.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Ag",
                            IdPregunta = Pregu4.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Mn",
                            IdPregunta = Pregu4.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = Pregu4.Id,
                Pregunta = Pregu4.Pregunta,

            }); ;
            Preguntas Pregu5 = new Preguntas()
            {
                Id = 5,
                IdSeccion = 1,
                Pregunta = "¿Cuál es la fórmula química de la sal de mesa?",
                RespCorrecta = 3
            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"MgSO4",
                            IdPregunta = Pregu5.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"CaCO3",
                            IdPregunta = Pregu5.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"NaCl",
                            IdPregunta = Pregu5.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"KCl",
                            IdPregunta = Pregu5.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = Pregu5.Id,
                Pregunta = Pregu5.Pregunta,

            }); ;
            Preguntas Pregu6 = new Preguntas()
            {
                Id = 6,
                IdSeccion = 1,
                Pregunta = "¿Cuál es la ciencia que estudia los cuerpos celestes del universo?",
                RespCorrecta = 2
            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Astrología",
                            IdPregunta = Pregu6.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Astronomía",
                            IdPregunta = Pregu6.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Elogía",
                            IdPregunta = Pregu6.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Meteorología",
                            IdPregunta = Pregu6.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = Pregu6.Id,
                Pregunta = Pregu6.Pregunta,

            }); ;

            ///Historia Q&A
            Preguntas PHistoria1 = new Preguntas()
            {
                Id = 7,
                Pregunta = "¿En que fecha se firmo la constitucion de 1917?",
                IdSeccion = 2,
                RespCorrecta = 1,



            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"5 de mayo de 1917",
                            IdPregunta = PHistoria1.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"5 de febrero de 1917",
                            IdPregunta = PHistoria1.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"5 de febrero de 1920",
                            IdPregunta = PHistoria1.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"5 de mayo de 1920",
                            IdPregunta = PHistoria1.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria1.Id,
                Pregunta = PHistoria1.Pregunta,

            }); ;

            conn.InsertAll(respuestas);

            conn.InsertAll(Lpreguntas);
        }
    }
}
