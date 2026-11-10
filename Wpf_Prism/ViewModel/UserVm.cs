using Prism.Mvvm;

namespace Wpf_Prism.ViewModel
{
    public class UserVm : BindableBase
    {
        private string _uName = "User ViewModel";

        public string UName
        {
            get => _uName;
            set => SetProperty(ref _uName, value);
        }
    }
}
