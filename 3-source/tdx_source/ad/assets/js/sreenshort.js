this.screenshotPreview = function () {
    /* CONFIG */

    xOffset = 10;
    yOffset = 30;

    // these 2 variable determine popup's distance from the cursor
    // you might want to adjust to get the right result

    /* END CONFIG */
    var screenshot_width, screenshot_height;
    var window_width, window_height;
    $("a.screenshot").hover(function (e) {
        this.t = this.title;
        this.title = "";
        var c = (this.t != "") ? "<br/>" + this.t : "";
        $("body").append("<p id='screenshot'><img src='" + this.rel + "' alt='url preview' />" + c + "</p>");
        screenshot_width = $("#screenshot").outerWidth();
        screenshot_height = $("#screenshot").outerHeight();
        window_width = $(window).width();
        window_height = $(window).height() + $(window).scrollTop();
        if (e.pageX + yOffset + screenshot_width > window_width) {
            $("#screenshot")
			    .css("left", (e.pageX - yOffset - screenshot_width) + "px");
        }
        else {
            $("#screenshot")
			.css("left", (e.pageX + yOffset) + "px");
        }
        if (e.pageY + screenshot_height / 2 > window_height - yOffset) {
            $("#screenshot").css("top", (window_height - screenshot_height - yOffset) + "px");
        }
        else if (e.pageY - screenshot_height / 2 < $(window).scrollTop()) {
            $("#screenshot").css("top", $(window).scrollTop() + "px");
        }
        else {
            $("#screenshot").css("top", (e.pageY - screenshot_height / 2) + "px")
        }
        $("#screenshot").fadeIn("fast");
    },
	function () {
	    this.title = this.t;
	    $("#screenshot").remove();
	});
    $("a.screenshot").mousemove(function (e) {
        if (e.pageX + yOffset + screenshot_width > window_width) {
            $("#screenshot")
			    .css("left", (e.pageX - yOffset - screenshot_width) + "px");
        }
        else {
            $("#screenshot")
			.css("left", (e.pageX + yOffset) + "px");
        }
        if (e.pageY + screenshot_height / 2 > window_height - yOffset) {
            $("#screenshot").css("top", (window_height - screenshot_height - yOffset) + "px");
        }
        else if (e.pageY - screenshot_height / 2 < $(window).scrollTop()) {
            $("#screenshot").css("top", $(window).scrollTop() + "px");
        }
        else {
            $("#screenshot").css("top", (e.pageY - screenshot_height / 2) + "px")
        }
    });
};


// starting the script on page load
$(document).ready(function () {
    screenshotPreview();
});