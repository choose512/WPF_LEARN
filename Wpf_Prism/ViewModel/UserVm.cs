using System.Windows;

namespace Wpf_Prism.ViewModel
{
    public class UserVm : BindableBase
    {
        private string _userName = "姓名";
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _passWord = "密码";

        public string PassWord
        {
            get { return _passWord; }
            set => SetProperty(ref _passWord, value);
        }



        private DelegateCommand? _loginCommand;

        public DelegateCommand LoginCommand =>
            _loginCommand ??= new DelegateCommand(() =>
            {
                if (UserName == "admin" && PassWord == "123")
                {
                    MessageBox.Show("登录成功");
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }, () => CanLogin);

        public bool CanLogin => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(PassWord);

        private DelegateCommand<string>? _editName;

        // 首次绑定访问时创建，之后复用同一实例
        public DelegateCommand<string> EditName =>
            _editName ??= new DelegateCommand<string>(s => UserName = s);
    }
}
