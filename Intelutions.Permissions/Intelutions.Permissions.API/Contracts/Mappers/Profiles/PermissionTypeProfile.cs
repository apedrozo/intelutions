//---------------------------------------------------------------------------
// <copyright file="PermissionTypeProfile.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Mappers.Profiles
{
    using AutoMapper;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Contracts.Requests;
    using Intelutions.Permissions.API.Contracts.Responses;

    /// <summary>
    /// Configura el mapeo de entidades relacionadas con la clase <see cref="PermissionTypeProfile"/>.
    /// </summary>
    public class PermissionTypeProfile : Profile
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="PermissionTypeProfile"/>.
        /// </summary>
        public PermissionTypeProfile()
        {
            CreateMap<PermissionTypeRequest, PermissionType>()
                .ForMember(d => d.PermissionTypeId, o => o.MapFrom(s => s.Id));

            CreateMap<PermissionType, PermissionTypeResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.PermissionTypeId));
        }
    }
}
