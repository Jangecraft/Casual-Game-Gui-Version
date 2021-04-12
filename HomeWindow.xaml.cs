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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        string name;
        int plv, ATK, HP;
        int mlv = 1, mATK, mHP;
        int maxexp;
        int exp;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataPlayer Dp = new DataPlayer();
            gotoDp_open(Dp);
        }

        int expl;
        public HomeWindow(MainWindow mainWindow, DataPlayer Dp)
        {
            InitializeComponent();

            name = Dp.Name;
            gotovar(Dp);
            show();
        }
        public HomeWindow(Window1 Window1, DataPlayer Dp)
        {
            InitializeComponent();

            name = Dp.Name;
            gotovar(Dp);
            show();
        }
        public void gotovar(DataPlayer Dp)
        {
            plv = int.Parse(Dp.Lv);
            maxexp = int.Parse(Dp.MaxExp);
            exp = int.Parse(Dp.Exp);
        }

        public void gotoDp_open(DataPlayer Dp)
        {
            maxexp = plv * 100;
            Dp.Name = name;
            Dp.Lv = plv.ToString();
            Dp.Exp = exp.ToString();
            Dp.MaxExp = maxexp.ToString();
            Window1 win1 = new Window1(this, Dp);
            win1.Show();
            this.Close();
        }

        public void show()
        {
            player player = new player();
            DataPlayer Dp = player.Lv_up(maxexp, exp, expl, plv);
            gotovar(Dp);
            maxexp = plv * 100;
            txtName.Text = name;
            txtLv.Text = plv.ToString();
            txtExp.Text = exp.ToString() + "/" + maxexp.ToString();
            ATK = plv * 10; ;
            HP = plv * 100;
            txtATK.Text = ATK.ToString();
            txtHP.Text = HP.ToString();
        }

    }
}
