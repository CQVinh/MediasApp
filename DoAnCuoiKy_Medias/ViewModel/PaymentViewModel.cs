using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    class PaymentViewModel : BaseViewModel
    {
        bool IsCardNumber(string CardNumber)
        {
            return Regex.IsMatch(CardNumber, @"^[0-9]{16}$");
        }
        bool IsExpirationDate(string ExpirationDate)
        {
            return Regex.IsMatch(ExpirationDate, @"(0[1-9]|10|11|12)/[0-9]{2}$");
        }
        bool IsCVV(string CVV)
        {
            return Regex.IsMatch(CVV, @"^[0-9]{4}$");
        }
        public bool IsPayment { get; set; }
        public ICommand ChangePlanCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LoadedChangePlan { get; set; }
        private string _MonthlyPrice;
        public string MonthlyPrice { get => _MonthlyPrice; set { _MonthlyPrice = value; OnPropertyChanged(); } }
        private string _NamePlan;
        public string NamePlan { get => _NamePlan; set { _NamePlan = value; OnPropertyChanged(); } }
        private string _FirstName;
        public string FirstName { get => _FirstName; set { _FirstName = value; OnPropertyChanged(); } }
        private string _LastName;
        public string LastName { get => _LastName; set { _LastName = value; OnPropertyChanged(); } }
        private string _CardNumber;
        public string CardNumber { get => _CardNumber; set { _CardNumber = value; OnPropertyChanged(); } }
        private string _ExpirationDate;
        public string ExpirationDate { get => _ExpirationDate; set { _ExpirationDate = value; OnPropertyChanged(); } }
        private string _CVV;
        public string CVV { get => _CVV; set { _CVV = value; OnPropertyChanged(); } }
        private int _Plan;
        public int Plan { get => _Plan; set { _Plan = value; OnPropertyChanged(); } }
        private string _Error;
        public string Error { get => _Error; set { _Error = value; OnPropertyChanged(); } }
        private string _VisibilityError;
        public string VisibilityError { get => _VisibilityError; set { _VisibilityError = value; OnPropertyChanged(); } }

        public PaymentViewModel()
        {
            IsPayment = false;
            FirstName = "";
            LastName = "";
            CardNumber = "";
            ExpirationDate = "";
            CVV = "";
            LoadedChangePlan = new RelayCommand<Window>((p) => { return true; }, (p) => { ChangePlan(); VisibilityError = "Collapsed"; });
            ChangePlanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsPayment = true; p.Close(); });
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsPayment = false; Login(p); });
        }

        void ChangePlan()
        {
            ChooseThePlanWindow choosetheplanWindow = new ChooseThePlanWindow();
            var choosetheplan = choosetheplanWindow.DataContext as ChooseThePlanViewModel;
            if (choosetheplan.IsBasic == true)
            {
                MonthlyPrice = "180,000 ₫/month";
                NamePlan = "Basic";
                Plan = 1;
            }
            else if (choosetheplan.IsStandard == true)
            {
                MonthlyPrice = "220,000 ₫/month";
                NamePlan = "Standard";
                Plan = 2;
            }
            else if (choosetheplan.IsPremium == true)
            {
                MonthlyPrice = "260,000 ₫/month";
                NamePlan = "Premium";
                Plan = 3;
            }
            choosetheplanWindow.Close();
        }

        void Login(Window p)
        {
            if (p == null)
                return;
            if (FirstName.Length > 1 && LastName.Length > 1 && IsCardNumber(CardNumber) == true && IsExpirationDate(ExpirationDate) == true && IsCVV(CVV) == true)
            {
                Payment(p);
                p.Hide();
                VisibilityError = "Collapsed";
                p.Close();
            }
            else
            {
                if (FirstName.Length < 1)
                    Error = "First Name is required!";
                else if (LastName.Length < 1)
                    Error = "Last Name is required!";
                else if (IsCardNumber(CardNumber) == false)
                    Error = "Please enter a valid credit card number";
                else if (IsExpirationDate(ExpirationDate) == false)
                    Error = "Please enter a valid credit expiration date";
                else if (IsCVV(CVV) == false)
                    Error = "Please enter a valid credit cvv";
                else
                    Error = "Last Name or First Name is required!";
                VisibilityError = "Visible";
            }
        }

        void Payment(Window p)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            if (registrationWindow.DataContext == null)
                return;
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.DataContext == null)
                return;
            var registration1 = registrationWindow.DataContext as RegistrationViewModel;
            var registration2 = loginWindow.DataContext as LoginViewModel;
            if (registration1.IsRegistration == true || registration2.IsRegistration == true)
            {
                if (registration1.IsRegistration == true)
                {
                    var newAccount = new Account()
                    {
                        Email = registration1.Email,
                        Password = registration1.Password,
                        UserPlan = Plan,
                        Role = "user"
                    };
                    DataProvider.Ins.DB.Account.Add(newAccount);
                    var newPaymentHistory = new PaymentHistory()
                    {
                        PHEmailId = newAccount.Id,
                        FirstName = FirstName,
                        LastName = LastName,
                        CardNumber = CardNumber,
                        ExpirationDate = ExpirationDate,
                        CVV = CVV,
                        DateOfPayment = DateTime.Now,
                        PlanId = Plan
                    };
                    DataProvider.Ins.DB.PaymentHistory.Add(newPaymentHistory);
                    DataProvider.Ins.DB.SaveChanges();
                }
                else if (registration2.IsRegistration == true)
                {
                    var newAccount = new Account()
                    {
                        Email = registration2.EmailAddress,
                        Password = registration2.Password2,
                        UserPlan = Plan,
                        Role = "user"
                    };
                    DataProvider.Ins.DB.Account.Add(newAccount);
                    var newPaymentHistory = new PaymentHistory()
                    {
                        PHEmailId = newAccount.Id,
                        FirstName = FirstName,
                        LastName = LastName,
                        CardNumber = CardNumber,
                        ExpirationDate = ExpirationDate,
                        CVV = CVV,
                        DateOfPayment = DateTime.Now,
                        PlanId = Plan
                    };
                    DataProvider.Ins.DB.PaymentHistory.Add(newPaymentHistory);
                    DataProvider.Ins.DB.SaveChanges();
                }
            }
            else if(registration1.IsRegistration == false && registration2.IsRegistration == false)
            {
                MainWindow mainWindow = new MainWindow();
                if (mainWindow.DataContext == null)
                    return;
                var main = mainWindow.DataContext as MainViewModel;
                var login = loginWindow.DataContext as LoginViewModel;
                var accountlist = DataProvider.Ins.DB.Account.ToList();
                if (main.IsLogin == true)
                {
                    for (int i = 0; i < accountlist.Count(); i++)
                    {
                        if (accountlist[i].Email == main.Email)
                        {
                            var newPaymentHistory = new PaymentHistory()
                            {
                                PHEmailId = accountlist[i].Id,
                                FirstName = FirstName,
                                LastName = LastName,
                                CardNumber = CardNumber,
                                ExpirationDate = ExpirationDate,
                                CVV = CVV,
                                DateOfPayment = DateTime.Now,
                                PlanId = Plan
                            };
                            DataProvider.Ins.DB.PaymentHistory.Add(newPaymentHistory);
                            DataProvider.Ins.DB.SaveChanges();
                            break;
                        }
                    }
                }
                else if (login.IsLogin == true)
                {
                    for (int i = 0; i < accountlist.Count(); i++)
                    {
                        if (accountlist[i].Email == login.EmailAddress)
                        {
                            var newPaymentHistory = new PaymentHistory()
                            {
                                PHEmailId = accountlist[i].Id,
                                FirstName = FirstName,
                                LastName = LastName,
                                CardNumber = CardNumber,
                                ExpirationDate = ExpirationDate,
                                CVV = CVV,
                                DateOfPayment = DateTime.Now,
                                PlanId = Plan
                            };
                            DataProvider.Ins.DB.PaymentHistory.Add(newPaymentHistory);
                            DataProvider.Ins.DB.SaveChanges();
                            break;
                        }
                    }
                }
                mainWindow.Close();
            }
            registrationWindow.Close();
            loginWindow.Close();
        }
    }
}
