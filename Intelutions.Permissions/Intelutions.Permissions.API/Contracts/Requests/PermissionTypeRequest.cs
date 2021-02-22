//---------------------------------------------------------------------------
// <copyright file="PermissionTypeRequest.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Requests
{
    /// <summary>
    /// Define una solicitud de tipo de permiso.
    /// </summary>
    public class PermissionTypeRequest
    {
        /// <summary>
        /// Identificador único del tipo de permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Descripción del permiso.
        /// </summary>
        public string Description { get; set; }
    }
}
