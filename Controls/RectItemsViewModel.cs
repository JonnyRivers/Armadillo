using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Controls
{
    public class RectItemsViewModel
    {
        private ObservableCollection<RectItem> _rectItems;

        public RectItemsViewModel()
        {
            _rectItems = new ObservableCollection<RectItem>
            {
                new RectItem { X = 100, Y = 50, Width = 20, Height = 30, Fill = Brushes.Blue },
                new RectItem { X = 200, Y = 50, Width = 30, Height = 10, Fill = Brushes.Green },
            };
        }

        public ObservableCollection<RectItem> RectItems { get => _rectItems; }
    }
}
