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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string name;
        int plv, ATK, HP;
        int mlv = 1, mATK, mHP;
        int maxexp;
        int exp;
        int expl;
        Random random = new Random();
        public Window1(HomeWindow homeWindow)
        {
        }


        private void ATK_Button_Click(object sender, RoutedEventArgs e)
        {
            AtkVs();
            if (HP <= 0)
            {
                //expl = 10;
                //exp = exp + expl;

                //exp lose
                exp = exp + (expl / 8);
                txtpData.Text = "You lose";
                txtmData.Text = "You have been : " + (expl / 8) + " EXP";
                show();
                showMonster();
            }
            if (mHP <= 0)
            {
                //expl = 100;
                //exp = exp + expl;

                //exp win
                exp = exp + (expl * 10);
                txtpData.Text = "You win";
                txtmData.Text = "You have been : " + (expl * 10) + " EXP" ;
                show();
                showMonster();
            }
            //expl = uint.Parse(txtData.Text);
            
        }

        private void Give_up_Button_Click(object sender, RoutedEventArgs e)
        {
            DataPlayer Dp = new DataPlayer();
            txtpData.Text = name + " : Give up !";
            show();
            showMonster();
            gotoDp_open(Dp);
        }

        public Window1(HomeWindow homeWindow, DataPlayer Dp)
        {
            InitializeComponent();

            //เพิ่มไอเทมเข้า ComboDifficulty
            ComboDifficulty.Items.Add("--- Difficulty ---");
            ComboDifficulty.Items.Add("Super Very Easy");
            ComboDifficulty.Items.Add("Very Easy");
            ComboDifficulty.Items.Add("Easy");
            ComboDifficulty.Items.Add("Normal");
            ComboDifficulty.Items.Add("Hard");
            ComboDifficulty.Items.Add("Impossible");
            ComboDifficulty.SelectedIndex = 0;

            name = Dp.Name;
            gotovar(Dp);
            show();
            showMonster();
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
            ATK = plv * 10;;
            HP = plv * 100;
            txtATK.Text = ATK.ToString();
            txtHP.Text = HP.ToString();
        }

        public void showMonster()
        {
            mATK = mlv * 12;
            mHP = mlv * 120;
            txtLvMonster.Text = mlv.ToString();
            txtATKMonster.Text = mATK.ToString();
            txtHPMonster.Text = mHP.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string select = ComboDifficulty.SelectedItem.ToString();
            int select = ComboDifficulty.SelectedIndex;
            //MessageBox.Show(select.ToString());
            if (select != 0)
            {
                if (select == 1)
                {
                    mlv = 1;
                    //Moneyl = 1;
                    expl = 10;
                }
                else if(select == 2)
                {
                    mlv = random.Next(2, 5);
                    //Moneyl = 10;
                    expl = 10;
                }
                else if (select == 3)
                {
                    mlv = random.Next(5, 10);
                    //Moneyl = 100;
                    expl = 30;
                }
                else if (select == 4)
                {
                    mlv = random.Next(10, 20);
                    //Moneyl = 1000;
                    expl = 50;
                }
                else if (select == 5)
                {
                    mlv = random.Next(20, 50);
                    //Moneyl = 10000;
                    expl = 100;
                }
                else if (select == 6)
                {
                    mlv = random.Next(50, 150);
                    //Moneyl = 100000;
                    expl = 1000;
                }
                showMonster();
            }
        }

        public void gotovar(DataPlayer Dp)
        {
            plv = int.Parse(Dp.Lv);
            maxexp = int.Parse(Dp.MaxExp);
            exp = int.Parse(Dp.Exp);
        }

        private void AtkVs()
        {
            int NowATK;
            int randomATK = random.Next(0, 10);
            //int randomATK = 0;
            if (randomATK == 0)
            {
                NowATK = ATK * 0;
                txtpData.Text = name + " : ATK " + NowATK + " Missed...";
                mHP -= NowATK;
                txtHPMonster.Text = mHP.ToString();

                MonsterATK();
            }
            else if (randomATK == 1)
            {
                NowATK = ATK * 2;
                txtpData.Text = name + " : ATK " + NowATK + " Critical !";
                mHP -= NowATK;
                txtHPMonster.Text = mHP.ToString();

                MonsterATK();

            }
            else
            {
                NowATK = ATK;
                txtpData.Text = name + " : ATK " + NowATK + " Normal";
                mHP -= NowATK;
                txtHPMonster.Text = mHP.ToString();

                MonsterATK();

            }
        }

        private void MonsterATK()
        {
            int NowATK;
            int randomATK = random.Next(0, 10);
            if (randomATK == 0)
            {
                NowATK = mATK * 0;
                txtmData.Text = txtNameMonster.Text + " : ATK " + NowATK + " Missed...";
                HP -= NowATK;
                txtHP.Text = HP.ToString();
            }
            else if (randomATK == 1)
            {
                NowATK = mATK * 2;
                txtmData.Text = txtNameMonster.Text + " : ATK " + NowATK + " Critical !";
                HP -= NowATK;
                txtHP.Text = HP.ToString();
            }
            else
            {
                NowATK = mATK;
                txtmData.Text = txtNameMonster.Text + " : ATK " + NowATK + " Normal";
                HP -= NowATK;
                txtHP.Text = HP.ToString();
            }
        }
        public void gotoDp_open(DataPlayer Dp)
        {
            maxexp = plv * 100;
            Dp.Name = name;
            Dp.Lv = plv.ToString();
            Dp.Exp = exp.ToString();
            Dp.MaxExp = maxexp.ToString();
            HomeWindow homeWindow = new HomeWindow(this, Dp);
            homeWindow.Show();
            this.Close();
        }

    }
}
