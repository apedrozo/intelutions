//---------------------------------------------------------------------------
// <copyright file="PermissionTypeRequestValidator.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Validators
{
    using FluentValidation;
    using Intelutions.Permissions.API.Contracts.Requests;

    /// <summary>
    /// Configura las reglas validación para la solicitud de un tipo de permiso de la clase 
    /// <see cref="PermissionTypeRequest"/>.
    /// </summary>
    public class PermissionTypeRequestValidator : AbstractValidator<PermissionTypeRequest>
    {
        /// <summary>
        /// Crea una instancia de la clase <see cref="PermissionTypeRequestValidator"/>.
        /// </summary>
        public PermissionTypeRequestValidator()
        {
            this.RuleFor(p => p.Description).NotEmpty()
                .WithMessage("La descripción del permiso es requerida.");
            this.RuleFor(p => p.Description).MaximumLength(500)
                .WithMessage("La descripción del permiso no puede contener mas de 500 caracteres.");
        }
    }
}
