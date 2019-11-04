using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastersofMemory.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName)); //Als de handler geen null aangeeft, wordt de waarde geupdated
        }

        //Variabelen worden automatisch aangepast door deze Observable Object, 
        //dit komt door de inheritance van de inteface 'INotifyPropertyChanged'

    }
}
