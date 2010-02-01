namespace MakeItEasy
{
    /// <summary>
    /// Looks up property values.
    /// </summary>
    /// <typeparam name="T">type of object for which the properties apply.</typeparam>
    public interface IPropertyLookup<T>
    {
        /// <summary>
        /// Looks up a property value.
        /// </summary>
        /// <typeparam name="V">the type of the value</typeparam>
        /// <param name="property">the property for which a value will be returned</param>
        /// <param name="defaultValue">the default value to use if no value can be found</param>
        /// <returns>the value for the given property, or <var>defaultValue</var> if no value can be found.</returns>
        V valueOf<V>(Property<T> property, V defaultValue);
    }
}