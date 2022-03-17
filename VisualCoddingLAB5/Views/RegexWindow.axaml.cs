using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System;


namespace VisualCoddingLAB5.Views
{
    public partial class RegexWindow : Window
    {
        public delegate void OkHandler(string message);
        public event OkHandler? OkNotify;
        public RegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OkeyNow").Click += async delegate
            {
                OkNotify(this.Find<TextBox>("textRegVr").Text);
                Close();

            };
            this.FindControl<Button>("CancelNow").Click += async delegate
            {
                Close();


            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}