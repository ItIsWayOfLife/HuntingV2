using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hunting
{
    class VultureBlue:Bird
    {
        public VultureBlue(int id) : base(id)
        {
            Point = 50;       

            Random random = new Random();
            Speed = random.Next(10,16);

            int[] widthStartPoints = new int[] { -100, -200, -300, -400 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(10, 500));
            PictureBox.Image = Image.FromFile(@"3.gif");
            PictureBox.Size = new System.Drawing.Size(156, 83);         
        }

        public override void Move()
        {
            X += Speed;
        }       
    }
}
