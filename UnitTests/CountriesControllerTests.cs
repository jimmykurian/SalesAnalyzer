using API.Controllers;
using Application.Countries.Queries;
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
    public class CountriesControllerTests
    {
        private Mock<IMediator> _mediator;

        public CountriesControllerTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public void Get_List_Of_Countries()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<List.Query>(), new CancellationToken()))
                .ReturnsAsync(new List<Country>());
            var countriesController = new CountriesController(_mediator.Object);

            // Act
            var result = countriesController.List();

            // Assert 
            Assert.IsType<Task<ActionResult<List<Country>>>>(result);
        }

        [Fact]
        public void Get_Country_By_Id()
        {
            // Arrange
            _mediator
                .Setup(x => x.Send(It.IsAny<Details.Query>(), new CancellationToken()))
                .ReturnsAsync(new Country());
            var countriesController = new CountriesController(_mediator.Object);

            // Act
            var result = countriesController.Details(Guid.NewGuid());

            // Assert 
            Assert.IsType<Task<ActionResult<Country>>>(result);
        }
    }
}
