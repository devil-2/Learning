using System.ComponentModel;

namespace BasicApp.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected MessageViewModel ErrorMessageViewModel { get; set; }
        protected MessageViewModel StatusMessageViewModel { get; set; }

        public string ErrorMessage { set => ErrorMessageViewModel.Message = value; }
        public string StatusMessage { set => StatusMessageViewModel.Message = value; }

        public ViewModelBase()
        {
        }

        public void ResetMessageViewModel()
        {
            if (ErrorMessageViewModel is not null) ErrorMessageViewModel.Message = string.Empty;
            if (StatusMessageViewModel is not null) StatusMessageViewModel.Message = string.Empty;
        }
    }
}
