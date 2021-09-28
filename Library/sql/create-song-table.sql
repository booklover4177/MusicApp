CREATE TABLE Songs(

id integer PRIMARY KEY AUTOINCREMENT,
songname varchar(20),
album_id integer,
genre varchar(20),
length real,
FOREIGN KEY(album_id) REFERENCES Albums(id)

);