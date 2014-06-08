window.addEventListener('load', main, false);

var boxWidth = 120;
var boxHeight = 40;
var boxMarginX = boxWidth + boxHeight / 2;
var boxMarginY = 80;
var initialX = 500;

var treeColor = 'rgb(0, 158, 179)';
var fontSize = 10;

function main() {
    var stage = new Kinetic.Stage({
        container: 'kinetic-container',
        width: 1400,
        height: 1400
    });

    var layer = new Kinetic.Layer();

    var data = familyData.map(function (item) {
        return new Family(item.mother, item.father, item.children);
    });

    var tree = buildTree(data);
    var root = findRoot(data, tree);

    drawTree(layer, root);
    stage.add(layer);
}

function Family(mother, father, children) {
    this.mother = mother;
    this.father = father;
    this.children = children || [];
    this.isFemale = false;
}

Family.prototype.hasChild = function (personName) {
    for (var i = 0; i < this.children.length; i++) {
        var child = this.children[i];
        if (child.mother === personName || child.father === personName) {
            return true;
        }
    }
};

function buildTree(data) {
    var tree = [];

    for (var i = 0; i < data.length; i++) {
        tree[data[i].mother] = tree[data[i].father] = data[i];
    }

    for (var parent in tree) {
        var family = tree[parent];

        for (var i = 0; i < family.children.length; i++) {
            var childName = family.children[i];

            if (tree[childName] && !(childName instanceof Family)) {
                family.children[i] = tree[childName];

                if (tree[childName].mother === childName) {
                    tree[childName].isFemale = true;
                }
            } else if (!(childName instanceof Family)) {
                var leaf = new Family(null, childName);
                tree[childName] = leaf;
                family.children[i] = leaf;
            }
        }
    }

    return tree;
}

function findRoot(data, tree) {
    var root = null;

    for (var i = 0; i < data.length; i++) {
        var mother = data[i].mother;
        var father = data[i].father;
        var isRoot = true;

        for (var j = 0; j < data.length; j++) {
            if (i == j) {
                continue;
            }

            if (data[j].hasChild(mother) || data[j].hasChild(father)) {
                isRoot = false;
                break;
            }
        }

        if (isRoot) {
            root = data[i];
            break;
        }
    }

    return tree[root.mother];
}

function drawTree(layer, root) {
    var queue = [];
    root.posX = initialX;
    root.posY = 0;
    queue.push(root);
    // BFS
    while (queue.length > 0) {
        var node = queue.shift();
        for (var i = 0; i < node.children.length; i++) {
            var child = node.children[i];
            child.posY = node.posY + boxMarginY;
            var offset = node.children.length > 1 ? boxMarginX * (node.children.length - 1) : 0;
            child.posX = node.posX + (2 * boxMarginX) * i - offset;
            queue.push(node.children[i]);
        }
        drawFamily(layer, node);
    }
}

function drawFamily(layer, root) {
    if (root.father) {
        drawBox(layer, root.posX, root.posY, root.father || "", boxHeight * 0.1);
    }

    if (root.mother) {
        drawBox(layer, root.posX + boxMarginX, root.posY, root.mother || "", boxHeight * 0.4);
    }

    // line: father - mother
    if (root.father && root.mother) {
        var dX = root.posX + boxWidth;
        var dY = root.posY + boxHeight / 2 - 5;
        layer.add(new Kinetic.Line({
            points: [dX, dY, dX + 20, dY],
            stroke: treeColor,
            strokeWidth: 1
        }));
    }

    // lines: parents - children
    for (var i = 0; i < root.children.length; i++) {
        var child = root.children[i];
        var x = child.posX + boxWidth / 2;
        if (child.father === null || child.isFemale) {
            x += boxMarginX;
        }
        drawParentToChild(root.posX - 20, root.posY, x - 50, child.posY - 1, layer);
    }
}

function drawParentToChild(leftParentX, leftParentY, childX, childY, layer) {
    var x1 = leftParentX + boxWidth * 1.25;
    var y1 = leftParentY + boxHeight / 2 + 8;
    var x2 = childX + boxWidth / 2;
    var y2 = childY;
    layer.add(new Kinetic.Line({
        points: [x1, y1, x2, y2],
        stroke: treeColor,
        strokeWidth: 1,
    }));
}

function drawBox(layer, posX, posY, text, radius) {
    var nodeText = new Kinetic.Text({
        x: posX,
        y: posY,
        width: boxWidth,
        padding: 10,
        text: text,
        fontSize: fontSize,
        fill: 'black',
        align: 'center'
    });

    var nodeFigure = new Kinetic.Rect({
        x: posX,
        y: posY,
        width: boxWidth,
        stroke: treeColor,
        strokeWidth: 1,
        height: nodeText.height(),
        cornerRadius: radius
    });

    layer.add(nodeFigure);
    layer.add(nodeText);
}