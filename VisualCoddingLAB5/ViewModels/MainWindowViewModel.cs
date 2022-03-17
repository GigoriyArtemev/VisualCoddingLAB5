using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Reactive;
using ReactiveUI;

namespace VisualCoddingLAB5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string path;
        public string Path
        {
            get => path;
            set => this.RaiseAndSetIfChanged(ref path,value);
        }
    }
}
