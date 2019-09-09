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
    class Flamingo:Bird
    {
        public Flamingo(int id) : base(id)
        {
            Point = 50;

            Random random = new Random();
            Speed = random.Next(3, 6);

            int[] widthStartPoints = new int[] {-200, -400, -600 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], SceneContainer.Height-150 );
            PictureBox.Image = Image.FromFile(@"0.gif");
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
            X +=Speed;
        }

       
    }
}
