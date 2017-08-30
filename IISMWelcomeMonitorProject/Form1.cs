using EyeXFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISMWelcomeMonitorProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Program.EyeXHost.Connect(behaviorMap1);

            //list of all picture boxes
            PBList = tableLayoutPanel1.Controls.OfType<PictureBox>().ToList();

            foreach (PictureBox PB in PBList)
            {
                behaviorMap1.Add(PB, new GazeAwareBehavior(OnGaze));
            }
   
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //list of colored pictureboxes
      private List<PictureBox> ColoredPBList;
        //list of all picture boxes
        private List<PictureBox> PBList;
        int i = 0;

        private void OnGaze(object sender, GazeAwareEventArgs e)
        {
            //var panel = sender as Panel;
            // panel.BorderStyle = (e.HasGaze) ? BorderStyle.FixedSingle : BorderStyle.None;

            var pictureBox = sender as PictureBox;
            pictureBox.BackColor = Color.Black;
            //pictureBox.BorderStyle = BorderStyle.Fixed3D;

            //Check if all the memebers of the list has black background
            if(PBList.All(x => x.BackColor == Color.Black))
            {
                System.Diagnostics.Process.Start("http://www.iism.kit.edu/");
                this.Close();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
