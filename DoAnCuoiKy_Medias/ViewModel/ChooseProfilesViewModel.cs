using DoAnCuoiKy_Medias.Model;
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
    public class ChooseProfilesViewModel : BaseViewModel
    {
        private Account _AccountLogin;
        public Account AccountLogin { get => _AccountLogin; set { _AccountLogin = value; OnPropertyChanged(); } }
        private List<Profiles> _ProfilesList;
        public List<Profiles> ProfilesList { get => _ProfilesList; set { _ProfilesList = value; OnPropertyChanged(); } }
        private List<Profiles> _profileslist;
        public List<Profiles> profileslist { get => _profileslist; set { _profileslist = value; OnPropertyChanged(); } }
        private Profiles _SelectedItemProfiles;
        public Profiles SelectedItemProfiles { get => _SelectedItemProfiles; set { _SelectedItemProfiles = value; OnPropertyChanged(); } }
        public ICommand DoneCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand AddProfilesCommand { get; set; }
        public ICommand ManageProfilesCommand { get; set; }
        private string _ShowMessage;
        public string ShowMessage { get => _ShowMessage; set { _ShowMessage = value; OnPropertyChanged(); } }
        public ICommand MessageBoxCommand { get; set; }
        private string _Message;
        public string Message { get => _Message; set { _Message = value; OnPropertyChanged(); } }

        public ChooseProfilesViewModel()
        {
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                profileslist = new List<Profiles>();
                ShowMessage = "Collapsed";
                Message = "Choose your profile";
                SelectedItemProfiles = null;
                LoadedProfilesList();
            });
            AddProfilesCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                AddProfilesWindow addProfilesWindow = new AddProfilesWindow();
                addProfilesWindow.ShowDialog();
                if (addProfilesWindow.DataContext == null)
                    return;
                var addprofiles = addProfilesWindow.DataContext as AddProfilesViewModel;
                if (addprofiles.IsAddProfiles)
                {
                    LoadedProfilesList();
                    p.ShowDialog();
                }
                else
                {
                    p.Close();
                }
                addProfilesWindow.Close();
            });
            DoneCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                if (SelectedItemProfiles == null)
                    ShowMessage = "Visible";
                else
                {
                    p.Hide();
                    UserWindow userWindow = new UserWindow();
                    userWindow.ShowDialog();
                    p.Close();
                }
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
                    LoadedProfilesList();
                    p.ShowDialog();
                }
                else
                {
                    p.Close();
                }
                manageProfilesWindow.Close();
            });
            MessageBoxCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ShowMessage = "Collapsed";
            });
        }
        void LoadedProfilesList()
        {
            profileslist = DataProvider.Ins.DB.Profiles.ToList();
            var accountlist = DataProvider.Ins.DB.Account.ToList();
            ProfilesList = new List<Profiles>();
            MainWindow mainWindow = new MainWindow();
            if (mainWindow.DataContext == null)
                return;
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.DataContext == null)
                return;
            var main = mainWindow.DataContext as MainViewModel;
            var login = loginWindow.DataContext as LoginViewModel;
            if (main.IsLogin == true)
            {
                for (int i = 0; i < accountlist.Count(); i++)
                {
                    if (accountlist[i].Email == main.Email)
                    {
                        AccountLogin = accountlist[i];
                        var query = from a in profileslist
                                    where a.PFEmailId == accountlist[i].Id
                                    select a;
                        ProfilesList = query.ToList();
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
                        AccountLogin = accountlist[i];
                        var query = from a in profileslist
                                    where a.PFEmailId == accountlist[i].Id
                                    select a;
                        ProfilesList = query.ToList();
                        break;
                    }
                }
            }
            mainWindow.Close();
            loginWindow.Close();
        }
    }
}
