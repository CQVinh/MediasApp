using DoAnCuoiKy_Medias.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    class ForgotPasswordViewModel : BaseViewModel
    {
        public bool IsForgotPassword { get; set; }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        private string _ConfirmNewPassword;
        public string ConfirmNewPassword { get => _ConfirmNewPassword; set { _ConfirmNewPassword = value; OnPropertyChanged(); } }
        public ICommand LoadedForgotPasswordCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand ConfirmPasswordChangedCommand { get; set; }
        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }

        public ForgotPasswordViewModel()
        {
            IsForgotPassword = false;
            Error = "";
            Email = ""; 
            NewPassword = ""; 
            ConfirmNewPassword = "";
            VisibilityError = "Collapsed";
            LoadedForgotPasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Email = ""; NewPassword = ""; ConfirmNewPassword = ""; VisibilityError = "Collapsed"; });
            ForgotPasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ForgotPassword(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });
            ConfirmPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ConfirmNewPassword = p.Password; });
        }

        void ForgotPassword(Window p)
        {
            if (p == null)
                return;
            var query = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).Count();
            var selecteduser = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).SingleOrDefault();
            if (NewPassword == ConfirmNewPassword && query >= 1 && NewPassword.Length >= 4 && NewPassword.Length <= 60 && ConfirmNewPassword.Length >= 4 && ConfirmNewPassword.Length <= 60 && string.IsNullOrWhiteSpace(Email) == false)
            {
                var user = DataProvider.Ins.DB.Account.Where(x => x.Id == selecteduser.Id).SingleOrDefault();
                user.Password = NewPassword;
                DataProvider.Ins.DB.SaveChanges();
                IsForgotPassword = true;
                VisibilityError = "Collapsed";
                p.Close();
            }
            else
            {
                var email = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).Count();
                if (email == 0)
                    Error = "Sorry, we can't find an account with this email address. Please try again or create a new account.";
                else if (NewPassword != ConfirmNewPassword)
                    Error = "Must match your new password.";
                else if (NewPassword.Length < 4 || NewPassword.Length > 60 || ConfirmNewPassword.Length < 4 || ConfirmNewPassword.Length > 60)
                    Error = "Password should be between 4 and 60 characters";
                else
                    Error = "Emai or Password is required!";
                VisibilityError = "Visible";
                IsForgotPassword = false;
            }
        }
    }
}
