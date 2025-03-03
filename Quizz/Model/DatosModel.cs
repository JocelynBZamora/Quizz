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
        static string p = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Quizz-1.7.db");
        SQLiteConnection conn = new(p);

        public DatosModel()
        {
            conn.CreateTable<Respuestas>();
            conn.CreateTable<Preguntas>();
            conn.CreateTable<Seccion>();
            if (!GetSeccion().Any())
            {
                setSecciones();
            }
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

        public void setSecciones()
        {
            List<Seccion> Lsecciones = new List<Seccion>();
            Seccion ciencias = new Seccion() 
            { 
                Id = 1,
                NombreSec = "Ciencias"
            };
            Seccion Historia = new Seccion()
            {
                Id = 2,
                NombreSec = "Historia"
            };
            Seccion Matematicas = new Seccion()
            {
                Id = 3,
                NombreSec = "Matematicas"
            };
            Seccion Español = new Seccion() 
            {Id = 4,
                NombreSec  = "Literatura y escritura"
            };
            Seccion Arte = new Seccion()
            {Id = 5,
                NombreSec = "Arte"
            };
            Lsecciones.Add(ciencias);
            Lsecciones.Add(Historia);
            Lsecciones.Add(Matematicas);
            Lsecciones.Add(Español);
            Lsecciones.Add(Arte);

            conn.InsertAll(Lsecciones);
            //Lsecciones.Add(new Seccion()
            //{
            //    NombreSec = "Ciencias Naturales"
            //});
        }
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

            Preguntas PHistoria2 = new Preguntas()
            {
                Id = 8,
                Pregunta = "¿Cuánto tiempo duró la guerra de los 100 años?",
                IdSeccion = 2,
                RespCorrecta = 4,



            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"90 años",
                            IdPregunta = PHistoria2.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"115 años",
                            IdPregunta = PHistoria2.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"100 años",
                            IdPregunta = PHistoria2.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"116 años",
                            IdPregunta = PHistoria2.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria2.Id,
                Pregunta = PHistoria2.Pregunta,

            }); ;

            Preguntas PHistoria3 = new Preguntas()
            {
                Id = 9,
                Pregunta = "¿Quién fue el primer hombre en caminar sobre la luna?",
                IdSeccion = 2,
                RespCorrecta = 4,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Buzz Aldrin",
                            IdPregunta = PHistoria3.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Alan Armstrong",
                            IdPregunta = PHistoria3.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Alan Shepard",
                            IdPregunta = PHistoria3.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Neil Armstrong ",
                            IdPregunta = PHistoria3.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria3.Id,
                Pregunta = PHistoria3.Pregunta,

            }); ;

            Preguntas PHistoria4 = new Preguntas()
            {
                Id = 10,
                Pregunta = "¿Dónde nació Adolf Hitler?",
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
                            Respuesta = $"Austria",
                            IdPregunta = PHistoria4.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Alemania",
                            IdPregunta = PHistoria4.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Rusia",
                            IdPregunta = PHistoria4.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Polonia",
                            IdPregunta = PHistoria4.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria4.Id,
                Pregunta = PHistoria4.Pregunta,

            }); ;

            Preguntas PHistoria5 = new Preguntas()
            {
                Id = 11,
                Pregunta = "¿Dónde nació Adolf Hitler?",
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
                            Respuesta = $"Austria",
                            IdPregunta = PHistoria5.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Alemania",
                            IdPregunta = PHistoria5.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Rusia",
                            IdPregunta = PHistoria5.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Polonia",
                            IdPregunta = PHistoria5.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria5.Id,
                Pregunta = PHistoria5.Pregunta,

            }); ;

            Preguntas PHistoria6 = new Preguntas()
            {
                Id = 12,
                Pregunta = "¿Qué ciudades fueron bombardeadas con bombas atómicas en 1945?",
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
                            Respuesta = $"Hiroshima y Nagasaki",
                            IdPregunta = PHistoria6.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Hiroshima y Tokio",
                            IdPregunta = PHistoria6.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Yokohama y Tokio",
                            IdPregunta = PHistoria6.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Tokio y Nagasaki",
                            IdPregunta = PHistoria6.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PHistoria6.Id,
                Pregunta = PHistoria6.Pregunta,

            }); ;

            ///Matematicas Q&A  

            Preguntas PMate1 = new Preguntas()
            {
                Id = 13,
                Pregunta = "¿Cuánto es 15 ÷ 3?",
                IdSeccion = 3,
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
                            Respuesta = $"5",
                            IdPregunta = PMate1.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"8",
                            IdPregunta = PMate1.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"1",
                            IdPregunta = PMate1.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"3",
                            IdPregunta = PMate1.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate1.Id,
                Pregunta = PMate1.Pregunta,

            }); ;

            Preguntas PMate2 = new Preguntas()
            {
                Id = 14,
                Pregunta = "Si un número se multiplica por 0, ¿cuál es el resultado?",
                IdSeccion = 3,
                RespCorrecta = 3,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"10",
                            IdPregunta = PMate2.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"1",
                            IdPregunta = PMate2.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"0",
                            IdPregunta = PMate2.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"7",
                            IdPregunta = PMate2.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate2.Id,
                Pregunta = PMate2.Pregunta,

            }); ;

            Preguntas PMate3 = new Preguntas()
            {
                Id = 15,
                Pregunta = " ¿Cuántos lados tiene un dodecágono?",
                IdSeccion = 3,
                RespCorrecta = 2,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"17",
                            IdPregunta = PMate3.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"6",
                            IdPregunta = PMate3.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"10",
                            IdPregunta = PMate3.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"12",
                            IdPregunta = PMate3.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate3.Id,
                Pregunta = PMate3.Pregunta,

            }); ;

            Preguntas PMate4 = new Preguntas()
            {
                Id = 16,
                Pregunta = "¿Cuál es la fórmula del teorema de Pitágoras?",
                IdSeccion = 3,
                RespCorrecta = 2,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $" a² = b² + c²",
                            IdPregunta = PMate4.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"c² = a² + b²",
                            IdPregunta = PMate4.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $" c² = a² - b²\n",
                            IdPregunta = PMate4.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"c = a + b",
                            IdPregunta = PMate4.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate4.Id,
                Pregunta = PMate4.Pregunta,

            }); ;

            Preguntas PMate5 = new Preguntas()
            {
                Id = 17,
                Pregunta = "¿Cuál es la fórmula para calcular el área de un triángulo?",
                IdSeccion = 3,
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
                            Respuesta = $"A = (b × h) / 2",
                            IdPregunta = PMate5.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"A = 2(b × h)",
                            IdPregunta = PMate5.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"A = (b × h) / 3",
                            IdPregunta = PMate5.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"A = 2(b × h)",
                            IdPregunta = PMate5.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate5.Id,
                Pregunta = PMate5.Pregunta,

            }); ;

            Preguntas PMate6 = new Preguntas()
            {
                Id = 18,
                Pregunta = "¿Cuánto es ¾ en decimal?",
                IdSeccion = 3,
                RespCorrecta = 3,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"0.50",
                            IdPregunta = PMate6.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"75",
                            IdPregunta = PMate6.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"0.75",
                            IdPregunta = PMate6.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"0.55",
                            IdPregunta = PMate6.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PMate6.Id,
                Pregunta = PMate6.Pregunta,

            }); ;

            ///Español Q&A

            Preguntas PEspañol1 = new Preguntas()
            {
                Id = 19,
                Pregunta = "¿Quién escribió \"Don Quijote de la Mancha\"?",
                IdSeccion = 4,
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
                            Respuesta = $"Miguel de Cervantes",
                            IdPregunta = PEspañol1.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Federico García Lorca",
                            IdPregunta = PEspañol1.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"William Shakespeare",
                            IdPregunta = PEspañol1.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Gabriel García Márquez",
                            IdPregunta = PEspañol1.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol1.Id,
                Pregunta = PEspañol1.Pregunta,

            }); ;

            Preguntas PEspañol2 = new Preguntas()
            {
                Id = 20,
                Pregunta = "¿Qué autor es conocido por el realismo mágico y escribió \"Cien años de soledad\"?",
                IdSeccion = 4,
                RespCorrecta = 2,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Miguel de Cervantes",
                            IdPregunta = PEspañol2.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Gabriel García Márquez",
                            IdPregunta = PEspañol2.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"William Shakespeare",
                            IdPregunta = PEspañol2.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Jorge Luis Borges",
                            IdPregunta = PEspañol2.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol2.Id,
                Pregunta = PEspañol2.Pregunta,

            }); ;

            Preguntas PEspañol3 = new Preguntas()
            {
                Id = 21,
                Pregunta = "¿Qué autor es conocido por sus cuentos de terror y misterio, como El cuervo y El corazón delator?",
                IdSeccion = 4,
                RespCorrecta = 4,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Stephen King",
                            IdPregunta = PEspañol3.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Gabriel García Márquez",
                            IdPregunta = PEspañol3.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"William Shakespeare",
                            IdPregunta = PEspañol3.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Edgar Allan Poe",
                            IdPregunta = PEspañol3.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol3.Id,
                Pregunta = PEspañol3.Pregunta,

            }); ;

            Preguntas PEspañol4 = new Preguntas()
            {
                Id = 22,
                Pregunta = "¿Qué es una fábula?",
                IdSeccion = 4,
                RespCorrecta = 3,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Un poema épico",
                            IdPregunta = PEspañol4.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Una novela larga",
                            IdPregunta = PEspañol4.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Un cuento corto con una lección moral",
                            IdPregunta = PEspañol4.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Una historia de terror",
                            IdPregunta = PEspañol4.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol4.Id,
                Pregunta = PEspañol4.Pregunta,

            }); ;

            Preguntas PEspañol5 = new Preguntas()
            {
                Id = 23,
                Pregunta = "¿Qué es un poema?",
                IdSeccion = 4,
                RespCorrecta = 2,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Un relato de eventos reales",
                            IdPregunta = PEspañol5.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Un texto que expresa sentimientos e ideas usando versos",
                            IdPregunta = PEspañol5.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Una carta formal",
                            IdPregunta = PEspañol5.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Un texto científico",
                            IdPregunta = PEspañol5.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol5.Id,
                Pregunta = PEspañol5.Pregunta,

            });

            Preguntas PEspañol6 = new Preguntas()
            {
                Id = 24,
                Pregunta = "¿Cómo se llama el momento de mayor tensión en una historia?",
                IdSeccion = 4,
                RespCorrecta = 3,


            };
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Introducción",
                            IdPregunta = PEspañol6.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Desenlace",
                            IdPregunta = PEspañol6.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Clímax",
                            IdPregunta = PEspañol6.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Conflicto",
                            IdPregunta = PEspañol6.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PEspañol6.Id,
                Pregunta = PEspañol6.Pregunta,

            });

            ///Arte Q&A

            Preguntas PArte1 = new Preguntas()
            {
                Id = 25,
                Pregunta = "¿Cómo se llama el momento de mayor tensión en una historia?",
                IdSeccion = 4,
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
                            Respuesta = $"Leonardo da Vinci",
                            IdPregunta = PArte1.Id
                        });
                        break;
                    case 2:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Pablo Picasso",
                            IdPregunta = PArte1.Id
                        });
                        break;
                    case 3:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Vincent van Gogh",
                            IdPregunta = PArte1.Id
                        });
                        break;
                    case 4:
                        respuestas.Add(new Respuestas()
                        {
                            Id = i,
                            Respuesta = $"Diego Velázquez",
                            IdPregunta = PArte1.Id
                        });
                        break;

                }


            }
            Lpreguntas.Add(new Preguntas()
            {
                Id = PArte1.Id,
                Pregunta = PArte1.Pregunta,

            });

            conn.InsertAll(respuestas);

            conn.InsertAll(Lpreguntas);
        }
    }   
}
