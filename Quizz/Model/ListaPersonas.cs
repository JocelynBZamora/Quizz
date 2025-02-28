using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public class ListaPersonas
    {
        List<PersonaDTO> listaPersonas { get; set; } = new();
        public ListaPersonas()
        {
            for (int i = 0; i == 3; i++)
            {
                listaPersonas.Add(null);
            }
        }
    }
}
