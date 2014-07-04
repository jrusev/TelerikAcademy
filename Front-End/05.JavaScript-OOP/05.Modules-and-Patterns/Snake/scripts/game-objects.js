var gameObjects = (function () {
    "use strict";

    function Cell(x, y) {
        this.x = x;
        this.y = y;
    }

    function Apple(cell) {
        this.x = cell.x;
        this.y = cell.y;
        this.draw = function (renderer) {
            var body = new Cell(this.x, this.y);
            renderer.drawCells([body], 'yellow');
        }
    }

    var Snake = (function () {
        var _cellSize, _self;
        var _dirs = {
            right: [1, 0],
            left: [-1, 0],
            up: [0, -1],
            down: [0, 1]
        };
        // constructor
        function Snake(cellSize, startLength, startX, startY) {
            _self = this;
            _cellSize = cellSize;
            this.head = new Cell(startX, startY);
            this.body = new Array(startLength - 1);
            for (var i = 0; i < startLength - 1; i++) {
                this.body[i] = new Cell(startX - _cellSize * (i + 1), startY);
            }

            this.direction = _dirs.right;
        }

        Snake.prototype.move = function () {
            this.body.splice(this.body.length - 1, 1);
            this.body.unshift(new Cell(this.head.x, this.head.y));

            this.head.x += this.direction[0] * _cellSize;
            this.head.y += this.direction[1] * _cellSize;
        }

        Snake.prototype.draw = function (renderer) {
            renderer.drawCells([this.head], 'red');
            renderer.drawCells(this.body, 'green');
        }

        Snake.prototype.onKeyDown = function (event) {
            event = event || window.event;
            var keyCode = event.keyCode;

            if (keyCode === 37 && _self.direction !== _dirs.right) // left
                _self.direction = _dirs.left;

            if (keyCode === 38 && _self.direction !== _dirs.down) // up
                _self.direction = _dirs.up;

            if (keyCode === 39 && _self.direction !== _dirs.left) // right
                _self.direction = _dirs.right;

            if (keyCode === 40 && _self.direction !== _dirs.up) // down
                _self.direction = _dirs.down;
        }

        return Snake;
    }());

    return {
        Cell: Cell,
        Snake: Snake,
        Apple: Apple
    };
}());