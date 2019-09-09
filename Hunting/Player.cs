using System.IO;

namespace Hunting
{
    class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player()
        {
            Score = 0;

            StreamReader streamReader = new StreamReader(@"NamePlayer.txt");
            Name = streamReader.ReadLine();
            streamReader.Close();
        }
    }
}
