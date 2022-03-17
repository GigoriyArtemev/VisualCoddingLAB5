using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace VisualCoddingLAB5.Views
{
    public partial class SetRegex : Window
    {
        public SetRegex()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OkeyNow").Click += async delegate
              {
                  Close("ok cliked");
  
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
