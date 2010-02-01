namespace MakeItEasy
{
    /// <summary>
    /// The value of a property.
    /// </summary>
    /// <typeparam name="T">the type of object that has the property</typeparam>
    public class PropertyValue<T>
    {
        /// <summary>
        /// The property
        /// </summary>
        public readonly Property<T> property;

        /// <summary>
        /// The property's value
        /// </summary>
        public readonly object value;

        public PropertyValue(Property<T> property, object value)
        {
            this.property = property;
            this.value = value;
        }
    }
}