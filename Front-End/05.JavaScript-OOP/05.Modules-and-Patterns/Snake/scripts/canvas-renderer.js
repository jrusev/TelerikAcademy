var CanvasRenderer = (function () {
    "use strict";

    var CanvasRenderer = (function () {

        // constructor
        var CanvasRenderer = (function (width, height, cellSize) {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;

            var canvas = document.createElement('canvas');
            canvas.width = this._width;
            canvas.height = this._height;
            canvas.style.border = '2px solid black';
            document.body.appendChild(canvas);
            this._context = canvas.getContext('2d');
        });

        CanvasRenderer.prototype.clearScreen = function () {
            this._context.fillStyle = 'black';
            this._context.fillRect(0, 0, this._width, this._height);
        };

        CanvasRenderer.prototype.drawCells = function (cells, color) {
            this._context.fillStyle = color;
            for (var i = 0; i < cells.length; i++) {
                this._context.fillRect(cells[i].x, cells[i].y, this._cellSize, this._cellSize);
            }
        };

        return CanvasRenderer;
    })();

    return {
        getRenderer: function (width, height, cellSize) {
            return new CanvasRenderer(width, height, cellSize);
        }
    };
})();