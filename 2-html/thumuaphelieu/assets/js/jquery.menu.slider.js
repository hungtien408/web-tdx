(function($){
	$.fn.extend({
		showMenu: function(options) {
			var defaults = {
					csswrap: ".wrap-in",
					csswrapa: ".wrap-a",
					csslinka: ".link-a",
					cssrev: ".btn-prev",
					cssnext: ".btn-next",
					csscurrent: "current",
                    showm: false,
					minw: 10 //khoang canh it mhat
				};
			var options = $.extend(defaults, options);
			return this.each(function() {
				var opts =options;
				var obj = $(this);           
				var items = $(opts.csslinka, obj);
				var wrapbox = $(opts.csswrap, obj);
				var wrapboxa = $(opts.csswrapa, obj);
				var btnprev = $(opts.cssrev, obj);
				var btnnext = $(opts.cssnext, obj);
				/*==============*/
				var i = 0;
				var countlink = items.size();
				var wa = opts.minw;
				var wlis = 0;
				items.each(function (e) {
					$(this).width($(this).width());
					wlis += ($(this).width() + wa) ;
				});
				wrapboxa.width(wlis);
				btnnext.addClass(".btn-a");
				btnprev.addClass(".btn-a");
				var clearmy;
				myprev(i);
				btnnext.click(function () {
					i++;
					var ia = i;
					myreauto();
					i = mynext(ia);
					return false;
				});
				btnprev.click(function () {
					i--;
					var ia = i;
					if (i < 0) {
						ia = 0;
					}
					myreauto();
					i = myprev(ia);
					return false;
				});
				$(window).resize(function () {
				    myreauto();
				    clearTimeout(clearmy);
				    clearmy = setTimeout(function () {
				        var currenti = obj.find("." + opts.csscurrent).index();
				        i = myprev(currenti);
				    }, 0);
				});
				/*====================*/
				function myprev(batdau) {
				    //items.show();
				    //items.width("auto");
					//wrapbox.width("auto");
					//wrapboxa.width("auto");
					var totalsum = 0;
					var totalw = 0;
					if (batdau == 0) {
					    btnprev.hide();
					    var wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth());
					} else {
					    btnprev.show();
					    var wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth() * 2);
					}
					var stepstart = batdau;
					var stepend = 0;
					var enda = 0;
					var btna = 0;
					var countlink = items.size();
					var numc = 0;
					for (var k = stepstart; k < countlink; k++) {
					    if (totalsum >= wrapwidth) {
					        totalw = totalsum - (items.filter(":eq(" + (k - 1) + ")").width() + wa);
					        stepend = k - 1;
					        break;
					    } else {
					        totalsum += (items.filter(":eq(" + k + ")").outerWidth() + wa);
					    }
					}
					items.removeClass(opts.csscurrent);
					items.filter(":eq(" + stepstart + ")").addClass(opts.csscurrent);

					var sumwi = 0;
					var wlink = 0;
					var totalad = 0;
					for (var kj = 0; kj < countlink; kj++) {
					    totalad += (items.filter(":eq(" + kj + ")").outerWidth() + wa);
					    numc++;
					}
					if (totalsum < wrapwidth && obj.width() >= totalad) {
					    stepend = countlink;
					    wrapwidth = obj.width();
					    btna = obj.find(".btn-a").outerWidth();
					    obj.find(".btn-a").hide();
					    if (opts.showm) {
					        wlink = parseInt((wrapwidth - totalad) / stepend);
					    } else {
					        if (wrapwidth - totalad >= btna) {
					            wlink = Math.round(btna / stepend);
					        } else {
					            wlink = 0;
					        }
					    }
					    for (var j = 0; j < stepend; j++) {
					        var wj = items.filter(":eq(" + j + ")").width() + wlink + wa;
					        items.filter(":eq(" + j + ")").width(wj);
					    }
					    //alert("aaa");
					    wrapbox.width(wrapwidth);
					    wrapboxa.width(wrapwidth);
					} else {
					    items.filter(":lt(" + stepstart + ")").hide();
					    if (stepend == 0) {
					        for (var j = stepstart; j < countlink; j++) {
					            totalw += (items.filter(":eq(" + j + ")").width() + wa);
					            stepend = countlink;
					        }

					        if (totalw > wrapwidth) {
					            totalw = totalw - (items.filter(":eq(" + (stepend - 1) + ")").width() + wa);
					            //wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth());
					            stepend = countlink - 1;
					            items.filter(":gt(" + (stepend - 1) + ")").hide();
					            btnnext.show();
					            //alert("bbb" + totalw + " - " + wrapwidth);
					        } else {
					            wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth());
					            btnnext.hide();
					            stepend = countlink;
					            //alert("ccc");
					        }
					    } else {
					        //alert("ddd");
					        btnnext.show();
					        items.filter(":gt(" + (stepend - 1) + ")").hide();
					    }
					    wlink = parseInt((wrapwidth - totalw) / (stepend - stepstart));
					    if (wlink < 0) {
					        wlink = 0;
					    }
					    for (var j = stepstart; j < stepend; j++) {
					        var wj = items.filter(":eq(" + j + ")").width() + wlink + wa;
					        sumwi += wj;
					        items.filter(":eq(" + j + ")").width(wj);
					    }
					    if (sumwi + 1 >= wrapwidth) {
					        wrapbox.width(sumwi - 1);
					    } else {
					        wrapbox.width(sumwi);
					    }
					    wrapboxa.width(sumwi);
					}
					return stepstart;
				}

				function mynext(batdau) {
				    //items.show();
					//items.width("auto");
					//wrapbox.width("auto");
					//wrapboxa.width("auto");
					var totalsum = 0;
					var totalw = 0;
					var wp = wa;
					if (batdau == 0) {
					    btnprev.hide();
					    var wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth());
					} else {
					    btnprev.show();
					    var wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth() * 2);
					}
					obj.attr("data-wid", wrapwidth);
					var stepstart = batdau - 1;
					var stepend = 0;
					var enda = 0;
					var countlink = items.size();
					for (var k = stepstart; k < countlink; k++) {
					    if (totalsum >= wrapwidth) {
					        totalw = totalsum;
					        stepend = k;
					        break;
					    } else {
					        totalsum += (items.filter(":eq(" + k + ")").outerWidth() + wa);
					    }
					}
					var totali = 0;
					for (var ji = stepstart; ji < stepend; ji++) {
					    if (totalw < wrapwidth) {
					        totali = totalw;
					        stepstart = ji;
					        break;
					    } else {
					        totalw = totalw - (items.filter(":eq(" + ji + ")").outerWidth() + wa);
					    }
					}

					items.removeClass(opts.csscurrent);
                    
					//if (totalsum < wrapwidth) {
					//} else {
					//}
					if (stepend == 0) {
					    items.width("auto");
					    for (var ja = stepstart; ja < countlink; ja++) {
					        totalw += (items.filter(":eq(" + ja + ")").width() + wa);
					        stepend = countlink;
					    }

					    if (totalw > wrapwidth) {
					        totali = totalw - (items.filter(":eq(" + stepstart + ")").width() + wa);
					        wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth());
					        stepstart = stepstart + 1;
					        stepend = countlink;
					        if (totali > wrapwidth) {
					            wp = wa - parseInt((totali - wrapwidth) / 2);
					            totali = 0;
					            wrapwidth = 0;
					        }
					        btnnext.hide();
					        //alert("aa" + stepstart + " - " + stepend + " - " + totali);
					    } else {
					        wrapwidth = obj.width() - (obj.find(".btn-a").outerWidth() * 2);
					        totali = totalw;
					        btnnext.show();
					        wp = wa;
					        //alert("ab");
					    }
					} else {
					    //alert("ac");
					    btnnext.show();
					    items.filter(":gt(" + (stepend - 1) + ")").hide();
					    wp = wa;
					}
					//alert(wp);
					items.filter(":eq(" + stepstart + ")").addClass(opts.csscurrent);
					items.filter(":lt(" + stepstart + ")").hide();
					var sumwi = 0;
					var wlink = parseInt((wrapwidth - totali) / (stepend - stepstart));
					if (wlink < 0) {
					    wlink = 0;
					}

					for (var j = stepstart; j < stepend; j++) {
					    var wj = items.filter(":eq(" + j + ")").width() + wlink + wp;
					    sumwi += wj;
					    items.filter(":eq(" + j + ")").width(wj);
					}
                    
					if (sumwi + 1 >= wrapwidth) {
					    wrapbox.width(sumwi - 1);
					} else {
					    wrapbox.width(sumwi);
					}
					wrapboxa.width(sumwi);
					//alert(stepstart);
					return stepstart;
				}
			    /*===============*/
				function myreauto() {
				    items.show();
				    items.width("auto");
				    wrapbox.width("auto");
				    wrapboxa.width("auto");
				}
			});

		}
	});
})(jQuery);