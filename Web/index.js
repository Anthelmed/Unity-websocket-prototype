import "ws";

const ws = new WebSocket('ws://192.168.1.18:8081');

window.addEventListener("deviceorientation", function(event) {
    let x = map(event.beta, -180, 180, 0, 1);
    let y = map(event.gamma, -90, 90, 0, 1);
    let z = map(event.alpha, 0, 360, 0, 1);
    
    ws.send(JSON.stringify({"x":  x, "y": y, "z": z}));
}, true);

ws.onopen = () => {
    console.log("Client - OnOpen");
};

ws.onmessage = (message) => {
    console.log("Client - OnMessage : ", message);
};

function map(value, low1, high1, low2, high2) {
    return low2 + (high2 - low2) * (value - low1) / (high1 - low1);
}

