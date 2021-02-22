//---------------------------------------------------------------------------
// <copyright file="PermissionRepository.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts.Repositories
{
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las operaciones para la gestión de permisos.
    /// </summary>
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Crea una instancia de la clas <see cref="PermissionRepository"/>.
        /// </summary>
        /// <param name="context">Contexto de la base de datos de la aplicación.</param>
        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Crea una nuevo permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<Permission> Create(Permission permission)
        {
            var ePermission = _context.Permissions.Add(permission).Entity;
            await _context.SaveChangesAsync();

            return ePermission;
        }

        /// <summary>
        /// Actualiza un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Update(int id, Permission permission)
        {
            var ePermission = await Get(permission.PermissionId);
            if (ePermission is null)
            {
                return false;
            }

            ePermission.EmployeeFirstname = permission.EmployeeFirstname;
            ePermission.EmployeeLastname = permission.EmployeeLastname;
            ePermission.PermissionTypeId = permission.PermissionTypeId;
            ePermission.PermissionDate = permission.PermissionDate;

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        /// <summary>
        /// Elimina un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Delete(int id)
        {
            var ePermission = await Get(id);
            if (ePermission != null)
            {
                _context.Permissions.Remove(ePermission);
            }

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        /// <summary>
        /// Obtiene un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta con la información del permiso.</returns>
        public async Task<Permission> Get(int id)
        {
            var permission = await _context.Permissions
                .Include(x => x.PermissionType).FirstOrDefaultAsync(x => x.PermissionId == id);

            return permission;
        }

        /// <summary>
        ///  Obtiene un listado de los permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de permisos.</returns>
        public async Task<IEnumerable<Permission>> GetAll(int pageSize = 100, int pageIndex = 0)
        {
            List<Permission> permissions = await _context.Permissions.Include(p => p.PermissionType)
                .OrderByDescending(p => p.PermissionDate)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return permissions;
        }
    }
}
