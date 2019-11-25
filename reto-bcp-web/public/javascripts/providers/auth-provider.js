class AuthProvider {
    constructor() {
    }

    promiseLogin(data) {
        var dfd = jQuery.Deferred();
        jQuery.ajax({
            type: "post",
            url: AuthApi.BASE + AuthApi.LOGIN,
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