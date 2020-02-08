const host = `ws://${ location.hostname }:57772`;
const myName = "Тимофей";
const myAvatar = "https://pp.userapi.com/c840227/v840227058/862e8/ZDaOiXuBcL8.jpg";

let URL = host + "/csp/chat/CHAT.WebSocket.cls",
    ws = new WebSocket(URL);

ws.addEventListener("open", () => ws.send(JSON.stringify({
    name: myName,
    avatar: myAvatar
})));

ws.addEventListener("error", (err) => printMessage({
    name: "System",
    text: "Ошибка соединения: " + err.toString()
}));

ws.addEventListener("close", () => printMessage({
    name: "System",
    text: "Соединение с сервером завершено"
}));

ws.addEventListener("message", (m) => {
    let message = JSON.parse(m.data);
    if (message["error"])
        return console.error(`Сервер записал ошибку: ${ message.error }`);
    if (message["updates"] instanceof Array) message["updates"].forEach(update => {
        if (update.type === "message")
            printMessage(update);
        else if (update.type === "notification")
            printMessage(update);
        else
            console.warn("Необработанное сообщение сокета", message);
    });
});

function printMessage ({ date = Date.now(), name, text, avatar = "" }) {
    let block = document.querySelector(".messages");
    block.innerHTML += `<div class="message">
        <div class="avatar" style="background-image: url(${ avatar })"></div>
        <div class="body">
            <div class="headline">
                <span class="date">${ new Date(date).toLocaleString() }</span>,
                <span class="name">${ name }</span>
            </div>
            <div class="text">${ text }</div>
        </div>
    </div>`;
    document.body.scrollTop = 99999999;
}

document.addEventListener("DOMContentLoaded", () => {
    const input = document.querySelector(".input");
    input.addEventListener("keydown", (event) => {
        if (input.value && event.keyCode === 13) {
            ws.send(JSON.stringify({ "text": input.value }));
            input.value = "";
        }
    });
});
