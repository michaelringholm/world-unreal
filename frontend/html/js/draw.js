$(function() {
    drawCanvas();
    getMapData();
    drawMap();
});
var context={};
const mapObjectImageSize=48;
const horizontalCells=50;
const verticalCells=50;

function getMapData() {
    post("https://localhost:7243/Game",{}, drawMap);
}

function drawCanvas() {
    var canvas = document.getElementById("myCanvas");    
    canvas.width=mapObjectImageSize*horizontalCells;
    canvas.height=mapObjectImageSize*verticalCells;
    context = canvas.getContext("2d");
    context.webkitImageSmoothingEnabled = false;
    context.mozImageSmoothingEnabled = false;
    context.imageSmoothingEnabled = false;
}

function drawMap(data) {
    logDebug("drawMap()");
    
    //var img = document.getElementById("orc1");
    var img = $("#orc-icon-48")[0];
    //const img = new Image();
    //img.src = "https://cdna.artstation.com/p/assets/images/images/026/799/902/large/chairat-toraya-5-1.jpg?1589771227";
    //context.drawImage(img, 10, 10, 32, 32);
    context.drawImage(img, 10, 10, mapObjectImageSize, mapObjectImageSize);
    //log(img);
    
    //octx.drawImage(img, 0, 0, oc.width, oc.height);
}


