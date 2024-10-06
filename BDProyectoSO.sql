DROP DATABASE IF EXISTS proyecto;
CREATE DATABASE proyecto;
USE proyecto;

CREATE TABLE clase (classid INTEGER PRIMARY KEY NOT NULL, hp INTEGER, dmg INTEGER);
INSERT INTO clase(classid,hp,dmg) VALUES (1,200,40);
INSERT INTO clase(classid,hp,dmg) VALUES (2,170,60);
INSERT INTO clase(classid,hp,dmg) VALUES (3,300,30);

CREATE TABLE players (name VARCHAR(100), playerid INTEGER PRIMARY KEY AUTO_INCREMENT,class INTEGER, FOREIGN KEY (class) REFERENCES  clase(classid));
INSERT INTO players (name,class) VALUES ('Carlos',2);
INSERT INTO players (name,class) VALUES ('Juan',1);
INSERT INTO players (name,class) VALUES ('Alex',2);

CREATE TABLE juego (matchid INTEGER, winnerid INTEGER NOT NULL, loserid INTEGER NOT NULL, datetimefinish DATETIME, duration INTEGER,FOREIGN KEY (winnerid) REFERENCES  players(playerid), FOREIGN KEY (loserid) REFERENCES  players(playerid));
INSERT INTO juego(matchid,winnerid,loserid,datetimefinish,duration) VALUES (1,1,2,'2024-09-28 15:12:49',40);
INSERT INTO juego(matchid,winnerid,loserid,datetimefinish,duration) VALUES (2,1,3,'2024-09-29 11:37:32',20);
INSERT INTO juego(matchid,winnerid,loserid,datetimefinish,duration) VALUES (3,2,1,'2024-09-29 14:16:27',30);