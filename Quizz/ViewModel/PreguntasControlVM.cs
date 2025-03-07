using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using QuizzServer.Model;
using QuizzServer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static QuizzServer.Model.PeeguntasModel1;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasControlVM : ObservableRecipient, IRecipient<NavegacionModel>
    {
        [ObservableProperty]
        public List<string> respuestas = new();
        [ObservableProperty]
        public string pregunta;
        private List<PreguntaItem> preguntaItems = new();
        public PreguntasControlVM()
        {
            IsActive = true;
            eventoshelper.setSeccion += (e => { cargarSecciones(e); });
        }
        public Timer timerPreguntas;
        public void cargarSecciones(string seccion)
        {
            string json = File.ReadAllText(@"Model\DatosModel1.json");
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var preguntas = JsonSerializer.Deserialize<Root>(json, opciones);

            if (seccion == "Español")
            {
                
                preguntaItems = preguntas.Español;
            }
            else if (seccion == "Matematicas")
            {

                preguntaItems = preguntas.Español;
            }
            else if (seccion == "Historia")
            {

                preguntaItems = preguntas.Historia;
            }
            else
            {
                preguntaItems = preguntas.CienciasNaturales;
                
            }
        }

        public void Receive(NavegacionModel message)
        {
            cargarSecciones(message.seccion);
        }
    }
}
