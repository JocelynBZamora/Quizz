using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    internal class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int NumRespuesta { get; set; } 
    }
}
