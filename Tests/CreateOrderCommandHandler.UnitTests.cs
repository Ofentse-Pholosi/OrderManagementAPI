using Xunit;
using Moq;
using MongoDB.Driver;
using OrderManagementAPI.Commands;
using OrderManagementAPI.Entities;
using OrderManagementAPI.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManagementAPI.Tests
{
    public class CreateOrderCommandHandlerUnitTests
    {
		private readonly Mock<MongoDBContext> _mockContext;
		private readonly Mock<IMongoCollection<Order>> _mockCollection;
		private readonly CreateOrderCommandHandler _handler;

		public CreateOrderCommandHandlerUnitTests()
		{
			// Setup mocks
			_mockCollection = new Mock<IMongoCollection<Order>>();
			_mockContext = new Mock<MongoDBContext>();
			_mockContext.Setup(c => c.Orders).Returns(_mockCollection.Object);

			// Create handler instance with mocked context
			_handler = new CreateOrderCommandHandler(_mockContext.Object);
		}
	}
}
