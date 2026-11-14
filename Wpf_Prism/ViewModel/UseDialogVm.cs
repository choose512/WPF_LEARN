
namespace Wpf_Prism.ViewModel
{
    public class UseDialogVm : BindableBase
    {
        private readonly IDialogService _dialogService;

        public UseDialogVm(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private string _lastResult = string.Empty;

        public string LastResult
        {
            get => _lastResult;
            set => SetProperty(ref _lastResult, value);
        }

        private DelegateCommand? _openDialogCommand;

        public DelegateCommand OpenDialogCommand =>
            _openDialogCommand ??= new DelegateCommand(OpenDialog);

        private void OpenDialog()
        {
            var parameters = new DialogParameters
            {
                { "message", "你好，我是 DialogUc！" }
            };

            // 对话框名称与 App.RegisterTypes 中注册的名称一致
            _dialogService.ShowDialog("DialogUc", parameters, result =>
            {
                LastResult = $"对话框已关闭，结果：{result.Result}";
            });
        }
    }
}
