
$("#sign").click(function () {
    $("#mark").attr("disabled", !this.checked);
    $("#mark").val("1");

});

function Submit() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var semester = $("#semester").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var params = { id, sign, mark, semester };

    $.ajax({
        url: "Home/Modify",
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

function Delete() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var semester = $("#semester").text();
    var params = { id, sign, mark, semester };

    $.ajax({
        url: "Home/Delete",
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