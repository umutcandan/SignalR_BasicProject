"use strict"

const signalrConnection = new signalR.HubConnectionBuilder()
    .withUrl("/messageBroker")
    .build();

signalrConnection.start().then(function () {
    console.log("its works.");
}).catch(function (err) {
    return console.error(err.toString());
});

signalrConnection.on("getMessage", function (eventMessage) {
    console.log(eventMessage);
});