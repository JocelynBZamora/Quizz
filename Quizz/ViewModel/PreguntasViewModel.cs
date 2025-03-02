using CommunityToolkit.Mvvm.ComponentModel;
using QuizzServer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzServer.ViewModel
{
    public partial class PreguntasViewModel : ObservableRecipient
    {
        [ObservableProperty]//propiedad
        public string userName;

        public PreguntasViewModel()
        {
            UserName = string.Empty;
            //OnPropertyChanged();//para actualizar vista

        }


    }
}
