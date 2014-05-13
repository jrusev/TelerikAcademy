function _ClickON_TheButton(THE_event, argumenti) {
    var moqProzorec = window;
    var brauzyra = moqProzorec.navigator.appCodeName;
    var ism = brauzyra == "Mozilla";
    if (ism) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
