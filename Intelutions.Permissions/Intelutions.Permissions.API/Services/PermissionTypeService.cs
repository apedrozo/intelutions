//---------------------------------------------------------------------------
// <copyright file="PermissionTypeService.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Services
{
    using AutoMapper;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Contexts.Repositories;
    using Intelutions.Permissions.API.Contracts.Responses;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Servicio que define la gestión de tipos de permisos.
    /// </summary>
    public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        
        /// <summary>
        /// Crea una instancia de la clas <see cref="PermissionTypeService"/>.
        /// </summary>
        /// <param name="permissionTypeRepository">Repositorio para la gestión de tipos de permiso.</param>
        public PermissionTypeService(IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionTypeRepository = permissionTypeRepository ?? throw new ArgumentNullException(nameof(permissionTypeRepository));
        }

        /// <summary>
        /// Crea una nuevo tipo de permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<PermissionType> Create(PermissionType permissionType)
        {
            return await _permissionTypeRepository.Create(permissionType);
        }

        /// <summary>
        /// Actualiza un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Update(int id, PermissionType permissionType)
        {
            return await _permissionTypeRepository.Update(id, permissionType);
        }

        /// <summary>
        /// Elimina un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Delete(int id)
        {
            return await _permissionTypeRepository.Delete(id);
        }

        /// <summary>
        /// Obtiene un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta con la información del tipo de permiso.</returns>
        public async Task<PermissionType> Get(int id)
        {
            return await _permissionTypeRepository.Get(id);
        }

        /// <summary>
        ///  Obtiene un listado de los tipos de permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de tipos de permisos.</returns>
        public async Task<List<PermissionType>> GetAll(int pageSize = 100, int pageIndex = 0)
        {
            return await _permissionTypeRepository.GetAll(pageSize, pageIndex);
        }

        /// <summary>
        /// Obtiene el número total de registros.
        /// </summary>
        /// <returns>Número de registros totales.</returns>
        public async Task<long> GetCount()
        {
            return await _permissionTypeRepository.GetCount();
        }
    }
}
