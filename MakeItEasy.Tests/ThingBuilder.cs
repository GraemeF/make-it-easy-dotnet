namespace MakeItEasy.Tests
{
    public class ThingBuilder : MakeItEasyBuilders
    {
        public static readonly Property<ThingToMake> name = Property<ThingToMake>.newProperty();
        public static readonly Property<ThingToMake> age = Property<ThingToMake>.newProperty();
        public static readonly Property<ThingContainer> thing = Property<ThingContainer>.newProperty();

        protected IInstantiator<ThingContainer> ThingContainer
        {
            get { return new ThingContainerInstantiator(); }
        }

        protected IInstantiator<ThingToMake> ThingToMake
        {
            get { return new ThingToMakeInstantiator(); }
        }

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