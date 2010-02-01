namespace MakeItEasy
{
    /// <summary>
    /// The value of a property.
    /// </summary>
    /// <typeparam name="T">the type of object that has the property</typeparam>
    /// <typeparam name="V">the type of the value of the property</typeparam>
    public class PropertyValue<T, V>
    {
        /// <summary>
        /// The property
        /// </summary>
        public readonly Property<T, V> property;

        /// <summary>
        /// The property's value
        /// </summary>
        public readonly V value;

        public PropertyValue(Property<T, V> property, V value)
        {
            this.property = property;
            this.value = value;
        }
    }
}