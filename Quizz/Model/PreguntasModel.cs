using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class PreguntasModel
    {
        public int Id { get; set; }
        public string Pregunta { get; set; } = null!;
        public string Respuesta1 { get; set; } = null!;
        public string Respuesta2 { get; set; } = null!;
        public string Respuesta3 { get; set; } = null!;
        public string Respuesta4 { get; set; } = null!;
        public string RCorrecta { get; set; } = null!;
        
    }

}
