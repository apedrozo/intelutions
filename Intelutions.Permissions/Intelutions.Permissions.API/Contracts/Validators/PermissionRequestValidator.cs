//---------------------------------------------------------------------------
// <copyright file="PermissionRequestValidator.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Validators
{
    using FluentValidation;
    using Intelutions.Permissions.API.Contracts.Requests;

    /// <summary>
    /// Configura las reglas validación para la solicitud de un permiso de la clase <see cref="PermissionRequest"/>.
    /// </summary>
    public class PermissionRequestValidator : AbstractValidator<PermissionRequest>
    {
        /// <summary>
        /// Crea una instancia de la clase <see cref="PermissionRequestValidator"/>.
        /// </summary>
        public PermissionRequestValidator()
        {
            this.RuleFor(p => p.EmployeeFirstname).NotEmpty()
                .WithMessage("El nombre del empleado es requerido");
            this.RuleFor(p => p.EmployeeFirstname).MaximumLength(200)
                .WithMessage("El nombre del empleado no puede contener mas de 200 caracteres");
            this.RuleFor(p => p.EmployeeLastname).NotEmpty()
                .WithMessage("Los apellidos del empleado son requeridos");
            this.RuleFor(p => p.EmployeeLastname).MaximumLength(200)
                .WithMessage("El nombre del empleado no puede contener mas de 200 caracteres");
            this.RuleFor(p => p.PermissionTypeId).NotEmpty()
                .WithMessage("El tipo de permiso es requerido");
            this.RuleFor(p => p.PermissionDate).NotEmpty()
                .WithMessage("La fecha del permiso es requerida");
        }
    }
}
