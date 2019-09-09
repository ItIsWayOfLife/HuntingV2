using System;
using System.Windows.Forms;
using System.IO;

namespace Hunting
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();

            StreamReader streamReader = new StreamReader(@"NamePlayer.txt");
            textBox1.Text = streamReader.ReadLine();
            streamReader.Close();          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"NamePlayer.txt", textBox1.Text);  // записила в файл нового игрока
            Close();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
