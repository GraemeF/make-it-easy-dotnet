using System;
using MbUnit.Framework;

namespace MakeItEasy.Tests
{
    [TestFixture]
    public class MakeItEasyTest : MakeItEasyBuilders
    {
        public static readonly Property<ThingToMake, object> name = Property<ThingToMake, object>.newProperty();
        public static readonly Property<ThingToMake, object> age = Property<ThingToMake, object>.newProperty();
        public static readonly Property<ThingContainer, object> thing = Property<ThingContainer, object>.newProperty();

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
            ThingToMake madeThing = make(a(new ThingToMakeInstantiator(), with(name, "Bob"), with(age, 10)));

            Assert.AreEqual("Bob", madeThing.name);
            Assert.AreEqual(10, madeThing.age);

            ThingToMake differentName = make(a(new ThingToMakeInstantiator(), with(name, "Bill")));
            Assert.AreEqual("Bill", differentName.name);
        }

        [Test]
        public void canUseMakersToInitialisePropertyValues()
        {
            ThingContainer container =
                make(a(new ThingContainerInstantiator(),
                       with(thing, a(new ThingToMakeInstantiator(), with(name, "foo")))));

            Assert.AreEqual("Foo", container.thing.name);
        }

        #region Nested type: ThingContainer

        public class ThingContainer
        {
            public readonly ThingToMake thing;

            public ThingContainer(ThingToMake thing)
            {
                this.thing = thing;
            }
        }

        #endregion

        #region Nested type: ThingContainerInstantiator

        public class ThingContainerInstantiator : IInstantiator<ThingContainer>
        {
            #region IInstantiator<ThingContainer> Members

            public ThingContainer instantiate(IPropertyLookup<ThingContainer> lookup)
            {
                return new ThingContainer(lookup.valueOf(thing, make(a(new ThingToMakeInstantiator()))));
            }

            #endregion
        }

        #endregion

        #region Nested type: ThingToMake

        public class ThingToMake
        {
            public readonly int age;
            public readonly string name;

            public ThingToMake(String name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        #endregion

        #region Nested type: ThingToMakeInstantiator

        private class ThingToMakeInstantiator : IInstantiator<ThingToMake>
        {
            #region IInstantiator<ThingToMake> Members

            public ThingToMake instantiate(IPropertyLookup<ThingToMake> lookup)
            {
                return new ThingToMake(lookup.valueOf(name, "Nemo"), lookup.valueOf(age, 99));
            }

            #endregion
        }

        #endregion
    }
}