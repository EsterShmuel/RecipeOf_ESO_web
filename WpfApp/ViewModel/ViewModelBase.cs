using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //tels the UI wat Binding to update
        public event PropertyChangedEventHandler PropertyChanged;

        //tels when property value is change and update UI
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public virtual void Dispose() { }
    }
}
