namespace TripBookingApi.Tests.Bookings.Commands
{
    [TestFixture]
    internal class RegisterBookingCommandHandlerTests
    {
        Mock<IDbContext> dbContextMock = new Mock<IDbContext>();
        [SetUp]
        public void SetUp()
        {
            var trip1 = new Trip("trip1", new Country(1, "Country1"), "test", new DateTime(), 5);
            trip1.Bookings.Add(new Booking(trip1, "m@m.pl"));
            List<Trip> trips = new List<Trip>
            {
                trip1
            };
            dbContextMock.Setup(c => c.Trips).Returns(trips.AsQueryable().BuildMockDbSet().Object);
        }

        [Test]
        public void TripNotFoundException()
        {
            var registerBookingCommand = new RegisterBookingCommand
            {
                Email = "m@m.pl",
                TripName = "trip2"
            };

            var handler = new RegisterBookingCommandHandler(dbContextMock.Object);

            Assert.ThrowsAsync<TripNotFoundException>(async () => await handler.Handle(registerBookingCommand, CancellationToken.None));
        }

        [Test]
        public void TripFound()
        {
            var registerBookingCommand = new RegisterBookingCommand
            {
                Email = "m2@m.pl",
                TripName = "trip1"
            };

            var handler = new RegisterBookingCommandHandler(dbContextMock.Object);

            Assert.DoesNotThrowAsync(async () => await handler.Handle(registerBookingCommand, CancellationToken.None));
        }

        [Test]
        public void BookingAllreadyRegistered()
        {
            var registerBookingCommand = new RegisterBookingCommand
            {
                Email = "m@m.pl",
                TripName = "trip1"
            };

            var handler = new RegisterBookingCommandHandler(dbContextMock.Object);

            Assert.ThrowsAsync<BookingFoundException>(async () => await handler.Handle(registerBookingCommand, CancellationToken.None));
        }
    }
}
