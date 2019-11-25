using Microsoft.AspNetCore.Identity;
using reto_bcp_api.Dtos.CuentasUsuario;
using reto_bcp_api.Persistance.Models;
using reto_bcp_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CuentasUsuarioService : ICuentasUsuarioService
    {
        private readonly SignInManager<RetoBcpUser> _signManager;
        private readonly UserManager<RetoBcpUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signManager"></param>
        /// <param name="roleManager"></param>
        public CuentasUsuarioService(
            UserManager<RetoBcpUser> userManager, 
            SignInManager<RetoBcpUser> signManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                var createAdminRoleResult = _roleManager.CreateAsync(new IdentityRole("Admin")).Result;
            }
            if (!_roleManager.RoleExistsAsync("ApiUser").Result)
            {
                var createApiUserRoleResult = _roleManager.CreateAsync(new IdentityRole("ApiUser")).Result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cuentaUsuario"></param>
        public void Create(CuentaUsuarioDto cuentaUsuario)
        {
            if (cuentaUsuario == null)
                throw new ArgumentNullException("cuentaUsuario", "CuentasUsuarioService.Create");

            if (string.IsNullOrWhiteSpace(cuentaUsuario.Usuario))
                throw new ArgumentNullException("cuentaUsuario.Usuario", "CuentasUsuarioService.Create");

            if (string.IsNullOrWhiteSpace(cuentaUsuario.Contrasena))
                throw new ArgumentNullException("cuentaUsuario.Contrasena", "CuentasUsuarioService.Create");

            if (string.IsNullOrWhiteSpace(cuentaUsuario.ConfirmarContrasena))
                throw new ArgumentNullException("cuentaUsuario.ConfirmarContrasena", "CuentasUsuarioService.Create");

            if (cuentaUsuario.ConfirmarContrasena != cuentaUsuario.Contrasena)
                throw new ApplicationException($"cuentaUsuario.Create : campos contrasena y confirmar contrasena son distintos.");

            var user = new RetoBcpUser { UserName = cuentaUsuario.Usuario };
            var result = _userManager.CreateAsync(user, cuentaUsuario.Contrasena).Result;
            if (result != IdentityResult.Success) throw new ApplicationException($"cuentaUsuario.Create : No se pudo crear cuenta de usuario");

            if (cuentaUsuario.Usuario == "vvilelaj" || cuentaUsuario.Usuario == "bcpAdmin")
            {
                var adminResult = _userManager.AddToRoleAsync(user, "Admin").Result;
            }

            var apiUserResult = _userManager.AddToRoleAsync(user, "ApiUser").Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreUsuario"></param>
        public void Delete(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ApplicationException("CuentasUsuarioService.Delete : nombreUsuario es nulo o vacio");

            var usuario = _userManager.FindByNameAsync(nombreUsuario).Result;
            var apiUserResult = _userManager.RemoveFromRoleAsync(usuario, "ApiUser").Result;
            if (nombreUsuario == "vvilelaj" || nombreUsuario == "bcpAdmin")
            {
                var adminResult = _userManager.RemoveFromRoleAsync(usuario, "adminResult").Result;
            }
            var result = _userManager.DeleteAsync(usuario).Result;

            if (result != IdentityResult.Success) throw new ApplicationException($"cuentaUsuario.Delete : No se pudo eliminar cuenta de usuario");
        }
    }
}
