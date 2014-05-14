function onButtonClick(event, args) {
    var userWindow = window;
    var browser = userWindow.navigator.appCodeName;
    var isMozilla = browser === "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}