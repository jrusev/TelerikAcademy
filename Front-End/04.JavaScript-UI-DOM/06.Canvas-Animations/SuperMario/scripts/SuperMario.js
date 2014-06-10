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
                    10, 290, 75, 120,
                    85, 290, 75, 120,
                    175, 290, 75, 120,
                    255, 290, 75, 120,
                    335, 290, 75, 120,
                    405, 290, 75, 120,
                    480, 290, 75, 120,
                    570, 290, 75, 120,
                    660, 290, 75, 120,
                    745, 290, 75, 120
                ]
            },
            frameRate: 8,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);
        mario.start();
    };

    img.src = "./images/SuperMario.png";
}());