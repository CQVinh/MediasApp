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
    class RegistrationViewModel : BaseViewModel
    {
        bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public bool IsRegistration { get; set; }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoadedRegistrationCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand ChooseThePlanCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }

        public RegistrationViewModel()
        {
            IsRegistration = false;
            Email = "";
            Password = "";
            LoadedRegistrationCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { VisibilityError = "Collapsed"; });
            ChooseThePlanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { ChooseThePlan(p); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                MainWindow loginWindow = new MainWindow();
                loginWindow.ShowDialog();
                p.Close();
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void ChooseThePlan(Window p)
        {
            if (p == null)
                return;
            var query = DataProvider.Ins.DB.Account.Where(x => x.Email == Email);
            if (query.ToList().Count() == 0 && CheckEmail(Email) == true && Password.Length >= 4 && Password.Length <= 60)
            {
                p.Hide();
                IsRegistration = true;
                ChooseThePlanWindow chooseThePlanWindow = new ChooseThePlanWindow();
                chooseThePlanWindow.ShowDialog();
                IsRegistration = false;
                VisibilityError = "Collapsed";
                p.Close();
            }
            else
            {
                var email = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).Count();
                if (email > 0)
                    Error = "Looks like that account already exists. Sign into that account or try using a different email.";
                else if(CheckEmail(Email) == false)
                    Error = "Please enter a valid credit Email";
                else if (Password.Length < 4 || Password.Length > 60)
                    Error = "Password should be between 4 and 60 characters";
                else
                    Error = "Emai or Password is required!";
                VisibilityError = "Visible";
            }
        }
    }
}
