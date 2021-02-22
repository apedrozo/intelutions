//---------------------------------------------------------------------------
// <copyright file="PermissionTypeRepository.cs" company="Intelutions">
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

    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Crea una instancia de la clas <see cref="PermissionTypeService"/>.
        /// </summary>
        /// <param name="context">Contexto de la base de datos de la aplicación.</param>
        public PermissionTypeRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Crea una nuevo tipo de permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<PermissionType> Create(PermissionType permissionType)
        {
            var ePermissionType = _context.PermissionTypes.Add(permissionType).Entity;
            await _context.SaveChangesAsync();

            return ePermissionType;
        }

        /// <summary>
        /// Actualiza un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Update(int id, PermissionType permissionType)
        {
            var ePermissionType = await Get(permissionType.PermissionTypeId);
            if (ePermissionType is null)
            {
                return false;
            }
            
            ePermissionType.Description = permissionType.Description;
            
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        /// <summary>
        /// Elimina un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        public async Task<bool> Delete(int id)
        {
            var ePermissionType = await Get(id);
            if (ePermissionType != null)
            {
                _context.PermissionTypes.Remove(ePermissionType);
            }

            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        /// <summary>
        /// Obtiene un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta con la información del tipo de permiso.</returns>
        public async Task<PermissionType> Get(int id)
        {
            var permissionType = await _context.PermissionTypes
                .FirstOrDefaultAsync(x => x.PermissionTypeId == id);

            return permissionType;
        }

        /// <summary>
        ///  Obtiene un listado de los tipos de permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de tipos de permisos.</returns>
        public async Task<List<PermissionType>> GetAll(int pageSize = 100, int pageIndex = 0)
        {
            List<PermissionType> permissionTypes = await _context.PermissionTypes
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return permissionTypes;
        }

        /// <summary>
        /// Obtiene el número total de registros.
        /// </summary>
        /// <returns>Número de registros totales.</returns>
        public async Task<long> GetCount()
        {
            return await _context.Permissions.LongCountAsync();
        }
    }
}
