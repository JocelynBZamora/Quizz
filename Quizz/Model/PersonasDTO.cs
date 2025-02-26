using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuizzServer.Model
{
    public partial class PersonasDTO : ObservableObject
    {
        [ObservableProperty]

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        //cliente
        [JsonIgnore]
        public TcpClient? Cliente { get; set; }
    }
  
}
