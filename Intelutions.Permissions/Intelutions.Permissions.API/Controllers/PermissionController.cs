//---------------------------------------------------------------------------
// <copyright file="PermissionController.cs" company="Intelutions">
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
    public class PermissionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una instancia de la clase <see cref="PermissionController"/>.
        /// </summary>
        /// <param name="context">Contexto de la base de datos de la aplicación.</param>
        /// <param name="mapper">Mapeador de clases.</param>
        public PermissionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region POST

        /// <summary>
        /// Crea una nuevo permiso.
        /// </summary>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] PermissionRequest request)
        {
            var permission = _mapper.Map<Permission>(request);
            if (!_context.PermissionTypes.Any(p => p.PermissionTypeId == request.PermissionTypeId))
            {
                return NotFound(new
                {
                    message = "El tipo de permiso no existe"
                });
            }

            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<PermissionResponse>(permission);

            return AcceptedAtAction("GetPermissionById", new { id = permission.PermissionId }, response);
        }

        #endregion

        #region PUT

        /// <summary>
        /// Actualiza un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <param name="request">Solicitud con la información del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] PermissionRequest request)
        {
            var permission = await _context.Permissions.SingleOrDefaultAsync(p => p.PermissionId == id);

            if (permission is null)
            {
                return NotFound(new
                {
                    message = "El permiso ha actualizar no se existe"
                });
            }

            if (!_context.PermissionTypes.Any(p => p.PermissionTypeId == request.PermissionTypeId))
            {
                return NotFound(new
                {
                    message = "El tipo de permiso no se existe"
                });
            }

            permission.EmployeeFirstname = request.EmployeeFirstname;
            permission.EmployeeLastname = request.EmployeeLastname;
            permission.PermissionTypeId = request.PermissionTypeId;
            permission.PermissionDate = request.PermissionDate;

            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<PermissionResponse>(permission);

            return Ok(response);
        }

        #endregion

        #region DELETE

        /// <summary>
        /// Elimina un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta de la operación.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var permission = await _context.Permissions.SingleOrDefaultAsync(p => p.PermissionId == id);

            if (permission is null)
            {
                return NotFound(new
                {
                    message = "El permiso ha eliminar no se existe"
                });
            }

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Permiso eliminado"
            });
        }

        #endregion

        #region GET

        /// <summary>
        /// Obtiene un permiso.
        /// </summary>
        /// <param name="id">Identificador del permiso.</param>
        /// <returns>Respuesta con la información del permiso.</returns>
        [HttpGet("{id}", Name = "GetPermissionById")]
        public async Task<ActionResult<PermissionResponse>> GetPermissionById(int id)
        {
            var permission = await _context.Permissions.Include(p => p.PermissionType).SingleOrDefaultAsync(p => p.PermissionId == id);

            if (permission is null)
            {
                return NotFound(new
                {
                    message = "El permiso solicitado no se existe"
                });
            }

            return _mapper.Map<PermissionResponse>(permission);
        }

        /// <summary>
        /// Obtiene un listado de los permisos.
        /// </summary>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="pageIndex">Índice de página.</param>
        /// <returns>Respuesta con el listado de permisos.</returns>
        [HttpGet]
        public async Task<ActionResult<PaginatedItems<PermissionResponse>>> GetAsync([FromQuery] int pageSize = 100, [FromQuery] int pageIndex = 0)
        {
            List<Permission> permissions = await _context.Permissions.Include(p => p.PermissionType)
                .OrderByDescending(p => p.PermissionDate)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            var totalItems = await _context.Permissions.LongCountAsync();
            var itemsOnPage = _mapper.Map<List<Permission>, List<PermissionResponse>>(permissions);
            var paginatedItems = new PaginatedItems<PermissionResponse>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(paginatedItems);
        }

        #endregion
    }
}
