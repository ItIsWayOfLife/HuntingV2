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


            Speed = random.Next(7,13);


            int[] widthStartPoints = new int[] { SceneContainer.Width + 500, SceneContainer.Width + 600, SceneContainer.Width + 700 };


            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(10, 200));
            PictureBox.Image = Image.FromFile(@"4.gif");
            PictureBox.Size = new System.Drawing.Size(194, 119);
           

            // when you click on PictureBox methods are called
            //
            //  PictureBox.Click += new System.EventHandler();
            //   PictureBox.Click += new System.EventHandler();
            //

        }

        public override Bird Death()
        {
            Life = false;
            Cry();
            return null;
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
