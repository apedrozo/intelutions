//---------------------------------------------------------------------------
// <copyright file="PermissionTypeServiceFake.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.UnitTest
{
    using Intelutions.Permissions.API.Contexts.DataModels;
    using Intelutions.Permissions.API.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PermissionTypeServiceFake : IPermissionTypeService
    {
        private readonly List<PermissionType> _permissionTypes;

        public PermissionTypeServiceFake()
        {
            _permissionTypes = new List<PermissionType>()
            {
                new PermissionType
                {
                    PermissionTypeId = 1,
                    Description= "Enfermedad"
                },
                new PermissionType
                {
                    PermissionTypeId = 2,
                    Description= "Otros"
                }
            };
        }

        public Task<PermissionType> Create(PermissionType permissionType)
        {
            Random rnd = new Random();
            permissionType.PermissionTypeId = rnd.Next(10, 10000);
            _permissionTypes.Add(permissionType);

            return Task.FromResult<PermissionType>(permissionType);
        }

        public Task<bool> Update(int id, PermissionType permissionType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PermissionType> Get(int id)
        {
            var permissionType = _permissionTypes
                .FirstOrDefault(a => a.PermissionTypeId == id);

            return Task.FromResult<PermissionType>(permissionType);
        }

        public Task<List<PermissionType>> GetAll(int pageSize = 100, int pageIndex = 0)
        {
            List<PermissionType> permissionTypes = _permissionTypes
               .Skip(pageSize * pageIndex)
               .Take(pageSize)
               .ToList();

            return Task.FromResult<List<PermissionType>>(permissionTypes);
        }

        public Task<long> GetCount()
        {
            return Task.FromResult<long>(_permissionTypes.LongCount());
        }
    }
}
