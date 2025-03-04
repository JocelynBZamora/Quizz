using CommunityToolkit.Mvvm.Input;
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
        public RespuestaCliente Respuesta { get; set; } = new();
        QuizzClient.Services.RespuestaCliente cliente { get; set; } = new();
        public RelayCommand EnviarCommand { get; }

        public RespuestasVM()
        {
            EnviarCommand = new RelayCommand(Enviar);
        }

        private void Enviar()
        {
            cliente.Enviar(Respuesta);
        }


        public event PropertyChangingEventHandler? PropertyChanging;
    }
}
