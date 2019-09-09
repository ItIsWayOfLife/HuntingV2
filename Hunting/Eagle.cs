using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Hunting
{
    class Eagle:Bird
    {
        public Eagle(int id):base(id)
        {
            Point = 50;
         
            Random random = new Random();

            Speed = random.Next(20,25);

            int[] widthStartPoints = new int[] { SceneContainer.Width + 200, SceneContainer.Width + 300, SceneContainer.Width + 400 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(10, 200));
            PictureBox.Image = Image.FromFile(@"4.gif");
            PictureBox.Size = new System.Drawing.Size(194, 119);           
        }

        public override void Move()
        {
            X -= Speed;
        }

        protected override void Cry()
        {
            SoundPlayer sw = new SoundPlayer(@"eagle.wav");
            sw.Play();
        }
    }
}
