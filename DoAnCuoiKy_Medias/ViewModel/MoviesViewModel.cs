using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class MoviesViewModel : BaseViewModel
    {
        public bool IsMovies { get; set; }
        public ICommand LoadedMoviesWindowCommand { get; set; }
        public ICommand StatusCommand { get; set; }
        public ICommand VolumeCommand { get; set; }
        private Movies _Movies;
        public Movies Movies { get => _Movies; set { _Movies = value; OnPropertyChanged(); } }
        private string _MoviesStatus;
        public string MoviesStatus { get => _MoviesStatus; set { _MoviesStatus = value; OnPropertyChanged(); } }
        private double _MoviesVolume;
        public double MoviesVolume { get => _MoviesVolume; set { _MoviesVolume = value; OnPropertyChanged(); } }
        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        private string _Volume;
        public string Volume { get => _Volume; set { _Volume = value; OnPropertyChanged(); } }
        public ICommand VolumeChanged { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private List<Movies> _recommended;
        public List<Movies> recommended { get => _recommended; set { _recommended = value; OnPropertyChanged(); } }
        private List<Movies> _RecommendedList;
        public List<Movies> RecommendedList { get => _RecommendedList; set { _RecommendedList = value; OnPropertyChanged(); } }
        private List<Movies> _recommendedlist;
        public List<Movies> recommendedlist { get => _recommendedlist; set { _recommendedlist = value; OnPropertyChanged(); } }
        public ICommand PlayMovies { get; set; }
        private Movies _SelectedMovies;
        public Movies SelectedMovies { get => _SelectedMovies; set { _SelectedMovies = value; OnPropertyChanged(); } }
        public class PagingInfo
        {
            public int RowsPerPage { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public int TotalItems { get; set; }
        }
        PagingInfo _pagingInfo;
        int rowsPerPage;
        int currentIndex;
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        private string _MovieFullScreen;
        public string MovieFullScreen { get => _MovieFullScreen; set { _MovieFullScreen = value; OnPropertyChanged(); } }
        public ICommand FullScreenCommand { get; set; }
        private string _Screen;
        public string Screen { get => _Screen; set { _Screen = value; OnPropertyChanged(); } }
        private string _NameOfMovies;
        public string NameOfMovies { get => _NameOfMovies; set { _NameOfMovies = value; OnPropertyChanged(); } }
        private string _genresmoviesdisplay;
        public string genresmoviesdisplay { get => _genresmoviesdisplay; set { _genresmoviesdisplay = value; OnPropertyChanged(); } }
        private string _subgenresmoviesdisplay;
        public string subgenresmoviesdisplay { get => _subgenresmoviesdisplay; set { _subgenresmoviesdisplay = value; OnPropertyChanged(); } }
        private List<GenresMovies> _genresmovies;
        public List<GenresMovies> genresmovies { get => _genresmovies; set { _genresmovies = value; OnPropertyChanged(); } }
        private List<SubGenresMovies> _subgenresmovies;
        public List<SubGenresMovies> subgenresmovies { get => _subgenresmovies; set { _subgenresmovies = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }
        private string _Movie;
        public string Movie { get => _Movie; set { _Movie = value; OnPropertyChanged(); } }
        public ICommand Play { get; set; }
        public ICommand ControlCommand { get; set; }
        private string _IconControl;
        public string IconControl { get => _IconControl; set { _IconControl = value; OnPropertyChanged(); } }
        private int _HeightControl;
        public int HeightControl { get => _HeightControl; set { _HeightControl = value; OnPropertyChanged(); } }

        public MoviesViewModel()
        {
            LoadedMoviesWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsMovies = true;
                if (p == null)
                    return;
                genresmovies = new List<GenresMovies>();
                genresmovies = DataProvider.Ins.DB.GenresMovies.ToList();
                subgenresmovies = new List<SubGenresMovies>();
                subgenresmovies = DataProvider.Ins.DB.SubGenresMovies.ToList();
                UserWindow userWindow = new UserWindow();
                if (userWindow.DataContext == null)
                    return;
                var source = userWindow.DataContext as UserViewModel;
                Movies = source.SelectedMovies;
                Image = "Visible";
                Movie = "Collapsed";
                MoviesStatus = "Pause";
                MoviesVolume = 0;
                MovieFullScreen = "Hidden";
                genresmoviesdisplay = "";
                subgenresmoviesdisplay = "";
                IconControl = "MenuDown";
                HeightControl = 60;
                NameOfMovies = WordWrap(Movies.NameOfMovies);
                var g = genresmovies.Where(x => x.MoviesId == Movies.Id).Select(x => x.Genres).ToList();
                for (int i = 0; i < g.Count(); i++)
                {
                    genresmoviesdisplay += g[i].Name + ", ";
                }
                var sg = subgenresmovies.Where(x => x.MoviesId == Movies.Id).Select(x => x.SubGenres).ToList();
                for (int i = 0; i < sg.Count(); i++)
                {
                    if (i == sg.Count() - 1)
                        subgenresmoviesdisplay += sg[i].Name;
                    else
                        subgenresmoviesdisplay += sg[i].Name + ", ";
                }
                userWindow.Close();
                LoadedRecommended();
            });
            Play = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Image = "Collapsed";
                Movie = "Visible";
                MoviesStatus = "Play";
                MoviesVolume = 1;
                Status = "Pause";
                Volume = "VolumeHigh";
                MovieFullScreen = "Hidden";
                Screen = "Fullscreen";
            });
            StatusCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (MoviesStatus == "Play" && Status == "Pause")
                {
                    MoviesStatus = "Pause";
                    Status = "Play";
                }
                else
                {
                    MoviesStatus = "Play";
                    Status = "Pause";
                }
            });
            VolumeCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (MoviesVolume != 0 && Volume == "VolumeHigh")
                {
                    MoviesVolume = 0;
                    Volume = "VolumeOff";
                }
                else
                {
                    MoviesVolume = 1;
                    Volume = "VolumeHigh";
                }
            });
            VolumeChanged = new RelayCommand<Slider>((p) => { return true; }, (p) =>
            {
                MoviesVolume = p.Value;
                if (p.Value == 0)
                    Volume = "VolumeOff";
                else
                    Volume = "VolumeHigh";
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                IsMovies = false;
                p.Close();
            });
            RestoreCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                MoviesStatus = "Stop";
                MoviesStatus = "Play";
            });
            PlayMovies = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Movies = SelectedMovies;
                NameOfMovies = WordWrap(Movies.NameOfMovies);
                genresmoviesdisplay = "";
                var g = genresmovies.Where(x => x.MoviesId == Movies.Id).Select(x => x.Genres).ToList();
                for (int i = 0; i < g.Count(); i++)
                {
                    genresmoviesdisplay += g[i].Name + ", ";
                }
                subgenresmoviesdisplay = "";
                var sg = subgenresmovies.Where(x => x.MoviesId == Movies.Id).Select(x => x.SubGenres).ToList();
                for (int i = 0; i < sg.Count(); i++)
                {
                    if (i == sg.Count() - 1)
                        subgenresmoviesdisplay += sg[i].Name;
                    else
                        subgenresmoviesdisplay += sg[i].Name + ", ";
                }
                UserWindow userWindow = new UserWindow();
                if (userWindow.DataContext == null)
                    return;
                var user = userWindow.DataContext as UserViewModel;
                var profile = user.SelectedProfile;
                var newHistory = new HistoryList()
                {
                    ProfileId = profile.Id,
                    MoviesId = SelectedMovies.Id
                };
                DataProvider.Ins.DB.HistoryList.Add(newHistory);
                DataProvider.Ins.DB.SaveChanges();
                userWindow.Close();
                LoadedRecommended();
            });
            PreviousCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                    ChangeCurrentIndex();
                }
            });
            NextCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (currentIndex == _pagingInfo.TotalPages - 1)
                    return;
                if (currentIndex >= 0)
                {
                    currentIndex++;
                    ChangeCurrentIndex();
                }
            });
            FullScreenCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (Screen == "Fullscreen")
                {
                    MovieFullScreen = "Disabled";
                    Screen = "FullscreenExit";
                }
                else if (Screen == "FullscreenExit")
                {
                    MovieFullScreen = "Hidden";
                    Screen = "Fullscreen";
                }
            });
            ControlCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (IconControl == "MenuDown")
                {
                    IconControl = "MenuUp";
                    HeightControl = 0;
                }
                else if (IconControl == "MenuUp")
                {
                    IconControl = "MenuDown";
                    HeightControl = 60;
                }
                else
                    return;
            });
        }

        void Paging()
        {
            rowsPerPage = 7;
            currentIndex = 0;
            _pagingInfo = new PagingInfo()
            {
                RowsPerPage = rowsPerPage,
                TotalItems = recommendedlist.ToList().Count,
                TotalPages = recommendedlist.ToList().Count / rowsPerPage +
                    (((recommendedlist.ToList().Count % rowsPerPage) == 0) ? 0 : 1),
                CurrentPage = 1
            };
        }
        void ChangeCurrentIndex()
        {
            int nextPage = currentIndex + 1;
            _pagingInfo.CurrentPage = nextPage;
            var skip = (_pagingInfo.CurrentPage - 1) * _pagingInfo.RowsPerPage;
            var take = _pagingInfo.RowsPerPage;
            RecommendedList = recommendedlist.Skip(skip).Take(take).ToList();
        }
        void LoadedRecommended()
        {
            recommended = new List<Movies>();
            recommendedlist = new List<Movies>();
            RecommendedList = new List<Movies>();
            UserWindow userWindow = new UserWindow();
            if (userWindow.DataContext == null)
                return;
            var user = userWindow.DataContext as UserViewModel;
            recommended = user.allmovies.ToList();
            for (int i = 0; i < recommended.Count(); i++)
            {
                var subgenresrecommended = "";
                var sg = subgenresmovies.Where(x => x.MoviesId == recommended[i].Id).Select(x => x.SubGenres).ToList();
                for (int j = 0; j < sg.Count(); j++)
                {
                    if (j == sg.Count() - 1)
                        subgenresrecommended += sg[j].Name;
                    else
                        subgenresrecommended += sg[j].Name + ", ";
                }
                if (subgenresrecommended.ToLower().Contains(subgenresmoviesdisplay.ToLower()) && recommended[i].Id != Movies.Id)
                {
                    recommendedlist.Add(recommended[i]);
                }
            }
            Paging();
            ChangeCurrentIndex();
            userWindow.Close();
        }
        public string WordWrap(string text)
        {
            char[] charArr = text.ToCharArray();
            string newtext = "";
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i].ToString() == ":")
                {
                    newtext += charArr[i].ToString();
                    newtext += "\n";
                    i = i + 1;
                }
                else
                    newtext += charArr[i].ToString();
            }
            return newtext;
        }
    }
}
