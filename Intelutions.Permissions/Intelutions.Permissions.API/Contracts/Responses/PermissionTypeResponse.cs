//---------------------------------------------------------------------------
// <copyright file="PermissionTypeResponse.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Responses
{
    /// <summary>
    /// Respuesta de un tipo de permiso.
    /// </summary>
    public class PermissionTypeResponse
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
