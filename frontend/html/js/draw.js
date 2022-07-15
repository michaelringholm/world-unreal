$(function() {
    drawCanvas();
    getMap();
    setInterval(getMapDetails, 1000);
});

var game={};
var context={};
var canvas={};
const mapObjectImageSize=48;
const horizontalCells=50;
const verticalCells=50;
const FACTIONS={ORC:"Orc",HUMAN:"Human"};

// API calls
function getMapDetails() {
    post("https://localhost:5001/api/game/map-details",{}, drawMap);
}

function getMap() {
    post("https://localhost:5001/api/game/map",{}, updateGameSettings);
}
// End API calls

function drawCanvas() {
    canvas = document.getElementById("myCanvas");    
    canvas.width=mapObjectImageSize*horizontalCells;
    canvas.height=mapObjectImageSize*verticalCells;
    context = canvas.getContext("2d");
    context.webkitImageSmoothingEnabled = false;
    context.mozImageSmoothingEnabled = false;
    context.imageSmoothingEnabled = false;
}

function updateGameSettings(response) {
    game.gameID=response.gameID;
    game.xTiles=response.xTiles;
    game.yTiles=response.yTiles;
}

function drawMap(response) {
    logDebug("drawMap()");
    var orcImg = $("#orc-icon-48")[0];
    var humanImg = $("#knight-icon-48")[0];
    var humanCastleImg = $("#castle-icon-48")[0];
    var orcCastleImg = $("#sand-castle-icon-48")[0];
    var unknownImg = $("#sand-castle-icon-48")[0];
    context.clearRect(0, 0, canvas.width, canvas.height);
    //const img = new Image();
    //img.src = "https://cdna.artstation.com/p/assets/images/images/026/799/902/large/chairat-toraya-5-1.jpg?1589771227";
    response.mapActionObjects.forEach(mapObject=>drawImage(mapObject));
}

function pickImage(factionName, mapObjectType, label) {
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
        if(mapObjectType=="Warrior") { humanImg.title=label; return humanImg; } // https://stackoverflow.com/questions/8429011/how-to-write-text-on-top-of-image-in-html5-canvas
        else return unknownImg;
    }
    else return unknownImg;
}

function pickImage2(factionName, mapObjectType) {
    return orcImg;
}

var registeredLogicalPosition=[,];
function calcUIPosition(mapObject) {
    mapObject.pos.adjustedUIXPos=mapObject.pos.x*mapObjectImageSize;
    mapObject.pos.adjustedUIYPos=mapObject.pox.y*mapObjectImageSize;
    if(!registeredLogicalPosition[mapObject.pos.x,mapObject.pox.y]) {
        registeredLogicalPosition[mapObject.pos.x,mapObject.pox.y]=new Array();
    }
    else {
        // Need to check for map boundaries as well
        
    }
    registeredLogicalPosition[mapObject.pos.x,mapObject.pox.y].push(mapObject);
}

function drawImage(mapObject) {
    calcUIPosition(mapObject);
    context.drawImage(pickImage(mapObject.factionName, mapObject.mapObjectType, mapObject.label), mapObject.pos.adjustedUIXPos, mapObject.pos.adjustedUIYPos, mapObjectImageSize, mapObjectImageSize);
    var barWidth=mapObjectImageSize*(mapObject.hp/mapObject.baseHp);
    if(mapObject.hp<0) barWidth=0;
    drawHealthbar(mapObject.pos.adjustedUIXPos, mapObject.pos.adjustedUIYPos, barWidth, 10, 2);
}

function drawHealthbar(x, y, width, thickness, marginBottom) {
    context.beginPath();
    //context.rect(x-width/2, y, width, thickness);
    context.rect(x, y-thickness-marginBottom, width, thickness);
    context.fillStyle="red";
    context.closePath();
    context.fill();
}
