using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Quizz;
using QuizzServer.Model;
using QuizzServer.Services;
using QuizzServer.View;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static QuizzServer.Model.PeeguntasModel1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasViewModel : INotifyPropertyChanged
    {

        public int puntaje = 1;
        private UserControl vistaActual;
        public UserControl Vista { get => vistaActual; set { vistaActual = value;OnPropertyChanged(nameof(vistaActual)); } }
        ListaServer server = new ListaServer();
        public PreguntasViewModel()
        {
            server.PersonaResivida += EntradaJugador;
            cargarsecciones();
            VerPreguntasCommand = new RelayCommand(VerPreguntas);
        }

         ICommand VerPreguntasCommand {  get; set; }
        public void VerPreguntas()
        {
            Vista = new Preguntas();
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
                PreguntaItem p = new();

                if (p.RespuestaCorrecta == obj.NumRespuesta)
                { //compara la informacion resivida si es correcta y suma el puntaje
                    puntaje++;
                }
            });
            }
        }
   

        public void cargarsecciones()
        {
            string DirectorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string ruta = Path.Combine(DirectorioBase, @"Model\DatosModel1.json");
            string json = File.ReadAllText(ruta);

            var datos = JsonConvert.DeserializeObject<Root>(json);

            var t = datos;
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
