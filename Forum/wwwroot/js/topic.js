var connection = new signalR.HubConnectionBuilder().withUrl("/topichub").build();





connection.start().then(function () {
    console.log("STARTED")
    document.getElementById('refreshPageWarning').innerHTML = 'ERROR';
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UpdateTopic", function () {
    console.log("KADDAODAODA")
    document.getElementById('refreshPageWarning').innerHTML = 'There are new messages in this topic.<br />Refresh page to review'
})