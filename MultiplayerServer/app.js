var io = require('socket.io')(process.env.PORT || 3000)

console.log('Server connected');
var players = 0
io.on('connection', function(socket){
	console.log('Client Connected')

	//spawn all newly joined players
	socket.broadcast.emit('spawn')
	players++;
	
	for(var i = 0; i < players; i++){
		//spawns player character
		socket.emit('spawn')
		console.log('spawning player')
	}

	socket.on('yolo', function(data){
		console.log('You only yolo yolo')
		console.log(data)
	})

	socket.on('move', function(data){
		console.log("player is moving", JSON.stringify(data))
		socket.broadcast.emit('move', data);
	})

	socket.on('disconnect', function(){
		console.log("player disconnected")
		players--;
	})
})