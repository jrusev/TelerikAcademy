(function () {
    var stage = new Kinetic.Stage({
        container: 'kinetic-container',
        width: 655,
        height: 273
    });

    var layer = new Kinetic.Layer();

    var img = new Image();
    img.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 280,
            y: 142,
            image: img,
            animation: 'idle',
            animations: {
                idle: [
                    // x, y, width, height (8 frames)
                    10, 0, 75, 120,
                    85, 0, 75, 120,
                    175, 0, 75, 120,
                    255, 0, 75, 120,
                    335, 0, 75, 120,
                    405, 0, 75, 120,
                    480, 0, 75, 120,
                    570, 0, 75, 120,
                    660, 0, 75, 120,
                    745, 0, 75, 120
                ]
            },
            frameRate: 8,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();
    };

    img.src = "./images/SuperMario-walk.png";
}());