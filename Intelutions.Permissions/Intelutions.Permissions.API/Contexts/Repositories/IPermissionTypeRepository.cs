//---------------------------------------------------------------------------
// <copyright file="IPermissionTypeRepository.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts.Repositories
{
    using Intelutions.Permissions.API.Contexts.DataModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Define las operaciones para la gestión de permisos.
    /// </summary>
    public interface IPermissionTypeRepository
    {
        /// <summary>
        /// Crea una nuevo tipo de permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<PermissionType> Create(PermissionType permissionType);

        /// <summary>
        /// Actualiza un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<bool> Update(int id, PermissionType permissionType);

        /// <summary>
        /// Elimina un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Obtiene un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta con la información del tipo de permiso.</returns>
        Task<PermissionType> Get(int id);

        /// <summary>
        ///  Obtiene un listado de los tipos de permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de tipos de permisos.</returns>
        Task<List<PermissionType>> GetAll(int pageSize = 100, int pageIndex = 0);

        /// <summary>
        /// Obtiene el número total de registros.
        /// </summary>
        /// <returns>Número de registros totales.</returns>
        Task<long> GetCount();
    }
}
