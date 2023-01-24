using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] mayin = new int[3];
        int[] rdnpuan = new int[50];
        Random rdn = new Random();
        int bmayin = 3;
        int skor = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
                mayin[0] = rdn.Next(0, 15);
                mayin[1] = rdn.Next(15, 35);
                mayin[2] = rdn.Next(35, 50);
            for (int i = 0; i <rdnpuan.Length; i++)
            {
                rdnpuan[i] = rdn.Next(0, 100);
            }
            
            for (int i = 0; i < 50; i++)
            {
                Button btn = new Button();
                btn.Width =btn.Height=50;
                btn.Padding = new Padding(0);
                flowLayoutPanel1.Controls.Add(btn);
                btn.Tag = i;
                btn.Text = "*";
                btn.Click += btn_Click;
            }
            label4.Text = bmayin.ToString();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button basılan = sender as Button;
            int b = Convert.ToInt32(basılan.Tag);
            if (b== mayin[0]||b==mayin[1]||b==mayin[2])
            {
                basılan.BackColor = Color.Red;
                basılan.Text = "x";
                bmayin--;
                label4.Text = bmayin.ToString();
                if (bmayin==0)
                {
                    flowLayoutPanel1.Controls.Clear();
                    MessageBox.Show($" puanınız: { skor}", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    skor = 0;
                    bmayin = 3;
                    label4.Text = bmayin.ToString();

                }
                
                label3.Text = skor.ToString();

            }
            else
            {
                basılan.BackColor = Color.Green;
                basılan.Text = rdnpuan[Convert.ToInt32(basılan.Tag)].ToString();
                skor+= rdnpuan[Convert.ToInt32(basılan.Tag)];
                label3.Text = skor.ToString();
            }
            basılan.Enabled = false;

        }
    }
}

