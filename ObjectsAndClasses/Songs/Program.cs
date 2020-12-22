using System;
using System.Collections.Generic;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] songData = Console.ReadLine().Split("_");
                Song song = new Song();
                song.TypeList = songData[0];
                song.Name = songData[1];
                song.Time = songData[2];
                songs.Add(song);
            }
            string typeList = Console.ReadLine();
            if (typeList == "all") foreach (Song song in songs) Console.WriteLine(song.Name);
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList) Console.WriteLine(song.Name);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
