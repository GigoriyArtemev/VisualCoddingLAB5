using Avalonia.Controls;
using Avalonia;
using System;
using System.IO;
using Avalonia.Markup.Xaml;
using VisualCoddingLAB5.ViewModels;
using Avalonia.Interactivity;

namespace VisualCoddingLAB5.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("OpenFileNow").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                context.Text = string.Join(@"\", path);

                using (StreamReader sr = File.OpenText(context.Text))
                {
                    string s = "";
                    string temp;
                    bool flag = true;
                    while (flag)
                    {
                        temp = sr.ReadLine();
                        if (temp != null)
                        {
                            s += temp;
                            temp = " ";
                        }
                        else flag = false;
                    }
                    string p = s;
                    context.Text = string.Join(@" ", s);
                }
            };

            this.FindControl<Button>("SaveFileNow").Click += async delegate
            {
                var taskGetPath = new OpenFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string[]? pathToFile = await taskGetPath;
                var contex = this.DataContext as MainWindowViewModel;
                if (pathToFile != null)
                {
                    using (StreamWriter writer = new StreamWriter(string.Join(@"\", pathToFile), false))
                    {
                        await writer.WriteLineAsync(contex.RegularResult);
                    }

                }
            };
        }

        private void MyClickEventHandler(object sender, RoutedEventArgs e)
        {
            var v = new RegexWindow();
            v.OkNotify += delegate (string str)
            {
                var contex = this.DataContext as MainWindowViewModel;
                contex.Pattern = str;
                contex.RegularResult = contex.FindRegular();

            };
            v.Show((Window)this.VisualRoot);
        }
    }
}