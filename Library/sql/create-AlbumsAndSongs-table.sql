Create table AlbumsAndSongs(

song_id integer,
album_id integer,
FOREIGN KEY(song_id) REFERENCES Songs(id),
FOREIGN KEY(album_id) REFERENCES Albums(id)

);