-- Nás Botond
-- Neptun: KHUPIB


-- Tables: Song, Artist, Service, Listener, conn_listener_song, conn_song_service
-- References:
-- cars -> brands
-- conn -> cars
-- conn -> extras

-- DROP: conn_listener_song, conn_song_service, songs, artists, listeners, services //remove the left side first
-- CREATE: services, listeners, artists, songs, conn_song_service, conn_listener_song //add right side first
--USE DM_Project_KHUPIB
--GO


IF object_id('conn_listener_song', 'U') is not null DROP TABLE conn_listener_song;
IF object_id('conn_song_service', 'U') is not null DROP TABLE conn_song_service;
IF object_id('songs', 'U') is not null DROP TABLE songs;
IF object_id('artists', 'U') is not null DROP TABLE artists;
IF object_id('listener', 'U') is not null DROP TABLE listener;
IF object_id('servs', 'U') is not null DROP TABLE servs;
GO

CREATE TABLE servs (
	serv_id int primary key, -- first field is almost always an id primary key
	serv_name nvarchar(100), -- always use nvarchar(N) because you might use non english characters, also size of N isn't a problem unless you have more than 200 fields
	serv_size int,
	serv_website nvarchar(100),
	serv_price int,
	serv_country nvarchar(100)

);

CREATE TABLE listener (
	listener_id int primary key,
	listener_name nvarchar(200),
	listener_country nvarchar(100),
	listener_deviceType nvarchar(200),
	listener_email nvarchar(200),
	listener_gender nvarchar(20)
);

CREATE TABLE artists (
	artist_id int primary key,
	artist_name nvarchar(200),
	artist_label nvarchar(200),
	artist_age int,
	artist_gender nvarchar(20),
	artist_genre nvarchar(200)
);

CREATE TABLE songs (
	song_id int primary key,
	song_title nvarchar(200),
	song_album nvarchar(200),
	song_length int,
	song_explicit bit,
	song_dateReleased date,
	song_artistId int references artists(artist_id)
);


CREATE TABLE conn_song_service ( -- for many to many relationships
	connOne_id int IDENTITY primary key,
	connOne_songId int references songs(song_id),
	connOne_serviceId int references servs(serv_id),	
	CONSTRAINT chk_unique1 UNIQUE (connOne_songId, connOne_serviceId)	
);


CREATE TABLE conn_listener_song (
	connTwo_id int IDENTITY primary key,
	connTwo_listenerId int references listener(listener_id),
	connTwo_songId int references songs(song_id),
	CONSTRAINT chk_unique2 UNIQUE (connTwo_listenerId, connTwo_songId)
);
GO

INSERT INTO servs VALUES (1, 'Spotify', 83, 'spotify.com', 10, 'Sweden');
INSERT INTO servs VALUES (2, 'Apple Music', 50, 'apple.com', 10, 'USA');
INSERT INTO servs VALUES (3, 'Soundcloud', 175, 'soundcloud.com', 0, 'Sweden');
INSERT INTO servs VALUES (4, 'Tidal', 14, 'tidal.com', 10, 'Norway');
INSERT INTO servs VALUES (5, 'YouTube Music', 2, 'youtube.com', 10, 'USA');
INSERT INTO servs VALUES (6, 'Amazon Music Unlimited', 5, 'music.amazon.com', 10, 'USA');

INSERT INTO listener VALUES (1, 'Bill Hader', 'United Kingdom', 'PC', 'bill.bill@gmail.com', 'Male');
INSERT INTO listener VALUES (2, 'Bence Mészáros', 'Hungary', 'Android', 'bence123@gmail.com', 'Male');
INSERT INTO listener VALUES (3, 'Judy Jones', 'USA', 'Mac', 'judy.b.jones@yahoo.com', 'Female');
INSERT INTO listener VALUES (4, 'Stewart Griffin', 'USA', 'iPhone', 'stewie@hotmail.com', 'Male');
INSERT INTO listener VALUES (5, 'Consuela', 'Mexico', 'PC', 'nonono@gmail.com', 'Female');

INSERT INTO artists VALUES (1, 'JAY Z', 'ROC-A-FELLA RECORDS', 48, 'Male', 'Hip-Hop');
INSERT INTO artists VALUES (2, 'Yo-Yo Ma', 'Sony Classical Records', 63, 'Male', 'Classical');
INSERT INTO artists VALUES (3, 'Sting', 'A&M Records', 67, 'Male', 'Rock');
INSERT INTO artists VALUES (4, 'Rihanna', 'Def Jam Recordings', 30, 'Female', 'Pop');
INSERT INTO artists VALUES (5, 'Janis Joplin', 'Columbia Records', null, 'Female', 'Soul');

INSERT INTO songs VALUES (1, 'Me and Bobby McGee', 'Pearl', 271, 0, '1971-01-17', 5);
INSERT INTO songs VALUES (2, 'Shape of My Heart', 'Ten Summoners Tales', 279, 0, '1993-03-09', 3);
INSERT INTO songs VALUES (3, 'Unaccompanied Cello Suite No. 1 in G Major, BMV 1007: I. Prélude', 'Six Evolutions - Bach: Cello Suites', 150, 0, '2018-09-17', 2);
INSERT INTO songs VALUES (4, 'Needed Me', 'ANTI', 191, 1, '2016-01-27', 4);
INSERT INTO songs VALUES (5, 'The Story of OJ.', '4:44', 231, 1, '2017-06-30', 1);
INSERT INTO songs VALUES (6, 'Kill Jay Z', '4:44', 178, 1, '2017-06-30', 1);

 

INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (1, 4);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (1, 6);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (2, 5);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (2, 1);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (3, 6);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (3, 5);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (4, 1);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (5, 2);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (6, 4);
INSERT INTO conn_song_service (connOne_songId, connOne_serviceId) VALUES (6, 2); 

INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (1, 6);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (1, 1);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (2, 4);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (3, 6);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (2, 6);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (5, 1);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (5, 3);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (4, 2);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (5, 2);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (3, 4);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (1, 5);
INSERT INTO conn_listener_song (connTWO_listenerId, connTwo_songId) VALUES (2, 1);

GO