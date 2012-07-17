<%@ Page Language="C#" AutoEventWireup="true" %>

<!doctype html>
<html>
<head>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type">
    <title>Web Socket Test</title>
    <script type="text/javascript">
        var socket;
        function initializeWebSocket() {
            var host = "ws://<%: Request.Url.Host %>:<%: Request.Url.Port %><%: Response.ApplyAppPathModifier("~/Handler.ashx") %>";

            try {
                socket = new WebSocket(host);

                socket.onopen = function(msg){
                    var s = 'Socket open';
                    document.getElementById("serverStatus").innerHTML = s;  
                };

                socket.onmessage = function(msg){
                    var serverData = document.getElementById("serverData");
                    var newElem = document.createElement("p");
                    newElem.appendChild(document.createTextNode(msg.data));
                    serverData.insertBefore(newElem, serverData.firstChild);
                };

                socket.onclose = function(msg){ 
                    var s = 'Socket closed';
                    document.getElementById("serverStatus").innerHTML = s;  
                };

            } 
            catch(ex){ alert(ex); }
        }

        function send() {
            var e = document.getElementById("msgText");
            socket.send(e.value);
        }

        initializeWebSocket();
    </script>
</head>
<body>
    <h1>Web Socket Demo</h1>
    <p id="serverStatus"></p>
    <p>
        This text will be sent on the socket:<br />
        <input id="msgText" type="text" size="30">
        <input type="button" value="Send" onclick="send()">
    </p>
    <div id="serverData"></div>
</body>
</html>
