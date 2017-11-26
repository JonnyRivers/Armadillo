using Armadillo.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Checkers
{
    public class ViewModel : BaseViewModel
    {
        private ObservableCollection<Tile> _tiles;

        public ViewModel()
        {
            List<Tile> tiles = new List<Tile>();
            for (int x = 0; x < 8; ++x)
            {
                for (int y = 0; y < 8; ++y)
                {
                    Brush fill = ((x + y) % 2 == 0) ? Brushes.AntiqueWhite : Brushes.DarkSeaGreen;
                    tiles.Add(new Tile(x, y, fill));
                }
            }

            _tiles = new ObservableCollection<Tile>(tiles);
        }

        public ObservableCollection<Tile> Tiles { get => _tiles; }
    }
}
