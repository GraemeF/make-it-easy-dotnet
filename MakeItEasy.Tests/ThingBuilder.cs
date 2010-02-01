using MakeItEasy.Tests;

namespace MakeItEasy
{
    public class ThingBuilder : MakeItEasyBuilders
    {
        public static readonly Property<ThingToMake, object> name = Property<ThingToMake, object>.newProperty();
        public static readonly Property<ThingToMake, object> age = Property<ThingToMake, object>.newProperty();
        public static readonly Property<ThingContainer, object> thing = Property<ThingContainer, object>.newProperty();

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

        #region Nested type: ThingToMakeInstantiator

        protected class ThingToMakeInstantiator : IInstantiator<ThingToMake>
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