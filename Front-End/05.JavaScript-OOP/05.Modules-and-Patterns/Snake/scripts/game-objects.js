var GameObjects = (function () {
    "use strict";

    function Cell(x, y) {
        this.x = x;
        this.y = y;
    }

    var Apple = (function () {

        function Apple(cell) {
            this.body = new Cell(cell.x, cell.y);
        }
        Apple.prototype.draw = function (renderer) {
            renderer.drawCells([this.body], 'yellow');
        };

        return Apple;
    })();

    var Snake = (function () {
        var Dirs = {
            right: [1, 0],
            left: [-1, 0],
            up: [0, -1],
            down: [0, 1]
        };

        // constructor
        function Snake(cellSize, startLength, startX, startY) {
            this._cellSize = cellSize;
            this._head = new Cell(startX, startY);
            this._body = new Array(startLength - 1);
            for (var i = 0; i < startLength - 1; i++) {
                this._body[i] = new Cell(startX - this._cellSize * (i + 1), startY);
            }
            this._direction = Dirs.right;
        }

        Snake.prototype.move = function () {
            this._body.splice(this._body.length - 1, 1);
            this._body.unshift(new Cell(this._head.x, this._head.y));

            this._head.x += this._direction[0] * this._cellSize;
            this._head.y += this._direction[1] * this._cellSize;
        };

        Snake.prototype.draw = function (renderer) {
            renderer.drawCells([this._head], 'red');
            renderer.drawCells(this._body, 'green');
        };

        Snake.prototype.eatApple = function () {
            // Add cell to the snake body
            var tailX = this._body[this._body.length - 1].x * 2 - this._body[this._body.length - 2].x;
            var tailY = this._body[this._body.length - 1].y * 2 - this._body[this._body.length - 2].y;
            this._body.push(new Cell(tailX, tailY));
        };

        Snake.prototype.headCollidesWithBody = function () {
            for (var i = 0; i < this._body.length; i++)
                if (this._head.x === this._body[i].x && this._head.y === this._body[i].y)
                    return true;
            return false;
        };

        Snake.prototype.attachEventHandlers = function (element) {
            var self = this;
            element.addEventListener('keydown', function (event) {
                event = event || window.event;
                var keyCode = event.keyCode;

                if (keyCode === 37 && self._direction !== Dirs.right) // left
                    self._direction = Dirs.left;

                if (keyCode === 38 && self._direction !== Dirs.down) // up
                    self._direction = Dirs.up;

                if (keyCode === 39 && self._direction !== Dirs.left) // right
                    self._direction = Dirs.right;

                if (keyCode === 40 && self._direction !== Dirs.up) // down
                    self._direction = Dirs.down;
            }, false);
        };

        return Snake;
    }());

    return {
        Apple: Apple,
        Snake: Snake
    };
}());