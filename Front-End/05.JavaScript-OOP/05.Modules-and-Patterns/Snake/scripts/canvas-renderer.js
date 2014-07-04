var CanvasRenderer = (function () {
    "use strict";

    var CanvasRenderer = (function () {

        var _canvasContext,
            _canvasWidth,
            _canvasHeight,
            _cellSize;

        // constructor
        var CanvasRenderer = (function (width, height, cellSize) {
            _canvasWidth = width;
            _canvasHeight = height;
            _cellSize = cellSize;

            var canvas = document.createElement('canvas');
            canvas.width = _canvasWidth;
            canvas.height = _canvasHeight;
            canvas.style.border = '2px solid black';
            document.body.appendChild(canvas);
            _canvasContext = canvas.getContext('2d');
        });

        CanvasRenderer.prototype.clearScreen = function () {
            _canvasContext.fillStyle = 'black';
            _canvasContext.fillRect(0, 0, _canvasWidth, _canvasHeight);
        }

        CanvasRenderer.prototype.drawCells = function (cells, color) {
            _canvasContext.fillStyle = color;
            for (var i = 0; i < cells.length; i++) {
                _canvasContext.fillRect(cells[i].x, cells[i].y, _cellSize, _cellSize);
            }
        }

        return CanvasRenderer;
    })();

    return {
        getRenderer: function (width, height, cellSize) {
            return new CanvasRenderer(width, height, cellSize);
        }
    }
})();