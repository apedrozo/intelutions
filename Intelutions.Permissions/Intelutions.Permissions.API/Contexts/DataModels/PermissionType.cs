//---------------------------------------------------------------------------
// <copyright file="PermissionType.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts.DataModels
{
    /// <summary>
    /// Entidad que define el modelo de datos de la tabla tipos de permiso.
    /// </summary>
    public class PermissionType
    {
        /// <summary>
        /// Identificador único del tipo de permiso.
        /// </summary>
        public int PermissionTypeId { get; set; }

        /// <summary>
        /// Descripción del tipo de permiso.
        /// </summary>
        public string Description { get; set; }
    }
}
