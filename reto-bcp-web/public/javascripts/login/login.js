$(document).ready(() => {
    var view = new LoginView();
    var loginProvider = new AuthProvider();
    var localStorage = new LocalStorage();
    var general = new General();

    var config = {
        loginView: view,
        loginProvider: loginProvider,
        localStorage: localStorage,
        general: general
    };

    var presenter = new LoginPresenter(config);
});