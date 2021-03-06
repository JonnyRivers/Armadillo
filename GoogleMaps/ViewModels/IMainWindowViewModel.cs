﻿using System.Windows.Input;
using System.Windows.Media;

namespace DoogleMaps
{
    public interface IMainWindowViewModel
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
        int Zoom { get; set; }
        ImageSource ViewportImageSource { get; set; }

        ICommand ViewportScrollCommand { get; }
        ICommand ZoomInCommand { get; }
        ICommand ZoomOutCommand { get; }
    }
}
