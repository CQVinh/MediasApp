using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class YourAccountViewModel : BaseViewModel
    {
        bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public bool IsSetting { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand EmailCommand { get; set; }
        public ICommand PasswordCommand { get; set; }
        public ICommand PlanCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveEmailCommand { get; set; }
        public ICommand SavePasswordCommand { get; set; }
        public ICommand OldPasswordCommand { get; set; }
        public ICommand NewPasswordCommand { get; set; }
        public ICommand ConfirmNewPasswordCommand { get; set; }
        public ICommand ManageProfilesCommand { get; set; }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _NewEmail;
        public string NewEmail { get => _NewEmail; set { _NewEmail = value; OnPropertyChanged(); } }
        private string _PasswordView;
        public string PasswordView { get => _PasswordView; set { _PasswordView = value; OnPropertyChanged(); } }
        private string _NamePlanDisplay;
        public string NamePlanDisplay { get => _NamePlanDisplay; set { _NamePlanDisplay = value; OnPropertyChanged(); } }
        private string _MonthlyPiceDisplay;
        public string MonthlyPiceDisplay { get => _MonthlyPiceDisplay; set { _MonthlyPiceDisplay = value; OnPropertyChanged(); } }
        private string _ExpirationDateDisplay;
        public string ExpirationDateDisplay { get => _ExpirationDateDisplay; set { _ExpirationDateDisplay = value; OnPropertyChanged(); } }
        private string _FormChangeEmail;
        public string FormChangeEmail { get => _FormChangeEmail; set { _FormChangeEmail = value; OnPropertyChanged(); } }
        private string _FormChangePassword;
        public string FormChangePassword { get => _FormChangePassword; set { _FormChangePassword = value; OnPropertyChanged(); } }
        private string _OldPassword;
        public string OldPassword { get => _OldPassword; set { _OldPassword = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        private string _ConfirmNewPassword;
        public string ConfirmNewPassword { get => _ConfirmNewPassword; set { _ConfirmNewPassword = value; OnPropertyChanged(); } }
        private Profiles _SelectedProfile;
        public Profiles SelectedProfile { get => _SelectedProfile; set { _SelectedProfile = value; OnPropertyChanged(); } }
        private Account _SelectedUser;
        public Account SelectedUser { get => _SelectedUser; set { _SelectedUser = value; OnPropertyChanged(); } }
        public ICommand BilingDetailsCommand { get; set; }
        private string _CardNumberView;
        public string CardNumberView { get => _CardNumberView; set { _CardNumberView = value; OnPropertyChanged(); } }
        private string _BillingDetails;
        public string BillingDetails { get => _BillingDetails; set { _BillingDetails = value; OnPropertyChanged(); } }
        public ICommand CloseBillingDetailsCommand { get; set; }
        private PaymentHistory _payment;
        public PaymentHistory payment { get => _payment; set { _payment = value; OnPropertyChanged(); } }
        private string _DateNextBill;
        public string DateNextBill { get => _DateNextBill; set { _DateNextBill = value; OnPropertyChanged(); } }

        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }

        public ICommand HistoryPaymentCommand { get; set; }
        public ICommand CloseHistoryPaymentCommand { get; set; }
        private string _HistoryPayment;
        public string HistoryPayment { get => _HistoryPayment; set { _HistoryPayment = value; OnPropertyChanged(); } }
        private List<PaymentHistory> _HistoryPaymentList;
        public List<PaymentHistory> HistoryPaymentList { get => _HistoryPaymentList; set { _HistoryPaymentList = value; OnPropertyChanged(); } }

        public YourAccountViewModel()
        {
            IsSetting = false;
            Email = "";
            Password = "";
            NewEmail = "";
            NamePlanDisplay = "";
            MonthlyPiceDisplay = "";
            OldPassword = "";
            NewPassword = "";
            ConfirmNewPassword = "";
            PasswordView = "";
            CardNumberView = "";
            Error = "";
            FormChangeEmail = "Collapsed";
            FormChangePassword = "Collapsed";
            BillingDetails = "Collapsed";
            HistoryPayment = "Collapsed";
            OldPasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { OldPassword = p.Password; });
            NewPasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { NewPassword = p.Password; });
            ConfirmNewPasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { ConfirmNewPassword = p.Password; });
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                Email = "";
                Password = "";
                NewEmail = "";
                NamePlanDisplay = "";
                MonthlyPiceDisplay = "";
                OldPassword = "";
                NewPassword = "";
                ConfirmNewPassword = "";
                PasswordView = "";
                CardNumberView = "";
                Error = "";
                UserWindow userWindow = new UserWindow();
                if (userWindow.DataContext == null)
                    return;
                var user = userWindow.DataContext as UserViewModel;
                SelectedProfile = user.SelectedProfile;
                userWindow.Close();
                VisibilityError = "Collapsed";
                ChooseProfilesWindow chooseProfilesWindow = new ChooseProfilesWindow();
                if (chooseProfilesWindow.DataContext == null)
                    return;
                var chooseprofiles = chooseProfilesWindow.DataContext as ChooseProfilesViewModel;
                Email = chooseprofiles.AccountLogin.Email;
                Password = chooseprofiles.AccountLogin.Password;
                if (chooseprofiles.AccountLogin.UserPlan == 1)
                {
                    NamePlanDisplay = "Basic";
                    MonthlyPiceDisplay = "180,000₫";
                }
                else if (chooseprofiles.AccountLogin.UserPlan == 2)
                {
                    NamePlanDisplay = "Standard";
                    MonthlyPiceDisplay = "220,000₫";
                }
                else if (chooseprofiles.AccountLogin.UserPlan == 3)
                {
                    NamePlanDisplay = "Premium";
                    MonthlyPiceDisplay = "260,000₫";
                }
                SelectedUser = chooseprofiles.AccountLogin;
                for (int i = 0; i < Password.Count(); i++)
                {
                    PasswordView += "*";
                }
                var paymentlist = DataProvider.Ins.DB.PaymentHistory.Where(x => x.PHEmailId == SelectedUser.Id).ToList();
                payment = paymentlist[paymentlist.Count - 1];
                for (int i = 0; i <payment.CardNumber.Length - 4; i++)
                {
                    if (i == 4 || i == 8)
                    {
                        CardNumberView += " ";
                    }
                    CardNumberView += "*";
                }
                for (int i = 12; i < payment.CardNumber.Length; i++)
                {
                    if (i == 12)
                    {
                        CardNumberView += " ";
                    }
                    if (i >= 12)
                    {
                        CardNumberView += payment.CardNumber[i];
                    }
                }
                ExpirationDateDisplay = DateTime.Parse(payment.DateOfPayment.ToString()).ToString("dd/MM/yyyy");
                DateNextBill = DateTime.Parse(ExpirationDateDisplay).AddDays(30).ToString("dd/MM/yyyy");
                HistoryPaymentList = new List<PaymentHistory>();
                HistoryPaymentList = paymentlist.ToList();
                chooseProfilesWindow.Close();
            });
            HomeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsSetting = true;
                p.Close();
            });
            EmailCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                FormChangeEmail = "Visible";
                VisibilityError = "Collapsed";
            });
            PasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                FormChangePassword = "Visible";
                VisibilityError = "Collapsed";
            });
            SaveEmailCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var checkemail = DataProvider.Ins.DB.Account.Where(x => x.Email == NewEmail).Count();
                if (checkemail == 0 && CheckEmail(NewEmail) == true)
                {
                    var email = DataProvider.Ins.DB.Account.Where(x => x.Id == SelectedUser.Id).SingleOrDefault();
                    email.Email = NewEmail;
                    DataProvider.Ins.DB.SaveChanges();
                    FormChangeEmail = "Collapsed";
                }
                else
                {
                    if (checkemail > 0)
                        Error = "Looks like that account already exists.";
                    else if (CheckEmail(NewEmail) == false)
                        Error = "Please enter a valid credit Email";
                    VisibilityError = "Visible";
                }
            });
            SavePasswordCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                if (OldPassword == SelectedUser.Password && NewPassword == ConfirmNewPassword && NewPassword.Length >= 4 && NewPassword.Length <= 60 && ConfirmNewPassword.Length >= 4 && ConfirmNewPassword.Length <= 60)
                {
                    var email = DataProvider.Ins.DB.Account.Where(x => x.Id == SelectedUser.Id).SingleOrDefault();
                    email.Password = NewPassword;
                    DataProvider.Ins.DB.SaveChanges();
                    FormChangePassword = "Collapsed";
                }
                else
                {
                    if (NewPassword != ConfirmNewPassword)
                        Error = "Must match your new password.";
                    else if (NewPassword.Length < 4 || NewPassword.Length > 60 || ConfirmNewPassword.Length < 4 || ConfirmNewPassword.Length > 60)
                        Error = "Password should be between 4 and 60 characters";
                    VisibilityError = "Visible";
                }
                PasswordView = "";
                for (int i = 0; i < NewPassword.Count(); i++)
                {
                    PasswordView += "*";
                }
            });
            CancelCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                FormChangeEmail = "Collapsed";
                FormChangePassword = "Collapsed";
                VisibilityError = "Collapsed";
            });
            PlanCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                ChooseThePlanWindow chooseThePlanWindow = new ChooseThePlanWindow();
                chooseThePlanWindow.ShowDialog();
                p.Close();
            });
            ManageProfilesCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                ManageProfilesWindow manageProfilesWindow = new ManageProfilesWindow();
                manageProfilesWindow.ShowDialog();
                if (manageProfilesWindow.DataContext == null)
                    return;
                var manageprofiles = manageProfilesWindow.DataContext as ManageProfilesViewModel;
                if (manageprofiles.IsLoaded)
                {
                    var profiles = DataProvider.Ins.DB.Profiles.ToList();
                    for (int i = 0; i < profiles.Count(); i++)
                    {
                        if (profiles[i].Id == SelectedProfile.Id)
                        {
                            SelectedProfile = profiles[i];
                            break;
                        }
                    }
                    p.ShowDialog();
                }
                else
                    p.Close();
            });
            BilingDetailsCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                BillingDetails = "Visible";
            });
            CloseBillingDetailsCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                BillingDetails = "Collapsed";
            });
            HistoryPaymentCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                HistoryPayment = "Visible";
            });
            CloseHistoryPaymentCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                HistoryPayment = "Collapsed";
            });
        }
    }
}
