

$(document).ready(function () {

   
    var myhub = $.connection.alertHub;

    $("#btnMyMethod").on("click", function () {
        console.log("about to call myMethod");
        myhub.server.myMethod().done(function () {
           // console.log("myMethod complete");

            //alertify.alert('Ready!');
            //alert("working ! ............");

        });
    });


    myhub.client.alertMe = function () {

       // var x = document.getElementsByClassName("myAudio"); 


       // console.log("ALERT ME: " );

        //alertify.alert('Ready!');
     //   alert("working ! ............");
        //x.pause(); 
    };
});

$.connection.hub.logging = true;


var options = {
    transport: ['webSockets', 'longPolling']
};

var deferredStart = $.connection.hub.start(options);




