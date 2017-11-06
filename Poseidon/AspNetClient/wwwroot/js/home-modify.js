
$("#sign").click(function () {
    $("#mark").attr("disabled", !this.checked);
    $("#mark").val("1");
});

function Submit(url) {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var studentId = $("#studentId").text();
    var semester = $("#semester").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var params = { id,studentId, sign, mark, semester };

    $.ajax({
        url: url,
        type: "POST",
        data: "id=" + id + "&studentId=" + studentId + "&sign=" + sign + "&mark=" + mark + "&semester=" + semester,
        success: function (data) { $("#ResultMessage").text(data); },
        error: function (error) { }
    });
    $("#myModal").modal('hide');
    $("#SuccessModal").fadeTo(800, 500).slideUp(500, function () {
        $("#SuccessModal").slideUp(200);
    });
    window.setTimeout('location.reload()', 500);
    
}

function Delete(url) {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var studentId = $("#studentId").text();
    var semester = $("#semester").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var params = { id, studentId, sign, mark, semester };

    $.ajax({
        url: url,
        type: "POST",
        data: "id=" + id + "&studentId=" + studentId + "&sign=" + sign + "&mark=" + mark + "&semester=" + semester,
        success: function (data) { $("#ResultMessage").text(data); },
        error: function (error) { }
    });
    $("#myModal").modal('hide');
    $("#SuccessModal").fadeTo(800, 500).slideUp(500, function () {
        $("#SuccessModal").slideUp(200);
    });
    window.setTimeout('location.reload()', 500);
}


