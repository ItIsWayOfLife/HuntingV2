using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Hunting
{
    class PinkVulture : Bird
    {
        public PinkVulture(int id):base(id)
        {
            Point = 50;

            Random random = new Random();
            Speed = random.Next(6, 9);

            int[] widthStartPoints = new int[] { SceneContainer.Width + 150, SceneContainer.Width + 250, SceneContainer.Width + 500 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(200,450));
            PictureBox.Image = Image.FromFile(@"2.gif");
            PictureBox.Size = new System.Drawing.Size(140, 65);
          

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
            X-=Speed ;
            
        }

        
    }
}
