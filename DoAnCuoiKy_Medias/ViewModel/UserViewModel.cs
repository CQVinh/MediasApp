using DoAnCuoiKy_Medias.Model;
using DoAnCuoiKy_Medias.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public ICommand LoadedMainWindowCommand { get; set; }
        private List<Movies> _MoviesList;
        public List<Movies> MoviesList { get => _MoviesList; set { _MoviesList = value; OnPropertyChanged(); } }
        private Movies _SourceMain;
        public Movies SourceMain { get => _SourceMain; set { _SourceMain = value; OnPropertyChanged(); } }
        private List<Movies> _TrendingList;
        public List<Movies> TrendingList { get => _TrendingList; set { _TrendingList = value; OnPropertyChanged(); } }
        private List<Movies> _AllMoviesList;
        public List<Movies> AllMoviesList { get => _AllMoviesList; set { _AllMoviesList = value; OnPropertyChanged(); } }
        private List<Movies> _MyListMovies;
        public List<Movies> MyListMovies { get => _MyListMovies; set { _MyListMovies = value; OnPropertyChanged(); } }
        private List<Movies> _LikedMovies;
        public List<Movies> LikedMovies { get => _LikedMovies; set { _LikedMovies = value; OnPropertyChanged(); } }
        private List<Movies> _HistoryMovies;
        public List<Movies> HistoryMovies { get => _HistoryMovies; set { _HistoryMovies = value; OnPropertyChanged(); } }
        private List<Movies> _FilterListMovies;
        public List<Movies> FilterListMovies { get => _FilterListMovies; set { _FilterListMovies = value; OnPropertyChanged(); } }
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private List<Profiles> _ProfilesList;
        public List<Profiles> ProfilesList { get => _ProfilesList; set { _ProfilesList = value; OnPropertyChanged(); } }
        private List<Profiles> _profileslist;
        public List<Profiles> profileslist { get => _profileslist; set { _profileslist = value; OnPropertyChanged(); } }
        private Profiles _SelectedProfiles;
        public Profiles SelectedProfiles { get => _SelectedProfiles; set { _SelectedProfiles = value; OnPropertyChanged(); if (SelectedProfiles != null) { SelectedProfile = SelectedProfiles; LoadMyList(); LoadLikedMovies(); LoadHistoryMovies(); } else return; } }
        private Profiles _SelectedProfile;
        public Profiles SelectedProfile { get => _SelectedProfile; set { _SelectedProfile = value; OnPropertyChanged(); } }
        public class PagingInfo
        {
            public int RowsPerPage { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
            public int TotalItems { get; set; }
        }
        PagingInfo _pagingInfoAM;
        PagingInfo _pagingInfoTD;
        int rowsPerPage;
        int currentIndexAM;
        int currentIndexTD;
        public ICommand PreviousAMCommand { get; set; }
        public ICommand NextAMCommand { get; set; }
        public ICommand PreviousTDCommand { get; set; }
        public ICommand NextTDCommand { get; set; }
        private List<Movies> _allmovies;
        public List<Movies> allmovies { get => _allmovies; set { _allmovies = value; OnPropertyChanged(); } }
        private List<Movies> _trending;
        public List<Movies> trending { get => _trending; set { _trending = value; OnPropertyChanged(); } }
        private List<Movies> _mylistmovies;
        public List<Movies> mylistmovies { get => _mylistmovies; set { _mylistmovies = value; OnPropertyChanged(); } }
        private List<Movies> _likedmovies;
        public List<Movies> likedmovies { get => _likedmovies; set { _likedmovies = value; OnPropertyChanged(); } }
        private List<Movies> _historymovies;
        public List<Movies> historymovies { get => _historymovies; set { _historymovies = value; OnPropertyChanged(); } }
        private List<Playlist> _playlist;
        public List<Playlist> playlist { get => _playlist; set { _playlist = value; OnPropertyChanged(); } }
        private List<LikedList> _likedlist;
        public List<LikedList> likedlist { get => _likedlist; set { _likedlist = value; OnPropertyChanged(); } }
        private List<HistoryList> _historylist;
        public List<HistoryList> historylist { get => _historylist; set { _historylist = value; OnPropertyChanged(); } }

        private Account _AccountLogin;
        public Account AccountLogin { get => _AccountLogin; set { _AccountLogin = value; OnPropertyChanged(); } }
        public ICommand YourAccountCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        public ICommand MainSourceCommand { get; set; }
        private Movies _SelectedMovies;
        public Movies SelectedMovies { get => _SelectedMovies; set { _SelectedMovies = value; OnPropertyChanged(); } }

        public ICommand PlayMovies { get; set; }
        private Movies _SelectedItemAM;
        public Movies SelectedItemAM { get => _SelectedItemAM; set { _SelectedItemAM = value; OnPropertyChanged(); if (SelectedItemAM != null) { SelectedMovies = SelectedItemAM; } } }
        private Movies _SelectedItemTD;
        public Movies SelectedItemTD { get => _SelectedItemTD; set { _SelectedItemTD = value; OnPropertyChanged(); if (SelectedItemTD != null) { SelectedMovies = SelectedItemTD; } } }
        private Movies _SelectedItemML;
        public Movies SelectedItemML { get => _SelectedItemML; set { _SelectedItemML = value; OnPropertyChanged(); if (SelectedItemML != null) { SelectedMovies = SelectedItemML; } } }
        private Movies _SelectedItemLM;
        public Movies SelectedItemLM { get => _SelectedItemLM; set { _SelectedItemLM = value; OnPropertyChanged(); if (_SelectedItemLM != null) { SelectedMovies = _SelectedItemLM; } } }
        private Movies _SelectedItemHL;
        public Movies SelectedItemHL { get => _SelectedItemHL; set { _SelectedItemHL = value; OnPropertyChanged(); if (_SelectedItemHL != null) { SelectedMovies = _SelectedItemHL; } } }
        private Movies _SelectedItemFL;
        public Movies SelectedItemFL { get => _SelectedItemFL; set { _SelectedItemFL = value; OnPropertyChanged(); if (SelectedItemFL != null) { SelectedMovies = SelectedItemFL; } } }

        public ICommand NavBarCommand { get; set; }
        private string _NavBarButton;
        public string NavBarButton { get => _NavBarButton; set { _NavBarButton = value; OnPropertyChanged(); } }
        private string _NavBar;
        public string NavBar { get => _NavBar; set { _NavBar = value; OnPropertyChanged(); } }

        public ICommand HomeCommand { get; set; }
        public ICommand MyListCommand { get; set; }
        public ICommand LikedListCommand { get; set; }
        private string _Home;
        public string Home { get => _Home; set { _Home = value; OnPropertyChanged(); } }
        private string _MyList;
        public string MyList { get => _MyList; set { _MyList = value; OnPropertyChanged(); } }
        private string _LikedList;
        public string LikedList { get => _LikedList; set { _LikedList = value; OnPropertyChanged(); } }
        private string _HistoryList;
        public string HistoryList { get => _HistoryList; set { _HistoryList = value; OnPropertyChanged(); } }
        private string _FilterList;
        public string FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }

        private string _CBContent;
        public string CBContent { get => _CBContent; set { _CBContent = value; OnPropertyChanged(); } }
        private List<Genres> _Genres;
        public List<Genres> Genres { get => _Genres; set { _Genres = value; OnPropertyChanged(); } }
        private List<Genres> _genres;
        public List<Genres> genres { get => _genres; set { _genres = value; OnPropertyChanged(); } }
        public ICommand SearchMoviesCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }
        public ICommand RemoveSearchCommand { get; set; }
        public ICommand CBCommand { get; set; }
        private Genres _SelectedItemCB;
        public Genres SelectedItemCB { get => _SelectedItemCB; set { _SelectedItemCB = value; OnPropertyChanged(); if (_SelectedItemCB != null) { CBContent = _SelectedItemCB.Name; LoadedCBList(); } } }
        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }
        public ICommand MoreInfoCommand { get; set; }
        public ICommand MoreInfoMainCommand { get; set; }
        public ICommand AddMyListMainCommand { get; set; }
        public ICommand AddMyListCommand { get; set; }
        public ICommand RemoveMyListCommand { get; set; }
        public ICommand CloseMoreInfoCommand { get; set; }
        public ICommand ManageProfilesCommand { get; set; }
        private string _MoreInfoMain;
        public string MoreInfoMain { get => _MoreInfoMain; set { _MoreInfoMain = value; OnPropertyChanged(); } }
        private string _ShowMessage;
        public string ShowMessage { get => _ShowMessage; set { _ShowMessage = value; OnPropertyChanged(); } }
        public ICommand MessageBoxCommand { get; set; }
        private string _Message;
        public string Message { get => _Message; set { _Message = value; OnPropertyChanged(); } }
        public ICommand LikeCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public bool IsLike { get; set; }
        private string _Like;
        public string Like { get => _Like; set { _Like = value; OnPropertyChanged(); } }
        private string _VisibilityMedia;
        public string VisibilityMedia { get => _VisibilityMedia; set { _VisibilityMedia = value; OnPropertyChanged(); } }
        private string _PlayMoviesMain;
        public string PlayMoviesMain { get => _PlayMoviesMain; set { _PlayMoviesMain = value; OnPropertyChanged(); } }
        private string _VisibilityImage;
        public string VisibilityImage { get => _VisibilityImage; set { _VisibilityImage = value; OnPropertyChanged(); } }
        private int _VolumeMain;
        public int VolumeMain { get => _VolumeMain; set { _VolumeMain = value; OnPropertyChanged(); } }
        public ICommand VolumeMainCommand { get; set; }
        private string _VolumeIcon;
        public string VolumeIcon { get => _VolumeIcon; set { _VolumeIcon = value; OnPropertyChanged(); } }
        private string _NameOfMovies;
        public string NameOfMovies { get => _NameOfMovies; set { _NameOfMovies = value; OnPropertyChanged(); } }
        private string _NameOfMoviesMoreInfo;
        public string NameOfMoviesMoreInfo { get => _NameOfMoviesMoreInfo; set { _NameOfMoviesMoreInfo = value; OnPropertyChanged(); } }
        public ICommand MediaEndedCommand { get; set; }
        private string _genresmoviesmaindisplay;
        public string genresmoviesmaindisplay { get => _genresmoviesmaindisplay; set { _genresmoviesmaindisplay = value; OnPropertyChanged(); } }
        private string _genresmoviesdisplay;
        public string genresmoviesdisplay { get => _genresmoviesdisplay; set { _genresmoviesdisplay = value; OnPropertyChanged(); } }
        private string _subgenresmoviesmaindisplay;
        public string subgenresmoviesmaindisplay { get => _subgenresmoviesmaindisplay; set { _subgenresmoviesmaindisplay = value; OnPropertyChanged(); } }
        private string _subgenresmoviesdisplay;
        public string subgenresmoviesdisplay { get => _subgenresmoviesdisplay; set { _subgenresmoviesdisplay = value; OnPropertyChanged(); } }
        private List<GenresMovies> _genresmovies;
        public List<GenresMovies> genresmovies { get => _genresmovies; set { _genresmovies = value; OnPropertyChanged(); } }
        private List<SubGenresMovies> _subgenresmovies;
        public List<SubGenresMovies> subgenresmovies { get => _subgenresmovies; set { _subgenresmovies = value; OnPropertyChanged(); } }

        public UserViewModel()
        {
            NavBarButton = "Menu";
            NavBar = "Collapsed";
            Home = "Visible";
            MyList = "Collapsed";
            LikedList = "Collapsed";
            HistoryList = "Collapsed";
            FilterList = "Collapsed";
            MoreInfoMain = "Collapsed";
            ShowMessage = "Collapsed";
            VolumeIcon = "VolumeMute";
            VolumeMain = 0;
            Message = "";
            IsLike = false;
            MoviesList = new List<Movies>();
            allmovies = new List<Movies>();
            trending = new List<Movies>();
            mylistmovies = new List<Movies>();
            likedmovies = new List<Movies>();
            historymovies = new List<Movies>();
            playlist = new List<Playlist>();
            likedlist = new List<LikedList>();
            historylist = new List<HistoryList>();
            profileslist = new List<Profiles>();
            genres = new List<Genres>();
            genresmovies = new List<GenresMovies>();
            subgenresmovies = new List<SubGenresMovies>();
            MoviesList = DataProvider.Ins.DB.Movies.ToList();
            for (int i = 0; i < MoviesList.Count(); i++)
            {
                var newMovies = new Movies()
                {
                    Id = MoviesList[i].Id,
                    NameOfMovies = MoviesList[i].NameOfMovies,
                    Description = MoviesList[i].Description,
                    Image = MoviesList[i].Image,
                    Video = MoviesList[i].Video,
                    DateOfIssue = MoviesList[i].DateOfIssue,
                    Nation = MoviesList[i].Nation,
                    Rate = MoviesList[i].Rate,
                    Starring = MoviesList[i].Starring,
                    NameSearch = MoviesList[i].NameSearch,
                    Views = MoviesList[i].Views
                };
                allmovies.Add(newMovies);
            }
            trending = allmovies.Where(x => x.Id == 1 || x.Id == 2 || x.Id == 3 || x.Id == 4 || x.Id == 6 || x.Id == 8 || x.Id == 12 || x.Id == 13 || x.Id == 17 || x.Id == 19 || x.Id == 21 || x.Id == 22 || x.Id == 24 || x.Id == 27).ToList();
            playlist = DataProvider.Ins.DB.Playlist.ToList();
            likedlist = DataProvider.Ins.DB.LikedList.ToList();
            historylist = DataProvider.Ins.DB.HistoryList.ToList();
            genres = DataProvider.Ins.DB.Genres.ToList();
            genresmovies = DataProvider.Ins.DB.GenresMovies.ToList();
            subgenresmovies = DataProvider.Ins.DB.SubGenresMovies.ToList();
            LoadMovies(allmovies);
            Paging();
            ChangeCurrentIndexAM();
            ChangeCurrentIndexTD();
            LoadedMainWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoadedMain();
                NameOfMovies = WordWrap(SourceMain.NameOfMovies);
                LoadedMoviesMain();
            });
            PreviousAMCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (currentIndexAM > 0)
                {
                    currentIndexAM--;
                    ChangeCurrentIndexAM();
                }
            });
            NextAMCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (currentIndexAM == _pagingInfoAM.TotalPages - 1)
                    return;
                if (currentIndexAM >= 0)
                {
                    currentIndexAM++;
                    ChangeCurrentIndexAM();
                }
            });
            PreviousTDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (currentIndexTD > 0)
                {
                    currentIndexTD--;
                    ChangeCurrentIndexTD();
                }
            });
            NextTDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (currentIndexTD == _pagingInfoTD.TotalPages - 1)
                    return;
                if (currentIndexTD >= 0)
                {
                    currentIndexTD++;
                    ChangeCurrentIndexTD();
                }
            });
            SignOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                SelectedProfiles = null;
                p.Close();
            });
            YourAccountCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                PlayMoviesMain = "Stop";
                p.Hide();
                YourAccountWindow yourAccountWindow = new YourAccountWindow();
                yourAccountWindow.ShowDialog();
                if (yourAccountWindow.DataContext == null)
                    return;
                var youraccount = yourAccountWindow.DataContext as YourAccountViewModel;
                if (youraccount.IsSetting)
                {
                    LoadedMoviesMain();
                    LoadedProfilesList();
                    for (int i = 0; i < profileslist.Count(); i++)
                    {
                        if (profileslist[i].Id == SelectedProfile.Id)
                        {
                            SelectedProfile = profileslist[i];
                            break;
                        }
                    }
                    p.ShowDialog();
                }
                else
                {
                    p.Close();
                }
                yourAccountWindow.Close();
            });
            ManageProfilesCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                PlayMoviesMain = "Stop";
                p.Hide();
                ManageProfilesWindow manageProfilesWindow = new ManageProfilesWindow();
                manageProfilesWindow.ShowDialog();
                if (manageProfilesWindow.DataContext == null)
                    return;
                var manageprofiles = manageProfilesWindow.DataContext as ManageProfilesViewModel;
                if (manageprofiles.IsLoaded)
                {
                    LoadMyList();
                    LoadLikedMovies();
                    LoadHistoryMovies();
                    LoadedMoviesMain();
                    LoadedProfilesList();
                    for (int i = 0; i < profileslist.Count(); i++)
                    {
                        if (profileslist[i].Id == SelectedProfile.Id)
                        {
                            SelectedProfile = profileslist[i];
                            break;
                        }
                    }
                    p.ShowDialog();
                }
                else
                {
                    p.Close();
                }
                manageProfilesWindow.Close();
            });
            MainSourceCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                PlayMoviesMain = "Stop";
                SelectedMovies = SourceMain;
                var newHistory = new HistoryList()
                {
                    ProfileId = SelectedProfile.Id,
                    MoviesId = SelectedMovies.Id
                };
                DataProvider.Ins.DB.HistoryList.Add(newHistory);
                HistoryMovies.Add(SelectedMovies);
                HistoryMovies = HistoryMovies.ToList();
                SelectedMovies.Views = SelectedMovies.Views + 1;
                var setViews = DataProvider.Ins.DB.Movies.Where(x => x.Id == SelectedMovies.Id).SingleOrDefault();
                setViews.Views = SelectedMovies.Views;
                DataProvider.Ins.DB.SaveChanges();
                MoviesWindow moviesWindow = new MoviesWindow();
                moviesWindow.ShowDialog();
                if (moviesWindow.DataContext == null)
                    return;
                var movies = moviesWindow.DataContext as MoviesViewModel;
                if (movies.IsMovies == false)
                    LoadedMoviesMain();
            });
            PlayMovies = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                PlayMoviesMain = "Stop";
                var newHistory = new HistoryList()
                {
                    ProfileId = SelectedProfile.Id,
                    MoviesId = SelectedMovies.Id
                };
                DataProvider.Ins.DB.HistoryList.Add(newHistory);
                HistoryMovies.Add(SelectedMovies);
                HistoryMovies = HistoryMovies.ToList();
                SelectedMovies.Views = SelectedMovies.Views + 1;
                var setViews = DataProvider.Ins.DB.Movies.Where(x => x.Id == SelectedMovies.Id).SingleOrDefault();
                setViews.Views = SelectedMovies.Views;
                DataProvider.Ins.DB.SaveChanges();
                MoviesWindow moviesWindow = new MoviesWindow();
                moviesWindow.ShowDialog();
                if (moviesWindow.DataContext == null)
                    return;
                var movies = moviesWindow.DataContext as MoviesViewModel;
                if (movies.IsMovies == false)
                    LoadedMoviesMain();
                LoadHistoryMovies();
            });
            VolumeMainCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                if (VolumeMain == 1)
                {
                    VolumeIcon = "VolumeMute";
                    VolumeMain = 0;
                }
                else if (VolumeMain == 0)
                {
                    VolumeIcon = "VolumeHigh";
                    VolumeMain = 1;
                }
            });
            AddMyListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var check = DataProvider.Ins.DB.Playlist.Where(x => x.Id == SelectedMovies.Id).Count();
                if (check == 0)
                {
                    var newPlayList = new Playlist()
                    {
                        ProfileId = SelectedProfile.Id,
                        MoviesId = SelectedMovies.Id
                    };
                    DataProvider.Ins.DB.Playlist.Add(newPlayList);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadMyList();
                    MoreInfoMain = "Collapsed";
                    Message = "Successfully added the movie to My List";
                }
                else
                    Message = "This movies already exists on your list";
                ShowMessage = "Visible";
            });
            RemoveMyListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var pl = DataProvider.Ins.DB.Playlist.Where(x => x.ProfileId == SelectedProfile.Id).ToList();
                for (int i = 0; i < pl.Count(); i++)
                {
                    if (SelectedMovies.Id == pl[i].MoviesId)
                    {
                        DataProvider.Ins.DB.Playlist.Remove(pl[i]);
                        DataProvider.Ins.DB.SaveChanges();
                        break;
                    }
                }
                LoadMyList();
                Message = "Successfully removed the movie from My List";
                ShowMessage = "Visible";
            });
            MoreInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                NameOfMoviesMoreInfo = WordWrap(SelectedMovies.NameOfMovies);
                CheckLikedMovies();
                genresmoviesdisplay = "";
                var g = genresmovies.Where(x => x.MoviesId == SelectedMovies.Id).Select(x => x.Genres).ToList();
                for (int i = 0; i < g.Count(); i++)
                {
                    genresmoviesdisplay += g[i].Name + ", ";
                }
                subgenresmoviesdisplay = "";
                var sg = subgenresmovies.Where(x => x.MoviesId == SelectedMovies.Id).Select(x => x.SubGenres).ToList();
                for (int i = 0; i < sg.Count(); i++)
                {
                    if (i == sg.Count() - 1)
                        subgenresmoviesdisplay += sg[i].Name;
                    else
                        subgenresmoviesdisplay += sg[i].Name + ", ";
                }
                MoreInfoMain = "Visible";
            });
            AddMyListMainCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                var pl = DataProvider.Ins.DB.Playlist.ToList();
                SelectedMovies = SourceMain;
                var check = DataProvider.Ins.DB.Playlist.Where(x => x.Id == SelectedMovies.Id && x.ProfileId == SelectedProfile.Id).Count();
                if (check == 0)
                {
                    var newPlayList = new Playlist()
                    {
                        ProfileId = SelectedProfile.Id,
                        MoviesId = SelectedMovies.Id
                    };
                    DataProvider.Ins.DB.Playlist.Add(newPlayList);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadMyList();
                    MoreInfoMain = "Collapsed";
                    Message = "Successfully added the movie to My List";
                }
                else
                    Message = "This movies already exists on your list";
                ShowMessage = "Visible";
            });
            MoreInfoMainCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                SelectedMovies = SourceMain;
                NameOfMoviesMoreInfo = WordWrap(SelectedMovies.NameOfMovies);
                CheckLikedMovies();
                genresmoviesdisplay = "";
                genresmoviesdisplay = genresmoviesmaindisplay;
                subgenresmoviesdisplay = "";
                subgenresmoviesdisplay = subgenresmoviesmaindisplay;
                MoreInfoMain = "Visible";
            });
            CloseMoreInfoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                MoreInfoMain = "Collapsed";
            });
            NavBarCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (NavBarButton == "Menu")
                {
                    NavBarButton = "ArrowLeftBoldBox";
                    NavBar = "Visible";
                }
                else
                {
                    NavBarButton = "Menu";
                    NavBar = "Collapsed";
                }
            });
            HomeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Home = "Visible";
                MyList = "Collapsed";
                LikedList = "Collapsed";
                HistoryList = "Collapsed";
                FilterList = "Collapsed";
                CBContent = "Genres";
                Search = "";
            });
            MyListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                MyList = "Visible";
                LikedList = "Collapsed";
                HistoryList = "Collapsed";
                Home = "Collapsed";
                FilterList = "Collapsed";
                CBContent = "Genres";
                Search = "";
            });
            LikedListCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LikedList = "Visible";
                MyList = "Collapsed";
                HistoryList = "Collapsed";
                Home = "Collapsed";
                FilterList = "Collapsed";
                CBContent = "Genres";
                Search = "";
            });
            HistoryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                HistoryList = "Visible";
                LikedList = "Collapsed";
                MyList = "Collapsed";
                Home = "Collapsed";
                FilterList = "Collapsed";
                CBContent = "Genres";
                Search = "";
            });
            CBCommand = new RelayCommand<PopupBox>((p) => { return true; }, (p) =>
            {
                Home = "Collapsed";
                MyList = "Collapsed";
                HistoryList = "Collapsed";
                LikedList = "Collapsed";
                FilterList = "Visible";
                if (SelectedItemCB == null)
                    return;
                LoadedCBList();
            });
            RemoveSearchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Search = "";
            });
            TextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Search = p.Text;
            });
            SearchMoviesCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var query = from m in allmovies
                            where m.NameSearch.ToLower().Contains(Search.ToLower())
                            select m;
                Home = "Collapsed";
                MyList = "Collapsed";
                HistoryList = "Collapsed";
                LikedList = "Collapsed";
                FilterList = "Visible";
                FilterListMovies = query.ToList();
            });
            MessageBoxCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ShowMessage = "Collapsed";
            });
            MediaEndedCommand = new RelayCommand<MediaElement>((p) => { return true; }, (p) =>
            {
                LoadedMoviesMain();
            });
            LikeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var lk = DataProvider.Ins.DB.LikedList.Where(x => x.ProfileId == SelectedProfile.Id).ToList();
                var check = DataProvider.Ins.DB.LikedList.Where(x => x.Id == SelectedMovies.Id).Count();
                if (check == 0)
                {
                    if (Like == "Gray")
                    {
                        var newLikedMovies = new LikedList()
                        {
                            ProfileId = SelectedProfile.Id,
                            MoviesId = SelectedMovies.Id
                        };
                        DataProvider.Ins.DB.LikedList.Add(newLikedMovies);
                        DataProvider.Ins.DB.SaveChanges();
                        LoadLikedMovies();
                        Message = "Successfully added the movie to Liked Movies";
                        Like = "OrangeRed";
                    }
                    else if (Like == "OrangeRed")
                    {
                        for (int i = 0; i < lk.Count(); i++)
                        {
                            if (SelectedMovies.Id == lk[i].MoviesId)
                            {
                                DataProvider.Ins.DB.LikedList.Remove(lk[i]);
                                DataProvider.Ins.DB.SaveChanges();
                                break;
                            }
                        }
                        LoadLikedMovies();
                        Message = "Successfully removed the movie from Liked Movies";
                        Like = "Gray";
                    }
                    else
                        return;
                }
                else
                    Message = "This movies already exists on your list";
                ShowMessage = "Visible";
            });
        }
        void LoadedMain()
        {
            LoadedProfiles();
            LoadedProfilesList();
            LoadMyList();
            LoadLikedMovies();
            LoadHistoryMovies();
            SelectedProfiles = null;
            Random rnd = new Random();
            int index = rnd.Next(0, 39);
            SourceMain = allmovies[index];
            CBContent = "Genres";
            Genres = new List<Genres>();
            var allgenres = new Genres()
            {
                Name = "All Movies"
            };
            Genres.Add(allgenres);
            for (int i = 0; i < genres.Count(); i++)
            {
                var newgenres = new Genres()
                {
                    Id = genres[i].Id,
                    Name= genres[i].Name
                };
                Genres.Add(newgenres);
            }
            Genres = Genres.ToList();
            genresmoviesmaindisplay = "";
            var g = genresmovies.Where(x => x.MoviesId == SourceMain.Id).Select(x => x.Genres).ToList();
            for (int i = 0; i < g.Count(); i++)
            {
                genresmoviesmaindisplay += g[i].Name + ", ";
            }
            subgenresmoviesmaindisplay = "";
            var sg = subgenresmovies.Where(x => x.MoviesId == SourceMain.Id).Select(x => x.SubGenres).ToList();
            for (int i = 0; i < sg.Count(); i++)
            {
                if (i == sg.Count() - 1)
                    subgenresmoviesmaindisplay += sg[i].Name;
                else
                    subgenresmoviesmaindisplay += sg[i].Name + ", ";
            }
        }
        void LoadMovies(List<Movies> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Video = projectDirectory + "/Data/" + "Videos/" + list[i].Video;
                list[i].Image = projectDirectory + "/Data/" + "Images/" + list[i].Image;
            }
        }
        void LoadedProfiles()
        {
            ChooseProfilesWindow chooseProfilesWindow = new ChooseProfilesWindow();
            if (chooseProfilesWindow == null)
                return;
            var chooseprofiles = chooseProfilesWindow.DataContext as ChooseProfilesViewModel;
            SelectedProfile = chooseprofiles.SelectedItemProfiles;
            chooseProfilesWindow.Close();
        }
        void LoadedProfilesList()
        {
            profileslist = DataProvider.Ins.DB.Profiles.ToList();
            ChooseProfilesWindow chooseProfilesWindow = new ChooseProfilesWindow();
            if (chooseProfilesWindow.DataContext == null)
                return;
            var chooseprofiles = chooseProfilesWindow.DataContext as ChooseProfilesViewModel;
            var query = from pf in profileslist
                        where pf.PFEmailId == chooseprofiles.AccountLogin.Id
                        select pf;
            ProfilesList = new List<Profiles>();
            ProfilesList = query.ToList();
            chooseProfilesWindow.Close();
        }
        void LoadMyList()
        {
            var mylist = DataProvider.Ins.DB.Playlist.ToList();
            var query = from pl in mylist
                        where pl.ProfileId == SelectedProfile.Id
                        select pl;
            mylistmovies = query.Select(x => x.Movies).ToList();
            MyListMovies = new List<Movies>();
            for (int i = 0; i < mylistmovies.Count(); i++)
            {
                var newMovies = new Movies()
                {
                    Id = mylistmovies[i].Id,
                    NameOfMovies = mylistmovies[i].NameOfMovies,
                    Description = mylistmovies[i].Description,
                    Image = mylistmovies[i].Image,
                    Video = mylistmovies[i].Video,
                    DateOfIssue = mylistmovies[i].DateOfIssue,
                    Nation = mylistmovies[i].Nation,
                    Rate = mylistmovies[i].Rate,
                    Starring = mylistmovies[i].Starring,
                    NameSearch = mylistmovies[i].NameSearch,
                    Views = mylistmovies[i].Views
                };
                MyListMovies.Add(newMovies);
            }
            LoadMovies(MyListMovies);
            MyListMovies = MyListMovies.ToList();
        }
        void LoadLikedMovies()
        {
            var like = DataProvider.Ins.DB.LikedList.ToList();
            var query = from pl in like
                        where pl.ProfileId == SelectedProfile.Id
                        select pl;
            likedmovies = query.Select(x => x.Movies).ToList();
            LikedMovies = new List<Movies>();
            for (int i = 0; i < likedmovies.Count(); i++)
            {
                var newMovies = new Movies()
                {
                    Id = likedmovies[i].Id,
                    NameOfMovies = likedmovies[i].NameOfMovies,
                    Description = likedmovies[i].Description,
                    Image = likedmovies[i].Image,
                    Video = likedmovies[i].Video,
                    DateOfIssue = likedmovies[i].DateOfIssue,
                    Nation = likedmovies[i].Nation,
                    Rate = likedmovies[i].Rate,
                    Starring = likedmovies[i].Starring,
                    NameSearch = likedmovies[i].NameSearch,
                    Views = likedmovies[i].Views
                };
                LikedMovies.Add(newMovies);
            }
            LoadMovies(LikedMovies);
            LikedMovies = LikedMovies.ToList();
        }
        void LoadHistoryMovies()
        {
            var history = DataProvider.Ins.DB.HistoryList.ToList();
            var query = from hl in history
                        where hl.ProfileId == SelectedProfile.Id
                        select hl;
            historymovies = query.Select(x => x.Movies).ToList();
            HistoryMovies = new List<Movies>();
            for (int i = 0; i < historymovies.Count(); i++)
            {
                var newMovies = new Movies()
                {
                    Id = historymovies[i].Id,
                    NameOfMovies = historymovies[i].NameOfMovies,
                    Description = historymovies[i].Description,
                    Image = historymovies[i].Image,
                    Video = historymovies[i].Video,
                    DateOfIssue = historymovies[i].DateOfIssue,
                    Nation = historymovies[i].Nation,
                    Rate = historymovies[i].Rate,
                    Starring = historymovies[i].Starring,
                    NameSearch = historymovies[i].NameSearch,
                    Views = historymovies[i].Views
                };
                HistoryMovies.Add(newMovies);
            }
            LoadMovies(HistoryMovies);
            HistoryMovies = HistoryMovies.ToList();
        }
        void Paging()
        {
            rowsPerPage = 7;
            currentIndexAM = 0;
            currentIndexTD = 0;
            _pagingInfoAM = new PagingInfo()
            {
                RowsPerPage = rowsPerPage,
                TotalItems = allmovies.ToList().Count,
                TotalPages = allmovies.ToList().Count / rowsPerPage +
                    (((allmovies.ToList().Count % rowsPerPage) == 0) ? 0 : 1),
                CurrentPage = 1
            };
            _pagingInfoTD = new PagingInfo()
            {
                RowsPerPage = rowsPerPage,
                TotalItems = trending.ToList().Count,
                TotalPages = trending.ToList().Count / rowsPerPage +
                    (((trending.ToList().Count % rowsPerPage) == 0) ? 0 : 1),
                CurrentPage = 1
            };
        }
        void ChangeCurrentIndexAM()
        {
            int nextPage = currentIndexAM + 1;
            _pagingInfoAM.CurrentPage = nextPage;
            var skip = (_pagingInfoAM.CurrentPage - 1) * _pagingInfoAM.RowsPerPage;
            var take = _pagingInfoAM.RowsPerPage;
            AllMoviesList = allmovies.Skip(skip).Take(take).ToList();
        }

        void ChangeCurrentIndexTD()
        {
            int nextPage = currentIndexTD + 1;
            _pagingInfoTD.CurrentPage = nextPage;
            var skip = (_pagingInfoTD.CurrentPage - 1) * _pagingInfoTD.RowsPerPage;
            var take = _pagingInfoTD.RowsPerPage;
            TrendingList = trending.Skip(skip).Take(take).ToList();
        }

        void LoadedCBList()
        {
            if (SelectedItemCB.Name == "All Movies")
            {
                FilterListMovies = allmovies.ToList();
            }
            else
            {
                var genresmovieslist = DataProvider.Ins.DB.GenresMovies.Where(x => x.GenresId == SelectedItemCB.Id).Select(x => x.Movies).ToList();
                FilterListMovies = new List<Movies>();
                for (int i = 0; i < genresmovieslist.Count(); i++)
                {
                    var newMovies = new Movies()
                    {
                        Id = genresmovieslist[i].Id,
                        NameOfMovies = genresmovieslist[i].NameOfMovies,
                        Description = genresmovieslist[i].Description,
                        Image = genresmovieslist[i].Image,
                        Video = genresmovieslist[i].Video,
                        DateOfIssue = genresmovieslist[i].DateOfIssue,
                        Nation = genresmovieslist[i].Nation,
                        Rate = genresmovieslist[i].Rate,
                        Starring = genresmovieslist[i].Starring,
                        NameSearch = genresmovieslist[i].NameSearch,
                        Views = genresmovieslist[i].Views
                    };
                    FilterListMovies.Add(newMovies);
                }
                LoadMovies(FilterListMovies);
                FilterListMovies = FilterListMovies.ToList();
            }
        }
        void CheckLikedMovies()
        {
            var query = DataProvider.Ins.DB.LikedList.Where(x => x.ProfileId == SelectedProfile.Id && x.MoviesId == SelectedMovies.Id).Count();
            if (query > 0)
                Like = "OrangeRed";
            else 
                Like = "Gray";
        }

        async void LoadedMoviesMain()
        {
            PlayMoviesMain = "Stop";
            VisibilityImage = "Visible";
            VisibilityMedia = "Collapsed";
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(3000);
            });
            VisibilityImage = "Collapsed";
            VisibilityMedia = "Visible";
            PlayMoviesMain = "Play";
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
