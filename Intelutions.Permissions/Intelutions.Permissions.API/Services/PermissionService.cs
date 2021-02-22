//---------------------------------------------------------------------------
// <copyright file="PermissionService.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Services
{
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Contexts.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las operaciones para la gestión de permisos.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        /// <summary>
        /// Crea una instancia de la clas <see cref="PermissionService"/>.
        /// </summary>
        /// <param name="permissionRepository">Repositorio para la gestión de permisos.</param>
        /// <param name="permissionTypeRepository">Repositorio para la gestión de tipos de permiso.</param>
        public PermissionService(
            IPermissionRepository permissionRepository, 
            IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            _permissionTypeRepository = permissionTypeRepository ?? throw new ArgumentNullException(nameof(permissionTypeRepository));
        }

        /// <summary>
        /// Crea una nuevo permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<Permission> Create(Permission permission)
        {
            var permissionType = await _permissionTypeRepository.Get(permission.PermissionTypeId);
            if (permissionType is null)
            {
                throw new Exception("El tipo de permiso no existe");
            }
            
            return await _permissionRepository.Create(permission);
        }

        /// <summary>
        /// Actualiza un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Update(int id, Permission permission)
        {
            return await _permissionRepository.Update(id, permission);
        }

        /// <summary>
        /// Elimina un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Delete(int id)
        {
            return await _permissionRepository.Delete(id);
        }

        /// <summary>
        /// Obtiene un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta con la información del permiso.</returns>
        public async Task<Permission> Get(int id)
        {
            return await _permissionRepository.Get(id);
        }

        /// <summary>
        ///  Obtiene un listado de los permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de permisos.</returns>
        public async Task<IEnumerable<Permission>> GetAll(int pageSize = 100, int pageIndex = 0)
        {
            return await _permissionRepository.GetAll(pageSize, pageIndex);
        }
    }
}
