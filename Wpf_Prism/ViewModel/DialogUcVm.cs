namespace Wpf_Prism.ViewModel
{
    public class DialogUcVm : BindableBase, IDialogAware
    {
        private string _message = "这是通过 DialogService 打开的 DialogUc";

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        /// <summary>
        /// 由 IDialogService 在显示对话框时赋值，调用它即可关闭对话框
        /// </summary>
        public DialogCloseListener RequestClose { get; }

        /// <summary>
        /// 是否能关闭对话框
        /// </summary>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 关闭时触发
        /// </summary>
        public void OnDialogClosed()
        {
        }

        /// <summary>
        /// 打开时触发
        /// </summary>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("message"))
            {
                Message = parameters.GetValue<string>("message");
            }
        }

        private DelegateCommand<string>? _closeCommand;

        public DelegateCommand<string> CloseCommand =>
            _closeCommand ??= new DelegateCommand<string>(Close);

        private void Close(string? button)
        {
            var result = button == "OK" ? ButtonResult.OK : ButtonResult.Cancel;
            RequestClose.Invoke(new DialogResult(result));
        }
    }
}
