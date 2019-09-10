using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hunting
{
    class VultureBlue:Bird
    {
        int dinamic;
        public VultureBlue(int id) : base(id)
        {
            Point = 50;       

            Random random = new Random();
            Speed = random.Next(10,16);

            dinamic = random.Next(0, 3);

            int[] widthStartPoints = new int[] { -100, -200, -300, -400 };

            PictureBox.Location = new Point(widthStartPoints[random.Next(0, widthStartPoints.Length)], random.Next(10, 500));
            PictureBox.Image = Image.FromFile(@"3.gif");
            PictureBox.Size = new System.Drawing.Size(156, 83);         
        }

        public override void Move()
        {
            MotionVariable++;

            if (dinamic == 0)
            {
                X += Speed;
            }
            else if (dinamic == 1)
            {
                if (MotionVariable >= 0 && MotionVariable <= 30)
                {
                    X += Speed;
                }
                else if (MotionVariable > 30 && MotionVariable <= 60)
                {
                    X += Speed;
                    Y -= 2;
                }
                else if (MotionVariable > 60 && MotionVariable <= 85)
                {
                    X += Speed;
                }
                else if (MotionVariable > 85 && MotionVariable <= 110)
                {
                    X += Speed + 2;
                    Y++;
                }
                else if (MotionVariable > 110 && MotionVariable <= 130)
                {
                    X += Speed;
                    Y -= 2;
                }
                else
                {
                    X += Speed;
                }
            }
            else if (dinamic == 2)
            {
                if (MotionVariable >= 0 && MotionVariable <= 30)
                {
                    X += Speed - 1;
                }
                else if (MotionVariable > 20 && MotionVariable <= 50)
                {
                    X += Speed;
                    Y += 3;
                }
                else if (MotionVariable > 50 && MotionVariable <= 85)
                {
                    X += Speed - 1;
                }
                else if (MotionVariable > 85 && MotionVariable <= 120)
                {
                    X += Speed + 2;
                    Y++;
                }
                else if (MotionVariable > 120 && MotionVariable <= 135)
                {
                    X += Speed - 4;
                    Y -= 3;
                }
                else
                {
                    X += Speed;
                }
            }
        }  
    }
}
