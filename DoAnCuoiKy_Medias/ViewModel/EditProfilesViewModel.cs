using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class EditProfilesViewModel : BaseViewModel
    {
        public bool IsEdit { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand OpenFileImageCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteProfileCommand { get; set; }
        private Profiles _Profile;
        public Profiles Profile { get => _Profile; set { _Profile = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }

        public EditProfilesViewModel()
        {
            IsEdit = false;
            Name = "";
            Avatar = "";
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => 
            {
                if (p == null)
                    return;
                Name = "";
                Avatar = "";
                ManageProfilesWindow manageProfilesWindow = new ManageProfilesWindow();
                if (manageProfilesWindow.DataContext == null)
                    return;
                var manageprofiles = manageProfilesWindow.DataContext as ManageProfilesViewModel;
                Profile = new Profiles()
                {
                    Id = manageprofiles.SelectedItemProfiles.Id,
                    PFEmailId = manageprofiles.SelectedItemProfiles.PFEmailId,
                    Name = manageprofiles.SelectedItemProfiles.Name,
                    Avatar = manageprofiles.SelectedItemProfiles.Avatar
                };
                manageProfilesWindow.Close();
                Name = Profile.Name;
                Avatar = Profile.Avatar;
            });
            OpenFileImageCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "image file (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png;";
                if (openFileDialog.ShowDialog() == true)
                {
                    Profile.Avatar = openFileDialog.FileName;
                    Avatar = Profile.Avatar;
                }
            });
            SaveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsEdit = true;
                var profile = DataProvider.Ins.DB.Profiles.Where(x => x.Id == Profile.Id).SingleOrDefault();
                profile.Name = Name;
                profile.Avatar = Avatar;
                DataProvider.Ins.DB.SaveChanges();
                p.Close();
            });
            CancelCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsEdit = true;
                p.Close();
            });
            DeleteProfileCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsEdit = true;
                ManageProfilesWindow manageProfilesWindow = new ManageProfilesWindow();
                if (manageProfilesWindow.DataContext == null)
                    return;
                var manageprofiles = manageProfilesWindow.DataContext as ManageProfilesViewModel;
                DataProvider.Ins.DB.Profiles.Remove(manageprofiles.SelectedItemProfiles);
                DataProvider.Ins.DB.SaveChanges();
                manageProfilesWindow.Close();
                p.Close();
            });
        }
    }
}
