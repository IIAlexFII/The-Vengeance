var mysql = require("mysql");
var http = require("http");
var express = require("express");
var cors = require("cors");
var bodyparser = require("body-parser");
var playersrouter = require("./routes/player");

const hostname = "0.0.0.0";
const port = 3434;
dbconnection = mysql.createConnection({
host:"localhost",
user:"nuno",
password:"nuno97",
database:"thevengeance;"});
dbconnection.connect(function(error){
	if(error){
	throw error;
	console.log("MYSQL CONNECTION ERROR!");
	}
	console.log("Connected to DataBase!");
});	
var webservice = express();
webservice.use(cors());
webservice.use(bodyparser.json());
webservice.use("/player", playersrouter);

webservice.listen(port, hostname, () => console.log(`WebService running at http://${hostname}:${port}`));