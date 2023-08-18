using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GloryOrDeath.WPF.CORE.Infrastructure
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? property = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

        protected bool Set<T>(ref T param, T value, string property = null)
        {
            if (Equals(param, value))
                return false;
            else
            {
                param = value;
                OnPropertyChanged(property);
                return true;
            }
        }
    }
}
