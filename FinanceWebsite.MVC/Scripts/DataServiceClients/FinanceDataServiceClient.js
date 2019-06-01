var FinanceDataServiceClient = (function () {
    //var baseUrl = 'http://localhost:63993/dataApi';
    var baseUrl = '/api';

    var formatTechnicalIndicators = function(technicalIndicators) {
        var params = '['

        for (var i = 0; i < technicalIndicators.length; i++) {
            if (i > 0) {
                params += ','
            }

            params += '{%22Type%22:%22' + technicalIndicators[i].type + '%22,%22Params%22:%22' + technicalIndicators[i].params + '%22}';
        }

        params += ']';

        return params;
    }

    return {
        getStockHistoryData: function (tickerSymbol, chartBeginDate, chartEndDate, uppers, lowers) {
            return new Promise(
                function (resolve, reject) {
                    var url = baseUrl + '/stocks/history';
                    url += '?tickerSymbol=' + tickerSymbol;
                    url += '&beginDate=' + chartBeginDate;
                    url += '&endDate=' + chartEndDate;
                    url += '&uppers=' + formatTechnicalIndicators(uppers);
                    url += '&lowers=' + formatTechnicalIndicators(lowers);

                    $.ajax({
                        type: 'GET',
                        url: url,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (result) {
                            resolve(result);
                        },
                        error: function (error) {
                            reject(error);
                        }
                    });
                });
        }
    }
})();