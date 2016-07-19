(function ($) {
    $.fn.extend({
        textHeight: function (options) {
            // Đặt các giá trị mặc định

            var defaults = {
                activetit: true,
                listcss: [{ cssname: ".news-name"}],
                wpointb: true,
                //widthpont: 479,
                desbool: true,
                listpos: [{ cssnamepos: ".desription", cssheightnum: "3" }],
                tbrow: false,
                csstr: ".element-item",
                max: true
            };

            var options = $.extend(defaults, options);

            return this.each(function () {

                var opts = options;
                // Đặt tên biến cho element (ul)
                var obj = $(this);
                // Lấy tất cả thẻ li trong ul
                var lenw = opts.listcss.length;
                var lendes = opts.listpos.length;
                var iteams = obj.find(opts.csstr);
                var myclear;
                myfunh();
                if (opts.wpointb) {
                    $(window).resize(function () {
                        myfunh();
                    });
                }
                function myfunh() {
                    clearTimeout(myclear);
                    if (opts.activetit) {
                        for (var i = 0; i < lenw; i++) {
                            $(opts.listcss[i].cssname, obj).height("auto");
                        }
                    }
                    if (opts.desbool) {
                        for (var j = 0; j < lendes; j++) {
                            $(opts.listpos[j].cssnamepos, obj).height("auto");
                        }
                    }
                    myclear = setTimeout(function () {
                        myfunHeight();
                    }, 100);
                }
                function myfunHeight() {
                    var widthtb = obj.width();
                    var widthcol = obj.find(opts.csstr).outerWidth();
                    var numcol = Math.round(widthtb / widthcol);
                    var counttd = obj.find(opts.csstr).size();
                    var numrow = parseInt(counttd / numcol);
                    var totalrow = 0;
                    var numstrp = 1;
                    var widthtr = 0;
                    //alert(numcol);
                    if (opts.tbrow) {
                            for (var i = 0; i < counttd; i++) {

                                widthtr += iteams.filter(":eq(" + i + ")").outerWidth();
                                if (widthtr <= widthtb) {
                                    iteams.filter(":eq(" + i + ")").attr("data-row", "row-" + (numstrp));
                                } else {
                                    widthtr = 0;
                                    numstrp++;
                                    widthtr += iteams.filter(":eq(" + i + ")").outerWidth();
                                    iteams.filter(":eq(" + i + ")").attr("data-row", "row-" + (numstrp));
                                }
                            }
                            if (numstrp == counttd) {
                                obj.find(opts.csstr).attr("data-row", "row");
                            } 
                    }
                    if (opts.max) {
                        if (opts.tbrow) {
                            if (numstrp > 1) {
                                if (opts.activetit) {
                                    for (var j = 0; j < numstrp; j++) {
                                        var colm = "[data-row='row-" + (j + 1) + "']";
                                        for (var i = 0; i < lenw; i++) {
                                            var strcol = colm + " " + opts.listcss[i].cssname;
                                            var maxHeight = Math.max.apply(null, $(strcol, obj).map(function () {
                                                return $(this).height();
                                            }).get());
                                            $(strcol, obj).height(maxHeight);
                                        }

                                    }
                                }
                                if (opts.desbool) {
                                    for (var k = 0; k < numstrp; k++) {
                                        var colm = "[data-row='row-" + (k + 1) + "']";
                                        for (var j = 0; j < lendes; j++) {
                                            var strname = colm + " " + opts.listpos[j].cssnamepos;
                                            var maxHeight2 = Math.max.apply(null, $(strname, obj).map(function () {
                                                return $(this).height();
                                            }).get());
                                            var lineh = parseInt($(strname, obj).css("line-height"));
                                            if (maxHeight2 > opts.listpos[j].cssheightnum * lineh) {
                                                $(strname, obj).height(opts.listpos[j].cssheightnum * lineh);
                                            } else {
                                                $(strname, obj).height(maxHeight2);
                                            }
                                        }

                                    }
                                }
                            } 
                        } else {
                            if (opts.activetit) {
                                for (var i = 0; i < lenw; i++) {

                                    var maxHeight = Math.max.apply(null, $(opts.listcss[i].cssname, obj).map(function () {
                                        return $(this).height();
                                    }).get());
                                    $(opts.listcss[i].cssname, obj).height(maxHeight);
                                }
                            }
                            if (opts.desbool) {
                                for (var j = 0; j < lendes; j++) {
                                    var maxHeight2 = Math.max.apply(null, $(opts.listpos[j].cssnamepos, obj).map(function () {
                                        return $(this).height();
                                    }).get());
                                    var lineh = parseInt($(opts.listpos[j].cssnamepos, obj).css("line-height"));
                                    if (maxHeight2 > opts.listpos[j].cssheightnum * lineh) {
                                        $(opts.listpos[j].cssnamepos, obj).height(opts.listpos[j].cssheightnum * lineh);
                                    } else {
                                        $(opts.listpos[j].cssnamepos, obj).height(maxHeight2);
                                    }
                                }
                            }
                        }
                    } else {

                        if (opts.tbrow) {
                            if (numcol > 1) {
                                if (opts.activetit) {
                                    for (var j = 0; j < numstrp; j++) {
                                        var colm = "[data-row='row-" + (j + 1) + "']";
                                        for (var i = 0; i < lenw; i++) {
                                            var strcol = colm + " " + opts.listcss[i].cssname;
                                            var maxHeight = Math.min.apply(null, $(strcol, obj).map(function () {
                                                return $(this).height();
                                            }).get());
                                            $(strcol, obj).height(maxHeight);
                                        }

                                    }
                                }
                                if (opts.desbool) {
                                    for (var k = 0; k < numstrp; k++) {
                                        var colm = "[data-row='row-" + (k + 1) + "']";
                                        for (var j = 0; j < lendes; j++) {
                                            var strname = colm + " " + opts.listpos[j].cssnamepos;
                                            var maxHeight2 = Math.min.apply(null, $(strname, obj).map(function () {
                                                return $(this).height();
                                            }).get());
                                            var lineh = parseInt($(strname, obj).css("line-height"));
                                            if (maxHeight2 > opts.listpos[j].cssheightnum * lineh) {
                                                $(strname, obj).height(opts.listpos[j].cssheightnum * lineh);
                                            } else {
                                                $(strname, obj).height(maxHeight2);
                                            }
                                        }

                                    }
                                }
                            } 
                        } else {
                            if (opts.activetit) {
                                for (var i = 0; i < lenw; i++) {
                                    var maxHeight = Math.min.apply(null, $(opts.listcss[i].cssname, obj).map(function () {
                                        return $(this).height();
                                    }).get());
                                    $(opts.listcss[i].cssname, obj).height(maxHeight);
                                }
                            }
                            if (opts.desbool) {
                                for (var j = 0; j < lendes; j++) {
                                    var maxHeight2 = Math.min.apply(null, $(opts.listpos[j].cssnamepos, obj).map(function () {
                                        return $(this).height();
                                    }).get());
                                    var lineh = parseInt($(opts.listpos[j].cssnamepos, obj).css("line-height"));
                                    if (maxHeight2 > opts.listpos[j].cssheightnum * lineh) {
                                        $(opts.listpos[j].cssnamepos, obj).height(opts.listpos[j].cssheightnum * lineh);
                                    } else {
                                        $(opts.listpos[j].cssnamepos, obj).height(maxHeight2);
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }
    });
})(jQuery);