// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using System;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Sets;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Core.Controllers.Contracts;

    // 1. What does the method make : RETURNS STRINGS
    //  - two options - output for success for fail
    //  - to get failed output, 

    // 2. 
    //  - 


    using NUnit.Framework;
    using FestivalManager.Entities.Instruments;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetController_ShouldReturn_FailMessage()
	    {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            stage.AddSet(set);

            string expectedResult = "1. Set1:\r\n-- Did not perform";
            string actualResult = setController.PerformSets();
            Assert.That(actualResult == expectedResult);
            
        }

        [Test]
        public void SetController_ShouldReturn_SuccessMessage()
        {
            //Arrange
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Gaga", 29);
            ISong song = new Song("Song", new TimeSpan(0, 2, 30));

            //Act
            performer.AddInstrument(new Guitar());
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);

            string actual = setController.PerformSets();
            string expected = "1. Set1:\r\n-- 1. Song (02:30)\r\n-- Set Successful";
            //Assert
            Assert.That(actual == expected);
        }

        [Test]
        public void PerfrormSets_ShouldDecrease_InstrumentWear()
        {
            //Arrange
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("Set1");
            IPerformer performer = new Performer("Gaga", 29);
            ISong song = new Song("Song", new TimeSpan(0, 2, 30));
            IInstrument instrument = new Guitar();

            //Act
            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);

            double instrumentWearBefore = instrument.Wear;
            setController.PerformSets();
            double instrumentWearAfter = instrument.Wear;

            //Assert
            Assert.That(instrumentWearAfter, Is.Not.EqualTo(instrumentWearBefore));
        }
	}
}