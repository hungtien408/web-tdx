function pageLoad() {
}
(function ($) {
    $(window).load(function () {
        var max = -1;
        $(".product-box .product-img").each(function () {
            var h = $(this).height();
            max = h > max ? h : max;
        });
        $(".product-box .product-img").css('line-height', max+'px');
        $(".product-box .product-img").css('height', max);
    });
    $(function () {
        myfunload();
        mypageload();
    });
})(jQuery);
//function===============================================================================================
/*=============================fun=========================================*/
function myfunload() {
    $(".panel-a").mobilepanel();
    $("#menu > li").clone().appendTo($("#menuMobile"));
    $("#menuMobile input").remove();
    $("#menuMobile > li > a").append('<span class="fa fa-chevron-circle-right iconar"></span>');
    $("#menuMobile li li a").append('<span class="fa fa-angle-right iconl"></span>');
    $(".fullbox-img").bgsizebox({
        fimg: true,
        imgcss: "hideo",
        attrname: "data-src"
    });
    if ($("#menuProducts").size() == 1) {
        //$("#menuProducts > li").clone().appendTo($("#menuProduct"));
        //$("#menuProduct input").remove();
        $("#menuProducts > li").clone().appendTo($("#moProduct"));
        $("#moProduct input").remove();
        $("#menuProduct > li > a").append($('<span class="iconar fa fa-chevron-circle-right"></span>'));
        $("#menuProduct ul li > a").append($('<span class="iconl fa fa-angle-right"></span>'));
        $(".menu-level").menulevel({
            csscurrent: "active",
            cssicon: true,
            cssdown: "fa fa-caret-down",
            cssup: "fa fa-caret-up"
        });
        $(".menu-level .active").find("ul:first").show();
    }
    $(".nav-tabs > li > a").append('<span class="arrow-down"></span>');
    $(".nav-tabs li:first-child").addClass("active");
    $('.slider-banner').slick({
        dots: false,
        arrows: true,
        fade: true,
        pauseOnHover: false,
        autoplay: true,
        speed: 500,
        autoplaySpeed: 3000
    });

    $('#menu > li').hover(function ()
    {
        $(this).children('.sub-menu').slideDown(600);
    },
    function () {
        $(this).children('.sub-menu').slideUp(600);
    });
    $(".icon-click").click(function () {
        $(this).toggleClass("current");
        $(".form-search").stop(true, true).toggle("slow");
    });
    if ($('.slider-tree').size() > 0) {
        $('.slider-tree').slick({
            //autoplay: true,
            //autoplaySpeed: 3000,
            infinite: true,
            dots: false,
            prevArrow: $("#slidePrevo"),
            nextArrow: $("#slideNexto"),
            slidesToShow: 3,
            slidesToScroll: 1,
            responsive: [
              {
                  breakpoint: 992,
                  settings: {
                      slidesToShow: 3,
                      slidesToScroll: 1
                  }
              },
              {
                  breakpoint: 639,
                  settings: {
                      slidesToShow: 2,
                      slidesToScroll: 1
                  }
              },
              {
                  breakpoint: 319,
                  settings: {
                      slidesToShow: 1,
                      slidesToScroll: 1
                  }
              }
              // You can unslick at a given breakpoint now by adding:
              // settings: "unslick"
              // instead of a settings object
            ]
        }).textHeight({
            activetit: true,
            listcss: [{ cssname: ".product-img" }, { cssname: ".product-name" }],
            wpointb: true,
            //widthpont: 479,
            desbool: false,
            listpos: [{ cssnamepos: ".description", cssheightnum: "3" }],
            tbrow: false,
            csstr: ".element-item",
            max: true
        });
    }
    if ($("#sliderDetails").size() == 1) {
        var bigimg = $(".small-img:first").attr("href");
        var smallimg = $(".small-img:first").attr("data-img");
        $(".cloud-zoom").attr("href", bigimg).find("img:first").attr("src", smallimg);
        jQuery('.cloud-zoom').CloudZoom();

        $('#sliderDetails .slider-for').slick({
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: false,
            infinite: false,
            fade: true,
            asNavFor: '#sliderDetails .slider-nav'
        });
        $('#sliderDetails .slider-nav').slick({
            slidesToShow: 4,
            slidesToScroll: 1,
            asNavFor: '#sliderDetails .slider-for',
            dots: false,
            infinite: false,
            //centerMode: true,
            focusOnSelect: true
        });
        $('#sliderDetails .slider-nav').on('beforeChange', function (event, slick, currentSlide, nextSlide) {
            var bigimg = $("#sliderDetails .slider-nav .slick-slide:eq(" + nextSlide + ") .small-img").attr("href");
            var smallimg = $("#sliderDetails .slider-nav .slick-slide:eq(" + nextSlide + ") .small-img").attr("data-img");
            $(".cloud-zoom").attr("href", bigimg).find("img:first").attr("src", smallimg);
            jQuery('.cloud-zoom').CloudZoom();
        });
    }
    /*  */
    $('.lh-slide').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        infinite: true,
        fade: false,
        autoplay: true,
        autoplaySpeed: 5000,
    });

    $('.img-hl').on('click', function () {
        $('.hotline-bg').toggleClass('hotline-bg-active');
        $('.img-hl').toggleClass('img-hl-active');
    });


    $(window).scroll(function () {
        if ($(this).scrollTop() > 185) {
            $('.hotline').addClass("hotlineq");
        } else {
            $('.hotline').removeClass("hotlineq");
        }
    });

    $('.two-rows-slide').slick({
        rows: 2,
        slidesToShow: 2,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });

/* */

$('#projectTab').tabs();
if ($('#mapshow').size() == 1) {
    mymap();
}
myfunsroll();

setHeigthImageOnTab();
//handle when switch the tabs
$('a[data-toggle="tab"]').off('shown.bs.tab');
$('a[data-toggle="tab"]').on('shown.bs.tab', function () {
    setHeigthImageOnTab();
});

if ($('#silderProduct').size() == 1) {
    var silderProduct = $('#silderProduct').imagesLoaded(function () {

        silderProduct.slick({
            autoplay: true,
            autoplaySpeed: 3000,
            //cssEase: 'linear',
            dots: false,
            infinite: true,
            speed: 300,
            slidesToShow: 3,
            slidesToScroll: 1,
            //prevArrow: $(".control-slider .prev"),
            //nextArrow: $(".control-slider .next"),
            responsive: [
              {
                  breakpoint: 639,
                  settings: {
                      slidesToShow: 2
                  }
              },
              {
                  breakpoint: 419,
                  settings: {
                      slidesToShow: 1
                  }
              }
              // You can unslick at a given breakpoint now by adding:
              // settings: "unslick"
              // instead of a settings object
            ]
        });
        silderProduct.textHeight({
            activetit: true,
            listcss: [{ cssname: ".product-img" }, { cssname: ".product-img" }],
            desbool: false,
            listpos: [{ cssnamepos: ".description", cssheightnum: "3" }],
            tbrow: false,
            csstr: ".element-item",
            max: true
        });
    });
}
}
/*=========================================================================*/
function mypageload() {
    $(".select-b").uniform();
    myListTb();
}
/*========================================================================*/
function myListTb() {
    if ($('.product-tb').size() > 0) {
        var producttb = $('.product-tb').imagesLoaded(function () {
            producttb.textHeight({
                activetit: true,
                listcss: [{ cssname: ".product-img" }, { cssname: ".product-name" }],
                wpointb: true,
                //widthpont: 479,
                desbool: false,
                listpos: [{ cssnamepos: ".description", cssheightnum: "3" }],
                tbrow: true,
                csstr: ".element-item",
                max: true
            });
            setTimeout(function () {
                producttb.isotope({
                    itemSelector: '.element-item',
                    layoutMode: 'fitRows'
                });
            }, 100);
        });
    }
}
/*==============================*/
function setHeigthImageOnTab() {
    if ($('.product-tab').size() > 0) {
        var producttab = $('.product-tab').imagesLoaded(function () {
            producttab.textHeight({
                activetit: true,
                listcss: [{ cssname: ".product-img" }, { cssname: ".product-name" }],
                wpointb: true,
                //widthpont: 479,
                desbool: false,
                listpos: [{ cssnamepos: ".description", cssheightnum: "3" }],
                tbrow: true,
                csstr: ".element-item",
                max: true
            });
            setTimeout(function () {
                producttab.isotope({
                    itemSelector: '.element-item',
                    layoutMode: 'fitRows'
                });
            }, 100);
        });
        
    }
}
/*===============================*/
function myfunsroll() {
    menusroll();
    mysroll();
    $("#sroltop a").click(function () {
        $("html, body").stop(true, true).animate({ scrollTop: 0 }, 500);
        return false;
    });
}
function mysroll() {
    mysrol();
    $(window).scroll(function () {
        mysrol();
    });
}
function mysrol() {
    var topsroll = $(window).scrollTop();
    if (topsroll > 100) {
        $("#sroltop").stop(true, true).animate({ "opacity": 1 }, 500);
    } else {
        $("#sroltop").stop(true, true).animate({ "opacity": 0 }, 500);
    }
}
function menusroll() {
    var htop = $("#header").height();
    srollmenu(htop);
    $(window).scroll(function () {
        srollmenu(htop);
    });
}
function srollmenu(htop) {
    if ($(window).scrollTop() > htop) {
        //$("#header").addClass("header-sroll");
    } else {
        //$("#header").removeClass("header-sroll");
    }
}
//==================
function mymap() {
    mympp();
    var timeout;
    $(window).resize(function () {
        clearTimeout(timeout);
        setTimeout(function () {
            mympp();
        }, 500);
    });
}
function mympp() {
    $('#mapwrap').remove();
    if ($(window).width() > 768) {
        $('#mapshow').append('<div id="mapwrap"><iframe id="iframe" src="map.aspx" frameborder="0" height="100%" width="100%"></iframe></div>');
    }
}