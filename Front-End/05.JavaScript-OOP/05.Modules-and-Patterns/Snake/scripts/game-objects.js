var gameObjects = (function () {
    "use strict";

    function Cell(x, y) {
        this.x = x;
        this.y = y;
    }

    function Apple(cell) {
        this.body = new Cell(cell.x, cell.y);
        this.draw = function (renderer) {
            renderer.drawCells([this.body], 'yellow');
        }
    }

    var Snake = (function () {
        var _self, _cellSize, _body;
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
            _body = new Array(startLength - 1);
            for (var i = 0; i < startLength - 1; i++) {
                _body[i] = new Cell(startX - _cellSize * (i + 1), startY);
            }

            this.direction = _dirs.right;
        }

        Snake.prototype.move = function () {
            _body.splice(_body.length - 1, 1);
            _body.unshift(new Cell(this.head.x, this.head.y));

            this.head.x += this.direction[0] * _cellSize;
            this.head.y += this.direction[1] * _cellSize;
        }

        Snake.prototype.draw = function (renderer) {
            renderer.drawCells([this.head], 'red');
            renderer.drawCells(_body, 'green');
        }

        Snake.prototype.eatApple = function () {
            // Add cell to the snake body
            var tailX = _body[_body.length - 1].x * 2 - _body[_body.length - 2].x;
            var tailY = _body[_body.length - 1].y * 2 - _body[_body.length - 2].y;
            _body.push(new Cell(tailX, tailY));
        }

        Snake.prototype.headCollidesWithBody = function () {
            for (var i = 0; i < _body.length; i++) {
                if (this.head.x === _body[i].x && this.head.y === _body[i].y) {
                    return true;
                }
            }

            return false;
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
        Apple: Apple,
        Snake: Snake
    };
}());