class AgenciasView {

    constructor() {

        this._elements = {
            userNotAuthenticatedPanel: {
                id: '#panel-usuario-no-autenticado'
            },
            userAuthenticatedPanel: {
                id: '#panel-agencias',
                tableBody: '#agencias'
            }
        };
    }

    ShowUserNotAuthenticatedPanel() {
        $(this._elements.userNotAuthenticatedPanel.id).show();
        $(this._elements.userAuthenticatedPanel.id).hide();
    }

    ShowUserAuthenticatedPanel(agencias) {
        if (typeof agencias === "undefined" || agencias === null)
            throw "AgenciasView.ShowUserAuthenticatedPanel : agencias is null or undefined";

        if (typeof agencias.length === "undefined" || agencias.length === null)
            throw "AgenciasView.ShowUserAuthenticatedPanel : agencias is not a list";

        let html = '';
        $.each(agencias, (index, el) => {
            html += '<tr>';
            for (let key in el) {
                html += `<td>${el[key]}</td>`;
            }
            html += '</tr>';
        });


        $(this._elements.userNotAuthenticatedPanel.id).hide();
        $(this._elements.userAuthenticatedPanel.tableBody).html('');
        $(this._elements.userAuthenticatedPanel.tableBody).html(html);
        $(this._elements.userAuthenticatedPanel.id).show();
    }
}