
$("#sign").click(function () {
    $("#mark").attr("disabled", !this.checked);
    $("#mark").val("1");

});
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
