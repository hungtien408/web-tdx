(function($){
    $.fn.extend({
        menulevel: function(options) {
            var defaults = {
                csscurrent: "current",
                cssopne: "open",
                cssactive: "active",
                datalevel: "data-level",
                iconsa: true,
                cssicon: false,
                cssdown: "icon-caret-down",
                cssup: "icon-caret-up"
            };
            var options = $.extend(defaults, options);
            return this.each(function() {
                var opts =options;
                var obj = $(this);    
                var items = $("a", obj);
                var itemsli = $("li", obj);
                var itemsactive = $("." + opts.cssactive, obj); 
                //itemsli.each(function () {
                //    $(this).filter(":has('ul li')").find("a:first").attr("href", "javascript:void(0);").append('<span class="iconr iconadown"></span><span class="iconr iconaup"></span>');
                //});
                if (opts.iconsa) {
                    itemsli.filter(":has('ul li')").find("a:first").attr("href", "javascript:void(0);").append('<span class="iconr iconadown"></span><span class="iconr iconaup"></span>');
                } else {
                    itemsli.filter(":has('ul li')").find("a:first").attr("href", "javascript:void(0);");
                }
                if (opts.cssicon) {
                    items.find(".iconadown").addClass(opts.cssdown);
                    items.find(".iconaup").addClass(opts.cssup);
                }
                items.click(function () {
                    var mlevel = $(this).parent("li").parent("ul").attr(opts.datalevel);
                    $("ul[" + opts.datalevel + "='" + mlevel + "'] > li").removeClass(opts.csscurrent);
                    $(this).toggleClass(opts.cssopne).parent("li").addClass(opts.csscurrent);
                    itemsli.each(function () {
                        var mulevel1 = $(this).parent("ul").attr(opts.datalevel);
                        var mulevel2 = $(this).find("ul:first").attr(opts.datalevel);
                        if ($(this).hasClass(opts.csscurrent) && $(this).find("a:first").hasClass(opts.cssopne)) {
                            $(this).find("ul:first").slideDown();
                        } else {
                            $(this).find("a:first").removeClass(opts.cssopne);
                            $(this).find("ul:first").slideUp();
                        }
                    });
                    //return false;
                });
                itemsactive.each(function () {
                    $(this).addClass(opts.csscurrent).find("a:first").addClass(opts.cssopne);
                    $(this).find("ul:first").show();
                });
            });
        }
    });
})(jQuery);