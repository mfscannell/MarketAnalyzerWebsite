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

        var tickerSymbol = $('#h2TickerSymbol').text();
        var chartBeginDate = $('#edtChartBeginDate').val();
        var chartEndDate = $('#edtChartEndDate').val();

        FinanceDataServiceClient.getStockHistoryData(
            tickerSymbol,
            chartBeginDate,
            chartEndDate,
            uppersList,
            lowersList
        ).then(function (result) {
            var groupingUnits = [[
                'day',
                [1]
            ]];

            var series = [];

            for (var i = 0; i < result.length; i++) {
                for (var j = 0; j < result[i].Data.length; j++) {
                    result[i].Data[j]['X'] = Date.parse(result[i].Data[j]['X']);
                }

                var chartSeries = {
                    color: result[i].Color,
                    type: result[i].Type,
                    name: result[i].Name,
                    dashStyle: result[i].DashStyle,
                    data: [],
                    dataGrouping: {
                        units: groupingUnits
                    },
                    yAxis: result[i].YAxis
                };

                for (var j = 0; j < result[i].Data.length; j++) {
                    var newDatum = {};

                    Object.keys(result[i].Data[j]).forEach(function (key) {
                        newDatum[StringUtilities.lowerCaseFirstLetter(key)] = result[i].Data[j][key];
                    });

                    chartSeries.data.push(newDatum);
                }

                if (chartSeries.type == 'line') {
                    chartSeries.lineWidth = 1;
                }

                series.push(chartSeries);
            }

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
                    text: tickerSymbol
                },
                xAxis: [{
                    min: new Date(chartBeginDate).getTime()
                }],
                yAxis: [{
                    labels: {
                        align: 'left',
                        x: -3
                    },
                    title: {
                        text: 'OHLC'
                    },
                    height: '60%',
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
                    top: '65%',
                    height: '35%',
                    offset: 0,
                    lineWidth: 2
                }],
                tooltip: {
                    split: true
                },
                series: series
            });
        }).catch(function (error) {
            alert('ERROR!');
        });
    });

    $("#btnAddUpperIndicator").click(function () {
        var indicatorType = $("#upperIndicatorTypeSelect option:selected").text();
        var indicatorParameters = $("#upperIndicatorParametersInput").val();
        var newListItem = '';
        newListItem += '<div class="container">';
        newListItem += '<div class="row upperIndicator">';
        newListItem += '<div class="col-md-7 indicatorType">' + indicatorType + '</div>';
        newListItem += '<div class="col-md-2 indicatorParameters">' + indicatorParameters + '</div>';
        newListItem += '<div class="col-md-1">';
        newListItem += '<button type="submit" class="removeUpperIndicator btn btn-danger">-</button>';
        newListItem += '</div>';
        newListItem += '</div>';
        newListItem += '</div>';
        $("#selectedUpperIndicators").append(newListItem);
    });

    $("#btnAddLowerIndicator").click(function () {
        var indicatorType = $("#lowerIndicatorTypeSelect option:selected").text();
        var indicatorParameters = $("#lowerIndicatorParametersInput").val();
        var newListItem = '';
        newListItem += '<div class="container">';
        newListItem += '<div class="row lowerIndicator">';
        newListItem += '<div class="col-md-7 indicatorType">' + indicatorType + '</div>';
        newListItem += '<div class="col-md-2 indicatorParameters">' + indicatorParameters + '</div>';
        newListItem += '<div class="col-md-1">';
        newListItem += '<button type="submit" class="removeLowerIndicator btn btn-danger">-</button>';
        newListItem += '</div>';
        newListItem += '</div>';
        newListItem += '</div>';
        $("#selectedLowerIndicators").append(newListItem);
    });

    $('#selectedUpperIndicators').on('click', '.removeUpperIndicator', function () {
        $(this).closest(".upperIndicator").remove();
    });

    $('#selectedLowerIndicators').on('click', '.removeLowerIndicator', function () {
        $(this).closest(".lowerIndicator").remove();
    });
});