using DoAnCuoiKy_Medias.Model;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DoAnCuoiKy_Medias.ViewModel
{
    public class AdminDashboardViewModel : BaseViewModel
    {
        bool CheckEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        bool IsNumber(string num)
        {
            return Regex.IsMatch(num, @"\d");
        }
        private string _VisibilityUser;
        public string VisibilityUser { get => _VisibilityUser; set { _VisibilityUser = value; OnPropertyChanged(); } }
        private string _VisibilityMovies;
        public string VisibilityMovies { get => _VisibilityMovies; set { _VisibilityMovies = value; OnPropertyChanged(); } }
        private string _VisibilityGenres;
        public string VisibilityGenres { get => _VisibilityGenres; set { _VisibilityGenres = value; OnPropertyChanged(); } }
        private string _VisibilityDashboard;
        public string VisibilityDashboard { get => _VisibilityDashboard; set { _VisibilityDashboard = value; OnPropertyChanged(); } }
        private string _VisibilityUserControl;
        public string VisibilityUserControl { get => _VisibilityUserControl; set { _VisibilityUserControl = value; OnPropertyChanged(); } }
        private string _VisibilityMoviesControl;
        public string VisibilityMoviesControl { get => _VisibilityMoviesControl; set { _VisibilityMoviesControl = value; OnPropertyChanged(); } }
        private string _VisibilityGenresControl;
        public string VisibilityGenresControl { get => _VisibilityGenresControl; set { _VisibilityGenresControl = value; OnPropertyChanged(); } }
        private string _VisibilityChangeGenres;
        public string VisibilityChangeGenres { get => _VisibilityChangeGenres; set { _VisibilityChangeGenres = value; OnPropertyChanged(); } }
        private string _VisibilityChangeSubGenres;
        public string VisibilityChangeSubGenres { get => _VisibilityChangeSubGenres; set { _VisibilityChangeSubGenres = value; OnPropertyChanged(); } }
        private string _VisibilityStatistical;
        public string VisibilityStatistical { get => _VisibilityStatistical; set { _VisibilityStatistical = value; OnPropertyChanged(); } }

        public ICommand LoadedCommand { get; set; }
        public ICommand DashboardCommand { get; set; }
        public ICommand UserListCommand { get; set; }
        public ICommand MoviesListCommand { get; set; }
        public ICommand GenresListCommand { get; set; }
        public ICommand StatisticalCommand { get; set; }
        public ICommand UserControlCommand { get; set; }
        public ICommand MoviesControlCommand { get; set; }
        public ICommand GenresControlCommand { get; set; }

        private List<Account> _AccountList;
        public List<Account> AccountList { get => _AccountList; set { _AccountList = value; OnPropertyChanged(); } }
        private List<Movies> _MoviesList;
        public List<Movies> MoviesList { get => _MoviesList; set { _MoviesList = value; OnPropertyChanged(); } }
        private List<Genres> _GenresList;
        public List<Genres> GenresList { get => _GenresList; set { _GenresList = value; OnPropertyChanged(); } }
        private List<SubGenres> _SubGenresList;
        public List<SubGenres> SubGenresList { get => _SubGenresList; set { _SubGenresList = value; OnPropertyChanged(); } }
        private List<Plan> _PlanList;
        public List<Plan> PlanList { get => _PlanList; set { _PlanList = value; OnPropertyChanged(); } }

        private Account _SelectedAccount;
        public Account SelectedAccount { get => _SelectedAccount; set { _SelectedAccount = value; OnPropertyChanged();
                if (SelectedAccount != null)
                {
                    Email = SelectedAccount.Email;
                    Password = SelectedAccount.Password;
                    SelectedPlan = SelectedAccount.Plan;
                }
            } }
        private Movies _SelectedMovies;
        public Movies SelectedMovies { get => _SelectedMovies; set { _SelectedMovies = value; OnPropertyChanged();
                if (SelectedMovies != null)
                {
                    NameOfMovies = SelectedMovies.NameOfMovies;
                    Genres = "";
                    SubGenres = "";
                    Description = SelectedMovies.Description;
                    DateOfIssue = SelectedMovies.DateOfIssue.ToString();
                    Nation = SelectedMovies.Nation;
                    Starring = SelectedMovies.Starring;
                    Rate = SelectedMovies.Rate.ToString();
                    Views = SelectedMovies.Views.ToString();
                    Image = SelectedMovies.Image;
                    Video = SelectedMovies.Video;
                    WatchImage = projectDirectory + "/Data/" + "Images/" + Image;
                    WatchVideo = projectDirectory + "/Data/" + "Videos/" + Video;
                    NameSearch = SelectedMovies.NameSearch;
                    GenresMovieList = new List<Genres>();
                    var genresmovieslist = SelectedMovies.GenresMovies.ToList();
                    for (int i = 0; i < genresmovieslist.Count(); i++)
                    {
                        var newGenres = new Genres()
                        {
                            Id = genresmovieslist[i].Genres.Id,
                            Name = genresmovieslist[i].Genres.Name
                        };
                        GenresMovieList.Add(newGenres);
                    }
                    GenresMovieList = GenresMovieList.ToList();
                    SubGenresMovieList = new List<SubGenres>();
                    var subgenresmovieslist = SelectedMovies.SubGenresMovies.ToList();
                    for (int i = 0; i < subgenresmovieslist.Count(); i++)
                    {
                        var newSubGenres = new SubGenres()
                        {
                            Id = subgenresmovieslist[i].SubGenres.Id,
                            Name = subgenresmovieslist[i].SubGenres.Name
                        };
                        SubGenresMovieList.Add(newSubGenres);
                    }
                    SubGenresMovieList = SubGenresMovieList.ToList();
                }
            } }
        private Genres _SelectedGenres;
        public Genres SelectedGenres { get => _SelectedGenres; set { _SelectedGenres = value; OnPropertyChanged(); if (SelectedGenres != null) GenresName = SelectedGenres.Name; } }
        private SubGenres _SelectedSubGenres;
        public SubGenres SelectedSubGenres { get => _SelectedSubGenres; set { _SelectedSubGenres = value; OnPropertyChanged(); if (SelectedSubGenres != null) SubGenresName = SelectedSubGenres.Name; } }
        private Plan _SelectedPlan;
        public Plan SelectedPlan { get => _SelectedPlan; set { _SelectedPlan = value; OnPropertyChanged(); } }

        public ICommand AddUserCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand AddMoviesCommand { get; set; }
        public ICommand EditMoviesCommand { get; set; }
        public ICommand DeleteMoviesCommand { get; set; }
        public ICommand AddGenresCommand { get; set; }
        public ICommand EditGenresCommand { get; set; }
        public ICommand DeleteGenresCommand { get; set; }
        public ICommand AddSubGenresCommand { get; set; }
        public ICommand EditSubGenresCommand { get; set; }
        public ICommand DeleteSubGenresCommand { get; set; }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _NameOfMovies;
        public string NameOfMovies { get => _NameOfMovies; set { _NameOfMovies = value; OnPropertyChanged(); } }
        private string _Genres;
        public string Genres { get => _Genres; set { _Genres = value; OnPropertyChanged(); } }
        private string _SubGenres;
        public string SubGenres { get => _SubGenres; set { _SubGenres = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }
        private string _DateOfIssue;
        public string DateOfIssue { get => _DateOfIssue; set { _DateOfIssue = value; OnPropertyChanged(); } }
        private string _Nation;
        public string Nation { get => _Nation; set { _Nation = value; OnPropertyChanged(); } }
        private string _Starring;
        public string Starring { get => _Starring; set { _Starring = value; OnPropertyChanged(); } }
        private string _Rate;
        public string Rate { get => _Rate; set { _Rate = value; OnPropertyChanged(); } }
        private string _Views;
        public string Views { get => _Views; set { _Views = value; OnPropertyChanged(); } }
        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }
        private string _Video;
        public string Video { get => _Video; set { _Video = value; OnPropertyChanged(); } }
        private string _NameSearch;
        public string NameSearch { get => _NameSearch; set { _NameSearch = value; OnPropertyChanged(); } }
        private string _WatchImage;
        public string WatchImage { get => _WatchImage; set { _WatchImage = value; OnPropertyChanged(); } }
        private string _WatchVideo;
        public string WatchVideo { get => _WatchVideo; set { _WatchVideo = value; OnPropertyChanged(); } }

        private string _GenresName;
        public string GenresName { get => _GenresName; set { _GenresName = value; OnPropertyChanged(); } }
        private string _SubGenresName;
        public string SubGenresName { get => _SubGenresName; set { _SubGenresName = value; OnPropertyChanged(); } }

        public ICommand UserTextChangedCommand { get; set; }
        public ICommand MoviesTextChangedCommand { get; set; }

        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public ICommand BrowseImageCommand { get; set; }
        public ICommand BrowseVideoCommand { get; set; }
        public ICommand ChangeGenresCommand { get; set; }
        public ICommand ChangeSubGenresCommand { get; set; }
        private List<Genres> _GenresMovieList;
        public List<Genres> GenresMovieList { get => _GenresMovieList; set { _GenresMovieList = value; OnPropertyChanged(); } }
        private List<SubGenres> _SubGenresMovieList;
        public List<SubGenres> SubGenresMovieList { get => _SubGenresMovieList; set { _SubGenresMovieList = value; OnPropertyChanged(); } }
        private Genres _SelectedGenresMovie;
        public Genres SelectedGenresMovie { get => _SelectedGenresMovie; set { _SelectedGenresMovie = value; OnPropertyChanged(); } }
        private SubGenres _SelectedSubGenresMovie;
        public SubGenres SelectedSubGenresMovie { get => _SelectedSubGenresMovie; set { _SelectedSubGenresMovie = value; OnPropertyChanged(); } }
        public ICommand GenresToGenresMovieCommand { get; set; }
        public ICommand RemoveGenresMovieCommand { get; set; }
        public ICommand SubGenresToSubGenresMovieCommand { get; set; }
        public ICommand RemoveSubGenresMovieCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveGenresMovieCommand { get; set; }
        public ICommand SaveSubGenresMovieCommand { get; set; }
        public ICommand SignOutCommand { get; set; }
        private List<Movies> _RankedListMovies;
        public List<Movies> RankedListMovies { get => _RankedListMovies; set { _RankedListMovies = value; OnPropertyChanged(); } }
        private List<PaymentHistory> _PaymentHistoryList;
        public List<PaymentHistory> PaymentHistoryList { get => _PaymentHistoryList; set { _PaymentHistoryList = value; OnPropertyChanged(); } }
        private int _TotalIncome;
        public int TotalIncome { get => _TotalIncome; set { _TotalIncome = value; OnPropertyChanged(); } }
        public ICommand ViewCommand { get; set; }
        private DateTime _SelectedFromDate;
        public DateTime SelectedFromDate { get => _SelectedFromDate; set { _SelectedFromDate = value; OnPropertyChanged(); } }
        private DateTime _SelectedToDate;
        public DateTime SelectedToDate { get => _SelectedToDate; set { _SelectedToDate = value; OnPropertyChanged(); } }
        private List<Movies> _StatisticalMovies;
        public List<Movies> StatisticalMovies { get => _StatisticalMovies; set { _StatisticalMovies = value; OnPropertyChanged(); } }
        private List<Genres> _StatisticalGenresMovies;
        public List<Genres> StatisticalGenresMovies { get => _StatisticalGenresMovies; set { _StatisticalGenresMovies = value; OnPropertyChanged(); } }
        private List<SubGenres> _StatisticalSubGenresMovies;
        public List<SubGenres> StatisticalSubGenresMovies { get => _StatisticalSubGenresMovies; set { _StatisticalSubGenresMovies = value; OnPropertyChanged(); } }
        private Genres _SelectedStatisticalGenres;
        public Genres SelectedStatisticalGenres { get => _SelectedStatisticalGenres; set { _SelectedStatisticalGenres = value; OnPropertyChanged(); } }
        private SubGenres _SelectedStatisticalSubGenres;
        public SubGenres SelectedStatisticalSubGenres { get => _SelectedStatisticalSubGenres; set { _SelectedStatisticalSubGenres = value; OnPropertyChanged(); } }
        public ICommand SelectedCommand { get; set; }
        public ICommand YearTextChangedCommand { get; set; }
        public ICommand RatingTextChangedCommand { get; set; }
        private string _Year;
        public string Year { get => _Year; set { _Year = value; OnPropertyChanged(); } }
        private string _Rating;
        public string Rating { get => _Rating; set { _Rating = value; OnPropertyChanged(); } }
        private int _TotalMovies;
        public int TotalMovies { get => _TotalMovies; set { _TotalMovies = value; OnPropertyChanged(); } }
        private List<GenresMovies> _GenresMoviesList;
        public List<GenresMovies> GenresMoviesList { get => _GenresMoviesList; set { _GenresMoviesList = value; OnPropertyChanged(); } }
        private List<SubGenresMovies> _SubGenresMoviesList;
        public List<SubGenresMovies> SubGenresMoviesList { get => _SubGenresMoviesList; set { _SubGenresMoviesList = value; OnPropertyChanged(); } }
        private SeriesCollection _PieChartSeries1;
        public SeriesCollection PieChartSeries1 { get => _PieChartSeries1; set { _PieChartSeries1 = value; OnPropertyChanged(); } }
        private SeriesCollection _PieChartSeries2;
        public SeriesCollection PieChartSeries2 { get => _PieChartSeries2; set { _PieChartSeries2 = value; OnPropertyChanged(); } }
        private SeriesCollection _CartesianChartSeries;
        public SeriesCollection CartesianChartSeries { get => _CartesianChartSeries; set { _CartesianChartSeries = value; OnPropertyChanged(); } }
        private string[] _Labels;
        public string[] Labels { get => _Labels; set { _Labels = value; OnPropertyChanged(); } }

        public AdminDashboardViewModel()
        {
            Email = "";
            Password = "";
            NameOfMovies = "";
            Genres = "";
            SubGenres = "";
            Description = "";
            DateOfIssue = "";
            Nation = "";
            Starring = "";
            Rate = "";
            Views = "";
            Image = "";
            Video = "";
            WatchImage = "";
            WatchVideo = "";
            NameSearch = "";
            GenresName = "";
            SubGenresName = "";
            TotalIncome = 0;
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => 
            {
                VisibilityDashboard = "Visible";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
                PlanList = DataProvider.Ins.DB.Plan.ToList();
                GenresMovieList = new List<Genres>();
                SubGenresMovieList = new List<SubGenres>();
                LoadData();
            });
            DashboardCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Visible";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
            });
            UserListCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Visible";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
                AccountList = DataProvider.Ins.DB.Account.ToList();
            });
            MoviesListCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Visible";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
                MoviesList = DataProvider.Ins.DB.Movies.ToList();
            });
            GenresListCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Visible";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
            });
            StatisticalCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Visible";
            });
            UserControlCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Visible";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
                AccountList = DataProvider.Ins.DB.Account.ToList();
            });
            MoviesControlCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Visible";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
                MoviesList = DataProvider.Ins.DB.Movies.ToList();
            });
            GenresControlCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Visible";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                VisibilityStatistical = "Collapsed";
            });
            UserTextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                AccountList = DataProvider.Ins.DB.Account.ToList();
                AccountList = AccountList.Where(x=>x.Email.ToLower().Contains(p.Text.ToLower())).ToList();
            });
            MoviesTextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                MoviesList = DataProvider.Ins.DB.Movies.ToList();
                MoviesList = MoviesList.Where(x=>x.NameSearch.ToLower().Contains(p.Text.ToLower())).ToList();
            });
            BrowseImageCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Image = "";
                WatchImage = "";
                string sourceFile = "";
                string destinationFile = projectDirectory + "/Data/Images/";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "image file (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png;";
                if (openFileDialog.ShowDialog() == true)
                {
                    Image = openFileDialog.SafeFileName;
                    WatchImage = projectDirectory + "/Data/" + "Images/" + Image;
                    sourceFile = openFileDialog.FileName;
                    destinationFile += Image;
                }
                if (File.Exists(destinationFile))
                {
                    return;
                }
                else
                {
                    try
                    {
                        File.Copy(sourceFile, destinationFile, true);
                    }
                    catch (IOException iox) { }
                }
            });
            BrowseVideoCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Video = "";
                WatchVideo = "";
                string sourceFile = "";
                string destinationFile = projectDirectory + "/Data/Videos/";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "video file (*.avi, *.flv, *.wmv, *.mov, *.mp4) | *.avi; *.flv; *.wmv; *.mov; *.mp4;";
                if (openFileDialog.ShowDialog() == true)
                {
                    Video = openFileDialog.SafeFileName;
                    WatchVideo = projectDirectory + "/Data/" + "Images/" + Video;
                    sourceFile = openFileDialog.FileName;
                    destinationFile += Video;
                }
                if (File.Exists(destinationFile))
                {
                    return;
                }
                else
                {
                    try
                    {
                        File.Copy(sourceFile, destinationFile, true);
                    }
                    catch (IOException iox) { }
                }
            });
            AddUserCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || SelectedPlan == null || CheckEmail(Email) == false || Password.Length < 4 || Password.Length > 60)
                    return false;
                var checkemail = DataProvider.Ins.DB.Account.Where(x => x.Email == Email).Count();
                if (checkemail > 0)
                    return false;
                return true;
            }, (p) =>
            {
                var newAccount = new Account()
                {
                    Email = Email,
                    Password = Password,
                    UserPlan = SelectedPlan.Id,
                    Role = "user"
                };
                DataProvider.Ins.DB.Account.Add(newAccount);
                DataProvider.Ins.DB.SaveChanges();
                LoadData();
            });
            EditUserCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || SelectedPlan == null || CheckEmail(Email) == false || Password.Length < 4 || Password.Length > 60)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedAccount != null)
                {
                    var account = DataProvider.Ins.DB.Account.Where(x => x.Id == SelectedAccount.Id).SingleOrDefault();
                    account.Email = Email;
                    account.Password = Password;
                    account.UserPlan = SelectedPlan.Id;
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            DeleteUserCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedAccount == null)
                    return false;
                return true; 
            }, (p) =>
            {
                if (SelectedAccount != null)
                {
                    var account = DataProvider.Ins.DB.Account.Where(x => x.Id == SelectedAccount.Id).SingleOrDefault();
                    DataProvider.Ins.DB.Account.Remove(account);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            AddGenresCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(GenresName) || string.IsNullOrWhiteSpace(GenresName))
                    return false;
                return true; 
            }, (p) =>
            {
                var newGenres = new Genres()
                {
                    Name = GenresName
                };
                DataProvider.Ins.DB.Genres.Add(newGenres);
                DataProvider.Ins.DB.SaveChanges();
                LoadData();
            });
            EditGenresCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(GenresName) || string.IsNullOrWhiteSpace(GenresName))
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedGenres != null)
                {
                    var genres = DataProvider.Ins.DB.Genres.Where(x => x.Id == SelectedGenres.Id).SingleOrDefault();
                    genres.Name = GenresName;
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            DeleteGenresCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedGenres == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedGenres != null)
                {
                    var genres = DataProvider.Ins.DB.Genres.Where(x => x.Id == SelectedGenres.Id).SingleOrDefault();
                    DataProvider.Ins.DB.Genres.Remove(genres);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            AddSubGenresCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(SubGenresName) || string.IsNullOrWhiteSpace(SubGenresName))
                    return false;
                return true;
            }, (p) =>
            {
                var newSubGenres = new SubGenres()
                {
                    Name = SubGenresName
                };
                DataProvider.Ins.DB.SubGenres.Add(newSubGenres);
                DataProvider.Ins.DB.SaveChanges();
                LoadData();
            });
            EditSubGenresCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(SubGenresName) || string.IsNullOrWhiteSpace(SubGenresName))
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedSubGenres != null)
                {
                    var subgenres = DataProvider.Ins.DB.SubGenres.Where(x => x.Id == SelectedSubGenres.Id).SingleOrDefault();
                    subgenres.Name = SubGenresName;
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            DeleteSubGenresCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedSubGenres == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedSubGenres != null)
                {
                    var subgenres = DataProvider.Ins.DB.SubGenres.Where(x => x.Id == SelectedSubGenres.Id).SingleOrDefault();
                    DataProvider.Ins.DB.SubGenres.Remove(subgenres);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            AddMoviesCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(NameOfMovies) || string.IsNullOrWhiteSpace(NameOfMovies)
                || string.IsNullOrEmpty(Description) || string.IsNullOrWhiteSpace(Description)
                || string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image)
                || string.IsNullOrEmpty(Video) || string.IsNullOrWhiteSpace(Video)
                || string.IsNullOrEmpty(DateOfIssue.ToString()) || string.IsNullOrWhiteSpace(DateOfIssue.ToString()) || IsNumber(DateOfIssue.ToString()) == false
                || string.IsNullOrEmpty(Nation) || string.IsNullOrWhiteSpace(Nation)
                || string.IsNullOrEmpty(Rate.ToString()) || string.IsNullOrWhiteSpace(Rate.ToString()) || IsNumber(Rate.ToString()) == false
                || string.IsNullOrEmpty(Starring) || string.IsNullOrWhiteSpace(Starring)
                || string.IsNullOrEmpty(NameSearch) || string.IsNullOrWhiteSpace(NameSearch)
                || string.IsNullOrEmpty(Views.ToString()) || string.IsNullOrWhiteSpace(Views.ToString()) || IsNumber(Views.ToString()) == false)
                    return false;
                return true; 
            }, (p) =>
            {
                var newMovie = new Movies()
                {
                    NameOfMovies = NameOfMovies,
                    Description = Description,
                    Image = Image,
                    Video = Video,
                    DateOfIssue = int.Parse(DateOfIssue),
                    Nation = Nation,
                    Rate = int.Parse(Rate),
                    Starring = Starring,
                    NameSearch = NameSearch,
                    Views = int.Parse(Views)
                };
                DataProvider.Ins.DB.Movies.Add(newMovie);
                DataProvider.Ins.DB.SaveChanges();
                LoadData();
            });
            EditMoviesCommand = new RelayCommand<object>((p) => 
            {
                if (string.IsNullOrEmpty(NameOfMovies) || string.IsNullOrWhiteSpace(NameOfMovies)
                || string.IsNullOrEmpty(Description) || string.IsNullOrWhiteSpace(Description)
                || string.IsNullOrEmpty(Image) || string.IsNullOrWhiteSpace(Image)
                || string.IsNullOrEmpty(Video) || string.IsNullOrWhiteSpace(Video)
                || string.IsNullOrEmpty(DateOfIssue.ToString()) || string.IsNullOrWhiteSpace(DateOfIssue.ToString()) || IsNumber(DateOfIssue.ToString()) == false
                || string.IsNullOrEmpty(Nation) || string.IsNullOrWhiteSpace(Nation)
                || string.IsNullOrEmpty(Rate.ToString()) || string.IsNullOrWhiteSpace(Rate.ToString()) || IsNumber(Rate.ToString()) == false
                || string.IsNullOrEmpty(Starring) || string.IsNullOrWhiteSpace(Starring)
                || string.IsNullOrEmpty(NameSearch) || string.IsNullOrWhiteSpace(NameSearch)
                || string.IsNullOrEmpty(Views.ToString()) || string.IsNullOrWhiteSpace(Views.ToString()) || IsNumber(Views.ToString()) == false)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedMovies != null)
                {
                    var movie = DataProvider.Ins.DB.Movies.Where(x => x.Id == SelectedMovies.Id).SingleOrDefault();
                    movie.NameOfMovies = NameOfMovies;
                    movie.Description = Description;
                    movie.Image = Image;
                    movie.Video = Video;
                    movie.DateOfIssue = int.Parse(DateOfIssue);
                    movie.Nation = Nation;
                    movie.Rate = int.Parse(Rate);
                    movie.Starring = Starring;
                    movie.NameSearch = NameSearch;
                    movie.Views = int.Parse(Views);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            DeleteMoviesCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedMovies == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedMovies != null)
                {
                    var movie = DataProvider.Ins.DB.Movies.Where(x => x.Id == SelectedMovies.Id).SingleOrDefault();
                    DataProvider.Ins.DB.Movies.Remove(movie);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadData();
                }
            });
            ChangeGenresCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Visible";
                VisibilityChangeSubGenres = "Collapsed";
            });
            ChangeSubGenresCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Collapsed";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Visible";
            });
            CancelCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Visible";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
            });
            GenresToGenresMovieCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedGenres == null)
                    return false;
                return true; 
            }, (p) =>
            {
                if (SelectedGenres != null)
                {
                    GenresMovieList.Add(SelectedGenres);
                    GenresMovieList = GenresMovieList.ToList();
                }
            });
            RemoveGenresMovieCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedGenresMovie == null)
                    return false;
                return true;
            }, (p) =>
            {
                GenresMovieList.Remove(SelectedGenresMovie);
                GenresMovieList = GenresMovieList.ToList();
            });
            SubGenresToSubGenresMovieCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedSubGenres == null)
                    return false;
                return true;
            }, (p) =>
            {
                if (SelectedSubGenres != null)
                {
                    SubGenresMovieList.Add(SelectedSubGenres);
                    SubGenresMovieList = SubGenresMovieList.ToList();
                }
            });
            RemoveSubGenresMovieCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedSubGenresMovie == null)
                    return false;
                return true;
            }, (p) =>
            {
                SubGenresMovieList.Remove(SelectedSubGenresMovie);
                SubGenresMovieList = SubGenresMovieList.ToList();
            });
            SaveGenresMovieCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var genresmovieslist = DataProvider.Ins.DB.GenresMovies.Where(x => x.MoviesId == SelectedMovies.Id).ToList();
                for (int i = 0; i < genresmovieslist.Count(); i++)
                {
                    DataProvider.Ins.DB.GenresMovies.Remove(genresmovieslist[i]);
                }
                for (int i = 0; i < GenresMovieList.Count(); i++)
                {
                    var newgenresmovies = new GenresMovies()
                    {
                        MoviesId = SelectedMovies.Id,
                        GenresId = GenresMovieList[i].Id
                    };
                    DataProvider.Ins.DB.GenresMovies.Add(newgenresmovies);
                }
                DataProvider.Ins.DB.SaveChanges();
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Visible";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                LoadData();
            });
            SaveSubGenresMovieCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var subgenresmovieslist = DataProvider.Ins.DB.SubGenresMovies.Where(x => x.MoviesId == SelectedMovies.Id).ToList();
                for (int i = 0; i < subgenresmovieslist.Count(); i++)
                {
                    DataProvider.Ins.DB.SubGenresMovies.Remove(subgenresmovieslist[i]);
                }
                for (int i = 0; i < SubGenresMovieList.Count(); i++)
                {
                    var newsubgenresmovies = new SubGenresMovies()
                    {
                        MoviesId = SelectedMovies.Id,
                        SubGenresId = SubGenresMovieList[i].Id
                    };
                    DataProvider.Ins.DB.SubGenresMovies.Add(newsubgenresmovies);
                }
                DataProvider.Ins.DB.SaveChanges();
                VisibilityDashboard = "Collapsed";
                VisibilityUser = "Collapsed";
                VisibilityMovies = "Collapsed";
                VisibilityGenres = "Collapsed";
                VisibilityUserControl = "Collapsed";
                VisibilityMoviesControl = "Visible";
                VisibilityGenresControl = "Collapsed";
                VisibilityChangeGenres = "Collapsed";
                VisibilityChangeSubGenres = "Collapsed";
                LoadData();
            });
            SignOutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                p.Close();
            });
            ViewCommand = new RelayCommand<object>((p) => 
            {
                if (SelectedFromDate == null || SelectedToDate == null)
                    return false;
                return true; 
            }, (p) =>
            {
                PaymentHistoryList = new List<PaymentHistory>();
                PaymentHistoryList = DataProvider.Ins.DB.PaymentHistory.ToList();
                var query = from pm in PaymentHistoryList
                            where DateTime.Compare(DateTime.Parse(pm.DateOfPayment.ToString()), SelectedFromDate) > 0 && DateTime.Compare(DateTime.Parse(pm.DateOfPayment.ToString()), SelectedToDate) < 0
                            select pm;
                PaymentHistoryList = query.ToList();
                PaymentHistoryList = PaymentHistoryList.ToList();
                TotalIncome = 0;
                for (int i = 0; i < PaymentHistoryList.Count(); i++)
                {
                    TotalIncome += int.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
            });
            YearTextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                Year = p.Text;
            });
            RatingTextChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                Rating = p.Text;
            });
            SelectedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                StatisticalMovies = new List<Movies>();
                if (SelectedStatisticalGenres.Id != 0 && SelectedStatisticalSubGenres.Id == 0)
                {
                    StatisticalMovies = GenresMoviesList.Where(x => x.GenresId == SelectedStatisticalGenres.Id).Select(x => x.Movies).ToList();
                }
                else if (SelectedStatisticalSubGenres.Id != 0 && SelectedStatisticalGenres.Id == 0)
                {
                    StatisticalMovies = SubGenresMoviesList.Where(x => x.SubGenresId == SelectedStatisticalSubGenres.Id).Select(x => x.Movies).ToList();
                }
                else if (SelectedStatisticalGenres.Id != 0 && SelectedStatisticalSubGenres.Id != 0)
                {
                    var genresmovies = GenresMoviesList.Where(x => x.GenresId == SelectedStatisticalGenres.Id).Select(x => x.Movies).ToList();
                    var subgenresmovies = SubGenresMoviesList.Where(x => x.SubGenresId == SelectedStatisticalSubGenres.Id).Select(x => x.Movies).ToList();
                    if (genresmovies != null && subgenresmovies != null)
                    {
                        for (int i = 0; i < genresmovies.Count(); i++)
                        {
                            for (int j = 0; j < subgenresmovies.Count(); j++)
                            {
                                if (genresmovies[i].Id == subgenresmovies[j].Id)
                                {
                                    StatisticalMovies.Add(genresmovies[i]);
                                }
                            }
                        }
                        StatisticalMovies = StatisticalMovies.ToList();
                    }
                    else if (genresmovies == null)
                    {
                        StatisticalMovies = subgenresmovies.ToList();
                    }
                    else if (subgenresmovies == null)
                    {
                        StatisticalMovies = genresmovies.ToList();
                    }
                    else
                        StatisticalMovies = DataProvider.Ins.DB.Movies.ToList();
                }
                else
                    StatisticalMovies = DataProvider.Ins.DB.Movies.ToList();
                if (string.IsNullOrWhiteSpace(Year) && string.IsNullOrWhiteSpace(Rating) == false)
                {
                    var query = from m in StatisticalMovies
                                where m.Rate == int.Parse(Rating)
                                select m;
                    StatisticalMovies = query.ToList();
                }
                else if (string.IsNullOrWhiteSpace(Rating) && string.IsNullOrWhiteSpace(Year) == false)
                {
                    var query = from m in StatisticalMovies
                                where m.DateOfIssue == int.Parse(Year)
                                select m;
                    StatisticalMovies = query.ToList();
                }
                else if (string.IsNullOrWhiteSpace(Rating) == false && string.IsNullOrWhiteSpace(Year) == false)
                {
                    var query = from m in StatisticalMovies
                                where m.DateOfIssue == int.Parse(Year) && m.Rate == int.Parse(Rating)
                                select m;
                    StatisticalMovies = query.ToList();
                }
                StatisticalMovies = StatisticalMovies.ToList();
                TotalMovies = StatisticalMovies.Count();
                LoadPieChartStatisticalMovies();
            });
        }

        void LoadData()
        {
            AccountList = new List<Account>();
            MoviesList = new List<Movies>();
            GenresList = new List<Genres>();
            SubGenresList = new List<SubGenres>();
            AccountList = DataProvider.Ins.DB.Account.ToList();
            MoviesList = DataProvider.Ins.DB.Movies.ToList();
            GenresList = DataProvider.Ins.DB.Genres.ToList();
            SubGenresList = DataProvider.Ins.DB.SubGenres.ToList();
            AccountList = AccountList.ToList();
            MoviesList = MoviesList.ToList();
            GenresList = GenresList.ToList();
            SubGenresList = SubGenresList.ToList();
            RankedListMovies = new List<Movies>();
            for (int i = 0; i < MoviesList.Count(); i++)
            {
                var newMovie = new Movies()
                {
                    NameOfMovies = MoviesList[i].NameOfMovies,
                    Image = projectDirectory + "/Data/" + "Images/" + MoviesList[i].Image,
                    Views = MoviesList[i].Views
                };
                RankedListMovies.Add(newMovie);
            }
            for (int i = 0; i < RankedListMovies.Count() - 1; i++)
            {
                for (int j = i + 1; j < RankedListMovies.Count(); j++)
                {
                    if (RankedListMovies[i].Views < RankedListMovies[j].Views)
                    {
                        var movieTemp = new Movies();
                        movieTemp = RankedListMovies[i];
                        RankedListMovies[i] = RankedListMovies[j];
                        RankedListMovies[j] = movieTemp;
                    }
                }
            }
            RankedListMovies = RankedListMovies.Take(10).ToList();
            PaymentHistoryList = new List<PaymentHistory>();
            PaymentHistoryList = DataProvider.Ins.DB.PaymentHistory.ToList();
            for (int i = 0; i < PaymentHistoryList.Count(); i++)
            {
                TotalIncome += int.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
            }
            StatisticalMovies = new List<Movies>();
            StatisticalMovies = DataProvider.Ins.DB.Movies.ToList();
            TotalMovies = StatisticalMovies.Count();
            StatisticalGenresMovies = new List<Genres>();
            var newGenre = new Genres()
            {
                Id = 0,
                Name = "All Genres"
            };
            StatisticalGenresMovies.Add(newGenre);
            for (int i = 0; i < GenresList.Count(); i++)
            {
                var newGenres = new Genres()
                {
                    Id = GenresList[i].Id,
                    Name = GenresList[i].Name
                };
                StatisticalGenresMovies.Add(newGenres);
            }
            StatisticalGenresMovies = StatisticalGenresMovies.ToList();
            StatisticalSubGenresMovies = new List<SubGenres>();
            var newSubGenre = new SubGenres()
            {
                Id = 0,
                Name = "All SubGenres"
            };
            StatisticalSubGenresMovies.Add(newSubGenre);
            for (int i = 0; i < SubGenresList.Count(); i++)
            {
                var newSubGenres = new SubGenres()
                {
                    Id = SubGenresList[i].Id,
                    Name = SubGenresList[i].Name
                };
                StatisticalSubGenresMovies.Add(newSubGenres);
            }
            StatisticalSubGenresMovies = StatisticalSubGenresMovies.ToList();
            GenresMoviesList = new List<GenresMovies>();
            GenresMoviesList = DataProvider.Ins.DB.GenresMovies.ToList();
            SubGenresMoviesList = new List<SubGenresMovies>();
            SubGenresMoviesList = DataProvider.Ins.DB.SubGenresMovies.ToList();
            LoadPieChartStatisticalMovies();
            LoadPieChartStatisticalMoviesByViews();
            LoadCartesianChartSeriesStatisticsByRevenue(LoadDataSeries());
        }
        void LoadPieChartStatisticalMovies()
        {
            Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
            SeriesCollection series = new SeriesCollection();
            series.Add(new PieSeries() { Title = "All Movies", Values = new ChartValues<int> { MoviesList.Count() }, DataLabels = true, LabelPoint = labelPoint });
            series.Add(new PieSeries() { Title = "Selected Movies", Values = new ChartValues<int> { TotalMovies }, DataLabels = true, LabelPoint = labelPoint });
            PieChartSeries1 = series;
        }
        void LoadPieChartStatisticalMoviesByViews()
        {
            Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
            SeriesCollection series = new SeriesCollection();
            for (int i = 0; i < RankedListMovies.Count(); i++)
            {
                series.Add(new PieSeries() { Title = RankedListMovies[i].NameOfMovies, Values = new ChartValues<long> { long.Parse(RankedListMovies[i].Views.ToString()) }, DataLabels = true, LabelPoint = labelPoint });
            }
            PieChartSeries2 = series;
        }
        List<long> LoadDataSeries()
        {
            long doanhthu1 = 0;
            long doanhthu2 = 0;
            long doanhthu3 = 0;
            long doanhthu4 = 0;
            long doanhthu5 = 0;
            long doanhthu6 = 0;
            long doanhthu7 = 0;
            long doanhthu8 = 0;
            long doanhthu9 = 0;
            long doanhthu10 = 0;
            long doanhthu11 = 0;
            long doanhthu12 = 0;
            for (int i = 0; i < PaymentHistoryList.Count(); i++)
            {
                if (PaymentHistoryList[i].DateOfPayment.Value.Month == 1)
                {
                    doanhthu1 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 2)
                {
                    doanhthu2 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 3)
                {
                    doanhthu3 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 4)
                {
                    doanhthu4 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 5)
                {
                    doanhthu5 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 6)
                {
                    doanhthu6 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 7)
                {
                    doanhthu7 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 8)
                {
                    doanhthu8 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 9)
                {
                    doanhthu9 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 10)
                {
                    doanhthu10 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 11)
                {
                    doanhthu11 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
                else if (PaymentHistoryList[i].DateOfPayment.Value.Month == 12)
                {
                    doanhthu12 += long.Parse(PaymentHistoryList[i].Plan.MonthlyPice.ToString());
                }
            }
            List<long> revenue = new List<long>();
            revenue.Add(doanhthu1);
            revenue.Add(doanhthu2);
            revenue.Add(doanhthu3);
            revenue.Add(doanhthu4);
            revenue.Add(doanhthu5);
            revenue.Add(doanhthu6);
            revenue.Add(doanhthu7);
            revenue.Add(doanhthu8);
            revenue.Add(doanhthu9);
            revenue.Add(doanhthu10);
            revenue.Add(doanhthu11);
            revenue.Add(doanhthu12);
            return revenue;
        }
        void LoadCartesianChartSeriesStatisticsByRevenue(List<long> revenue)
        {
            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            SeriesCollection series = new SeriesCollection()
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { revenue[0], revenue[1], revenue[2], revenue[3], revenue[4], revenue[5], revenue[6], revenue[7], revenue[8], revenue[9], revenue[10], revenue[11] }
                },
            };
            CartesianChartSeries = series;
        }
    }
}
