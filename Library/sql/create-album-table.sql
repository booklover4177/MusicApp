CREATE Table Albums(

id integer PRIMARY KEY AUTOINCREMENT,
artists_id integer,
albumname varchar(30),
FOREIGN KEY(artists_id) REFERENCES artists(id)

);