using EyeXFramework;
using EyeXFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.EyeX.Framework;

namespace IISMWelcomeMonitorProject
{
    public partial class CalibrationForm : Form
    {
        private readonly FormsEyeXHost _eyeXHost;

        public CalibrationForm()
        {
            InitializeComponent();


            // Create the EyeX host.
            _eyeXHost = new FormsEyeXHost();

        }


        protected override void OnLoad(EventArgs e)
        {
            // Register an status-changed event listener for user presence.
            // NOTE that the event listener must be unregistered too. This is taken care of in the Dispose(bool) method.
            _eyeXHost.UserPresenceChanged += EyeXHost_UserPresenceChanged;
            _eyeXHost.GazeTrackingChanged += EyeXHost_GazeTrackingChanged;

            // Start the EyeX host.
            _eyeXHost.Start();

            // Wait until we're connected.
            if (_eyeXHost.WaitUntilConnected(TimeSpan.FromSeconds(5)))
            {
                // Make sure the EyeX Engine version is equal to or greater than 1.4.
                var engineVersion = _eyeXHost.GetEngineVersion().Result;
                if (engineVersion.Major != 1 || engineVersion.Major == 1 && engineVersion.Minor < 4)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Could not connect to EyeX engine.");
            }
        }


        private void EyeXHost_GazeTrackingChanged(object sender, EngineStateValue<GazeTracking> e)
        {
            // State-changed events are received on a background thread.
            // But operations that affect the GUI must be executed on the main thread.
            // We use BeginInvoke to marshal the call to the main thread.

            if (Created)
            {
                BeginInvoke(new Action(() =>
                {
                    if (e.IsValid && e.Value == GazeTracking.GazeTracked)
                    {
                        BackActivationMode("true");
                    }
                    else
                    {
                        BackActivationMode("false");

                    }
                }));
            }
        }

        private void EyeXHost_UserPresenceChanged(object sender, EngineStateValue<UserPresence> e)
        {
            // State-changed events are received on a background thread.
            // But operations that affect the GUI must be executed on the main thread.
            // We use BeginInvoke to marshal the call to the main thread.

            if (Created)
            {
                BeginInvoke(new Action(() => UpdateUserPresence(e)));
            }
        }

        private void UpdateUserPresence(EngineStateValue<UserPresence> value)
        {
            if (value.IsValid &&
                value.Value == UserPresence.Present)
            {

                BackActivationMode("true");

            }
            else
            {
              
                BackActivationMode("false");

            }
        }

        private void BackActivationMode(string v)
        {
            if (v == "false")
            {
                
                timer1.Stop();
                i = 0;
                panel3.Visible = false;
                button1.Visible = false;
                label3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                
            }
            else if (v == "true")
            {
                
                panel3.Visible = true;
                label1.Visible = true;
                label3.Visible = true;
                label2.Visible = true;

                i = 0;
                timer1.Start();
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        private void CalibrationForm_Load(object sender, EventArgs e)
        {

            
        }

        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //label3.Visible = !label3.Visible;

            i++;
            label3.Text = i.ToString();

            if (i == 10)
            {
                timer1.Stop();
                button1.Visible = true;
                label3.Visible = false;
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 paintform = new Form1();
          
            paintform.Show();
            this.Hide();
           
        }
    }
}
