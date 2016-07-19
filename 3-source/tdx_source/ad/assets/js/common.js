function ValidateComboBox(source, args) {
    var controltovalidate = jQuery(source).attr("controltovalidate");
    args.IsValid = $('#' + controltovalidate + '_HiddenField').val() != "0";
}

function openwindow(URL, width, height) {
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    var childWindow = window.open(URL, "mywindow", "menubar=0,scrollbars=1,resizable=1,copyhistory=0,location=0,width=" + width + ",height=" + height + ",top=" + top + ",left=" + left);
    childWindow.focus();
}

function ValidateComboBox(source, args) {
    var controltovalidate = jQuery(source).attr("controltovalidate");
    args.IsValid = $('#' + controltovalidate + '_HiddenField').val() != "0";
}

function changeActiveMenu(page) {
    $('.sf-menu a').removeClass("active");
    $('.sf-menu a[href*=' + page + ']').addClass("active").parent().parent().parent().find('> a').addClass("active");
}

function numbersonly(myfield, e, dec) {
    var key;
    var keychar;
    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    keychar = String.fromCharCode(key);

    // control keys
    if ((key == null) || (key == 0) || (key == 8) || (key == 9) || (key == 13) || (key == 27))
        return true;

    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;

    // decimal point jump
    else if (dec && (keychar == ".")) {
        myfield.form.elements[dec].focus();
        alert("Number only.\nEx: 123.456,55");
        return false;
    } else
        alert("Number only.\nEx: 123.456,55");
    return false;
}

function formatCurrency(num) {
    num = num.toString().replace(/\$|\./g, '');
    if (isNaN(num))
        num = "0";
    sign = (num == (num = Math.abs(num)));
    num = Math.floor(num * 100 + 0.50000000001);
    cents = num % 100;
    num = Math.floor(num / 100).toString();
    if (cents < 10)
        cents = "0" + cents;
    for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
        num = num.substring(0, num.length - (4 * i + 3)) + '.' +
                    num.substring(num.length - (4 * i + 3));
    return (((sign) ? '' : '-') + num);
}

function TextboxSelect() {
    $('input:text').focus(function () {
        $(this).select();
    });
}

$(function () {
    $('input:text').focus(function () {
        $(this).select();
    });
});

