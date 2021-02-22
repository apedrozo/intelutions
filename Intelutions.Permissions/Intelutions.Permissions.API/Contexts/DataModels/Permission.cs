//---------------------------------------------------------------------------
// <copyright file="Permission.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts.DataModels
{
    using System;

    /// <summary>
    /// Entidad que define el modelo de datos de la tabla permisos.
    /// </summary>
    public class Permission
    {
        /// <summary>
        ///  Identificador único del permiso.
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// Nombre del empleado.
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
        public PermissionType PermissionType { get; set; }

        /// <summary>
        /// Fecha de cuando se solicita el permiso.
        /// </summary>
        public DateTime PermissionDate { get; set; }
    }
}
