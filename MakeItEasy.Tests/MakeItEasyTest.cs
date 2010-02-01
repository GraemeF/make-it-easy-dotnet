using MbUnit.Framework;

namespace MakeItEasy.Tests
{
    [TestFixture]
    public class MakeItEasyTest : ThingBuilder
    {
        [Test]
        public void usesDefaultPropertyValuesIfNoPropertiesSpecified()
        {
            ThingToMake madeThing = make(a(new ThingToMakeInstantiator()));

            Assert.AreEqual("Nemo", madeThing.name);
            Assert.AreEqual(99, madeThing.age);
        }

        [Test]
        public void overridesDefaultValuesWithExplicitProperties()
        {
            ThingToMake madeThing = make(a(ThingToMake, with(name, "Bob"), with(age, 10)));

            Assert.AreEqual("Bob", madeThing.name);
            Assert.AreEqual(10, madeThing.age);

            ThingToMake differentName = make(a(ThingToMake, with(name, "Bill")));
            Assert.AreEqual("Bill", differentName.name);
        }

        [Test]
        public void canUseMakersToInitialisePropertyValues()
        {
            ThingContainer container =
                make(a(ThingContainer,
                       with(thing, a(ThingToMake, with(name, "Foo")))));

            Assert.AreEqual("Foo", container.thing.name);
        }
    }
}