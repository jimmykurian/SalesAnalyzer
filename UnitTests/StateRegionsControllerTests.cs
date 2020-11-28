using API.Controllers;
using Application.StateRegions.Queries;
using Application.StateRegions.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class StateRegionsControllerTests
    {
        private Mock<IMediator> _mediator;

        public StateRegionsControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public void Get_List_Of_StateRegions()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<List.Query>(), new CancellationToken()))
                .ReturnsAsync(new List<StateRegion>());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.List();

            // Assert 
            Assert.IsType<Task<ActionResult<List<StateRegion>>>>(result);
        }

        [Fact]
        public void Get_StateRegion_By_Id()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<Details.Query>(), new CancellationToken()))
                .ReturnsAsync(new StateRegion());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.Details(Guid.NewGuid());

            // Assert 
            Assert.IsType<Task<ActionResult<StateRegion>>>(result);
        }

        [Fact]
        public void Get_List_Of_StateMonthMatrices()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<ListByMatrix.Query>(), new CancellationToken()))
                .ReturnsAsync(new List<StateMonthMatrix>());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.ListByMatrix();

            // Assert 
            Assert.IsType<Task<ActionResult<List<StateMonthMatrix>>>>(result);
        }

        [Fact]
        public void Create_StateMonthMatrices()
        {
            // Arrange
            var createStateMonthMatricesRequestModel = new StateRegionsRequest();
            _mediator
                .Setup(x => x.Send(It.IsAny<Create.Command>(), new CancellationToken()))
                .ReturnsAsync(new Unit());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.Create(createStateMonthMatricesRequestModel);

            // Assert 
            Assert.IsType<Task<ActionResult<Unit>>>(result);
        }

        [Fact]
        public void Edit_StateMonthMatrix_By_Id()
        {
            // Arrange
            var editCommand = new Edit.Command();
            _mediator
                .Setup(x => x.Send(It.IsAny<Edit.Command>(), new CancellationToken()))
                .ReturnsAsync(new Unit());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.Edit(Guid.NewGuid(), editCommand);

            // Assert 
            Assert.IsType<Task<ActionResult<Unit>>>(result);
        }

        [Fact]
        public void Delete_StateMonthMatrix_By_Id()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<Delete.Command>(), new CancellationToken()))
                .ReturnsAsync(new Unit());
            var stateRegionsController = new StateRegionsController(_mediator.Object);

            // Act
            var result = stateRegionsController.Delete(Guid.NewGuid());

            // Assert 
            Assert.IsType<Task<ActionResult<Unit>>>(result);
        }
    }
}
