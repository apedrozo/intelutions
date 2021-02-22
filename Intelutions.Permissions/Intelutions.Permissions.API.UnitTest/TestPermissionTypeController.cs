//---------------------------------------------------------------------------
// <copyright file="TestPermissionTypeController.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.UnitTest
{
    using AutoMapper;
    using Intelutions.Permissions.API.Contracts.Mappers.Profiles;
    using Intelutions.Permissions.API.Contracts.Requests;
    using Intelutions.Permissions.API.Contracts.Responses;
    using Intelutions.Permissions.API.Controllers;
    using Intelutions.Permissions.API.Services;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class TestPermissionTypeController
    {
        private readonly PermissionTypeController _controller;
        private readonly IPermissionTypeService _service;
        private readonly IMapper _mapper;

        public TestPermissionTypeController()
        {
            _service = new PermissionTypeServiceFake();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PermissionTypeProfile());
            });

            _mapper = mapperConfiguration.CreateMapper();
            _controller = new PermissionTypeController(_service, _mapper);
        }

        [Fact]
        public void TestCreate()
        {
            PermissionTypeRequest permissionType = new PermissionTypeRequest
            {
                Description = "Nuevo tipo"
            };
            var okResult = _controller.CreateAsync(permissionType);
            Assert.IsType<AcceptedAtActionResult>(okResult.Result);
        }

        [Fact]
        public void TestGet()
        {
            var okResult = _controller.GetPermissionById(1);
            Assert.IsType<ActionResult<PermissionTypeResponse>>(okResult.Result);
        }

        [Fact]
        public void TestGetAll()
        {
            var okResult = _controller.GetAsync(100, 1);
            Assert.IsType<ActionResult<PaginatedItems<PermissionTypeResponse>>>(okResult.Result);
        }
    }
}
