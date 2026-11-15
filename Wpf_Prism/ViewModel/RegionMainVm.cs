namespace Wpf_Prism.ViewModel
{
    public class RegionMainVm : BindableBase
    {

        private readonly IRegionManager _regionManager;
        public RegionMainVm(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private DelegateCommand<string> _showViewCommand;

        public DelegateCommand<string> ShowViewCommand =>
            _showViewCommand ??= new DelegateCommand<string>(name => OpenView(name));

        private void OpenView(string name)
        {
            _regionManager.RequestNavigate("MainRegion", name);
        }
    }
}
