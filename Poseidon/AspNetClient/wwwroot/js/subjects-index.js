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
    $("#myModal").modal();
    //document.getElementById("myModal").setAttribute("style", "display:normal");
}

function Submit() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var semester = $("#semester").val();
    var params = { id,sign,mark, semester };

    $.ajax({
        url: "Subjects/Register",
        type: "POST",
        data: "id=" + id + "&sign=" + sign + "&mark=" + mark + "&semester=" + semester,
        success: function (data) { $("#ResultMessage").text(data); },
        error: function (error) { }
    });
    $("#myModal").modal('hide');
    $("#SuccessModal").fadeTo(800, 500).slideUp(500, function () {
        $("#SuccessModal").slideUp(200);
    });
}