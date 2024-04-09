using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab9.ViewModels
{
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;


            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
