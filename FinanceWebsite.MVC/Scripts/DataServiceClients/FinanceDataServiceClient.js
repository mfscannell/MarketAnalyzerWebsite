var FinanceDataServiceClient = (function () {
    var baseUrl = 'http://localhost:63993/dataApi';

    return {
        getStockHistoryData: function (tickerSymbol, chartBeginDate, chartEndDate, uppers, lowers) {
            return new Promise(
                function (resolve, reject) {
                    var url = baseUrl + '/stocks/history';
                    url += '?tickerSymbol=' + tickerSymbol;
                    url += '&beginDate=' + chartBeginDate;
                    url += '&endDate=' + chartEndDate;
                    url += '&uppers=[';

                    for (var i = 0; i < uppers.length; i++) {
                        if (i > 0) {
                            url += ','
                        }

                        url += '{%22Type%22:%22' + uppers[i].type + '%22,%22Params%22:%22' + uppers[i].params + '%22}';
                    }

                    url += ']';
                    url += '&lowers=[';

                    for (var i = 0; i < lowers.length; i++) {
                        if (i > 0) {
                            url += ','
                        }

                        url += '{%22Type%22:%22' + lowers[i].type + '%22,%22Params%22:%22' + lowers[i].params + '%22}';
                    }

                    url += ']';

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