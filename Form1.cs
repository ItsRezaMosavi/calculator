using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator2
{
    public partial class Form1 : Form
    {
        //baraye taghir button ha
        int page = 1;

        //PI haman adad pi ast
        const double PI = 3.14;

        //E haman adad neper ast
        const double E = 2.7;

        double a1 = 0, a2 = 1;

        //amaliat baraye in ast ke moshakhas shavad che amaly dar hal anjam ast
        string amaliat;

        //az posht ham zadan amalgar ha jologiri myshavad
        bool adadyaamal = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            //factorial gereftan az adad haye tabiyi

            if (txtM.Text == "")
            {
                return;
            }

            int x = Convert.ToInt32(txtM.Text);
            int s = 1;

            while (x > 1)
            {
                s *= x;
                x--;
            }
            txtM.Text = s + "";

        }

        private void btn1_x_Click(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                return;
            }
            double x = Convert.ToDouble(txtM.Text);
            txtM.Text = (1 / x) + "";
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                return;
            }
            int x;
            x = Convert.ToInt32(txtM.Text);
            int i = 1;
            int s = 1;
            if (page==1)
            {
                s = 10;
                while (i < x)
                {
                    s = s * 10;
                    i++;
                }
            }
            else
            {
                s = 2;
                while(i<x)
                {
                    s = s * 2;
                    i++;
                }
            }
            txtM.Text = s + "";
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            if (page==1)
            {
                txtM.Text = E + "";
            }
            else
            {
                txtM.Text = PI + "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnErase_Click(object sender, EventArgs e)
        {
            //be onvan backspace

            //l = andaze va tedad karaktere daroon textbox
            int l = txtM.Text.Length;

            if (l == 0)
            {
                return;
            }

            txtM.Text = txtM.Text.Substring(0, l - 1);
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            //baraye aashary kardan adad

            int x;
            x = Convert.ToInt32(txtM.Text);
            txtM.Text = x + ".";
            adadyaamal = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(txtM.Text=="")
            {
                return;
            }

            if (page==1)
            {
                amaliat = "^";

                if (adadyaamal)
                {
                    return;
                }
                a1 = Convert.ToDouble(txtM.Text);
                txtM.Text = "";
                adadyaamal = true;
            }

            else
            {
                double x, i = 1, s = E;
                x = Convert.ToInt32(txtM.Text);
                while(i<x)
                {
                    s = s * E;
                    i++;
                }
                txtM.Text = s + "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                return;
            }

            a2 = Convert.ToDouble(txtM.Text);


            if (a2 < 10)
            {
                a2 = Convert.ToDouble("0.0" + a2);
            }
            else
            {
                a2 = Convert.ToDouble("0." + a2);
            }


            if (amaliat == "+")
            {
                txtM.Text = a2 * a1 + "";
            }
            else
            {
                txtM.Text = a2 + "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //pak kardan textbox

            txtM.Text = "";
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            //manfy kardan text box

            double x;

            if (txtM.Text == "")
            {
                return;
            }

            x = Convert.ToDouble(txtM.Text);
            txtM.Text = -x + "";
        }

        private void txtM_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            //amalgar mosavy

            if (adadyaamal)
            {
                return;
            }

            if (amaliat == "*")
            {
                a1 *= Convert.ToDouble(txtM.Text);
                txtM.Text = a1 + "";
                adadyaamal = true;
            }


            else if (amaliat == "/")
            {
                a1 /= Convert.ToDouble(txtM.Text);
                txtM.Text = a1 + "";
                adadyaamal = true;
            }


            else if (amaliat == "+")
            {
                a1 += Convert.ToDouble(txtM.Text);
                txtM.Text = a1 + "";
                adadyaamal = true;
            }


            else if (amaliat == "-")
            {
                a1 -= Convert.ToDouble(txtM.Text);
                txtM.Text = a1 + "";
                adadyaamal = true;
            }

            else if (amaliat == "^")
            {
                int i = 1;
                double s = 1;
                a2 = Convert.ToDouble(txtM.Text);
                while (i <= a2)
                {
                    s = s * a1;
                    i++;
                }
                txtM.Text = s + "";
                adadyaamal = true;
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {

            //baraye taghsim

            //agar khal bashe kar nemikone
            if (txtM.Text == "")
            {
                return;
            }

            amaliat = "/";

            if (adadyaamal)
            {
                return;
            }

            if (a1 == 0)
            {
                a1 = Convert.ToDouble(txtM.Text);
            }
            else
            {
                a1 /= Convert.ToDouble(txtM.Text);
            }

            adadyaamal = true;
            txtM.Text = "";
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {

            //baraye zarb

            if (txtM.Text == "")
            {
                return;
            }

            amaliat = "*";

            if (adadyaamal)
            {
                return;
            }

            //baraye inke javab hamishe sefr nashavad
            if (a1 == 0)
            {
                a1 = Convert.ToDouble(txtM.Text);
            }
            else
            {
                a1 *= Convert.ToDouble(txtM.Text);
            }

            adadyaamal = true;
            txtM.Text = a1 + "";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {

            //baraye menha

            if (txtM.Text == "")
            {
                return;
            }

            amaliat = "-";

            if (adadyaamal)
            {
                return;
            }

            adadyaamal = true;

            if (a1 != 0)
            {
                a1 -= Convert.ToDouble(txtM.Text);
            }
            else
            {
                a1 = Convert.ToDouble(txtM.Text);
            }
            txtM.Text = a1 + "";
        }

        private void btnSum_Click(object sender, EventArgs e)
        {

            //baraye be alave

            if (txtM.Text == "")
            {
                return;
            }
            amaliat = "+";
            if (adadyaamal)
            {
                return;
            }
            adadyaamal = true;
            a1 += Convert.ToDouble(txtM.Text);
            txtM.Text = a1 + "";
        }

        private void btnN0_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 0;
        }

        private void btnN9_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 9;
        }

        private void btnN8_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 8;
        }

        private void btnN7_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 7;
        }

        private void btnN6_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 6;
        }

        private void btnN5_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 5;
        }

        private void btnN4_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 3;
        }

        private void btnN2_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 2;
        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            if (adadyaamal)
            {
                txtM.Text = "";
                adadyaamal = false;
            }
            txtM.Text += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtM.Text = "";
            adadyaamal = false;
            a1 = 0;
            a2 = 0;
            amaliat = "";
        }

        private void btnAbsolute_Click(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                return;
            }
            double x = 0;
            x = Convert.ToDouble(txtM.Text);

            if (x < 0)
            {
                txtM.Text = (-x) + "";
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            //log adad dar mabnaye 10 ra hesab mikonad

            if (txtM.Text == "")
            {
                return;
            }
            double x = 0;

            x = Convert.ToDouble(txtM.Text);

            //tedad dafate zarb dah
            int i = 0;

            while (x > 1)
            {
                x /= 10;
                i++;
            }

            txtM.Text = i + "";
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (page == 1)
            {
                page = 2;
                btnSecond.BackColor = Color.DeepPink;
                btnPower2.Text = "x^3";
                btnEorPI.Text = "PI";
                btnPowerX.Text = "2^x";
                btnPower.Text = "e^x";
            }
            else
            {
                page = 1;
                btnSecond.BackColor = Color.Pink;
                btnPower2.Text = "x^2";
                btnEorPI.Text = "e";
                btnPowerX.Text = "10^x";
                btnPower.Text = "^";
            }

        }

        private void btnPower2_Click(object sender, EventArgs e)
        {
            if (txtM.Text == "")
            {
                return;
            }

            double x;
            x = Convert.ToDouble(txtM.Text);

            if (page==1)
            {
                x = x * x;
            }
            else
            {
                x = x * x * x;
            }

            txtM.Text = x + "";
        }
    }
}