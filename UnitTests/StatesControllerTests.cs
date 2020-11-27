using API.Controllers;
using Application.States.Queries;
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
    public class StatesControllerTests
    {
        private Mock<IMediator> _mediator;

        public StatesControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public void Get_List_Of_States()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<List.Query>(), new CancellationToken()))
                .ReturnsAsync(new List<State>());
            var statesController = new StatesController(_mediator.Object);

            // Act
            var result = statesController.List();

            // Assert 
            Assert.IsType<Task<ActionResult<List<State>>>>(result);
        }

        [Fact]
        public void Get_State_By_Id()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<Details.Query>(), new CancellationToken()))
                .ReturnsAsync(new State());
            var statesController = new StatesController(_mediator.Object);

            // Act
            var result = statesController.Details(Guid.NewGuid());

            // Assert 
            Assert.IsType<Task<ActionResult<State>>>(result);
        }

    }
}
