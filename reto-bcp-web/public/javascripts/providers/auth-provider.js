class AuthProvider {
    constructor() {
        this.url = {
            login: "http://localhost:10000/api/auth/"
            
        };
    }

    promiseLogin(data) {
        var dfd = jQuery.Deferred();
        jQuery.ajax({
            type: "post",
            url: this.url.login,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            async: true,
            cache: false,
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