using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MemoryGame
{
    public interface IGamePlane
    {
        List<IGameTile> Tiles { get; set; }
        IGameTile T0_0 { get; }
        IGameTile T0_1 { get; }
        IGameTile T0_2 { get; }
        IGameTile T1_0 { get; }
        IGameTile T1_1 { get; }
        IGameTile T1_2 { get; }
        IGameTile T2_0 { get; }
        IGameTile T2_1 { get; }
        IGameTile T2_2 { get; }

        Command<IGameTile> TileClick { get; set; }
    }

    public interface IGameTile
    {
        object Char { get; set; }
        bool IsShown { get; set; }
        string HiddenChar { get; }
    }

    public class MemoryCharsGamePlane : IGamePlane
    {

        public MemoryCharsGamePlane()
        {
            Tiles = new List<IGameTile>();
            TileClick = new Command<IGameTile>(OnTileClick);
        }

        private void OnTileClick(IGameTile obj)
        {
            if (obj == null)
                return;

            obj.IsShown = !obj.IsShown;
        }

        public List<IGameTile> Tiles { get; set; }

        public IGameTile T0_0 => Tiles[0 * 3 + 0];

        public IGameTile T0_1 => Tiles[0 * 3 + 1];

        public IGameTile T0_2 => Tiles[0 * 3 + 2];

        public IGameTile T1_0 => Tiles[1 * 3 + 0];

        public IGameTile T1_1 => Tiles[1 * 3 + 1];

        public IGameTile T1_2 => Tiles[1 * 3 + 2];

        public IGameTile T2_0 => Tiles[2 * 3 + 0];

        public IGameTile T2_1 => Tiles[2 * 3 + 1];

        public IGameTile T2_2 => Tiles[2 * 3 + 2];

        public Command<IGameTile> TileClick { get; set; }
    }

    public class CharGameTileItem : IGameTile, INotifyPropertyChanged
    {
        public CharGameTileItem()
        {

        }

        public CharGameTileItem(string _char)
        {
            Char = _char;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Char { get; set; }

        bool _isShown = false;

        public bool IsShown
        {
            get => _isShown; set
            {
                _isShown = value;
                OnPropertyChanged("IsShown");
            }
        }

        public string HiddenChar => "?";
    }
}
