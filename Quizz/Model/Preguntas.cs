﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class Preguntas
    {
        public string Pregunta { get; set; } = null!;
        public List<Respuestas>respuestas { get; set; } = new List<Respuestas>();

    }
    public class Respuestas
    {
        public int Id { get; set; }
        public string Respuesta { get; set; } = null!; 
    }

}
