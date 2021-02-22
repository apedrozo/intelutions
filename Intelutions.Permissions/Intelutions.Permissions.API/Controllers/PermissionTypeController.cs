//---------------------------------------------------------------------------
// <copyright file="PermissionTypeController.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Controllers
{
    using AutoMapper;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Contracts.Requests;
    using Intelutions.Permissions.API.Contracts.Responses;
    using Intelutions.Permissions.API.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/v1/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeService _permissionTypeService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Crea una instancia de la clase <see cref="PermissionTypeController"/>.
        /// </summary>
        /// <param name="permissionTypeService">Servicio para la gestión de tipos de permisos.</param>
        /// <param name="mapper">Mapeador de clases.</param>
        public PermissionTypeController(IPermissionTypeService permissionTypeService, IMapper mapper)
        {
            _permissionTypeService = permissionTypeService;
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
            var ePermissionType = await _permissionTypeService.Create(permissionType);

            var response = _mapper.Map<PermissionTypeResponse>(ePermissionType);

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
            var permissionType = _mapper.Map<PermissionType>(request);
            var updated = await _permissionTypeService.Update(id, permissionType);

            if (!updated)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha actualizar no se existe"
                });
            }

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
            var deleted = await _permissionTypeService.Delete(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha eliminar no se existe"
                });
            }

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
            var permissionType = await _permissionTypeService.Get(id);
            if (permissionType is null)
            {
                return NotFound(new
                {
                    message = "El tipo de permiso ha eliminar no existe"
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
            var permissionTypes = await _permissionTypeService.GetAll(pageSize, pageIndex);
            var totalItems = await _permissionTypeService.GetCount();
            var itemsOnPage = _mapper.Map<List<PermissionType>, List<PermissionTypeResponse>>(permissionTypes);
            var paginatedItems = new PaginatedItems<PermissionTypeResponse>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(paginatedItems);
        }

        #endregion
    }
}
