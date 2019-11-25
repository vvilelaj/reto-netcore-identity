class LoginView {
    get addLoginClickedEventHandler() { return this._addLoginClickedEventHandler; }
    set addLoginClickedEventHandler(v) { this._addLoginClickedEventHandler = v; }

    constructor() {
        this._addLoginClickedEventHandler = null;

        this._elements = {
            login: {
                username: '#username',
                password: '#password',
                btnLogin: '#login'
            }
        };

        $(this._elements.login.btnLogin).off('click');
        $(this._elements.login.btnLogin).on('click', (e) => {
            var eventArg = {
                usuario: $(this._elements.login.username).val(),
                contrasena: $(this._elements.login.password).val()
            };
            this._addLoginClickedEventHandler(e.target, eventArg);
            return false;
        });
    }

    showMessage(message) {
        if (typeof message === "undefined" || message === null)
            throw "LoginView.showMessage : message is null or undefined";

        alert(message);
    }
}