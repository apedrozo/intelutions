//---------------------------------------------------------------------------
// <copyright file="IPermissionRepository.cs" company="Intelutions">
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
    public interface IPermissionRepository
    {
        /// <summary>
        /// Crea una nuevo permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<Permission> Create(Permission permission);

        /// <summary>
        /// Actualiza un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<bool> Update(int id, Permission permission);

        /// <summary>
        /// Elimina un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Obtiene un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta con la información del permiso.</returns>
        Task<Permission> Get(int id);

        /// <summary>
        ///  Obtiene un listado de los permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de permisos.</returns>
        Task<IEnumerable<Permission>> GetAll(int pageSize = 100, int pageIndex = 0);
    }
}
