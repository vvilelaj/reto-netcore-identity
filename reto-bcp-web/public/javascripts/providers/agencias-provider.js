class AgenciasProvider {
    constructor() {
    }

    promiseGetAgencias(data) {
        var dfd = jQuery.Deferred();
        
        jQuery.ajax({
            type: "get",
            url: AgenciasApi.BASE + AgenciasApi.LIST,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            //data: JSON.stringify(data),
            async: true,
            cache: false,
            crossDomain: true,
            headers: {
                'Authorization' : 'Bearer ' + data
            },
            success: function (data) {
                dfd.resolve(data);
            },
            error: function (data, error) {
                dfd.reject(data, error);
            }
        });

        return dfd.promise();
    }
}