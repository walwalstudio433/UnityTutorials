io = require('socket.io')(4567);

io.on 'connection', (socket) ->
  socket.on 'join', () ->
    socket.emit 'join'

  socket.on 'Fly', (position) ->
    console.log "#{socket.id}: #{JSON.stringify(position)}"
    io.emit("Fly", {
      birdId: socket.id
      position: position
    })
