﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video;
using Accord.Video.DirectShow;

namespace BrainReader
{
    public partial class StartSessioForm : Form
    {
        FilterInfoCollection videoDevices;
        private string device;
        

        // Video device
        public string VideoDevice
        {
            get { return device; }
        }

        // Constructor
        public StartSessioForm()
        {
            InitializeComponent();

            // show device list
			try
			{
                // enumerate video devices
                videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

                if ( videoDevices.Count == 0 )
                    throw new ApplicationException( );

                // add all devices to combo
                foreach ( FilterInfo device in videoDevices )
                {
                    devicesCombo.Items.Add( device.Name );
                }
            }
            catch ( ApplicationException )
            {
                devicesCombo.Items.Add( "No local capture devices" );
                devicesCombo.Enabled = false;
                okButton.Enabled = false;
            }

            devicesCombo.SelectedIndex = 0;
        }
        


        private void okButton_Click(object sender, EventArgs e)
        {
            device = videoDevices[devicesCombo.SelectedIndex].MonikerString;
        }
    }
}
