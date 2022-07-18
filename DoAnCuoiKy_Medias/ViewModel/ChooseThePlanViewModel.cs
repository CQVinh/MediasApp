using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    class ChooseThePlanViewModel : BaseViewModel
    {
        private bool _IsBasic;
        public bool IsBasic { get => _IsBasic; set { _IsBasic = value; OnPropertyChanged(); } }
        private bool _IsStandard;
        public bool IsStandard { get => _IsStandard; set { _IsStandard = value; OnPropertyChanged(); } }
        private bool _IsPremium;
        public bool IsPremium { get => _IsPremium; set { _IsPremium = value; OnPropertyChanged(); } }
        public ICommand BasicButtonCommand { get; set; }
        public ICommand StandardButtonCommand { get; set; }
        public ICommand PremiumButtonCommand { get; set; }
        public ICommand LoadedPlan { get; set; }
        private string _ChoosePlan;
        public string ChoosePlan { get => _ChoosePlan; set { _ChoosePlan = value; OnPropertyChanged(); } }
        public ICommand PaymentCommand { get; set; }

        public ChooseThePlanViewModel()
        {
            LoadedPlan = new RelayCommand<Window>((p) => { return true; }, (p) => { IsBasic = false; IsStandard = false; IsPremium = true; ChoosePlan = "Premium"; });
            BasicButtonCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsBasic = true; IsStandard = false; IsPremium = false; ChoosePlan = "Basic"; });
            StandardButtonCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsBasic = false; IsStandard = true; IsPremium = false; ChoosePlan = "Standard"; });
            PremiumButtonCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { IsBasic = false; IsStandard = false; IsPremium = true; ChoosePlan = "Premium"; });
            PaymentCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Payment(p); });
        }

        void Payment(Window p)
        {
            if (p == null)
                return;
            p.Hide();
            PaymentWindow paymentWindow = new PaymentWindow();
            paymentWindow.ShowDialog();
            if (paymentWindow.DataContext == null)
                return;
            var payment = paymentWindow.DataContext as PaymentViewModel;
            if (payment.IsPayment)
                p.ShowDialog();
            else
            {
                p.Close();
            }
        }
    }
}
