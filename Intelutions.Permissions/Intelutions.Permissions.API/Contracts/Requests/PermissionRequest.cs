//---------------------------------------------------------------------------
// <copyright file="PermissionRequest.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Requests
{
    using System;

    /// <summary>
    /// Define una solicitud de permiso.
    /// </summary>
    public class PermissionRequest
    {
        /// <summary>
        /// Identificador único del permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del Empleado.
        /// </summary>
        public string EmployeeFirstname { get; set; }

        /// <summary>
        /// Apellidos del empleado.
        /// </summary>
        public string EmployeeLastname { get; set; }

        /// <summary>
        /// Tipo del permiso solicitado.
        /// </summary>
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Fecha para cuando se solicita el permiso.
        /// </summary>
        public DateTime PermissionDate { get; set; }
    }
}
