function changeChart(actualchart) {
    if (actualchart == "vertical") {
        $("#pie").removeClass("active");
        $("#vertical").addClass("active");
        $("#pie-chart").prop('hidden', true);
        $("#vert-chart").prop('hidden', false);
    }

    if (actualchart == "pie") {
        $("#pie").addClass("active");
        $("#vertical").removeClass("active");
        $("#pie-chart").prop('hidden', false);
        $("#vert-chart").prop('hidden', true);
    }
}