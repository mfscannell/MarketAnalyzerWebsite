function generateHtmlForSelectedTechnicalIndicator(upperLower, type, params) {
    var newListItem = '';
    newListItem += '<div class="container">';
    newListItem += `<div class="row ${upperLower}Indicator">`;
    newListItem += '<div class="col-md-7 indicatorType">' + type + '</div>';
    newListItem += '<div class="col-md-2 indicatorParameters">' + params + '</div>';
    newListItem += '<div class="col-md-1">';
    newListItem += `<button type="submit" class="remove${StringUtilities.upperCaseFirstLetter(upperLower)}Indicator btn btn-danger">-</button>`;
    newListItem += '</div>';
    newListItem += '</div>';
    newListItem += '</div>';

    return newListItem;
}

$(document).ready(function () {
    $('#btnUpdateChart').click(function () {
        var uppersList = [];
        var lowersList = [];

        $('.upperIndicator').each(function (index) {
            var indicatorType = $(this).find('.indicatorType').text();
            var indicatorParameters = $(this).find('.indicatorParameters').text();

            uppersList.push({ type: indicatorType, params: indicatorParameters });
        });

        $('.lowerIndicator').each(function (index) {
            var indicatorType = $(this).find('.indicatorType').text();
            var indicatorParameters = $(this).find('.indicatorParameters').text();

            lowersList.push({ type: indicatorType, params: indicatorParameters });
        });

        var tickerSymbol = $('#inputTickerSymbol').val();
        var chartBeginDate = $('#edtChartBeginDate').val();
        var chartEndDate = $('#edtChartEndDate').val();

        FinanceDataServiceClient.getStockHistoryData(
            tickerSymbol,
            chartBeginDate,
            chartEndDate,
            uppersList,
            lowersList).then(function (result) {
                for (var i = 0; i < result.length; i++) {
                    result[i].dataGrouping = {
                        units: [[
                            'day',
                            [1]
                        ]]
                    };

                    for (var j = 0; j < result[i].data.length; j++) {
                        result[i].data[j]['x'] = Date.parse(result[i].data[j]['x']);
                    }
                }

                var yAxis = [{
                    labels: {
                        align: 'left',
                        x: -3
                    },
                    title: {
                        text: ''
                    },
                    height: '40%',
                    lineWidth: 2,
                    resize: {
                        enabled: true
                    }
                }, {
                    labels: {
                        align: 'left',
                        x: -3
                    },
                    title: {
                        text: 'Volume'
                    },
                    top: '40%',
                    height: '15%',
                    offset: 0,
                    lineWidth: 2
                    }];

                lowersList.forEach(function (lower) {
                    yAxis.push({
                        labels: {
                            align: 'left',
                            x: -3
                        },
                        title: {
                            text: lower.type
                        },
                        top: `${40 + 15 * (yAxis.length - 1)}%`,
                        height: '15%',
                        offset: 0,
                        lineWidth: 2
                    });
                });

                Highcharts.stockChart('stockContainer', {
                    navigator: {
                        enabled: false
                    },
                    rangeSelector: {
                        enabled: false
                    },
                    scrollBar: {
                        enabled: false
                    },
                    title: {
                        text: ''
                    },
                    xAxis: [{
                        min: new Date(chartBeginDate).getTime(),
                        offset: -0.41*900
                    }],
                    yAxis: yAxis,
                    tooltip: {
                        split: true
                    },
                    series: result
                });
            }).catch(function (error) {
                alert('ERROR!');
            });
    });

    $("#btnAddUpperIndicator").click(function () {
        var indicatorType = $("#upperIndicatorTypeSelect option:selected").text();
        var indicatorParameters = $("#upperIndicatorParametersInput").val();
        var newListItem = generateHtmlForSelectedTechnicalIndicator('upper', indicatorType, indicatorParameters);
        $("#selectedUpperIndicators").append(newListItem);
    });

    $("#btnAddLowerIndicator").click(function () {
        var indicatorType = $("#lowerIndicatorTypeSelect option:selected").text();
        var indicatorParameters = $("#lowerIndicatorParametersInput").val();

        var newListItem = generateHtmlForSelectedTechnicalIndicator('lower', indicatorType, indicatorParameters);
        $("#selectedLowerIndicators").append(newListItem);
    });

    $('#selectedUpperIndicators').on('click', '.removeUpperIndicator', function () {
        $(this).closest(".upperIndicator").remove();
    });

    $('#selectedLowerIndicators').on('click', '.removeLowerIndicator', function () {
        $(this).closest(".lowerIndicator").remove();
    });
});