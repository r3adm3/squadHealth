
function random8 (){
   
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for( var i=0; i < 8; i++ )
        text += possible.charAt(Math.floor(Math.random() * possible.length));

    return text;

}

function answer(question, colour){
    console.log (doGetTempID() + " " + question + " " + colour);
    setMyAnswerImg(question,colour);
}

function setMyAnswerImg(question, colour){
    
    var questionNumber = question.replace("q", "")
    
    document.getElementById("userans" + questionNumber).src = "images/" + colour + ".png"

}

function doClear() {
    localStorage.clear();
    doShowAll();
}

function doSetItem() {
    var name = "tempID";
    var data = random8();
    localStorage.setItem(name, data);
    doShowAll();
}

function doGetTempID() {
    return localStorage.getItem("tempID");
}

function doShowAll() {
    var key = "";
    var i=0;
    for (i=0; i<=localStorage.length-1; i++) {
        key = localStorage.key(i);
        console.log(key+":"+localStorage.getItem(key));
    }

}