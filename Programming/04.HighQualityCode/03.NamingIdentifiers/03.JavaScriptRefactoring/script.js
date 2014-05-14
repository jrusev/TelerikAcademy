function onButtonClick(event, args) {
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;
    var isMozilla = browser === "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
