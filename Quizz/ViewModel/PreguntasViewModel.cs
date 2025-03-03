using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Quizz;
using QuizzServer.Model;
using QuizzServer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasViewModel : INotifyPropertyChanged
    {

        public int puntaje =1;

        ListaServer server = new ListaServer();
        public PreguntasViewModel()
        {
            server.PersonaResivida += RespuestaCliente;
            ObtenerNombreMaquina();
            

        }
        private string _nombreMaquina;

        public string NombreMaquina
        {
            get { return _nombreMaquina; }
            set
            {
                _nombreMaquina = value;
                OnPropertyChanged(nameof(NombreMaquina));
            }
        }


        private void ObtenerNombreMaquina()
        {
            try
            {
                string hostName = Dns.GetHostName();  // Obtiene el nombre de la máquina local
                NombreMaquina = hostName;
            }
            catch
            {
                NombreMaquina = "No disponible";
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //compara la informacion resivida si es correcta y suma el puntaje
        private void RespuestaCliente(Respuesta obj)
        {

            App.Current.Dispatcher.Invoke(() => 
            {
                Preguntas p = new();

                if (p.RespuestaCorrecta == obj.NumRespuesta )
                {
                    puntaje++;
                }
                
            });
        }
        public event PropertyChangedEventHandler? PropertyChanged;
       

        //public ObservableCollection<Seccion> Seccions { get; set; } = new ObservableCollection<Seccion>();
        //public ObservableCollection<Dictionary<tring,Respuesta>> questions { get; set; } = new();


        //public void CargarSecciones()
        //{
        //    string json = File.ReadAllText("DatosModel.json");

        //    var datos = JsonConvert.DeserializeObject<Root>(json);

        //    if (datos != null && datos.Secciones != null)
        //    {
        //        Seccions = new ObservableCollection<Seccion>(datos.Secciones);
        //    }
        //}

        //public void CargarPreguntas()
        //{
        //    string json = File.ReadAllText("DatosModel.json");
        //    var list = JsonConvert.DeserializeObject<List<Preguntas>>(json);

        //    if (list != null)
        //    {
        //        foreach (var item in list)
        //        {

        //            questions = new ObservableCollection<Preguntas>(item.Pregunta);
        //        }
        //    }
        //}

    }
}
