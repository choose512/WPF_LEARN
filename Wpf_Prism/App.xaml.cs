using System;
using System.Windows;
using Prism.Mvvm;
using Wpf_Prism.View;

namespace Wpf_Prism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        //启动窗体
        protected override Window CreateShell()
        {
            return Container.Resolve<User>();
        }

        //注册服务
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        //自定义规则：Wpf_Prism.View.User -> Wpf_Prism.ViewModel.UserVm
        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName!;
                var viewModelName = viewName.Replace(".View.", ".ViewModel.") + "Vm";
                return viewType.Assembly.GetType(viewModelName);
            });
        }
    }

}
