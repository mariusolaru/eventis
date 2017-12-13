using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using Data.Domain;

namespace EventsTests
{
    [TestClass]
    public class EventsTest : BaseIntegrationTest
    {
        [TestMethod]
        public void Given_EventsRepository_When_AddingEvent_ThenShouldBeProperlyAdded ()
        {
            RunOnDatabase(act =>
            {
                var repository = new EventRepository(act);

                var ev = Event.Create("Fii", "fii .net", "Laborator de .net",
                    "Laborator de .net impreuna cu colegii meu",
                    DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), "no-image");

                repository.AddEvent(ev);

                Assert.AreEqual(1, repository.GetAllActiveEvents().Count);

            });
        }

        [TestMethod]
        public void Given_EventsRepositry_When_GettingAllEvents_ThenShouldReturnAllProperly()
        {
            RunOnDatabase(act =>
                {
                    var repository = new EventRepository(act);

                    var firstEvent = Event.Create("Fii", "fii ML", "Seminar de Machine Learning",
                        "La Seminar",
                        DateTime.Now.AddMinutes(1), DateTime.Now.AddHours(2), "no-image");

                    var secondEvent = Event.Create("Fii", "fii .net", "Laborator de .net",
                        "Laborator de .net impreuna cu colegii meu",
                        DateTime.Now.AddMinutes(1), DateTime.Now.AddHours(2), "no-image");
                    repository.AddEvent(firstEvent);
                    repository.AddEvent(secondEvent);

                    Assert.AreEqual(2, repository.GetAllActiveEvents().Count);
                }
            );
        }

        [TestMethod]
        public void Given_EventsRepository_When_DeletingAnEvent_ThenShouldBeProperlyDeleted()
        {
            RunOnDatabase(act =>
            {
                var repository = new EventRepository(act);

                var firstEvent = Event.Create("Fii", "fii ML", "Seminar de Machine Learning",
                    "La Seminar",
                    DateTime.Now, DateTime.Now.AddHours(2), "no-image");

                repository.AddEvent(firstEvent);

                repository.DeleteEvent(firstEvent);

                Assert.AreEqual(0, repository.GetAllActiveEvents().Count);

            });
        }

        [TestMethod]
        public void Given_EventsRepository_When_GettingAllEventsUntillDate_ThenShouldBeProperlyReturned()
        {
            RunOnDatabase(act =>
            {
                var repository = new EventRepository(act);

                var firstEvent = Event.Create("Fii", "fii ML", "Seminar de Machine Learning",
                    "La Seminar",
                    DateTime.Now, DateTime.Now.AddHours(2), "no-image");

                var secondEvent = Event.Create("Fii", "fii .net", "Laborator de .net",
                    "Laborator de .net impreuna cu colegii meu",
                    DateTime.Now.AddHours(2), DateTime.Now.AddHours(3), "no-image");

                repository.AddEvent(firstEvent);
                repository.AddEvent(secondEvent);

                Assert.AreEqual(1, repository.GetEventsUntill(DateTime.Now.AddHours(1)).Count);
            });
        }
    }
}
