using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Hunting
{
    abstract class Bird
    {

        

        public Bird(int id)
        {
            Life = true;

            PictureBox.TabIndex = id;
            PictureBox.TabStop = false;
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.Anchor = AnchorStyles.Right;
            PictureBox.Anchor = AnchorStyles.Top;

            PictureBox.Click += new EventHandler((x, t) => { Death(); });

        }

        // motion variable
        public static int MotionVariable { get; set; }

        // kill points
        public int Point { get; protected set; }

        public int Speed { get; protected set; }

        public PictureBox PictureBox = new PictureBox(); 

        // variable life
        public bool Life { get; protected set; }

        // cry bird
        protected virtual void Cry()
        {
            SoundPlayer sw = new SoundPlayer(@"fire.wav");
            sw.Play();
        }

        // death  bird
        public abstract Bird Death();

        // move bird
        public abstract void Move();

        // coordinates Bird
        public int X
        {
            get
            {
                return PictureBox.Left;
            }
            set
            {
                PictureBox.Left = value;
            }
        }
        public int Y
        {
            get
            {
                return PictureBox.Top;
            }
            set
            {
                PictureBox.Top = value;
            }
        }
    }
}
