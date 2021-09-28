using System;
using Library;

namespace music_app
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            Console.WriteLine("Welcome to your music database!");
            while (isRunning)
            {
                isRunning = UserInterface();
            }
        }
        static bool UserInterface()
        {
            Console.WriteLine("\nWhat would you like to do? Make a selection:\nEnter 1 for all artists\nEnter 2 for all albums\nEnter 3 for all songs");
            Console.WriteLine("Enter 4 for all songs longer than 3 minutes\nEnter 5 for all albums by one artist\nEnter 6 for all songs by one artist");
            Console.WriteLine("Enter 7 for total songs by artist\nEnter 8 for all songs of one genre\nEnter 9 for number of songs by album\nEnter 0 to quit");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return false;
                case "1":
                    MusicSQL.GetAllArtists();
                    break;
                case "2":
                    MusicSQL.GetAllAlbums();
                    break;
                case "3":
                    MusicSQL.GetAllSongs();
                    break;
                case "4":
                    MusicSQL.GetSongsLongerThanThreeMin();
                    break;
                case "5":
                    MusicSQL.GetAllAlbumsForOneArtist();
                    break;
                case "6":
                    MusicSQL.GetAllSongsForOneArtist();
                    break;
                case "7":
                    MusicSQL.TotalSongsByArtist();
                    break;
                case "8":
                    MusicSQL.GetAllSongsForOneGenre();
                    break;
                case "9":
                    MusicSQL.TotalSongsByAlbum();
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
            return true;
        }
    }
}
