sudo mysql
USE thevengeance;
CREATE TABLE players(
	id INT AUTO_INCREMENT PRIMARY KEY,
	username VARCHAR(48),
	password VARCHAR(48),
	gold INT);