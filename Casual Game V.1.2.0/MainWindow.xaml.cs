using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //player pyr = new player();
        int plv = 1;
        int maxexp;
        int exp;
        //DataPlayer Dp = default(DataPlayer);
        DataPlayer Dp = new DataPlayer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            maxexp = plv * 100;
            Dp.Name = txtName.Text;
            Dp.Lv = plv.ToString();
            Dp.Exp = exp.ToString();
            Dp.MaxExp = maxexp.ToString();
            HomeWindow homeWindow = new HomeWindow(this, Dp);
            homeWindow.Show();
            //MainWindow win = new MainWindow();
            this.Close();
        }

    }
}
