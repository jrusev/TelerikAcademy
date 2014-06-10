(function () {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1200,
        height: 600
    });

    var layer = new Kinetic.Layer();

    var imageObj = new Image();
    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 300,
            y: 450,
            image: imageObj,
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

        // add the shape to the layer
        layer.add(mario);

        // add the layer to the stage
        stage.add(layer);

        // start sprite animation
        mario.start();
    };

    imageObj.src = "./images/SuperMario.png";
}());