using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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
        IGameTile T3_0 { get; }
        IGameTile T3_1 { get; }
        IGameTile T3_2 { get; }

        Command<IGameTile> TileClick { get; set; }
    }

    public interface IGameTile
    {
        object Char { get; set; }
        bool IsShown { get; set; }
        string HiddenChar { get; }
        bool IsResolved { get; set; }
    }

    public class MemoryCharsGamePlane : IGamePlane
    {
        IGameTile TileA = null;
        IGameTile TileB = null;

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

            if (!obj.IsShown)
                return;

            if (Tiles.Where(t => t.IsShown && !t.IsResolved).Count() > 2)
            {
                Tiles.Where(t => t != obj).ForEach(t => t.IsShown = false);
                TileA = obj;
                TileB = null;
                return;
            }

            if (TileA == null)
                TileA = obj;
            else
                TileB = obj;

            if (TileA != null && TileB != null)
            {
                if (TileA.Char == TileB.Char)
                {
                    TileA.IsResolved = TileB.IsResolved = true;
                    TileA = TileB = null;
                }
            }         
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

        public IGameTile T3_0 => Tiles[3 * 3 + 0];

        public IGameTile T3_1 => Tiles[3 * 3 + 1];

        public IGameTile T3_2 => Tiles[3 * 3 + 2];

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
            get => _isShown || IsResolved; 
            set
            {
                _isShown = value;
                OnPropertyChanged("IsShown");
            }
        }

        public string HiddenChar => "?";

        bool _IsResolved;
        public bool IsResolved 
        { 
            get => _IsResolved; 
            set
            {
                _IsResolved = value;
                OnPropertyChanged("IsResolved");
            }
        }
    }
}
