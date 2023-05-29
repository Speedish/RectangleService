using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RectangleService.Core.Models;
using RectangleService.Infrastructure.Context;
using RectangleService.Infrastructure.Repositories;
using Xunit;

namespace RectangleService.Infrastructure.Tests.Repositories
{
    /// <summary>
    /// RectangleRepositoryTests
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class RectangleRepositoryTests : IDisposable
    {
        /// <summary>
        /// The options
        /// </summary>
        private readonly DbContextOptions<RectangleDBContext> _options;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleRepositoryTests"/> class.
        /// </summary>
        public RectangleRepositoryTests()
        {
            // Create a new in-memory database for testing
            _options = new DbContextOptionsBuilder<RectangleDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            // Create an instance of AutoMapper configuration (if needed) and create the mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                // Add necessary mappings
                cfg.CreateMap<Infrastructure.Entities.Rectangle, Rectangle>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            using (var context = new RectangleDBContext(_options))
            {
                // Clear the database after each test
                context.Database.EnsureDeleted();
            }
        }

        /// <summary>
        /// Searches the rectangles with valid coordinates should return matching rectangles.
        /// </summary>
        [Fact]
        public async Task SearchRectangles_WithValidCoordinates_ShouldReturnMatchingRectangles()
        {
            // Arrange
            using (var context = new RectangleDBContext(_options))
            {
                // Seed the in-memory database with test data
                var rectangles = new List<Infrastructure.Entities.Rectangle>
                {
                    new Infrastructure.Entities.Rectangle { Id = 1, X = 0, Y = 0, Width = 10, Height = 10 },
                    new Infrastructure.Entities.Rectangle { Id = 2, X = 5, Y = 5, Width = 10, Height = 10 },
                    new Infrastructure.Entities.Rectangle { Id = 3, X = 20, Y = 20, Width = 10, Height = 10 }
                };
                await context.Rectangles.AddRangeAsync(rectangles);
                await context.SaveChangesAsync();
            }

            using (var context = new RectangleDBContext(_options))
            {
                // Create an instance of the repository with the in-memory database context and mapper
                var repository = new RectangleRepository(context, _mapper);

                var coordinates = new List<Coordinate>
                {
                    new Coordinate { X = 5, Y = 5 },
                    new Coordinate { X = 15, Y = 15 }
                };
                var input = new CoordinateInput { Coordinates = coordinates };

                // Act
                var result = await repository.SearchRectangles(input);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Contains(result, r => r.Id == 1);
                Assert.Contains(result, r => r.Id == 2);
            }
        }

        // Add more tests for other repository methods (AddRectangle, DeleteRectangle, UpdateRectangle, GetAllRectangles)
        // ...

    }
}
