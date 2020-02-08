function getAnchors() {
    var anchors = document.anchors;
    var length = anchors.length;
    return length;
}

function getLinks() {
    var links = document.links;
    var length = links.length;
    return length;
}

function getImages() {
    var images = document.images;
    var length = images.length;
    return length;
}

function clickButtonSendMessage() {
    console.log("Нажата кнопка ' Отправить сообщение '");
}

function prevSlide() {
    console.log("Переключен слайд на предыдщуй");
    var img = document.getElementById("currentSlide");
    var index = parseInt(img.src.substr(img.src.lastIndexOf("/") + 1, 1));
    if (index == 1) {
        index = 3;
    } else {
        index = index - 1;
    }
    img.src = "pictures/slides/" + index.toString() + ".jpg";
}

function nextSlide() {
    console.log("Переключен слайд на следующий");
    var img = document.getElementById("currentSlide");
    var index = parseInt(img.src.substr(img.src.lastIndexOf("/") + 1, 1));
    if (index == 3) {
        index = 1;
    } else {
        index = index + 1;
    }
    img.src = "pictures/slides/" + index.toString() + ".jpg";
}
