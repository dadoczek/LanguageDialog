var audio;

var errorCallback = function (e) {
    console.log('Połącznie z mikrofonem odrzucone!', e);
};

navigator.getUserMedia({ audio: true }, function (localMediaStream) {
    audio = document.querySelector('audio');
    audio.src = window.URL.createObjectURL(localMediaStream);

    audio.onloadedmetadata = function (e) {
    };
}, errorCallback);