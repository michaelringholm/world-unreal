$(function() {
    drawMap();
});

function drawMap() {
    log("drawMap()");
    var canvas = document.getElementById("myCanvas");
    var mapObjectImageSize=48;
    var horizontalCells=50;
    var verticalCells=50;
    canvas.width=mapObjectImageSize*horizontalCells;
    canvas.height=mapObjectImageSize*verticalCells;
    var context = canvas.getContext("2d");
    context.webkitImageSmoothingEnabled = false;
    context.mozImageSmoothingEnabled = false;
    context.imageSmoothingEnabled = false;
    //var img = document.getElementById("orc1");
    var img = $("#orc-icon-48")[0];
    //const img = new Image();
    //img.src = "https://cdna.artstation.com/p/assets/images/images/026/799/902/large/chairat-toraya-5-1.jpg?1589771227";
    //context.drawImage(img, 10, 10, 32, 32);
    context.drawImage(img, 10, 10, mapObjectImageSize, mapObjectImageSize);
    //log(img);
    
    //octx.drawImage(img, 0, 0, oc.width, oc.height);
}