//---------------------------------------------------------------------------
// <copyright file="PermissionProfile.cs" company="Intelutions">
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
    /// Configura el mapeo de entidades relacionadas con la clase <see cref="Permission"/>.
    /// </summary>
    public class PermissionProfile : Profile
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="PermissionProfile"/>.
        /// </summary>
        public PermissionProfile()
        {
            CreateMap<PermissionRequest, Permission>()
                .ForMember(d => d.PermissionId, o => o.MapFrom(s => s.Id));

            CreateMap<Permission, PermissionResponse>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.PermissionId))
                .ForMember(d => d.PermissionTypeDescription, o => o.MapFrom(s => s.PermissionType.Description));
        }
    }
}
