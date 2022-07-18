using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public bool IsLoaded { get; set; }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginLoadedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }
        private string _Content;
        public string Content { get => _Content; set { _Content = value; OnPropertyChanged(); } }
        private string _Loaded;
        public string Loaded { get => _Loaded; set { _Loaded = value; OnPropertyChanged(); } }
        public MainViewModel()
        {
            Email = "";
            Password = "";
            Content = "Visible";
            Loaded = "False";
            VisibilityError = "Collapsed";
            IsLogin = false;
            IsLoaded = false;
            LoginLoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var login = loginWindow.DataContext as LoginViewModel;
                if (login.IsLoaded)
                    p.Show();
                else
                    p.Close();
            });
            LoginCommand = new RelayCommand<Window>((p) => { if (IsLoaded == true) return false; return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            RegistrationCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                RegistrationWindow registrationWindow = new RegistrationWindow();
                registrationWindow.ShowDialog();
                p.Show();
            });
            ForgotPasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                ForgotPasswordWindow forgotpasswordWindow = new ForgotPasswordWindow();
                forgotpasswordWindow.ShowDialog();
                if (forgotpasswordWindow.DataContext == null)
                    return;
                var forgotpassword = forgotpasswordWindow.DataContext as ForgotPasswordViewModel;
                if (forgotpassword.IsForgotPassword)
                    p.Show();
                else
                    p.Close();
            });
        }

        async void Login(Window p)
        {
            if (p == null)
                return;
            var query = DataProvider.Ins.DB.Account.Where(x => x.Email == Email && x.Password == Password).Count();
            var checkRole = DataProvider.Ins.DB.Account.Where(x => x.Email == Email && x.Password == Password).Select(x=>x).SingleOrDefault();
            Content = "Collapsed";
            Loaded = "True";
            await Task.Run(() =>
            {
                IsLoaded = true;
                System.Threading.Thread.Sleep(3000);
            });
            if (query > 0 && checkRole.Role == "user")
            {
                IsLogin = true;
                p.Hide();
                ChooseProfilesWindow chooseProfilesWindow = new ChooseProfilesWindow();
                chooseProfilesWindow.ShowDialog();
                IsLogin = false;
                IsLoaded = false;
                Content = "Visible";
                Loaded = "False";
                VisibilityError = "Collapsed";
                p.Show();
            }
            else if (query > 0 && checkRole.Role == "admin")
            {
                p.Hide();
                AdminDashboard adminDashboard = new AdminDashboard();
                adminDashboard.ShowDialog();
                IsLogin = false;
                IsLoaded = false;
                Content = "Visible";
                Loaded = "False";
                VisibilityError = "Collapsed";
                p.Show();
            }
            else
            {
                var email = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).Count();
                var password = DataProvider.Ins.DB.Account.Where(x => x.Email == Email && x.Password == Password).Count();
                if (email == 0)
                    Error = "Sorry, we can't find an account with this email address. Please try again or create a new account.";
                else if (password == 0)
                    Error = "Incorrect password. Please try again or you can reset your password.";
                VisibilityError = "Visible";
                Content = "Visible";
                Loaded = "False";
                IsLoaded = false;
            }
        }
    }
}
