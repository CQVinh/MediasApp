using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class AddProfilesViewModel : BaseViewModel
    {
        public bool IsAddProfiles { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand ContinueCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand OpenFileImageCommand { get; set; }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        private Profiles _NewProfile;
        public Profiles NewProfile { get => _NewProfile; set { _NewProfile = value; OnPropertyChanged(); } }
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public AddProfilesViewModel()
        {
            Name = "";
            Avatar = "";
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsAddProfiles = false;
                Name = "";
                Avatar = "";
            });
            OpenFileImageCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "image file (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png;";
                if (openFileDialog.ShowDialog() == true)
                {
                    Avatar = openFileDialog.FileName;
                }
            });
            ContinueCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Hide();
                MainWindow mainWindow = new MainWindow();
                if (mainWindow.DataContext == null)
                    return;
                LoginWindow loginWindow = new LoginWindow();
                if (loginWindow.DataContext == null)
                    return;
                var main = mainWindow.DataContext as MainViewModel;
                var login = loginWindow.DataContext as LoginViewModel;
                var accountlist = DataProvider.Ins.DB.Account.ToList();
                if (Avatar == "")
                {
                    Random rnd = new Random();
                    int index = rnd.Next(1, 4);
                    Avatar = projectDirectory + "/Data/" + "Avatar/" + "avatar" + index + ".png";
                }
                if (main.IsLogin == true)
                {
                    for (int i = 0; i < accountlist.Count(); i++)
                    {
                        if (accountlist[i].Email == main.Email)
                        {
                            var newProfile = new Profiles()
                            {
                                PFEmailId = accountlist[i].Id,
                                Name = Name,
                                Avatar = Avatar
                            };
                            NewProfile = newProfile;
                            DataProvider.Ins.DB.Profiles.Add(newProfile);
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
                            var newProfile = new Profiles()
                            {
                                PFEmailId = accountlist[i].Id,
                                Name = Name,
                                Avatar = Avatar
                            };
                            NewProfile = newProfile;
                            DataProvider.Ins.DB.Profiles.Add(newProfile);
                            DataProvider.Ins.DB.SaveChanges();
                            break;
                        }
                    }
                }
                mainWindow.Close();
                loginWindow.Close();
                IsAddProfiles = true;
                p.Close();
            });
            CancelCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsAddProfiles = true;
                p.Close();
            });
        }
    }
}
