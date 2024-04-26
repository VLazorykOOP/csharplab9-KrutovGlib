using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT.Fourth
{
    internal class MusicCatalog
    {
        private Hashtable disks { get; set; }


        public MusicCatalog()
        {
            disks = new Hashtable();
        }

        public void AddDisk(string title)
        {
            disks[title] = new MusicDisk(title);
        }

        public bool RemoveDisk(string title)
        {
            if (disks.ContainsKey(title))
            {
                disks.Remove(title);
                return true;
            }
            return false;
        }

        public void AddSongToDisk(string diskTitle, Song song)
        {
            if (disks.ContainsKey(diskTitle))
            {
                ((MusicDisk)disks[diskTitle]).AddSong(song);
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' not found.");
            }
        }

        public bool RemoveSongFromDisk(string diskTitle, Song song)
        {
            if (disks.ContainsKey(diskTitle))
            {
                return ((MusicDisk)disks[diskTitle]).RemoveSong(song);
            }
            Console.WriteLine($"Disk '{diskTitle}' not found.");
            return false;
        }

        public void ShowCatalog()
        {
            Console.WriteLine("Catalog:");
            foreach (DictionaryEntry disk in disks)
            {
                ((MusicDisk)disk.Value).ShowContent();
            }
        }

        public void ShowDiskContent(string diskTitle)
        {
            if (disks.ContainsKey(diskTitle))
            {
                ((MusicDisk)disks[diskTitle]).ShowContent();
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' not found.");
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Search results for artist '{artist}':");
            foreach (DictionaryEntry disk in disks)
            {
                if (((MusicDisk)disk.Value).SearchByArtist(artist))
                {
                    Console.WriteLine($"Found in {((MusicDisk)disk.Value).Title}");

                }
            }
        }

    }
}
