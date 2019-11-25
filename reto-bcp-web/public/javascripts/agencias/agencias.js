
$(document).ready(() => {
    debugger;
    var agenciasView = new AgenciasView();
    var agenciasProvider = new AgenciasProvider();
    var localStorage = new LocalStorage();
    var general = new General();

    var config = {
        agenciasView: agenciasView,
        agenciasProvider: agenciasProvider,
        localStorage: localStorage,
        general: general
    };

    var presenter = new AgenciasPresenter(config);
});