(function ($) {
    $.fn.extend({
        bgsizebox: function (options) {
            // Đặt các giá trị mặc định
            var defaults = {
                fimg: true,
                imgcss: "hideo",
                attrname: "data-src"
            };
            var options = $.extend(defaults, options);
            return this.each(function () {
                var opts = options;
                // Đặt tên biến cho element (ul)

                var obj = $(this);
                var items = $("> img:first", obj);
                if (opts.fimg) {
                    items.addClass(opts.imgcss);
                    var srcimg = items.attr("src");
                    obj.css({ "background-image": "url(" + srcimg + ")" });
                } else {
                    var srcimg = obj.attr(opts.attrname);
                    obj.css({ "background-image": "url(" + srcimg + ")" });
                }
            });
        }
    });
})(jQuery);