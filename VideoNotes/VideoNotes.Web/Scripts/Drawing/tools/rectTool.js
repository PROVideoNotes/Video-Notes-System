(function(){
    var rectTool = makeTool('Rectangle', '', rectToolMouseDown, rectToolMouseMove, rectToolMouseUp, rectToolUpdateSettings),
        startX,
        startY,
        startDrawing = true;

    function rectToolUpdateSettings(){
        ctx.strokeStyle = swatch.style.backgroundColor;
        ctx.fillStyle = swatch.style.backgroundColor;
    }

    function rectToolMouseDown(){
        startX = mousePositionX;
        startY = mousePositionY;
        startDrawing=true;
    }

    function rectToolMouseMove(){
        if(startDrawing){
            drawRectangle(mousePositionX, mousePositionY);
        }
    }

    function rectToolMouseUp(){
        drawRectangle(mousePositionX, mousePositionY);
       startDrawing = false;
    }

    function drawRectangle(x,y){

        ctx.beginPath();
        ctx.fillStyle="#FFFFFF";
        ctx.fillRect(startX-ctx.lineWidth,startY-ctx.lineWidth,Math.abs(startX-x)+(2*ctx.lineWidth), Math.abs(startY-y)+(2*ctx.lineWidth));
         ctx.strokeRect(startX, startY, Math.abs(startX-x), Math.abs(startY-y));
    }
}());
