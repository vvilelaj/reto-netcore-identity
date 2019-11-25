class AgenciasPresenter {
    constructor(config) {
        if (typeof config === "undefined" || config === null) throw "config is null or undefined";
        if (typeof config.agenciasView === "undefined" || config.agenciasView === null) throw "config.agenciasView is null or undefined";
        if (typeof config.agenciasProvider === "undefined" || config.agenciasProvider === null) throw "config.agenciasProvider is null or undefined";
        if (typeof config.localStorage === "undefined" || config.localStorage === null) throw "config.localStorage is null or undefined";
        if (typeof config.general === "undefined" || config.general === null) throw "config.general is null or undefined";

        this._config = config;

        //this._config.localStorage.removeItem(LocalStorageKey.TOKEN);

        let tokenObject = this._config.localStorage.getItem(LocalStorageKey.TOKEN);

        if (typeof tokenObject === "undefined" || tokenObject === null) {
            this._config.agenciasView.ShowUserNotAuthenticatedPanel();
            return false;
        }

        this._config
            .agenciasProvider
            .promiseGetAgencias(tokenObject.data)
            .done(
                (data) => {
                    console.log(data.data);
                    this._config.agenciasView.ShowUserAuthenticatedPanel(data.data);
                })
            .fail(
                (data, error) => {
                    console.error("agenciasProvider.promiseLogin retrieval error");
                    console.error(data);
                    console.error(error);
                    this._config.loginView.showMessage('Error : No se pudo recuperar informacion de agencias.');
                });

        return false;
    }
}