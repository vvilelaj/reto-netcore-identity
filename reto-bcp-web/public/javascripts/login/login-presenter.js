class LoginPresenter {
    constructor(config) {
        if (typeof config === "undefined" || config === null) throw "config is null or undefined";
        if (typeof config.loginView === "undefined" || config.loginView === null) throw "config.loginView is null or undefined";
        if (typeof config.loginProvider === "undefined" || config.loginProvider === null) throw "config.loginProvider is null or undefined";
        if (typeof config.localStorage === "undefined" || config.localStorage === null) throw "config.localStorage is null or undefined";

        this._config = config;
        this._config.loginView.addLoginClickedEventHandler = this.addLoginClicked.bind(this);
    }

    addLoginClicked(sender, eventArg) {
        if (typeof sender === "undefined" || sender === null) throw "LoginPresenter.addLoginClicked : sender is null or undefined";
        if (typeof eventArg === "undefined" || eventArg === null) throw "LoginPresenter.addLoginClicked : eventArg is null or undefined";

        this._config
            .loginProvider
            .promiseLogin(
                {
                    usuario : eventArg.usuario,
                    contrasena : eventArg.contrasena
                })
            .done(
                (data) => {
                    this._config.localStorage.setItem("token", data.data);
                    console.log(data.data);
                })
            .fail(
                (data, error) => {
                    throw "loginProvider.promiseLogin retrieval error";
                });

    }
}