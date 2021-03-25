var noteid = -1;
var modalCommentBodyId = "#modal_comment_body";

 

function doComment(btn, e, commentid, spanid) {

    var button = $(btn);
    var mode = button.data("edit-mode");

    if (e === "edit_clicked") {
        if (!mode) {
            button.data("edit-mode", true);
            button.removeClass("btn-warning");
            button.addClass("btn-success");
            var btnSpan = button.find("span");
            btnSpan.removeClass("fa-edit");
            btnSpan.addClass("fa-check-circle");

            $(spanid).addClass("editable");
            $(spanid).attr("contenteditable", true);
            $(spanid).focus();
        }
        else {
            button.data("edit-mode", false);
            button.addClass("btn-warning");
            button.removeClass("btn-success");
            var btnSpan = button.find("span");
            btnSpan.addClass("fa-edit");
            btnSpan.removeClass("fa-check-circle");

            $(spanid).removeClass("editable");
            $(spanid).attr("contenteditable", false);

            var txt = $(spanid).text();

            $.ajax({
                method: "POST",
                url: "/Comment/Edit/" + commentid,
                data: { text: txt }
            }).done(function (data) {

                if (data.result) {
                    // yorumlar partial tekrar yüklenir..
                    $(modalCommentBodyId).load("/Comment/ShowNoteComments/" + noteid);
                }
                else {
                    alert("Yorum güncellenemedi.");
                }

            }).fail(function () {
                alert("Sunucu ile bağlantı kurulamadı.");
            });
        }

    }
    else if (e === "delete_clicked") {
        var dialog_res = confirm("Yorum silinsin mi?");
        if (!dialog_res) return false;

        $.ajax({
            method: "GET",
            url: "/Comment/Delete/" + commentid
        }).done(function (data) {

            if (data.result) {
                // yorumlar partial tekrar yüklenir..
                $(modalCommentBodyId).load("/Comment/ShowNoteComments/" + noteid);
            } else {
                alert("Yorum silinemedi.");
            }

        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.");
        });

    } else if (e === "new_clicked") {

        var txt = $("#new_comment_text").val();

        $.ajax({
            method: "POST",
            url: "/Comment/Create",
            data: { "text": txt, "noteid": noteid }
        }).done(function (data) {

            if (data.result) {
                // yorumlar partial tekrar yüklenir..
                $(modalCommentBodyId).load("/Comment/ShowNoteComments/" + noteid);
            } else {
                alert("Yorum eklenemedi.");
            }

        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.");
        });

    }

}