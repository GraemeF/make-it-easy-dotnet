namespace MakeItEasy
{
    /**
     * Instantiates an object, with an initial state specified by some
     * given property values or defaults defined by the implementer of
     * this interface.
     * 
     * @param <T> the type of object to instantiate
     */

    public interface IInstantiator<T>
    {
        /**
         * Instantiates a new object.
         * 
         * @param lookup initialisation property values
         * @return the new object
         */
        T instantiate(IPropertyLookup<T> lookup);
    }
}