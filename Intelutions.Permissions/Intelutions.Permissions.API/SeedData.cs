//---------------------------------------------------------------------------
// <copyright file="SeedData.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API
{
    using Intelutions.Permissions.API.Contexts;
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    /// <summary>
    /// Datos semilla.
    /// </summary>
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (!context.PermissionTypes.Any(p => p.Description.Contains("Enfermedad")))
            {
                context.PermissionTypes.Add(new PermissionType { Description = "Enfermedad" });
                context.SaveChanges();
            }

            if (!context.PermissionTypes.Any(p => p.Description.Contains("Diligencia")))
            {
                context.PermissionTypes.Add(new PermissionType { Description = "Diligencia" });
                context.SaveChanges();
            }

            if (!context.PermissionTypes.Any(p => p.Description.Contains("Otros")))
            {
                context.PermissionTypes.Add(new PermissionType { Description = "Otros" });
                context.SaveChanges();
            }

            if (!context.Permissions.Any(p => p.EmployeeFirstname.Contains("Alejandro")))
            {
                context.Permissions.Add(new Permission { EmployeeFirstname = "Alejandro", EmployeeLastname = "Pedrozo", PermissionTypeId = 1, PermissionDate = DateTime.Now });
                context.SaveChanges();
            }
        }
    }
}
