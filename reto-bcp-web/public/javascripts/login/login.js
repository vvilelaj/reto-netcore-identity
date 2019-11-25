$(document).ready(() => {
    debugger;

    var view = new LoginView();
    var loginProvider = new AuthProvider();
    var localStorage = new LocalStorage();

    var config = {
        loginView: view,
        loginProvider: loginProvider,
        localStorage: localStorage
    };

    var presenter = new LoginPresenter(config);
});