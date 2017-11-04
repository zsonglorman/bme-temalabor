$("#sign").click(function () {
    $("#mark").attr("disabled", !this.checked);
    $("#mark").val("1");

});

function getPartialView(id,url) {
    url = url.concat("/" + id);
    $.ajax({
        url: url,
        type: "GET",
        cache: false,
        success: function (result) {
            $("#SubjectDetails").html(result)
        }
    });
    $("#sign").attr("checked", false);
    $("#mark").val('1').attr("disabled", true);
    $("#myModal").modal();
    //document.getElementById("myModal").setAttribute("style", "display:normal");
}

function Submit() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }

    $("#myModal").modal('hide');
    $("#SuccessModal").fadeTo(800, 500).slideUp(500, function () {
        $("#SuccessModal").slideUp(200);
    });
}