using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public partial class PersonaDTO: ObservableObject
    {
        [ObservableProperty]

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
