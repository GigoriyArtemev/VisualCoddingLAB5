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
       /* public void CreateMyMultilineTextBox()
        {
            TextBox textBox1 = new TextBox();
            textBox1.AcceptsReturn = true;
            textBox1.TextWrapping = Avalonia.Media.TextWrapping.Wrap;
        }
       */
            public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Button>("OpenFileNow").Click += async delegate
            {
                var taskPath= new OpenFileDialog()
                {
                    Title = "Open File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);
                string[]? path = await taskPath;

                var context = this.DataContext as MainWindowViewModel;
                context.Path = string.Join(@"\", path);
                using (StreamReader sr = File.OpenText(context.Path))
                {
                    string s = "" ;
                    string temp;
                    bool flag = true;
                    while (flag)
                    {
                        temp=sr.ReadLine();
                        if (temp != null)
                        {
                            s += temp;
                            temp = " ";
                        }
                        else flag = false;
                    }
                    string p = s;
                 context.Path = string.Join(@" ", s);
                }
            };
        }
        private async void MyClickEventHandler(object sender, RoutedEventArgs e)
        {
           string? str= await new SetRegex().ShowDialog<string?>((Window)this.VisualRoot);
            var context = this.DataContext as MainWindowViewModel;
            context.Path = str ?? "";
        }
    } 
}
