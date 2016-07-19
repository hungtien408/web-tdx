(function ($) {
    $.fn.extend({

        mobilepanel: function (options) {

            // Đặt các giá trị mặc định
            var defaults = {
                panelLeft: "data-position",
                paneltype: "data-type", //true overlay, false reveal
                speed: 400,
                wrapperid: "#wrapper",
                cssmenu: ".menu-mobile",
                widthshow: 767,
                easing: null
            };

            var options = $.extend(defaults, options);

            return this.each(function () {
                var opts = options;

                // Đặt tên biến cho element (ul)
                var obj = $(this);
                var cssPrefix, cssPrefix, animProp;
                var positonLR = obj.attr(opts.panelLeft);
                var typep = obj.attr(opts.paneltype);
                var numtran = "120%";
                var usingCSS = (function () {
                    // create our test div element
                    var div = document.createElement('div');
                    // css transition properties
                    var props = ['WebkitPerspective', 'MozPerspective', 'OPerspective', 'msPerspective'];
                    // test for each property
                    for (var i in props) {
                        if (div.style[props[i]] !== undefined) {
                            //cssPrefix = props[i].replace('Perspective', '').toLowerCase();
                            //animProp = '-' + cssPrefix + '-transform';
                            return true;
                        }
                        //else {
                        //    //animProp = 'transform';
                        //}
                    }
                    return false;
                } ());
                // Thêm sự kiện click vào thẻ a
                if (opts.easing) {
                    var easings = opts.easing;
                } else {
                    var easings = 'swing';
                }

                //                $(".mobile-panel").css("left", '-100%');

                if (!usingCSS) {
                    if (typep == "true") {
                        $(".mobile-panel").css("left", '-100%');
                    } else{
                        $(name).removeClass("open-in").stop(true, true).animate({ "opacity": 0 }, 0);
                    }
                }
                obj.click(function (event) {
                    $(this).toggleClass("open");
                    var items = $(this).attr("href");
                    if (usingCSS) {
                        if (typep.toLowerCase() == "true") {
                            myfuntran($(this), items);
                            $(window).resize(function () {
                                mobileLR(items);
                            });
                        } else {
                            myfuntranreveal($(this), items, positonLR);
                            $(window).resize(function () {
                                mobileLRreveal(items, positonLR);
                            });
                        }
                    } else {
                        if (typep.toLowerCase() == "true") {
                            myfunanimate($(this), items, positonLR, opts.speed, easings);
                            $(window).resize(function () {
                                mobileLRa(items, positonLR);
                            });
                        } else {
                            myfunanimatereveal($(this), items, positonLR, opts.speed, easings);
                            $(window).resize(function () {
                                mobileLRareveal(items, positonLR);
                            });
                        }
                    }
                    return false;
                });
                //functions-tranform===========================================================================
                // tranform menu overlay=======================================
                function myfuntran(thisv, name) {
                    if (thisv.hasClass("open")) {
                        myaddtype();
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 200);
                        $(name).after('<div class="mask-panel" data-id="' + name + '"></div>');
                        mymenuheight(name);
                        mytranformfun(name, true, true, false, false);
                    } else {
                        mytranformfun(name, false, false, true, false);
                    }
                    $(".mask-panel[data-id='" + name + "']").click(function () {
                        mytranformfun(name, false, false, true, true);
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 500);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                    $(name).find("[href='" + name + "']").click(function () {
                        mytranformfun(name, false, false, true, true);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                }
                /*==================overlay=======================*/
                function mobileLR(idmenu) {
                    $(opts.wrapperid).css("min-height", $(window).height() + "px");
                    if ($(window).width() < opts.widthshow & obj.hasClass("open")) {
                        mymenuheight(idmenu);
                        mytranformsh(idmenu, true, true);
                    } else {
                        mytranformsh(idmenu, false, false);
                    }
                }
                function mytranformsh(name, active, show) {
                    mytranforms(name, active);
                    if (show) {
                        $(".mask-panel[data-id='" + name + "']").show();
                    } else {
                        $(".mask-panel[data-id='" + name + "']").hide();
                    }
                }
                function mytranformfun(name, active, addover, remov, reclose) {
                    mytranforms(name, active);
                    if (addover) {
                        $(opts.wrapperid).addClass("overflow");
                    } else {
                        $(opts.wrapperid).removeClass("overflow");
                    }
                    if (reclose) {
                        $("[href='" + name + "']").removeClass("open");
                    }
                    if (remov) {
                        $(".mask-panel[data-id='" + name + "']").remove();
                    }
                }
                function mytranforms(name, active) {
                    if (active) {
                        $(name).addClass("mobile-active");
                    } else {
                        $(name).removeClass("mobile-active");
                    }
                }
                // tranform main reveal==================================
                function myfuntranreveal(thisv, name, lr) {
                    if (thisv.hasClass("open")) {
                        myaddtype();
                        $(name).after('<div class="mask-panel" data-id="' + name + '"></div>');
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 10);
                        mymenuheight(name);
                        mytranformfunreveal(name, lr, true, true, false, false);
                    } else {
                        mytranformfunreveal(name, lr, false, false, true, false);
                    }
                    $(".mask-panel[data-id='" + name + "']").click(function () {
                        mytranformfunreveal(name, lr, false, false, true, true);
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 500);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                    $(name).find("[href='" + name + "']").click(function () {
                        mytranformfunreveal(name, lr, false, false, true, true);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                }
                /*========reveal========*/
                function mobileLRreveal(idmenu, lr) {
                    $(opts.wrapperid).css("min-height", $(window).height() + "px");
                    if ($(window).width() < opts.widthshow & obj.hasClass("open")) {
                        mymenuheight(idmenu);
                        mytranformshreveal(idmenu, true, true, lr);
                    } else {
                        mytranformshreveal(idmenu, false, false, lr);
                    }
                }
                function mytranformshreveal(name, active, show, poslr) {
                    mytranformreveal(name, active, poslr);
                    if (show) {
                        $(".mask-panel[data-id='" + name + "']").show();
                    } else {
                        $(".mask-panel[data-id='" + name + "']").hide();
                    }
                }
                function mytranformfunreveal(name, poslr , active, addover, remov, reclose) {
                    if (addover) {
                        $(opts.wrapperid).addClass("overflow");
                    } else {
                        $(opts.wrapperid).removeClass("overflow");
                    }
                    mytranformreveal(name, active, poslr);
                    if (reclose) {
                        $("[href='" + name + "']").removeClass("open");
                    }
                    if (remov) {
                        $(".mask-panel[data-id='" + name + "']").remove();
                    }
                }
                function mytranformreveal(name, active, poslr) {
                    var strpanel = "mobile-active-right";
                    if (poslr.toLowerCase() == "true") {
                        strpanel = "mobile-active-left";
                    }
                    if (active) {
                        $(name).addClass("open-in").stop(true, true).animate({ "opacity": 1 }, 10, function () {
                            $("body").addClass(strpanel);
                        });
                    } else {
                        $(name).removeClass("open-in").stop(true, true).animate({ "opacity": 0 }, 10, function () {
                            $("body").removeClass(strpanel);
                        });
                    }
                }
                //functions-animate-overlay===========================================================================
                function myfunanimate(thisv, name, lr, speeds, easing) {
                    if (lr.toLowerCase() == "true") {
                        $(name).css({ "left": "-100%", "right": "auto" });
                    } else {
                        $(name).css({ "left": "auto", "right": "-100%" });
                    }
                    if (thisv.hasClass("open")) {
                        myaddtype();
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 200);
                        $(name).after('<div class="mask-panel" data-id="' + name + '"></div>');
                        mymenuheight(name);
                        myanimate(name, lr, "0", opts.speed, easings, true, false, false, false);
                    }
                    $(".mask-panel[data-id='" + name + "']").click(function () {
                        myanimate(name, lr, "-100%", opts.speed, easings, false, true, true, true);
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 500);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                    $(name).find("[href='" + name + "']").click(function () {
                        myanimate(name, lr, "-100%", opts.speed, easings, false, true, true, true);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                }
                //=========overlay====================================
                function mobileLRa(idmenu, lr) {
                    $(opts.wrapperid).css("min-height", "100%");
                    if ($(window).width() < opts.widthshow & obj.hasClass("open")) {
                        mymenuheight(idmenu);
                        myanimatesh(idmenu, lr, "0", opts.speed, easings, false, true, false, false, true);
                    } else {
                        myanimatesh(idmenu, lr, "-100%", opts.speed, easings, false, true, false, false, false);
                    }
                }
                function myanimatesh(name, mylr, numx, speeds, easing, addover, removover, remov, reclose, show) {
                    myanimate(name, mylr, numx, speeds, easing, addover, removover, remov, reclose);
                    if (show) {
                        $(".mask-panel[data-id='" + name + "']").show();
                    } else {
                        $(".mask-panel[data-id='" + name + "']").hide();
                    }
                }
                function cssa(name, mylr, numx) {
                    $(name).css(mylr, numx);
                }
                function myanimate(name, lr, numx, speeds, easing, addover, removover, remov, reclose) {
                    if (addover) {
                        $(opts.wrapperid).addClass("overflow");
                    }
                    if (lr.toUpperCase() == "TRUE") {
                        $(name).stop(true, true).animate({ "left": numx }, speeds, easing, function () {
                            if (removover) {
                                $(opts.wrapperid).removeClass("overflow");
                            }
                            if (reclose) {
                                $("[href='" + name + "']").removeClass("open");
                            }
                            if (remov) {
                                $(".mask-panel[data-id='" + name + "']").remove();
                            }
                        });
                    } else {
                        $(name).stop(true, true).animate({ "right": numx }, speeds, easing, function () {
                            if (removover) {
                                $(opts.wrapperid).removeClass("overflow");
                            }
                            if (reclose) {
                                $("[href='" + name + "']").removeClass("open");
                            }
                            if (remov) {
                                $(".mask-panel[data-id='" + name + "']").remove();
                            }
                        });
                    }
                }
                //functions-animate-reveal===========================================================================
                function myfunanimatereveal(thisv, name, lr, speeds, easing) {
                    if (lr.toLowerCase() == "true") {
                        $(name).css({ "left": 0, "right": "auto" });
                    } else {
                        $(name).css({ "left": "auto", "right": 0 });
                    }
                    if (thisv.hasClass("open")) {
                        myaddtype();
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 200);
                        $(name).after('<div class="mask-panel" data-id="' + name + '"></div>');
                        mymenuheight(name);
                        myanimatereveal(name, lr, "240px", opts.speed, easings, true, false, false, false);
                    }
                    $(".mask-panel[data-id='" + name + "']").click(function () {
                        myanimatereveal(name, lr, "0", opts.speed, easings, false, true, true, true);
                        $("html,body").stop(true, true).animate({ scrollTop: 0 }, 500);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                    $(name).find("[href='" + name + "']").click(function () {
                        myanimatereveal(name, lr, "0", opts.speed, easings, false, true, true, true);
                        $(opts.wrapperid).css("min-height", "100%");
                        myremovetype();
                        return false;
                    });
                }
                //=========reveal====================================
                function mobileLRareveal(idmenu, lr) {
                    $(opts.wrapperid).css("min-height", "100%");
                    if ($(window).width() < opts.widthshow & obj.hasClass("open")) {
                        mymenuheight(idmenu);
                        myanimateshreveal(name, lr, "240px", opts.speed, easings, true, false, false, false, true);
                    } else {
                        myanimateshreveal(name, lr, "0", opts.speed, easings, false, true, true, true, false);
                    }
                }
                function myanimateshreveal(name, mylr, numx, speeds, easing, addover, removover, remov, reclose, show) {
                    myanimatereveal(name, mylr, numx, speeds, easing, addover, removover, remov, reclose);
                    if (show) {
                        $(".mask-panel[data-id='" + name + "']").show();
                    } else {
                        $(".mask-panel[data-id='" + name + "']").hide();
                    }
                }
                function cssareveal(name, mylr, numx) {
                    $(name).css(mylr, numx);
                }
                function myanimatereveal(name, lr, numx, speeds, easing, addover, removover, remov, reclose) {
                    $("body").removeClass("mobile-active-left mobile-active-right");
                    if (addover) {
                        $(opts.wrapperid).addClass("overflow");
                    }
                    var myclaer;
                    clearTimeout(myclaer);
                    myclaer = setTimeout(function () {
                        if (lr.toLowerCase() == "true") {
                            $("body").addClass("mobile-active-left");
                            $("#wrapper-in").css({ "right": "auto", "left": 0 }).stop(true, true).animate({ "left": numx }, speeds, easing, function () {
                                if (removover) {
                                    $(opts.wrapperid).removeClass("overflow");
                                }
                                if (reclose) {
                                    $("[href='" + name + "']").removeClass("open");
                                }
                                if (remov) {
                                    $(".mask-panel[data-id='" + name + "']").remove();
                                }
                            });
                        } else {
                            $("body").addClass("mobile-active-right");
                            $("#wrapper-in").css({ "left": "auto", "right": 0 }).stop(true, true).animate({ "right": numx }, speeds, easing, function () {
                                if (removover) {
                                    $(opts.wrapperid).removeClass("overflow");
                                }
                                if (reclose) {
                                    $("[href='" + name + "']").removeClass("open");
                                }
                                if (remov) {
                                    $(".mask-panel[data-id='" + name + "']").remove();
                                }
                            });
                        }
                        if (numx == 0) {
                            $(name).removeClass("open-in").stop(true, true).animate({ "opacity": 0 }, speeds);
                        } else {
                            $(name).addClass("open-in").stop(true, true).animate({ "opacity": 1 }, speeds);
                        }
                    }, 300);
                }
                //functions-height===========================================================================
                function mymenuheight(idmenu) {
                    var hh = $(idmenu).find(opts.cssmenu).outerHeight();
                    if (hh > $(document).height()) {
                        //alert("aaa");
                        //$(idmenu).height(hh);
                        $(opts.wrapperid).css("min-height", hh + "px");
                        //alert("aa");
                    } else {
                        //alert("bbb");
                        //$(idmenu).height($(document).height());
                        var hmenu = $(idmenu).find(".menu-mobile").outerHeight();
                        $(opts.wrapperid).css("min-height", hmenu + "px");
                        //alert("bbb");
                    }
                }
                //funntion add remove type
                function myaddtype() {
                    if (typep.toLowerCase() == "true") {
                        $("body").addClass("panel-overlay");
                    } else {
                        $("body").addClass("panel-reveal");
                    }
                }
                function myremovetype() {
                    var myclear;
                    clearTimeout(myclear);
                    myclear = setTimeout(function () {
                        $("body").removeClass("panel-overlay panel-reveal");
                    }, 300);
                }
            });
        }
    });
})(jQuery);