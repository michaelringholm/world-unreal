$(function() {
    drawCanvas();
    //getMapData();
    setInterval(getMapData, 1000);
});

var context={};
const mapObjectImageSize=48;
const horizontalCells=50;
const verticalCells=50;
const FACTIONS={ORC:"Orc",HUMAN:"Human"};

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

function pickImage(factionName, mapObjectType) {
    var orcImg = $("#orc-icon-48")[0];
    var humanImg = $("#knight-icon-48")[0];
    var humanCastleImg = $("#castle-icon-48")[0];
    var orcCastleImg = $("#sand-castle-icon-48")[0];
    var unknownImg = $("#sand-castle-icon-48")[0];

    if(factionName==FACTIONS.ORC) {
        if(mapObjectType=="Castle") return orcCastleImg;
        if(mapObjectType=="Warrior") return orcImg;
        else return unknownImg;
    }
    else if(factionName==FACTIONS.HUMAN) {
        if(mapObjectType=="Castle") return humanCastleImg;
        if(mapObjectType=="Warrior") return humanImg;
        else return unknownImg;
    }
    else return unknownImg;
}

function pickImage2(factionName, mapObjectType) {
    return orcImg;
}

function drawMap(mapObjects) {
    logDebug("drawMap()");
    var orcImg = $("#orc-icon-48")[0];
    var humanImg = $("#knight-icon-48")[0];
    var humanCastleImg = $("#castle-icon-48")[0];
    var orcCastleImg = $("#sand-castle-icon-48")[0];
    var unknownImg = $("#sand-castle-icon-48")[0];
    //const img = new Image();
    //img.src = "https://cdna.artstation.com/p/assets/images/images/026/799/902/large/chairat-toraya-5-1.jpg?1589771227";
    //for(var mapObject in mapObjects) {
    mapObjects.forEach(mapObject=>context.drawImage(pickImage(mapObject.factionName, mapObject.mapObjectType), mapObject.pos.x*mapObjectImageSize, mapObject.pos.y*mapObjectImageSize, mapObjectImageSize, mapObjectImageSize));
    //mapObjects.forEach(mapObject=>context.drawImage(orcImg, mapObject.pos.x*mapObjectImageSize, mapObject.pos.y*mapObjectImageSize, mapObjectImageSize, mapObjectImageSize));
}

