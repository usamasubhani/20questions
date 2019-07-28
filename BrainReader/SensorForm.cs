using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Controls.Vision;
using Accord.Video.DirectShow;

namespace BrainReader
{
    public partial class SensorForm : Form
    {
        QuestionForm parent;
        int x = -30;
        public SensorForm()
        {
            InitializeComponent();
        }

        public SensorForm(QuestionForm parentForm) 
            : this()
        {
            this.parent = parentForm;
            this.controller = parentForm.controller;
            this.controller.HeadMove += controller_HeadMove;
        }
        private void controller_HeadMove(object sender, Accord.Controls.Vision.HeadEventArgs e)
        {
            //x = -30;
            x = (int)(e.X * 20f);
            
            switch (x)
            {
                case -30:
                    yesProgressBar.Value = 0;
                    noProgressBar.Value = 0;
                    break;
                case -32:
                    yesProgressBar.Value = 30;
                    break;
                case -34:
                    yesProgressBar.Value = 60;
                    break;
                case -35:
                    yesProgressBar.Value = 90;
                    break;
                case -36:
                    yesProgressBar.Value = 100;
                    break;
                
                case -28:
                    noProgressBar.Value = 30;
                    break;
                case -25:
                    noProgressBar.Value = 60;
                    break;
                case -22:
                    noProgressBar.Value = 90;
                    break;
                case -24:
                    noProgressBar.Value = 100;
                    break;

            }
            if (x == -36)
            {
                parent.yesNo = 1;
                
                this.Close();
            }
            else if (x == -22)
            {
                parent.yesNo = 2;
                //MessageBox.Show("No Selected");
                this.Close();
            }
        }

        private void controller_HeadLeave(object sender, EventArgs e)
        {
            
        }

        private void controller_HeadEnter(object sender, Accord.Controls.Vision.HeadEventArgs e)
        {
            
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            parent.yesNo = 1;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            parent.yesNo = 2;
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
