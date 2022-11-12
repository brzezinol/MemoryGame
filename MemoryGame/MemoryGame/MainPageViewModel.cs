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
            GamePlane = new MemoryCharsGamePlane
            {
                Tiles= new List<IGameTile>
                {
                    new CharGameTileItem("A"),
                    new CharGameTileItem("B"),
                    new CharGameTileItem("C"),
                    new CharGameTileItem("A"),
                    new CharGameTileItem("B"),
                    new CharGameTileItem("C"),
                    new CharGameTileItem("D"),
                    new CharGameTileItem("F"),
                    new CharGameTileItem("G"),
                    new CharGameTileItem("G"),
                    new CharGameTileItem("F"),
                    new CharGameTileItem("D")
                }
            };
        }
    }
}
