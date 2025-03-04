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
using static QuizzServer.Model.PeeguntasModel1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasViewModel : INotifyPropertyChanged
    {

        public int puntaje =1;

        ListaServer server = new ListaServer();
        public string IP { get; set; } = "0.0.0.0";
        public PreguntasViewModel()
        {
            server.PersonaResivida += RespuestaCliente;
            cargarsecciones();
        }

      

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Usuario> Usuarios { get; private set; } = new();

        //agrega al jugador
        private void EntradaJugador(Respuesta obj)
        {
            if (obj != null)
            {

            App.Current.Dispatcher.Invoke(() =>
            {
                Usuario u = new();
                u.NombreUsuario = obj.Nombre;
                u.RespuestaSeleccionada = obj.NumRespuesta;
                Usuarios.Add(u);
            });
            }
        }
   

        //compara la informacion resivida si es correcta y suma el puntaje
        private void RespuestaCliente(Respuesta obj)
        {

            App.Current.Dispatcher.Invoke(() => 
            {
                PreguntaItem p = new();

                if (p.RespuestaCorrecta == obj.NumRespuesta )
                {
                    puntaje++;
                }
                
            });
        }
        public event PropertyChangedEventHandler? PropertyChanged;


        //public ObservableCollection<Seccion> Seccions { get; set; } = new ObservableCollection<Seccion>();
        //public ObservableCollection<Dictionary<tring,Respuesta>> questions { get; set; } = new();


        public void cargarsecciones()
        {
            string DirectorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string ruta = Path.Combine(DirectorioBase, @"Model\DatosModel1.json");
            string json = File.ReadAllText(ruta);

            var datos = JsonConvert.DeserializeObject<Root>(json);

            var t = datos;
        }

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
