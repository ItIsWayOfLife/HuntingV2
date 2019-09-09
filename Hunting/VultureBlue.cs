using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunting
{
    class VultureBlue:Bird
    {
        public VultureBlue(int id) : base(id)
        {
            Point = 50;
        

            Random random = new Random();
            Speed = random.Next(6,8);

            int[] widthStartPoints = new int[] { -200, -400, -600, -800 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(10, 500));
            PictureBox.Image = Image.FromFile(@"3.gif");
            PictureBox.Size = new System.Drawing.Size(156, 83);
           

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
            X += Speed;
        }

        
    }
}
