$(function () {
    $("#submit").click(function () {
        $.ajax({
            url: "UploadGoogleSheets/Index",
            cache: false,
            success: function (html) {
                $("#results").append(html);
            }
        });
    })
});