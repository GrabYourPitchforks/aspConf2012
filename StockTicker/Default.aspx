<%@ Page Language="C#" AutoEventWireUp="true" %>

<!doctype html>
<html>
<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
<title>Web Socket Test</title>
<script type="text/javascript">
    var socket;
    function initializeWebSocket() {
        var host = "ws://<%: Request.Url.Host %>:<%: Request.Url.Port %><%: Response.ApplyAppPathModifier("~/TickerHandler.ashx") %>";

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
                serverData.innerHTML = newElem.innerHTML;
            };

            socket.onclose = function(msg){ 
                var s = 'Socket closed';
                document.getElementById("serverStatus").innerHTML = s;  
            };

        } 
        catch(ex){ alert(ex); }
    }

    initializeWebSocket();
</script>
</head>
<body>
<h1>Web Socket Stock Ticker Demo</h1>
<p id="serverStatus"></p>
<div id="serverData"></div>
</body>
</html>
