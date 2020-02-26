var io = require('socket.io')(process.env.PORT || 3000)
var shortid = require('shortid')

//console.log(shortid.generate())

console.log('Server connected');
var players = []
var playerCount = 0;
io.on('connection', function(socket){
	console.log('Client Connected')

	var thisClientId = shortid.generate();
	players.push(thisClientId)
	playerCount++

	//spawn all newly joined players
	socket.broadcast.emit('spawn', {id:thisClientId})
	
	players.forEach(function(playerId){

		if(playerId == thisClientId){
			return
		}

		socket.emit('spawn', {id:playerId})
		console.log('spawning player Id: ', playerId)
	})

	socket.on('yolo', function(data){
		console.log('You only yolo yolo')
		console.log(data)
	})

	socket.on('move', function(data){
		data.id = thisClientId
		console.log("player is moving", JSON.stringify(data))
		socket.broadcast.emit('move', data);
	})

	socket.on('disconnect', function(){
		console.log("player disconnected")
		playerCount--;
	})
})