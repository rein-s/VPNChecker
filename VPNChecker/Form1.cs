using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPNChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            checkVPN();
        }


        private void behindVPN()
        {
            BackColor = Color.DarkGreen;
            label1.Text = "Behind VPN";
            positionLabel();
        }

        private void notBehindVPN()
        {
            BackColor = Color.DarkRed;
            label1.Text = "NOT behind VPN";
            positionLabel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkVPN();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            positionLabel();
        }

        private void positionLabel()
        {
            label1.AutoSize = true;
            label1.Anchor = AnchorStyles.None;
            label1.TextAlign = ContentAlignment.MiddleCenter;

            // Calculate the position of the label
            int labelX = (ClientSize.Width - label1.Width) / 2;
            int labelY = (ClientSize.Height - label1.Height) / 2;
            label1.Location = new Point(labelX, labelY);
        }

        private void checkVPN()
        {
            bool isBehindVPN = VPNChecker.IsBehindVPN();
            if (isBehindVPN)
            {
                behindVPN();
            }
            else
            {
                notBehindVPN();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
