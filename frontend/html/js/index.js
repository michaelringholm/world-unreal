$(function() {
    logInfo("jquery initialized.");
    $("#muteSound").click(function() {muteSound()});
	$("#toggleDebug").click(function() {toggleDebug()});
});

function printJson(json) {
	$("#jsonInfo").html(json);
}

function logDebug(msg) {
	$("#debugInfo").prepend("[INFO]: " + msg + "<br/>");
} 

function logInfo(msg) {
	$("#status").prepend("[INFO]: " + msg + "<br/>");
} 

function logError(msg) {
	$("#status").prepend("[ERROR]: " + msg + "<br/>");
	console.error(msg);
} 

function post(url, data, fnSuccess) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        crossDomain: true,
        dataType: "json",
        xhrFields: {
            'withCredentials': false // tell the client to send the cookies if any for the requested domain
         },
        contentType: "application/json",
        headers: {
            "accept": "application/json",
            "Access-Control-Allow-Origin":"*"
        },
        beforeSend : function() {},
        success: function(data)	{
            logInfo("call succeeded!");
            if(data) printJson(JSON.stringify(data));
            if(fnSuccess) fnSuccess(data);
        },
        error: function(error, status) {
            logDebug("call failed!");
            logDebug(JSON.stringify(error));
            //if(error && error.responseJSON) printJson(error.responseJSON);
            //if(fnError) fnError(error.responseJSON);
        },			
        complete : function() {}

    });
}

function setCookie(cookieName, cookieValue, exdays) {
	var d = new Date();
	d.setTime(d.getTime() + (exdays*24*60*60*1000));
	var expires = "expires="+ d.toUTCString();
	document.cookie = cookieName + "=" + cookieValue + ";" + expires + ";path=/";
}

function getCookie(cookieName) {
	var name = cookieName + "=";
	var decodedCookie = decodeURIComponent(document.cookie);
	var ca = decodedCookie.split(';');
	for(var i = 0; i <ca.length; i++) {
	  var c = ca[i];
	  while (c.charAt(0) == ' ') {
		c = c.substring(1);
	  }
	  if (c.indexOf(name) == 0) {
		return c.substring(name.length, c.length);
	  }
	}
	return "";
}

function muteSound() {
	soundPlayer.muteAll();
};

function toggleDebug() {
	$("#debugInfo").toggle();
	$("#jsonInfo").toggle();
};