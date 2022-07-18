using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public bool IsLoaded { get; set; }
        public bool IsLogin { get; set; }
        public bool IsRegistration { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand SignInCommand { get; set; }
        public ICommand GetStartedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand PasswordChanged1Command { get; set; }
        public ICommand PasswordChanged2Command { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        private string _Main;
        public string Main { get => _Main; set { _Main = value; OnPropertyChanged(); } }
        private string _Login;
        public string Login { get => _Login; set { _Login = value; OnPropertyChanged(); } }
        private string _Registration;
        public string Registration { get => _Registration; set { _Registration = value; OnPropertyChanged(); } }
        private string _EmailAddress;
        public string EmailAddress { get => _EmailAddress; set { _EmailAddress = value; OnPropertyChanged(); } }
        private string _Password1;
        public string Password1 { get => _Password1; set { _Password1 = value; OnPropertyChanged(); } }
        private string _Password2;
        public string Password2 { get => _Password2; set { _Password2 = value; OnPropertyChanged(); } }
        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }

        public LoginViewModel()
        {
            EmailAddress = "";
            Password1 = "";
            Password2 = "";
            Main = "Visible";
            Login = "Collapsed";
            Registration = "Collapsed";
            Error = "";
            VisibilityError = "Collapsed";
            IsRegistration = false;
            IsLoaded = false;
            IsLogin = true;
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                if (IsLoaded)
                    p.Close();
                else
                    p.Show();
            });
            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsLoaded = true;
                IsLogin = false;
                p.Close();
            });
            GetStartedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var checkemail = DataProvider.Ins.DB.Account.Where(x => x.Email == EmailAddress).Count();
                if (checkemail > 0)
                {
                    Main = "Collapsed";
                    Login = "Visible";
                }
                else
                {
                    Main = "Collapsed";
                    Registration = "Visible";
                }
            });
            PasswordChanged1Command = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password1 = p.Password; });
            PasswordChanged2Command = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password2 = p.Password; });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var query = DataProvider.Ins.DB.Account.Where(x => x.Email == EmailAddress && x.Password == Password1).Count();
                var checkRole = DataProvider.Ins.DB.Account.Where(x => x.Email == EmailAddress && x.Password == Password1).Select(x=>x).SingleOrDefault();
                if (query > 0 && checkRole.Role == "user")
                {
                    p.Hide();
                    IsLoaded = true;
                    IsLogin = true;
                    ChooseProfilesWindow chooseProfilesWindow = new ChooseProfilesWindow();
                    chooseProfilesWindow.ShowDialog();
                    IsLogin = false;
                    p.Close();
                }
                else if (query > 0 && checkRole.Role == "admin")
                {
                    p.Hide();
                    IsLoaded = true;
                    IsLogin = true;
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.ShowDialog();
                    IsLogin = false;
                    p.Close();
                }
                else
                {
                    Error = "Incorrect password. Please try again or you can reset your password.";
                    VisibilityError = "Visible";
                }
            });
            RegistrationCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var query = DataProvider.Ins.DB.Account.Where(x => x.Email == EmailAddress);
                if (query.ToList().Count() == 0 && CheckEmail(EmailAddress) == true)
                {
                    p.Hide();
                    IsRegistration = true;
                    IsLoaded = true;
                    ChooseThePlanWindow chooseThePlanWindow = new ChooseThePlanWindow();
                    chooseThePlanWindow.ShowDialog();
                    IsRegistration = false;
                    IsLogin = false;
                    p.Close();
                }
                else
                {
                    var email = DataProvider.Ins.DB.Account.Where(x => x.Email == EmailAddress).Count();
                    if (email > 0)
                        Error = "Looks like that account already exists. Sign into that account or try using a different email.";
                    else if (CheckEmail(EmailAddress) == false)
                        Error = "Please enter a valid credit Email";
                    else
                        Error = "Emai or Password is required!";
                    VisibilityError = "Visible";
                }
            });
            ForgotPasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                VisibilityError = "Collapsed";
                p.Hide();
                ForgotPasswordWindow forgotpasswordWindow = new ForgotPasswordWindow();
                forgotpasswordWindow.ShowDialog();
                if (forgotpasswordWindow.DataContext == null)
                    return;
                var forgotpassword = forgotpasswordWindow.DataContext as ForgotPasswordViewModel;
                if (forgotpassword.IsForgotPassword)
                    p.ShowDialog();
                else
                    p.Close();
            });
        }
    }
}
