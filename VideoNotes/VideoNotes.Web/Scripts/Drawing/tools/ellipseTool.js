(function () {
    var circleTool = makeTool('Ellipse', '', ecllipseToolMouseDown, ecllipseTooMouseMove, ecllipseTooMouseUp, ecllipseToolUpdateSettings),
            x1, y1, radius = 1, startDrawing = true;

    function ecllipseToolUpdateSettings() {
        ctx.strokeStyle = swatch.style.backgroundColor;
        ctx.fillStyle = swatch.style.backgroundColor;
    }

    function ecllipseToolMouseDown() {
        x1 = mousePositionX;
        y1 = mousePositionY;
        startDrawing = true;
    }
    function ecllipseTooMouseMove() {
        if (startDrawing) {
            var x2 = mousePositionX,
                y2 = mousePositionY;

            ctx.clearRect(x1 - 5, y1 - 5, x2 - x1 + 10, y2 - y1 + 10);
            drawEllipse(x1, y1, x2, y2);

            //ctx.strokeStyle = 'rgba(255, 0, 0, 0.5)';
            // ctx.strokeRect(x1, y1, x2 - x1, y2 - y1);
        }
    }
    function ecllipseTooMouseUp() {
        startDrawing = false;
    }
    function drawEllipse(x1, y1, x2, y2) {
        var radiusX = (x2 - x1) * 0.5,
            radiusY = (y2 - y1) * 0.5,
            centerX = x1 + radiusX,
            centerY = y1 + radiusY,
            step = 0.01,
            a = step,
            pi2 = Math.PI * 2 - step;

        ctx.beginPath();
        ctx.moveTo(centerX + radiusX * Math.cos(0),
                   centerY + radiusY * Math.sin(0));

        for (; a < pi2; a += step) {
            ctx.lineTo(centerX + radiusX * Math.cos(a),
                       centerY + radiusY * Math.sin(a));
        }

        ctx.closePath();
        ctx.strokeStyle = '#000';
        ctx.stroke();
    }
}());

