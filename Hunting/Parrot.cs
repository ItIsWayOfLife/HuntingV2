using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Hunting
{
    class Parrot : Bird
    {

        public Parrot(int id) : base(id)
        {
            Point = 50;
            Random random = new Random();


            Speed = random.Next(3,7);

            

            int[] widthStartPoints = new int[] { SceneContainer.Width + 150, SceneContainer.Width + 250, SceneContainer.Width + 500 };
               

            PictureBox.Location = new Point(widthStartPoints[random.Next(0,widthStartPoints.Length)], random.Next(200, 600));
            PictureBox.Image = Image.FromFile(@"1.gif");
            PictureBox.Size = new System.Drawing.Size(156, 83);
          
           

         

            // when you click on PictureBox methods are called
            //

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
