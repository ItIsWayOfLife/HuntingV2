using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hunting
{
    class PinkVulture : Bird
    {
        int iTrajectory;

        public PinkVulture(int id) : base(id)
        {
            Point = 50;

            Random random = new Random();
            Speed = random.Next(9, 15);

            iTrajectory = 1;

            int[] widthStartPoints = new int[] { SceneContainer.Width + 100, SceneContainer.Width + 200, SceneContainer.Width + 400 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(200, 450));
            PictureBox.Image = Image.FromFile(@"2.gif");
            PictureBox.Size = new System.Drawing.Size(140, 65);
        }

        public override void Move()
        {
            X -= Speed;


        }
    }
}
