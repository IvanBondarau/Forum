var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

connection.start().then(function () {
    console.log("STARTED")
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UpdateMessage", (messageId, likes) => {
    console.log('Message id: ' + messageId)
    let element = document.getElementById('message-' + messageId + '-likes');
    if (element != null) {
        element.innerHTML = likes + ' ';
    }
})