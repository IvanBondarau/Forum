var connection = new signalR.HubConnectionBuilder().withUrl("/topichub").build();

connection.start().then(function () {
    console.log("STARTED")
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UpdateTopic", function () {
    let element = document.getElementById('refreshPageWarning')
    if (element != null) {
        element.innerHTML = 'There are new messages in this topic.<br />Refresh page to review'
    }
})