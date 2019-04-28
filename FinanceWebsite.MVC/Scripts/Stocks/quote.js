function getStockHistory() {
    var tickerSymbol = $('#h2TickerSymbol').text();
    var url = 'http://localhost:63993/dataApi/stocks/history'
    url += '?tickerSymbol=' + tickerSymbol;
    url += '&beginDate=' + $('#edtChartBeginDate').val();
    url += '&endDate=' + $('#edtChartEndDate').val();

    var uppers = '';

    $('.upperIndicator').each(function (index) {
        if (index > 0) {
            uppers += ','
        }

        uppers += '{';

        var indicatorType = $(this).find('.indicatorType').text();
        var indicatorParameters = $(this).find('.indicatorParameters').text();

        uppers += '%22Type%22:%22' + indicatorType;
        uppers += '%22,%22Params%22:%22' + indicatorParameters;

        uppers += '%22}'


        var something2 = 5;
    });

    url += '&uppers=[' + uppers + ']';

    var something3 = 5;

    $.ajax({
        type: 'GET',
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (result) {
            var something6 = 5;
            //var ohlc = [];
            //var volume = [];
            var groupingUnits = [[
                'day',
                [1]
            ]];

            var series = [];

            for (var i = 0; i < result.length; i++) {
                for (var j = 0; j < result[i].Data.length; j++) {
                    result[i].Data[j][0] = Date.parse(result[i].Data[j][0]);
                }

                series.push({
                    type: result[i].Type,
                    name: result[i].Name,
                    data: result[i].Data,
                    dataGrouping: {
                        units: groupingUnits
                    },
                    yAxis: result[i].YAxis
                });
            }

            //for (var i = 0; i < result.length; i++) {
            //    result[i].NewDate = new Date(parseInt(result[i].Date.replace('/Date(', '').replace(')/', ''), 10));

            //    ohlc.push([
            //        Date.parse(result[i].Date),
            //        result[i].Open,
            //        result[i].High,
            //        result[i].Low,
            //        result[i].AdjClose
            //    ]);

            //    volume.push([
            //        Date.parse(result[i].Date),
            //        result[i].Volume
            //    ]);
            //}

            Highcharts.stockChart('stockContainer', {
                navigator: {
                    enabled: false
                },

                rangeSelector: {
                    enabled: false
                },

                plotOptions: {
                    candlestick: {
                        color: 'red',
                        upColor: 'green'
                    }
                },

                scrollBar: {
                    enabled: false
                },
                title: {
                    text: tickerSymbol
                },

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
                //    [{
                //    type: 'candlestick',
                //    name: tickerSymbol,
                //    data: ohlc,
                //    dataGrouping: {
                //        units: groupingUnits
                //    }
                //}, {
                //    type: 'column',
                //    name: 'Volume',
                //    data: volume,
                //    yAxis: 1, // For new chart below first
                //    dataGrouping: {
                //        units: groupingUnits
                //    }
                //}]
            });
        },
        error: function (error) {
            alert('ERROR!');
        }
    });
}

$(document).ready(function () {
    $('#btnUpdateChart').click(getStockHistory);

    $("#btnAddUpperIndicator").click(function () {
        var indicatorType = $("#upperIndicatorTypeSelect option:selected").text();
        var indicatorParameters = $("#upperIndicatorParametersInput").val();
        var newListItem = '';
        newListItem += '<div class="row upperIndicator">';
        newListItem += '<div class="col-md-2 indicatorType">' + indicatorType + '</div>';
        newListItem += '<div class="col-md-1 indicatorParameters">' + indicatorParameters + '</div>';
        newListItem += '<div class="col-md-1">';
        newListItem += '<button type="submit" class="removeUpperIndicator btn btn-danger">-</button>';
        newListItem += '</div>';
        newListItem += '</div>';
        $("#selectedUpperIndicators").append(newListItem);
    });

    $('#selectedUpperIndicators').on('click', '.removeUpperIndicator', function () {
        $(this).closest(".upperIndicator").remove();
    });
});