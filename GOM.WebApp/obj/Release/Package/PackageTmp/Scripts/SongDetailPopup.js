$(function () {

    $('#centralModalSm').on('show.bs.modal', function (e) {
        var btn = $(e.relatedTarget);
        noteid = btn.data("song-id");

        $("#centralModalSm_body").load("/Note/GetSongText/" + noteid);   //partial dönecek  modal_notedetail_body içine koyacak
    })

});