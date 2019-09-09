using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Hunting
{
    public partial class Scene : Form
    {
        // игрок
        Player player;
        // рекордсмен
        RecordHolder recordHolder;
        // coun time
        int OneSeanTime;

        // id for PictureBox bird
        public static int idBird = 0;

        // list bird 
        List<Bird> birds = new List<Bird>();


        //bool StartGame { get; set; }

        private void NewGame()
        {
            //StartGame = true;

            // time for count
            OneSeanTime = 1000;


            player = new Player(); // create player

            recordHolder = new RecordHolder(); // create bestplayer

            label5.Text = player.Name; // display name player in label
        }


        public Scene()
        {
            InitializeComponent();

            // SceneContainer options
            SceneContainer.Height = this.Size.Height;
            SceneContainer.Width = this.Size.Width;

            Cursor = new Cursor(@"Curs.cur");    // устанавливаем курсор прицел

            // start game
            NewGame();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OneSeanTime--; // уменьшаем переменну
            label4.Text = Convert.ToString(OneSeanTime * 60 / 1000); // переводим время в секунды
            label6.Text = player.Score.ToString();

            // если время закончилось
            if (OneSeanTime == 0) // если время = 0
            {// Вызываем информационный блок

                // считываем потоком рекорд
                //
                StreamReader streamReader = new StreamReader(@"Record.txt");
                string rec = streamReader.ReadLine();
                streamReader.Close();
                //

                // если игрок набрал больше баллов чем рекорд, он становится рекордсменом
                if (player.Score > Convert.ToInt32(rec))
                {
                    recordHolder = new RecordHolder(player.Name, player.Score); // устанавл нов рекорд
                }

                // считываем потоком рекорд
                //
                streamReader = new StreamReader(@"Record.txt");
                rec = streamReader.ReadLine();
                streamReader.Close();
                //

                // выз информ блок
                DialogResult result = MessageBox.Show($"{player.Name} вы набрали (балла): {player.Score} \nРекорд: {rec} \nНачать новую игру | Выход",
                                "Игра завершена",
                                 MessageBoxButtons.YesNo);

                // при ответе да запускает новую игру
                if (result == DialogResult.Yes)
                {
                    NewGame();
                }
                // при ответе нет выходит из игры
                if (result == DialogResult.No)
                {
                    Application.Exit();
                }
            }


            // СОЗД ПТИЦ
            if (birds.Count <= 12)
                {
                    birds.Add(RandomBird());
                }


                for (int i = birds.Count - 1; i != 0; i--)
                {
                    if (birds[i] != null)
                    {
                        birds[i].Move();
                        Controls.Add(birds[i].PictureBox);



                        if (birds[i].Life == false)
                        {
                            Controls.Remove(birds[i].PictureBox);
                            birds.Remove(birds[i]);
                        }
                    }
                }


                //  SceneContainer options
                if (SceneContainer.Height != this.Size.Height || SceneContainer.Width != this.Size.Width)
                {
                    SceneContainer.Height = this.Size.Height;
                    SceneContainer.Width = this.Size.Width;
                }


                
            
        }

        // Create new bird
        private Bird RandomBird()
        {
            //an array of all birds
            Bird[] birdsType = new Bird[] {new Eagle(idBird), new PinkVulture(idBird) , new Flamingo(idBird), new Parrot(idBird), new VultureBlue(idBird) };

            // number of birds created by species
            int[] arrayBirdSpecies = new int[birdsType.Count()];

            // determination of the number of birds
            foreach (Bird b in birds)
            {
                if (b is Eagle)
                    arrayBirdSpecies[0]++;

                if (b is PinkVulture)
                    arrayBirdSpecies[1]++;

                if (b is Flamingo)
                    arrayBirdSpecies[2]++;

                if (b is Parrot)
                    arrayBirdSpecies[3]++;

                if (b is VultureBlue)
                    arrayBirdSpecies[4]++;
            }

            l1:
            Random random = new Random();
            int i = random.Next(0,5);

            // a ban on creating identical birds
            //

            // there should be no more than one eagle
            if (arrayBirdSpecies[0] >= 1 && i == 0)
                goto l1;

            //there should be no more than one flamingo
            if (arrayBirdSpecies[2] >= 1 && i == 2)
                goto l1;

            //  there should be no more than two parrots
            if (arrayBirdSpecies[3] >= 2 && i == 3)
                goto l1;
            //

            // next new id for PictureBox bird
            idBird++;


            birdsType[i].PictureBox.Click += new EventHandler((x,t)=> { player.Score += birdsType[i].Point; });

               

            return birdsType[i];
        }

        private void Scene_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer sw = new SoundPlayer(@"fire.wav");
            sw.Play();
        }

        private void Scene_Load(object sender, EventArgs e)
        {

        }

        private void ReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Управляя мышкой сбивайте птиц \nДля сбития используйте клавишу ЛКМ " +
                "\nЗа 60 секунд необходимо набрать рекордное количество баллов \nБаллы начисляются за сбитие птиц" +
                " \nБудьте внимательны, каждая птица имеет свои баллы \n(изучите какие птицы выгоднее сбивать)", "Справка");
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewGamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerForm formPlayer = new PlayerForm(); // откр форму где регестрируем игрока
            formPlayer.Owner = this;
            formPlayer.ShowDialog();

            //StreamReader streamReader = new StreamReader(@"NamePlayer.txt"); // потоком читаем
            //string s = streamReader.ReadLine();

            player = new Player(); // создаем с таким именем

            label5.Text = player.Name; // выводим в label
            //streamReader.Close(); // закр поток
            NewGame(); // вызываем метод "Новая игра"
        }

        private void ViewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            recordHolder.GetInfo();
        }
    }
}
