namespace MakeItEasy
{
    /// <summary>
    /// Instantiates an object, with an initial state specified by some
    /// given property values or defaults defined by the implementer of
    /// this interface.
    /// </summary>
    /// <typeparam name="T">the type of object to instantiate</typeparam>
    public interface IInstantiator<T>
    {
        /// <summary>
        /// Instantiates a new object.
        /// </summary>
        /// <param name="lookup">initialisation property values</param>
        /// <returns>the new object</returns>
        T instantiate(IPropertyLookup<T> lookup);
    }
}