var express = require("express");
var router = express.Router();

router.get("/list", function(req, res){
	var sql = "SELECT username, score FROM players";
	dbconnection.query(sql, function(error, players, fields){	
		if(error){ throw error;}
		res.json({players});
	});
	
});


router.post("/new", function(req,res){
	var sql = "INSERT INTO players (username, password, score) VALUES (?)";
	var values = [req.body.username,
			req.body.password,
			0];
		dbconnection.query(sql,[values],function(error, players, fields){
			if(error)
			{
				throw error;
			}	
			res.json({status: 200, message: "New player was added!"});
		});
});

router.post("/login", function(req, res){
	var sql = "SELECT username, score, id FROM players WHERE username ='" + req.body.username + "'AND password ='" + req.body.password + "'";
	
	dbconnection.query(sql, function(error, players, fields){
			if(error)
			{
				throw error;
			}
			res.json(players[0])
		});
});

router.post("/updatescore",function(req,res){
	var sql = "UPDATE players SET score = ? WHERE id = ?";
	var values = [req.body.score,
			req.body.id];
	dbconnection.query(sql,values,function(error, players, fields){
			if(error)
			{
				throw error;
			}	
			res.json({status: 200, message: "Score updated!"});
		});		
	
});