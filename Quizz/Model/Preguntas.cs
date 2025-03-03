﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{

    public class Seccion
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string NombreSec { get; set; } = null!;
    }
    public class Preguntas
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Pregunta { get; set; } = null!;
        public int RespCorrecta { get; set; }
        public int IdSeccion { get; set; }
        //public List<Respuestas>respuestas { get; set; } = new List<Respuestas>();

    }
    public class Respuestas
    {
        
        public int Id { get; set; }
        public string Respuesta { get; set; } = null!; 
        public int IdPregunta { get; set; }
    }

}
