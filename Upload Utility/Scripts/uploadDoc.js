$(function () {
    $("#submit").click(function () {
        $.ajax({
            url: "test.html",
            cache: false,
            success: function (html) {
                $("#results").append(html);
            }
        });
    })
});