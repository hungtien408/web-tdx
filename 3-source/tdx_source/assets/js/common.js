function DisplaySessionTimeoutChildWindow() {
    //assigning minutes left to session timeout to Label

    sessionTimeout = sessionTimeout - 1;

    //if session is not less than 0
    if (sessionTimeout >= 0)
    //call the function again after 1 minute delay
        window.setTimeout("DisplaySessionTimeout()", 10000);
    else {
        //show message box
        alert("Due to inactivity, you will be logged out.  Click OK to log in again.");
        //window.returnValue == 2
        window.opener.LogOut();
        self.close();
    }
}

function ReloadParent() {
    window.opener.ReloadPage();
}

function ValidateComboBox(source, args) {
    var controltovalidate = jQuery(source).attr("controltovalidate");
    args.IsValid = $('#' + controltovalidate + '_HiddenField').val() != "0";
}
function DisplaySessionTimeoutParentWindow() {
    //assigning minutes left to session timeout to Label

    sessionTimeout = sessionTimeout - 1;

    //if session is not less than 0
    if (sessionTimeout >= 0)
    //call the function again after 1 minute delay
        window.setTimeout("DisplaySessionTimeout()", 10000);
    else {
        //show message box
        alert("Due to inactivity, you will be logged out.  Click OK to log in again.");
        __doPostBack('ctl00$LoginView1$LoginStatus1$ctl00', '');
    }
}

function openwindow(URL, width, height) {
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    var childWindow = window.open(URL, "mywindow", "menubar=0,scrollbars=1,resizable=1,copyhistory=0,location=0,width=" + width + ",height=" + height + ",top=" + top + ",left=" + left);
    childWindow.focus();
}

function ReloadPage() {
    $(".submitDialog").submit();
}

function LogOut() {
    __doPostBack('ctl00$LoginView1$LoginStatus1$ctl00', '');
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

$(function () {
    $('.textbox').focus(function () {
        $(this).select();
    });
});

