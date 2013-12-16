/// <summary>
/// This class defines the generic Puzzle type
/// </summary>

namespace Puzzles.Model
{
    using System.ComponentModel;
    using System.Data.Linq.Mapping;

    [Table]
    [InheritanceMapping(Code = "M", Type = typeof(Mcq))]
    [InheritanceMapping(Code = "T", Type = typeof(TextAnswer), IsDefault = true)]
    public abstract class Puzzle : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int puzzleId;
        private string title;
        private string imageLocation;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int PuzzleId
        {
            get
            {
                return this.puzzleId;
            }
            set
            {
                if (this.puzzleId != value)
                {
                    this.NotifyPropertyChanging("PuzzleId");
                    this.puzzleId = value;
                    this.NotifyPropertyChanged("PuzzleId");
                }
            }
        }

        [Column(CanBeNull = false)]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (this.title != value)
                {
                    this.NotifyPropertyChanging("Title");
                    this.title = value;
                    this.NotifyPropertyChanged("Title");
                }
            }
        }

        [Column(CanBeNull = false)]
        public string ImageLocation
        {
            get
            {
                return this.imageLocation;
            }
            set
            {
                if (this.imageLocation != value)
                {
                    this.NotifyPropertyChanging("ImageLocation");
                    this.imageLocation = value;
                    this.NotifyPropertyChanging("ImageLocation");
                }
            }
        }

        // Column that indicates which of the derived types does this row contain
        [Column(IsDiscriminator = true)]
        public string DiscKey;

        #region INotifiedPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region INotifedPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        protected void NotifyPropertyChanging(string propertyName)
        {
            if (this.PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        #endregion
    }
}
