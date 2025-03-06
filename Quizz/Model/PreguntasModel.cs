//using SQLite;
using QuizzServer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{

    public class PreguntaItem
    {
        public string Pregunta { get; set; } = null!;
        public List<string> Respuestas { get; set; } = new();
        public int RespuestaCorrecta { get; set; }
    }
    
    public class Tiempo
    {

        public DateTime Time { get; set; }
    }
    public class Usuario
    {
        public string Nombre { get; set; } = null!;
        public int RespuestaSeleccionada { get; set; }
    }

}
