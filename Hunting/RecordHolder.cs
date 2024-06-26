﻿using System;
using System.Windows.Forms;
using System.IO;

namespace Hunting
{
    // класс "Рекордсмен"
    class RecordHolder : Player
    {
       DateTime recordDate; // дата установления рекорда

        public RecordHolder()
        { }
        // конструктор
        public RecordHolder(string name, int score) 
        {
            Score = score;
            recordDate = DateTime.Now;

            NewRecord();
            newRecordHolder();
        }
        // выводит информацию о рекордсмене 
        public void GetInfo()
        {
            StreamReader streamReader = new StreamReader(@"RecordHolder.txt");
            string s = streamReader.ReadLine();
            MessageBox.Show(s, "Рекорд");
            streamReader.Close();
        }

        // метод записывает рекорд и поздравляет  
        public void NewRecord()
        {
            File.WriteAllText(@"Record.txt", Convert.ToString(Score)); // записываем рекорд 

            MessageBox.Show($"Поздравляем, вы установили новый рекорд: {Score}"); // поздравление         
        }

        // записываем рекордсмена в текст файл
        public void newRecordHolder()
        {
            string s = $"Имя: {Name}; баллы: {Score}; Дата установления рекорда: {recordDate}";
            File.WriteAllText("RecordHolder.txt", s);
        }
    }
}
