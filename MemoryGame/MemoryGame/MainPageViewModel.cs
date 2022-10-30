using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemoryGame
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
    }

    public class MainPageViewModel : BaseViewModel
    {
        public IGamePlane GamePlane { get; set; }

        public MainPageViewModel()
        {
            GamePlane = new MemoryCharsGamePlane();
            GamePlane.Tiles.Add(new CharGameTileItem("A"));
            GamePlane.Tiles.Add(new CharGameTileItem("B"));
            GamePlane.Tiles.Add(new CharGameTileItem("C"));
            GamePlane.Tiles.Add(new CharGameTileItem("A"));
            GamePlane.Tiles.Add(new CharGameTileItem("B"));
            GamePlane.Tiles.Add(new CharGameTileItem("C"));
            GamePlane.Tiles.Add(new CharGameTileItem("D"));
            GamePlane.Tiles.Add(new CharGameTileItem("F"));
            GamePlane.Tiles.Add(new CharGameTileItem("G"));
        }
    }
}
