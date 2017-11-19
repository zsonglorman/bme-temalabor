﻿var randomScalingFactor = function () {
    return Math.round(Math.random() * 100);
};



window.onload = function () {
    var ctx = document.getElementById("chart-area").getContext("2d");
    window.myPie = new Chart(ctx, config);
};

document.getElementById('randomizeData').addEventListener('click', function () {
    config.data.datasets.forEach(function (dataset) {
        dataset.data = dataset.data.map(function () {
            return randomScalingFactor();
        });
    });

    window.myPie.update();
});

var colorNames = Object.keys(window.chartColors);
document.getElementById('addDataset').addEventListener('click', function () {
    var newDataset = {
        backgroundColor: [],
        data: [],
        label: 'New dataset ' + config.data.datasets.length,
    };

    for (var index = 0; index < config.data.labels.length; ++index) {
        newDataset.data.push(randomScalingFactor());

        var colorName = colorNames[index % colorNames.length];;
        var newColor = window.chartColors[colorName];
        newDataset.backgroundColor.push(newColor);
    }

    config.data.datasets.push(newDataset);
    window.myPie.update();
});

document.getElementById('removeDataset').addEventListener('click', function () {
    config.data.datasets.splice(0, 1);
    window.myPie.update();
});