using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class PeeguntasModel1
    {
        public class CienciasNaturale
        {
            public string Pregunta { get; set; } = null!;
            public List<string> Respuestas { get; set; } = new();
            public int RespuestaCorrecta { get; set; }
        }

        public class Español
        {
            public string Pregunta { get; set; } = null!;
            public List<string> Respuestas { get; set; } = new();
            public int RespuestaCorrecta { get; set; }
        }

        public class Historia
        {
            public string Pregunta { get; set; } = null!;
            public List<string> Respuestas { get; set; } = new();
            public int RespuestaCorrecta { get; set; }
        }

        public class Matemática
        {
            public string Pregunta { get; set; } = null!;
            public List<string> Respuestas { get; set; } = new();
            public int RespuestaCorrecta { get; set; }
        }

        public class Root
        {
            public List<Historia> Historia { get; set; } = new();
            public List<Español> Espaol { get; set; } = new();
            public List<Matemática> Matemticas { get; set; } = new();

            public List<CienciasNaturale> CienciasNaturales { get; set; } = new();
        }
    }
}
