(function () {

    $(document).ready(function () {
        //var player = videojs('mainVideoPlayer');

        var options = {};

        var player = videojs('mainVideoPlayer', options, function onPlayerReady() {
            videojs.log('Your player is ready!');

            // In this context, `this` is the player that was created by Video.js.
            //this.play();
            $.get("TEst", { str: "hello" }, function () { });

            // How about an event listener?
            this.on('ended', function () {
                videojs.log('Awww...over so soon?!');
            });
        });
    });


})();




