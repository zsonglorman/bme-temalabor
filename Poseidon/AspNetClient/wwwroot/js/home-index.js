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