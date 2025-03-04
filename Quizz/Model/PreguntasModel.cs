//using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{

    public class Seccion
    {
        public string NombreSec { get; set; } = null!;
        public List<Preguntas> preguntas { get; set; } = new List<Preguntas>();
    }
    public class Preguntas
    {
        public int Id { get; set; }
        public int RespuestaCorrecta { get; set; }
        public string Pregunta { get; set; } = null!;
        public List<Respuestas> respuestas { get; set; } = new List<Respuestas>();

    }
    public class PreguntaItem
    {
        public string Pregunta { get; set; } = null!;
        public List<string> Respuestas { get; set; } = new();
        public int RespuestaCorrecta { get; set; }
    }
    public class Respuestas
    {

        public string Respuesta { get; set; } = null!;
    }


}
