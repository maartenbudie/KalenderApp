using KalenderApp.Core;
using KalenderAppTests.Fake_DAL;
using System.Linq.Expressions;

namespace KalenderAppTests
{
    [TestClass]
    public class EventServiceTest
    {
        [TestMethod]
        public void AddNewEventValidateInputName()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.AddNewEvent([1], String.Empty, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void AddNewEventValidateInputId()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.AddNewEvent([0], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void AddNewEventValidateInputStartDate()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.AddNewEvent([1], " ", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void AddNewEventValidateInputEndDate()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.AddNewEvent([1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(-1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void AddNewEventValidateInputRepetition()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.AddNewEvent([1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void AddNewEventDALReached()
        {
            // Arrange
            FakeEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            service.AddNewEvent([1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", "Daily");

            // Assert
            Assert.IsTrue(eventData.addReached);
        }
        public void EditEventValidateInputName()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(1, [1], String.Empty, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventValidateInputCategoryId()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(1, [0], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventValidateInputUserId()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(0, [1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventValidateInputStartDate()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(1, [1], " ", DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventValidateInputEndDate()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(1, [1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(-1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventValidateInputRepetition()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            Action expression = () => service.EditEvent(1, [1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", " ");

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void EditEventDALReached()
        {
            // Arrange
            FakeEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            service.EditEvent(1, [1], " ", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), " ", "Daily");

            // Assert
            Assert.IsTrue(eventData.editReached);
        }
        [TestMethod]
        public void DeleteEventValidateInputId()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            //Act
            Action expression = () => service.DeleteEvent(0);

            // Assert
            Assert.ThrowsException<InvalidValueException>(expression);
        }
        [TestMethod]
        public void DeleteEventDALReached()
        {
            // Arrange
            FakeEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);

            // Act
            service.DeleteEvent(1);

            // Assert
            Assert.IsTrue(eventData.deleteReached);
        }
        [TestMethod]
        public void GetEventsForDateReturnsEntity()
        {
            // Arrange
            IEventData eventData = new FakeEventData();
            EventService service = new EventService(eventData);
            DateTime dateTime = DateTime.Now;

            // Act
            List<EventEntity> result = service.GetEventsForDay(dateTime);

            // Assert
            Assert.AreEqual(dateTime, result[0].startTime);
        }
    }
}