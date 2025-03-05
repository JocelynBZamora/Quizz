using CommunityToolkit.Mvvm.Input;
using QuizzClient.Model;
using QuizzClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzClient.ViewModel
{
    internal class RespuestasVM : INotifyPropertyChanging
    {
        public RespuestaModel Respuesta { get; set; } = new();
        QuizzClient.Services.RespuestaCliente cliente { get; set; } = new();
        public RelayCommand EnviarUsuarioCommand { get; set; }
        public RelayCommand EnviarRespuestaCommand { get; set; }

        public RespuestasVM()
        {
            EnviarUsuarioCommand = new RelayCommand(EnviarUsuario);
            EnviarRespuestaCommand = new RelayCommand(EnviarRespuesta);
        }


        private void EnviarUsuario()
        {
            if (Respuesta.NombreUsuario != string.Empty)
            {
                cliente.Enviar(Respuesta);

            }
        }
        private void EnviarRespuesta()
        {
            if (Respuesta.Respuesta >= 1 && Respuesta.Respuesta <= 4)
            {

                cliente.Enviar(Respuesta);
            }

        }


        public event PropertyChangingEventHandler? PropertyChanging;
    }
}
