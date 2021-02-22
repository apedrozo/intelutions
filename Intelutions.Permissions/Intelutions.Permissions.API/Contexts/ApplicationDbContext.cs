//---------------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contexts
{
    using Intelutions.Permissions.API.Contexts.Configurations;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Define el contexto de base de datos de la aplicación.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Conjunto de datos de la tabla de permisos.
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Conjunto de datos de la tabla de tipo de permisos.
        /// </summary>
        public DbSet<PermissionType> PermissionTypes { get; set; }

        /// <summary>
        /// Método que permite aplicar la configuración de los modelos en la base de datos.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos de tablas.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeConfiguration());
        }
    }
}
