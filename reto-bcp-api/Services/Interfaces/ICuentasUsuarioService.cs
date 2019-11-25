using reto_bcp_api.Dtos.CuentasUsuario;

namespace reto_bcp_api.Services.Interfaces
{
    public interface ICuentasUsuarioService
    {
        void Create(CuentaUsuarioDto cuentaUsuario);
        void Delete(string nombreUsuario);
    }
}