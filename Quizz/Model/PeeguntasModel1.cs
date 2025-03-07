using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class PeeguntasModel1
    {
        //public class CienciasNaturale
        //{
        //    public string Pregunta { get; set; } = null!;
        //    public List<string> Respuestas { get; set; } = new();
        //    public int RespuestaCorrecta { get; set; }
        //}

        //public class Español
        //{
        //    public string Pregunta { get; set; } = null!;
        //    public List<string> Respuestas { get; set; } = new();
        //    public int RespuestaCorrecta { get; set; }
        //}

        //public class Historia
        //{
        //    public string Pregunta { get; set; } = null!;
        //    public List<string> Respuestas { get; set; } = new();
        //    public int RespuestaCorrecta { get; set; }
        //}

        //public class Matemática
        //{
        //    public string Pregunta { get; set; } = null!;
        //    public List<string> Respuestas { get; set; } = new();
        //    public int RespuestaCorrecta { get; set; }
        //}

        public class Root
        {
            public List<PreguntaItem> Historia { get; set; } = new();
            public List<PreguntaItem> Español { get; set; } = new();
            public List<PreguntaItem> Matemáticas { get; set; } = new();
            [JsonPropertyName("Ciencias Naturales")]
            public List<PreguntaItem> CienciasNaturales { get; set; } = new();
        }
    }
}
