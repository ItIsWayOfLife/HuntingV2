using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hunting
{
    class Flamingo:Bird
    {
        public Flamingo(int id) : base(id)
        {
            Point = 50;

            Random random = new Random();
            Speed = random.Next(3, 8);

            int[] widthStartPoints = new int[] {-100, -200, -300 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], SceneContainer.Height-150 );
            PictureBox.Image = Image.FromFile(@"0.gif");
            PictureBox.Size = new System.Drawing.Size(194, 119);
        }

        public override void Move()
        {
            X +=Speed;
        }       
    }
}
