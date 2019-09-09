using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Hunting
{
    class Parrot : Bird
    {
        public Parrot(int id) : base(id)
        {
            Point = 50;
            Random random = new Random();

            Speed = random.Next(6,10);
         
            int[] widthStartPoints = new int[] { SceneContainer.Width + 150, SceneContainer.Width + 250, SceneContainer.Width + 400 };
               
            PictureBox.Location = new Point(widthStartPoints[random.Next(0,widthStartPoints.Length)], random.Next(200, 600));
            PictureBox.Image = Image.FromFile(@"1.gif");
            PictureBox.Size = new System.Drawing.Size(156, 83);
        }


        public override void Move()
        {
            X -= Speed;
            MotionVariable++;

            if (MotionVariable > 20)
            {
                Y++;
            }
        }

        protected override void Cry()
        {
            SoundPlayer sw2 = new SoundPlayer(@"parrot.wav");
            sw2.Play();
        }
    }
}
