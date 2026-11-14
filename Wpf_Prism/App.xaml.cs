using System.Windows;
using Wpf_Prism.View;
using Wpf_Prism.ViewModel;

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
            return Container.Resolve<UseDialog>();
        }

        //注册服务
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //对话框名称默认为类型名：DialogUc
            containerRegistry.RegisterDialog<DialogUc>();
        }

        //自定义规则：Wpf_Prism.View.User -> Wpf_Prism.ViewModel.UserVm
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName!;
                var viewModelName = viewName.Replace(".View.", ".ViewModel.") + "Vm";
                return viewType.Assembly.GetType(viewModelName);
            });

            //通过容器创建 ViewModel，使其构造函数可以注入依赖（如 IDialogService）
            ViewModelLocationProvider.SetDefaultViewModelFactory(type => Container.Resolve(type));
        }
    }
}
