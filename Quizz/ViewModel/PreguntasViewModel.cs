using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using Newtonsoft.Json;
using System.Text.Json;
using Quizz;
using QuizzServer.Model;
using QuizzServer.Services;
using QuizzServer.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using CommunityToolkit.Mvvm.Messaging;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasViewModel : ObservableRecipient,IRecipient<NavegacionModel>
    {
        [ObservableProperty]
        public string vista = "Secciones";
        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private int respuestaSeleccionada;
        [ObservableProperty]
        public int puntaje = 0;

        public ObservableCollection<Usuario> Usuarios { get; set; } = new();
        List<Usuario> usuarios = new();//persistente
        ListaServer server = new ListaServer();
        public PreguntasViewModel()
        { 
            ///resive mensajes
            IsActive = true;
            ActualizarNombre();
            server.PersonaResivida += EntradaJugador;
            //cargarsecciones();
        }


    

        //agrega al jugador
        private void EntradaJugador(Respuesta obj)
        {
            //guarda y muestra el nombre del usuario
            if (!string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Usuario u = new();
                u.Nombre = obj.Nombre;
                usuarios.Add(u); 


            }
            ActualizarNombre();

            if (obj?.NumRespuesta != null)
            {
                Usuario u = new();

                u.RespuestaSeleccionada = obj.NumRespuesta;
                usuarios.Add(u);

                //foreach (var p in pregunta)
                //{

                //    if (p.RespuestaCorrecta == obj.NumRespuesta)
                //    { //compara la informacion resivida si es correcta y suma el puntaje
                //        puntaje++;
                //    }
                //}

            }
            Guardar();
        }
        private void Guardar()
        {
            //crea el archivo json
            var archivo = File.Create("usuarios.json");
            JsonSerializer.Serialize(archivo, usuarios);
            archivo.Close();
        }
        public void ActualizarNombre()
        {
            foreach (var u in usuarios)
            {
                Usuarios.Add(u);
            }
        }

        

        public void Receive(NavegacionModel message)
        {
            Vista = message.vista;
            if(message.seccion!= null)
            {
                eventoshelper.setSeccion?.Invoke(message.seccion);
            }
        }



        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        //public event PropertyChangedEventHandler? PropertyChanged;

    }
}
