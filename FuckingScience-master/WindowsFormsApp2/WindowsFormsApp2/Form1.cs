using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Compare_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn1.Text.Length, txtn1.Text);
            N n2 = new N(txtn2.Text.Length, txtn2.Text);
            if (N.COM_NN_D(n1, n2) == 2) tbResult.Text = "bigger";
            else if (N.COM_NN_D(n1, n2) == 1) tbResult.Text = "less";
            else tbResult.Text = "equal";
        }
        private void CmpWithNull_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn3.Text.Length, txtn3.Text);
            if (n1.NZER_N_B()) tbResult.Text = "n0 0";
            else tbResult.Text = "is 0";
        }
        private void ADD_NN_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn4.Text.Length, txtn4.Text);
            N n2 = new N(txtn5.Text.Length, txtn5.Text);
            new N(N.ADD_NN_N(n1, n2)).Print(tbResult);
        }
        private void ADD_1_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn6.Text.Length, txtn6.Text);
            n1.ADD_1N_N().Print(tbResult);
        }
        private void Sub_NN_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn7.Text.Length, txtn7.Text);
            N n2 = new N(txtn8.Text.Length, txtn8.Text);
            (N.SUB_NN_N(n1, n2)).Print(tbResult);
        }
        private void Mul_ND_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn9.Text.Length, txtn9.Text);
            N n2 = new N(txtn10.Text.Length, txtn10.Text);
            if (!(n2.IsN(txtn10.Text) && txtn10.Text.Length == 1))
                tbResult.Text = "Некорректный ввод!";
            else
            N.MUL_ND_N(n1, n2).Print(tbResult);
        }
        private void Mul_kN_btn(object sender, EventArgs e)
        {
            N n1 = new N(txtn11.Text.Length, txtn11.Text);
            N n2 = new N(txtn12.Text.Length, txtn12.Text);
            if (!(n2.IsN(txtn12.Text) && txtn12.Text.Length == 1))
                tbResult.Text = "Некорректный ввод!";
            else
                N.MUL_Nk_N(n1, n2).Print(tbResult);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn13.Text.Length, txtn13.Text);
            N n2 = new N(txtn14.Text.Length, txtn14.Text);
            tbResult.Text = Convert.ToString(N.DIV_NN_Dk(n1, n2));
        }
        private void button12_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn15.Text.Length, txtn15.Text);
            N n2 = new N(txtn16.Text.Length, txtn16.Text);
            N digit = new N(txtn17.Text.Length, txtn17.Text);
            if (!(n1.IsN(txtn15.Text) && n2.IsN(txtn16.Text) && (txtn17.Text.Length == 1)))
            {
                tbResult.Text = "Некорректный ввод!";
            }
            if (N.COM_NN_D(n1, N.MUL_ND_N(n2, digit)) == 1)
            {
                tbResult.Text = "Отрицательный результат!";
            }
            else
            {
                var Result = N.SUB_NDN_N(n1, n2, digit);
                Result.SetTop();
                Result.Print(tbResult);
            }        }
        private void button13_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn18.Text.Length, txtn18.Text);
            N n2 = new N(txtn19.Text.Length, txtn19.Text);
            N.MUL_NN_N(n1, n2).Print(tbResult);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn20.Text.Length, txtn20.Text);
            N n2 = new N(txtn21.Text.Length, txtn21.Text);
            N.DIV_NN_N(n1, n2, 1).Print(tbResult);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn22.Text.Length, txtn22.Text);
            N n2 = new N(txtn23.Text.Length, txtn23.Text);
            N.DIV_NN_N(n1, n2, 2).Print(tbResult);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn24.Text.Length, txtn24.Text);
            N n2 = new N(txtn25.Text.Length, txtn25.Text);
            N.GCF_NN_N(n1, n2).Print(tbResult);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            N n1 = new N(txtn26.Text.Length, txtn26.Text);
            N n2 = new N(txtn27.Text.Length, txtn27.Text);
            N.LCM_NN_N(n1, n2).Print(tbResult);
        }
    }
}
