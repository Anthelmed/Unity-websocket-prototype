const WebSocket = require('ws');

const wss = new WebSocket.Server({ port: 8081 });

wss.on('connection', function connection(ws) {
    console.log("Server - OnConnection");
    
    ws.on('message', function incoming(data) {
        console.log("Server - OnMessage :", data);
        
        wss.clients.forEach(function each(client) {
            if (client !== ws && client.readyState === WebSocket.OPEN) {
                client.send(data);
            }
        });
        
    });
});