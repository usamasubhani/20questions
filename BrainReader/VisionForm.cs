using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Accord.Controls.Vision;
using Accord.Imaging.Filters;
using Accord.Vision.Tracking;
using Accord.Video;

namespace BrainReader
{
    public partial class VisionForm : Form
    {
        QuestionForm parent;
        HeadController controller;
        RectanglesMarker marker = new RectanglesMarker(Color.Blue);

        bool backproj = true;

        public VisionForm()
        {
            InitializeComponent();
        }

        public VisionForm(QuestionForm  mainForm)
            : this()
        {
            this.parent = mainForm;
            this.controller = mainForm.controller;
            this.controller.HeadMove += controller_HeadMove;
            this.controller.NewFrame += controller_NewFrame;
        }

        void controller_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!backproj)
            {
                Bitmap image = eventArgs.Frame;

                if (image == null)
                    return;

                //if (parent.faceForm != null && !parent.faceForm.IsDisposed)
                //{
                //    MatchingTracker matching = parent.faceForm.faceController.Tracker as MatchingTracker;

                //    Rectangle rect = new Rectangle(
                //        matching.TrackingObject.Center.X,
                //        0,
                //        image.Width - matching.TrackingObject.Center.X,
                //        matching.TrackingObject.Center.Y);


                //    rect.Intersect(new Rectangle(0, 0, image.Width, image.Height));

                //    marker.Rectangles = new[] { matching.TrackingObject.Rectangle };
                //    image = marker.Apply(image);
                //}


                pictureBox.Image = image;
            }
        }


        void controller_HeadMove(object sender, HeadEventArgs e)
        {
            if (controller == null || controller.Tracker == null)
                return;

            if (backproj)
            {
                try
                {
                    Camshift camshift = controller.Tracker as Camshift;

                    Bitmap backprojection = camshift.GetBackprojection(
                        PixelFormat.Format24bppRgb, camshift.TrackingObject.Rectangle);

                    //if (parent.faceForm != null && !parent.faceForm.IsDisposed)
                    //{
                    //    MatchingTracker matching = parent.faceForm.faceController.Tracker as MatchingTracker;

                    //    marker.Rectangles = new[] { matching.TrackingObject.Rectangle };
                    //    marker.ApplyInPlace(backprojection);
                    //}


                    pictureBox.Image = backprojection;
                }
                catch
                {
                    pictureBox.Image = null;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backproj)
            {
                button1.Text = "Standard";
                backproj = false;
            }
            else
            {
                button1.Text = "Backprojection";
                backproj = true;
            }
        }

    }
}
