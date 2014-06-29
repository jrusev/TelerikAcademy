## Advanced Functions

1. Create a module for working to work with DOM. The module should have the following functionality
    * Add element to parent element by given selector
    * Remove element from the DOM  by given selector
    * Attach event to given selector by given event type and event hander
    * Add elements to buffer, which appends them to the DOM when their for some selector count becomes 100
        * The buffer contains elements for each selector it gets
    * Get elements by CSS selector
    * The module should reveal only the methods

    The module should have the following functionality:

    ```js
    var domModule = ...;
    var div = document.createElement("div");

    // Change the div
    domModule.appendChild(div, "#wrapper");
    domModule.removeChild("ul", "li:first");

    // Remove the first li from each ul
    domModule.addHandler("a.button", "click", function(){
        alert("Clicked");
    });

    domModule.appendToBuffer("container", div.cloneNode(true));
    domModule.appendToBuffer("#main-nav ul", navItem);
    ```
* Create a module that works with moving div elements. Implement functionality for:
    * Add new moving div element to the DOM
        * The module should generate random `background`, `font` and `border-color`
        * All the div elements are with the same `width` and `height`
    * The movements of the div elements can be either circular or rectangular
    * The elements should be moving all the time

    ```js
    var movingShapes = ...;

    // Add element with rectangular movement
    movingShapes.add("rect");

    // Add element with ellipse movement
    movingShapes.add("ellipse");
    ```
* Create a module to work with the `console` object. Implement functionality for:
    * Writing a line to the `console`
    * Writing a line to the `console` using a format
    * Writing to the console should call `toString()` to each element
    * Writing errors and warnings to the `console` with and without format

    ```js
    var specialConsole = ...;

    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: hello");

    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: {0}", "hello");

    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");
    ```