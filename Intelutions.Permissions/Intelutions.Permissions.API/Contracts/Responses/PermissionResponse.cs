//---------------------------------------------------------------------------
// <copyright file="PermissionResponse.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Responses
{
    using System;

    /// <summary>
    /// Respuesta de un permiso.
    /// </summary>
    public class PermissionResponse
    {
        /// <summary>
        /// Identificador único del permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del empleado.
        /// </summary>
        public string EmployeeFirstname { get; set; }

        /// <summary>
        /// Apellidos del empleado.
        /// </summary>
        public string EmployeeLastname { get; set; }

        /// <summary>
        /// Identificador del tipo del permiso solicitado.
        /// </summary>
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Descripción del tipo del permiso solicitado.
        /// </summary>
        public string PermissionTypeDescription { get; set; }

        /// <summary>
        /// Fecha de cuando se solicita el permiso.
        /// </summary>
        public DateTime PermissionDate { get; set; }
    }
}
