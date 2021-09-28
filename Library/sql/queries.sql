Select * from artists;
Select * from Albums;
Select * from Songs;

--Get all songs longer than 3 min
-- SELECT *
-- FROM Songs
-- Where length>3;

--find all albums by a particular artist
-- Select *
-- FROM Albums al
-- JOIN artists on al.artists_id=artists.id
-- Where artists.name='Icon For Hire';

--find all songs by a particular artist
-- Select s.songname, al.albumname, a.name
-- From Albums al
-- JOIN Songs s on s.album_id=al.id
-- JOIN artists a on a.id=al.artists_id
-- WHERE a.name='Polaris';

--find total number of songs by artist
-- Select count(s.id) AS Total_Songs, a.name
-- From Songs s
-- Join Albums al on al.id=s.album_id
-- Join artists a on a.id=al.artists_id
-- Group BY a.id
-- ORDER BY Total_Songs;

-- --find songs of a certain genre
-- SELECT Songs.songname, artists.name, Albums.albumname, Songs.genre, Songs.length
-- FROM Songs
-- JOIN Albums ON Albums.id=Songs.album_id
-- JOIN Artists ON artists.id=Albums.artists_id
-- WHERE genre='Rock';

-- --find number of songs by album
-- SELECT count(Songs.id) AS Total_Songs, Albums.albumname
-- FROM Songs
-- JOIN Albums ON Albums.id = Songs.album_id
-- GROUP BY Albums.albumname
-- ORDER BY Total_Songs;
