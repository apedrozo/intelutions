//---------------------------------------------------------------------------
// <copyright file="PermissionTypeController.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Controllers
{
    using AutoMapper;
    using Intelutions.Permissions.API.Contexts;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Contracts.Requests;
    using Intelutions.Permissions.API.Contracts.Responses;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una instancia de la clase <see cref="PermissionTypeController"/>.
        /// </summary>
        /// <param name="context">Contexto de la base de datos de la aplicación.</param>
        /// <param name="mapper">Mapeador de clases.</param>
        public PermissionTypeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region POST

        /// <summary>
        /// Crea una nuevo tipo de permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PermissionTypeRequest request)
        {
            var permissionType = _mapper.Map<PermissionType>(request);

            _context.PermissionTypes.Add(permissionType);
            _context.SaveChanges();

            var response = _mapper.Map<PermissionTypeResponse>(permissionType);

            return AcceptedAtAction("GetPermissionTypeById", new { id = permissionType.PermissionTypeId }, response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// Actualiza un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <param name="request">Solicitud con la información del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] PermissionTypeRequest request)
        {
            var permissionType = await _context.PermissionTypes.SingleOrDefaultAsync(p => p.PermissionTypeId == id);

            if (permissionType is null)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha actualizar no se existe"
                });
            }

            permissionType.Description = request.Description;

            _context.PermissionTypes.Update(permissionType);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<PermissionTypeResponse>(permissionType);

            return Ok(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Elimina un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var permissionType = await _context.PermissionTypes.SingleOrDefaultAsync(p => p.PermissionTypeId == id);

            if (permissionType is null)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha eliminar no se existe"
                });
            }

            _context.PermissionTypes.Remove(permissionType);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Tipo de permiso eliminado"
            });
        }

        #endregion

        #region GET

        /// <summary>
        /// Obtiene un tipo de permiso.
        /// </summary>
        /// <param name="id">Identificador del tipo de permiso.</param>
        /// <returns>Respuesta con la información del tipo de permiso.</returns>
        [HttpGet("{id}", Name = "GetPermissionTypeById")]
        public async Task<ActionResult<PermissionTypeResponse>> GetPermissionById(int id)
        {
            var permissionType = await _context.PermissionTypes.SingleOrDefaultAsync(p => p.PermissionTypeId == id);

            if (permissionType is null)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha eliminar no se existe"
                });
            }

            return _mapper.Map<PermissionTypeResponse>(permissionType);
        }

        /// <summary>
        /// Obtiene un listado de los tipos de permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de tipos de permisos.</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedItems<PermissionTypeResponse>>> GetAsync([FromQuery] int pageSize = 100, [FromQuery] int pageIndex = 0)
        {
            List<PermissionType> permissionTypes = await _context.PermissionTypes
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.PermissionTypes.LongCountAsync();
            var itemsOnPage = _mapper.Map<List<PermissionType>, List<PermissionTypeResponse>>(permissionTypes);
            var paginatedItems = new PaginatedItems<PermissionTypeResponse>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(paginatedItems);
        }

        #endregion
    }
}
