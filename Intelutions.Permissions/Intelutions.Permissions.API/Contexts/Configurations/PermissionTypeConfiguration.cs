//---------------------------------------------------------------------------
// <copyright file="PermissionTypeConfiguration.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts.Configurations
{
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Define la configuración de la tabla tipos de permiso.
    /// </summary>
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        /// <summary>
        /// Configura las columnas de la tabla tipos de permiso.
        /// </summary>
        /// <param name="builder">Builder de la entidad <see cref="PermissionType"/>.</param>
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("TipoPermiso");
            builder.HasKey(p => p.PermissionTypeId);

            builder.Property(p => p.PermissionTypeId)
                .HasColumnName("Id")
                .HasComment("Identificador único del tipo de permiso.")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                .HasColumnName("Descripcion")
                .HasComment("Descripción del tipo de permiso.")
                .IsRequired(true)
                .HasMaxLength(500);
        }
    }
}
