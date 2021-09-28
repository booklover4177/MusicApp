using System;
using Microsoft.Data.Sqlite;

namespace Library
{
    public class MusicSQL
    {
        public static void GetAllArtists()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                select artists.name
                from artists
            ";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var artistName = reader.GetString(0);
                Console.WriteLine($"Artist Name: {artistName}");
            }
        }

        public static void GetAllAlbums()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                select Albums.albumname
                from Albums
            ";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var albumName = reader.GetString(0);
                Console.WriteLine($"Album Name: {albumName}");
            }
        }

        public static void GetAllSongs()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                select Songs.songname
                from Songs
            ";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var songName = reader.GetString(0);
                Console.WriteLine($"Song Name: {songName}");
            }
        }

        public static void GetSongsLongerThanThreeMin()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT Songs.songname, Songs.length
                FROM Songs
                WHERE length > 3;
            ";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var songName = reader.GetString(0);
                var songLength = reader.GetString(1).Replace('.', ':');

                Console.WriteLine($"Song: {songName} Length: {songLength}");
            }
        }

        public static void GetAllAlbumsForOneArtist()
        {
            Console.WriteLine("Enter Artist's name: ");
            var inputArtistName = Console.ReadLine();

            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT al.albumname
                FROM Albums al
                JOIN artists ON al.artists_id = artists.id
                WHERE artists.name = $inputArtistName;
            ";

            command.Parameters.AddWithValue("$inputArtistName", inputArtistName);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var albumName = reader.GetString(0);
                Console.WriteLine($"Album: {albumName}");
            }
        }

        public static void GetAllSongsForOneArtist()
        {
            Console.WriteLine("Enter Artist's name: ");
            var inputArtistName = Console.ReadLine();

            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                Select s.songname, al.albumname
                From Albums al
                JOIN Songs s on s.album_id=al.id
                JOIN artists a on a.id=al.artists_id
                WHERE a.name= $inputArtistName;
            ";

            command.Parameters.AddWithValue("$inputArtistName", inputArtistName);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var songName = reader.GetString(0);
                var albumName = reader.GetString(1);

                Console.WriteLine($"Song: {songName} Album: {albumName}");
            }
        }

        public static void TotalSongsByArtist()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                Select count(s.id) AS Total_Songs, a.name
                From Songs s
                Join Albums al on al.id=s.album_id
                Join artists a on a.id=al.artists_id
                Group BY a.id
                ORDER BY Total_Songs;
            ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var totalSongs = reader.GetInt32(0);
                var artistName = reader.GetString(1);

                Console.WriteLine($"Artist: {artistName} Number of Songs: {totalSongs}");
            }
        }

        public static void GetAllSongsForOneGenre()
        {
            Console.WriteLine("Enter genre name: ");
            var inputGenre = Console.ReadLine();

            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT Songs.songname, artists.name, Albums.albumname, Songs.length
                FROM Songs
                JOIN Albums ON Albums.id=Songs.album_id
                JOIN Artists ON artists.id=Albums.artists_id
                WHERE genre= $genre;
            ";

            command.Parameters.AddWithValue("$genre", inputGenre);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var songName = reader.GetString(0);
                var artistName = reader.GetString(1);
                var albumName = reader.GetString(2);
                var songLength = reader.GetString(3).Replace('.', ':');

                Console.WriteLine($"Song: {songName} Artist: {artistName} Album: {albumName} Length: {songLength}");
            }
        }

        public static void TotalSongsByAlbum()
        {
            using var connection = new SqliteConnection("Data Source=./data/music.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
            @"
                SELECT count(Songs.id) AS Total_Songs, Albums.albumname
                FROM Songs
                JOIN Albums ON Albums.id = Songs.album_id
                GROUP BY Albums.albumname
                ORDER BY Total_Songs;
            ";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var totalSongs = reader.GetInt32(0);
                var albumName = reader.GetString(1);

                Console.WriteLine($"Album: {albumName} Number of songs: {totalSongs} ");
            }
        }
    }

}
