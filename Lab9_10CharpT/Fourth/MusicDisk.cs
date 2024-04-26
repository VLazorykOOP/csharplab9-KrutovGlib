using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT.Fourth
{
    internal class MusicDisk
    {
        public string Title { get; set; }
        private List<Song> songs;

        public MusicDisk(string title)
        {
            Title = title;
            songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public bool RemoveSong(Song song)
        {
            return songs.Remove(song);
        }

        public void ShowContent()
        {
            Console.WriteLine($"Content of {Title}:");
            foreach (var song in songs)
            {
                Console.WriteLine(song);
            }
        }

        public bool SearchByArtist(string artist)
        {
            foreach (var song in songs)
            {
                if (song.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
