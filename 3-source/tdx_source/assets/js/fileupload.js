//insert video
function file_change(sender, args) { check_upload_queue(sender); }

function check_upload_queue(ctrl) {
    var btn = document.getElementById("btn-upload");
    if (ctrl.GetFiles().length > 0) btn.className = "upload";
    else btn.className = "upload-d";
}

function add_file(ctrl, el) {
    ctrl.AddFile();
    if (ctrl.FileCount == ctrl.MaximumFileCount) el.className = "add-d";
}

function remove_file(ctrl, item) {
    if (ctrl.FileCount > 1) ctrl.RemoveFileAt(item);
    //else { ctrl.ClearFiles();ctrl.AddFile(); }
    //else ctrl.ClearFiles();
    //ctrl.ClearFiles();

    if (ctrl.FileCount < ctrl.MaximumFileCount) document.getElementById("btn-add").className = "add";
}


function upload_begin(sender, args) {
    //UploadDialog.Show();
}


function upload_end(sender, args) {
    //alert('upload done')
    Upload1.dispose();
    var abc = function () {
        init_upload1(Upload2);
    };
    setTimeout(abc, 1500);
}
function upload_end1(sender, args) {
    //alert('upload done')
    Upload3.dispose();
    if ($('.hdnImg').val() != "") {
        var def = function () {
            init_upload4(Upload4);
        };
        setTimeout(def, 1500);
    }
}

function generate_file_list(ctrl, cur) {
    var files = ctrl.GetFiles();
    var out = "";
    var cls = "done";

    for (var f in files) {
        var file = files[f].substring(files[f].lastIndexOf("\\") + 1, files[f].length);
        var li = "<li class=\"" + cls + "\">";
        if (file == cur) {
            li = (ctrl.Uploading) ? "<li class=\"cur\">" : "<li class=\"done\">";
            cls = "";
        }
        out += li + file + "</li>";
    }

    return "<ul>" + out + "</ul>";
}

//	File size functions
function format_file_size(n, fmt) {
    if (!fmt) {		//	no formatting specified; automatically select the best format
        if (n < 1000) fmt = "b";
        else if (n < 1000000) fmt = "kb";
        else if (n < 1000000000) fmt = "mb";
        else fmt = "gb";
    }

    switch (fmt.toLowerCase()) {
        case "kb": return String((n * 0.001).toFixed(2)) + " KB"; break;
        case "mb": return String((n * 0.000001).toFixed(2)) + " MB"; break;
        case "gb": return String((n * 0.000000001).toFixed(2)) + " GB"; break;
        default: return String(n.toFixed(2)) + " B";
    }
}

function get_percentage(n) { return String(Math.round(n * 100)); }

//	Time functions
function format_time(t, txt) {
    var s = Math.floor(t);
    var m = Math.floor(s / 60);
    var h = Math.floor(m / 60);

    if (!txt) {
        //	Output will always have be least mm:ss
        s = pad_time(s % 60);
        m = pad_time(m % 60) + ":";
        h = (h == 0) ? "" : pad_time(h % 60) + ":";

        return (h + m + s);
    } else {
        var secs = (s > 1) ? "seconds" : "second"; 		//	plural & singular second units
        var mins = (m > 1) ? "minute" : "minute"; 		//	plural & singular minute units
        var hours = (h > 1) ? "hours" : "hour"; 			//	plural & singular hour units

        s = (s > 0) ? String(s) + " " + secs : ""; 		//	string or empty?
        m = (m > 0) ? String(m) + " " + mins : ""; 		//	string or empty?
        h = (h > 0) ? String(h) + " " + hours : ""; 		//	string or empty?

        var out = "";
        if (h !== "") {										//	longer than an hour
            out = h;
            if (m != "") out += ", " + m; 				//	at least one minute
            if (s != "") out += ", " + s; 				//	at least one second
        }

        if (m !== "" && out == "") {						//	shorter than an hour, greater than 60 seconds
            out += m;
            if (s != "") out += ", " + s; 				//	at least one second
        }

        if (s !== "" && out == "") out = s; 				//	at least one second

        if (out == "") out = "less than 1 second"; 		//	less than a second

        return out;
    }
}

function pad_time(t) { return String(((t > 9) ? "" : "0") + t); }

function get_file_position(ctrl, cur) {
    var files = ctrl.GetFiles();
    for (var i = 0; i < files.length; i++) {
        var file = files[i].substring(files[i].lastIndexOf("\\") + 1, files[i].length);
        if (file == cur) return String(i + 1);
    }

    return "1";
}

function init_upload(ctrl) {
    var errorMessage = "";
    var fileNewImgVal = $('.fileNewImg').val();
    var fileNewImgEx = fileNewImgVal.substr(fileNewImgVal.lastIndexOf(".", fileNewImgVal.length), fileNewImgVal.length).toLowerCase();
    var fileNewVideoVal = $('.fileNewVideo').val();
    var fileNewVideoEx = fileNewVideoVal.substr(fileNewVideoVal.lastIndexOf(".", fileNewVideoVal.length), fileNewVideoVal.length).toLowerCase();
    var titleVal = $('.txtNewTitle').val();
    var desVal = $('.txtNewDescription').val();
    if (fileNewImgVal == "Chọn hình video (.jpg .gif . png)") {
        errorMessage += "Chưa chọn hình Video! \n";
    }
    else if (fileNewImgEx != ".jpg" && fileNewImgEx != ".jpeg" && fileNewImgEx != ".png" && fileNewImgEx != ".gif") {
        errorMessage += "Định dạng hình sai (.jpg .gif .png)! \n";
    }
    if (fileNewVideoVal == "Chọn file Video (.flv .mp4)") {
        errorMessage += "Chưa chọn Video! \n";
    }
    else if (fileNewVideoEx != ".flv" && fileNewVideoEx != ".mp4") {
        errorMessage += "Định dạng Video sai (.flv .mp4)! \n";
    }
    if (titleVal == "") {
        errorMessage += "Chưa nhập tên video! \n";
    }
    if (desVal == "") {
        errorMessage += "Chưa nhập mô tả! \n";
    }
    if (errorMessage == "") {
        ctrl.Upload();
        UploadDialog.Show();
    }
    else {
        alert(errorMessage);
    }
}

function init_upload1(ctrl) {
    ctrl.Upload();
    Dialog1.Show();
}

function setValue() {
    $('.hdnVideo').val($('.fileNewVideo').val());
}

(new Image()).src = "assets/assets/images/vertical.png";


//update video
function init_upload3(ctrl) {
    ctrl.Upload();
    UploadDialog.Show();
}
function init_upload4(ctrl) {
    ctrl.Upload();
    Dialog1.Show();
}
function checkfileupload() {
    var fileEditVideoVal = $('.fileEditVideo').val();
    var fileEditImgVal = $('.fileEditImg').val();
    var titleVal = $('.txtEditTitle').val();
    var desVal = $('.txtEditDescription').val();

    if (fileEditVideoVal == "Chọn file Video (.flv .mp4)" && fileEditImgVal == "Chọn hình video (.jpg .gif . png)") {
        if (titleVal == "" || desVal == "")
            return false;
        else
            return true;
    }
    else {
        var fileEditVideoEx = "";
        var fileEditImgEx = "";
        var titleVal = $('.txtEditTitle').val();
        var desVal = $('.txtEditDescription').val();
        var errorMessage = "";

        if (fileEditVideoVal != "Chọn file Video (.flv .mp4)") {
            fileEditVideoEx = fileEditVideoVal.substr(fileEditVideoVal.lastIndexOf(".", fileEditVideoVal.length), fileEditVideoVal.length).toLowerCase();
            $('.hdnVideo').val(fileEditVideoVal);
            if (fileEditVideoEx != ".flv" && fileEditVideoEx != ".mp4") {
                errorMessage += "Định dạng Video sai (.flv .mp4)! \n";
            }
        }
        if (fileEditImgVal != "Chọn hình video (.jpg .gif . png)") {
            fileEditImgEx = fileEditImgVal.substr(fileEditImgVal.lastIndexOf(".", fileEditImgVal.length), fileEditImgVal.length).toLowerCase();
            $('.hdnImg').val(fileEditImgVal);
            if (fileEditImgEx != ".jpg" && fileEditImgEx != ".jpeg" && fileEditImgEx != ".png" && fileEditImgEx != ".gif") {
                errorMessage += "Định dạng hình sai (.jpg .gif .png)! \n";
            }
        }

        if (titleVal == "") {
            errorMessage += "Chưa nhập tên video! \n";
        }
        if (desVal == "") {
            errorMessage += "Chưa nhập mô tả! \n";
        }
        if (errorMessage == "") {
            if ($('.hdnVideo').val() == "") {
                init_upload4(Upload4);
            }
            else {
                if ($('.hdnImg').val() != "") {
                    Upload3.AutoPostBack = false;
                }
                init_upload3(Upload3);
            }
        }
        else {
            alert(errorMessage);
        }

        return false;
    }
}