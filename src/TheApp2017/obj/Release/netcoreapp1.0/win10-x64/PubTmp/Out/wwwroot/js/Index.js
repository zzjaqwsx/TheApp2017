(function () {

    $(document).ready(function () {
        function resizeIframe(obj) {
            var width = $("#managed-yt-1").css("width");
            var height = (width.replace("px","") / 16) * 9;
            $("#managed-yt-1").css("height", height);
        }

        resizeIframe($("#managed-yt-1"));
    });
}
)();