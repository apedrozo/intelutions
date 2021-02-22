//---------------------------------------------------------------------------
// <copyright file="PermissionConfiguration.cs" company="Intelutions">
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
    /// Define la configuración de la tabla permisos.
    /// </summary>
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        /// <summary>
        /// Configura las columnas de la tabla permisos.
        /// </summary>
        /// <param name="builder">Builder de la entidad <see cref="Permission"/>.</param>
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permiso");
            builder.HasKey(p => p.PermissionId);
            builder.HasIndex(p => p.PermissionTypeId);

            builder.Property(p => p.PermissionId)
                .HasColumnName("Id")
                .HasComment("Identificador único del permiso.")
                .IsRequired(true)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.EmployeeFirstname)
                .HasColumnName("NombreEmpleado")
                .HasComment("Nombre del empleado.")
                .IsRequired(true)
                .HasMaxLength(200);

            builder.Property(t => t.EmployeeLastname)
                .HasColumnName("ApellidosEmpleado")
                .HasComment("Apellidos del empleado.")
                .IsRequired(true)
                .HasMaxLength(200);

            builder.Property(t => t.PermissionTypeId)
                .HasColumnName("TipoPermiso")
                .HasComment("Tipo del permiso solicitado.")
                .IsRequired(true);

            builder.Property(t => t.PermissionDate)
                .HasColumnName("FechaPermiso")
                .HasComment("Fecha de cuando se solicita el permiso.")
                .IsRequired(true);
        }
    }
}
