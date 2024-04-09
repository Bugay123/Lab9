using Lab9.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab9.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly AppDbContext _dbContext;


        public MainViewModel()
        {
            _dbContext = new AppDbContext();
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _dbContext.Tracks.Load();

            ReloadTracks();
        }

        private void ReloadTracks()
        {
            var items = _dbContext.Tracks.Local.ToList();
            var result = items;
            if (IsSorted)
            {
                if (IsByTitle) {result = items.OrderBy(x => x.Title).ToList();}}
            else if (IsByArtist){result = items.OrderBy(x => x.Artist).ToList();}
            else if (IsByAlbum){result = items.OrderBy(x => x.Album).ToList();}
            else if (IsByYear){ result = items.OrderBy(x => x.Year).ToList(); }
            else{result = items.OrderBy(x => x.Id).ToList();}

            Tracks.Clear();
            result.ForEach(x =>
            {
                Tracks.Add(x);
            });


        }
        public ObservableCollection<MusicTrack> Tracks { get; set; } = new ObservableCollection<MusicTrack>();

        private bool _isSorted;

        public bool IsSorted
        {
            get => _isSorted;
            set
            {
                SetProperty(ref _isSorted, value);
                ReloadTracks();
            }
        }

        private bool _isByTitle = true;

        public bool IsByTitle
        {
            get => _isByTitle;
            set
            {
                SetProperty(ref _isByTitle, value);
                ReloadTracks();
            }
        }

        private bool _isByArtist = true;

        public bool IsByArtist
        {
            get => _isByArtist;
            set
            {
                SetProperty(ref _isByArtist, value);
                ReloadTracks();
            }
        }

        private bool _isByAlbum;

        public bool IsByAlbum
        {
            get => _isByAlbum;
            set
            {
                SetProperty(ref _isByAlbum, value);
                ReloadTracks();
            }
        }

        private bool _isByYear;

        public bool IsByYear
        {
            get => _isByYear;
            set
            {
                SetProperty(ref _isByYear, value);
                ReloadTracks();
            }
        }

        private string _newTrackTitle;
        public string NewTrackTitle
        {
            get => _newTrackTitle;
            set => SetProperty(ref _newTrackTitle, value);
        }

        private string _newTrackArtist;
        public string NewTrackArtist
        {
            get => _newTrackArtist;
            set => SetProperty(ref _newTrackArtist, value);
        }


        private string _newTrackAlbum;
        public string NewTrackAlbum
        {
            get => _newTrackAlbum;
            set => SetProperty(ref _newTrackAlbum, value);
        }


        private int _newTrackYear;
        public int NewTrackYear
        {
            get => _newTrackYear;
            set => SetProperty(ref _newTrackYear, value);
        }


        public void SaveNewTrack()
        {
            _dbContext.Add(new MusicTrack
            {
                Title = NewTrackTitle,
                Artist = NewTrackArtist,
                Album = NewTrackAlbum,
                Year = NewTrackYear,
            });
            _dbContext.SaveChanges();
            ReloadTracks();
            ClearNewTrack();
        }


        public void ClearNewTrack()
        {
            NewTrackTitle = "";
            NewTrackArtist = "";
            NewTrackAlbum = "";
            NewTrackYear = 0;
        }
    }
}
