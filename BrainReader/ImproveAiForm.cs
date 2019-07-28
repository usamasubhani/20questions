using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainReader
{
    public partial class ImproveAiForm : Form
    {
        public string question;
        public string answer;
        public bool correct;
        public ImproveAiForm()
        {
            InitializeComponent();
        }

        private void ImproveAiForm_Load(object sender, EventArgs e)
        {
            answerToolTip.SetToolTip(answerTextBox, "Enter correct answer here.");
            questionToolTip.SetToolTip(questionTextBox, "Enter a question that can distinguish between my guess and your answer.");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            question = questionTextBox.Text;
            answer = answerTextBox.Text;
            if (yesRadio.Checked)
                correct = true;
            else if (noRadio.Checked)
                correct = false;
        }
    }
}
