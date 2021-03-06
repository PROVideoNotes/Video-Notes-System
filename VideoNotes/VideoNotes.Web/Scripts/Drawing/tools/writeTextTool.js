(function () {
    var textTool = makeTool('Text', '', writeTextOnMouseDown, null, null, updateTextToolSettings),
        startX,
        startY;
function updateTextToolSettings(){
    ctx.strokeStyle = swatch.style.backgroundColor;
    ctx.fillStyle = swatch.style.backgroundColor;
    ctx.font = (writingFontSize||30)+"px Cherry Cream Soda";
}
    function writeTextOnMouseDown() {
        startX = mousePositionX + 10;
        startY = mousePositionY-10;
        var input = $("<input type=text id='userInput' placeholder='Press enter to apply' />").css({
            "position": "absolute",
            "left":startX.toString()+'px',
            "top":startY.toString()+'px',
            "z-index": 20,
            "filter":"alpha(opacity=50)",
            "opacity": "0.5",
			"width": "130px",
			"height": "25px"
        });
        var element =$('#userInput');
        if (element.length === 0) {
            $("#paint-container").append(input);
        }
    }

    $(document).keypress(function(e){
        if(e.which === 13){
            var element = $('#userInput');
            ctx.fillText(element.val(), element.position().left - 10, element.position().top+10);
            element.remove();
        }
    });
}());
