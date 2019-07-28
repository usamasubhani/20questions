using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Accord.Controls.Vision;
using Accord.Video.DirectShow;


namespace BrainReader
{
    public partial class QuestionForm : Form
    {
        public VisionForm visionForm;
        //HeadMovement h;
        //HeadController controller;
        int x = -30;
        public int yesNo = 0;
        bool checkHead;

        public QuestionForm()
        {
            InitializeComponent();
        }

        public HeadController Controller
        {
            get { return controller; }
        }
        private void QuestionForm_Load(object sender, EventArgs e)
        {
            //selectCameraToolStripMenuItem_Click(this, e);
            
        }

        private void iterate()
        {
            BTree tree = new BTree();
            
            StreamReader fileReader = new StreamReader("Files/bst.txt");
            string line = "";
            Node temp = new Node();
            temp = tree.ReadFromFile(tree.Root, fileReader, line);
            fileReader.Close();

            if(temp != null)
            {
                tree.Root = temp;
                Node prev = new Node();
                Guess(tree.Root, prev, tree);
                if(tree.updated==1)
                {
                    FileStream fs = File.Open("Files/bst.txt", FileMode.Create);
                    StreamWriter fileWriter = new StreamWriter(fs);
                    tree.WriteToFile(tree.Root,fileWriter);
                    fileWriter.Close();
                    fs.Close();
                }
            }

        }
        

        public void Guess(Node tempRoot, Node prev, BTree tree)
        {
            Node ptr = tempRoot;
            
            
            if (!tree.IsEmpty())
            {
                if (ptr.Left != null && ptr.Right != null)
                {
                    questionLabel.Text = ptr.Data;
                    //toolStripStatusLabel1.Text = "Turn right for yes, left for no.";
                    checkHead = true;
                    //if (!backgroundWorker1.IsBusy)
                      //  backgroundWorker1.RunWorkerAsync();
                    
                    //controller.Reset();
                    controller.Start();
                    SensorForm s = new SensorForm(this);
                    s.ShowDialog();
                    controller.Stop();
                    MessageBox.Show("Answer selected");
                        if(yesNo==1) //yes
                        {
                            tree.side = 1;
                            prev = ptr;
                            ptr = ptr.Right;
                            Guess(ptr, prev, tree);
                            //break;
                        }
                        else if(yesNo==2) //No
                        {
                            tree.side = 2;
                            prev = ptr;
                            ptr = ptr.Left;
                            Guess(ptr, prev, tree);
                            //break;
                        }
                        
                        
                    
                    x = -30;
                    
                    checkHead = false;
                }

                else
                {
                    questionLabel.Text = "You are thinking about  " + ptr.Data;
                    
                    controller.Start();
                    SensorForm s = new SensorForm(this);
                    s.ShowDialog();
                    controller.Stop();

                    if (yesNo == 1) //Correct Guess
                    {
                        MessageBox.Show("Like a boss.");
                        this.Close();
                    }
                    else if (yesNo == 2) //Incorrect Guess
                    {
                        ImproveAiForm improveForm = new ImproveAiForm();
                        if (improveForm.ShowDialog() == DialogResult.OK)
                        {
                            tree.updated = 1;
                            Node tempQuestion = new Node();
                            tempQuestion.Data = improveForm.question;
                            Node tempCorrect = new Node();
                            tempCorrect.Data = improveForm.answer;

                            if (tree.side == 1) //last answer was yes
                                prev.Right = tempQuestion;
                            else if (tree.side == 2) //last answer was Yes
                                prev.Left = tempQuestion;

                            if (improveForm.correct == true)
                            {
                                tempQuestion.Right = tempCorrect;
                                tempQuestion.Left = ptr;
                                return;
                            }
                            else if (improveForm.correct == false)
                            {
                                tempQuestion.Left = tempCorrect;
                                tempQuestion.Right = ptr;
                                return;
                            }
                        }
                    }
                        x = 0;
                    
                }

            }
        }

        

        private static VideoCapabilities selectResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 240)
                    return cap;
                if (cap.FrameSize.Width == 320)
                    return cap;
            }

            return device.VideoCapabilities.Last();
        }

        private void controller_HeadMove(object sender, Accord.Controls.Vision.HeadEventArgs e)
        {
            x = (int)(e.X * 20f);
            //toolStripStatusLabel1.Text = x.ToString();
            //label1.Text = e.X.ToString();
            //label2.Text = e.Y.ToString();
            //label3.Text = x.ToString();
            
        }

        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);

            // stop current video source
            controller.SignalToStop();

            Properties.Settings.Default.Save();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // stop current video source
            controller.SignalToStop();

            Properties.Settings.Default.Save();
        }

        private void selectCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSessioForm form = new StartSessioForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
               VideoCaptureDevice device = new VideoCaptureDevice(form.VideoDevice);

                device.VideoResolution = selectResolution(device);

                controller.Device = device;

                //controller.Start();

                //if (visionForm == null || visionForm.IsDisposed)
                   // visionForm = new VisionForm(this);

                //visionForm.Show();

                iterate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iterate();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            controller.Reset();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            controller.Stop();
            this.Close();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            controller.Start();
            if (checkHead)
            {
                while (x >= -36 || x <= -24)
                {
                    if (x <= -36)
                    {
                        yesNo = 1; break;
                    }
                    else if (x >= -24)
                    {
                        yesNo = 2; break;
                    }
                }
            }
            controller.Stop();
        }

    }
}
