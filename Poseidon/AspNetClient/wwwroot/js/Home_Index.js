function getPartialView(id,url) {
    url = url.concat("/" + id);
    $.ajax({
        url: url,
        type: "GET",
        cache: false,
        success: function (result) {
            $("#SubjectModify").html(result)
        }
    });
    $("#myModal").modal();
}

function Delete() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var semester = 1;//$("#semester").val();
    var params = { id, sign, mark, semester };

    $.ajax({
        url: "Subjects/Delete",
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

function Update() {
    if (($("#mark").val() < 1) || ($("#mark").val() > 5)) {

        $("#markForm").addClass("has-error");
        return;
    }
    var id = $("#id").text();
    var sign = $("#sign").prop("checked");
    var mark = $("#mark").val();
    var semester = 1;//$("#semester").val();
    var params = { id, sign, mark, semester };

    $.ajax({
        url: "Subjects/Update",
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