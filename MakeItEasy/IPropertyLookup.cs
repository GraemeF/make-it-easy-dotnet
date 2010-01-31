namespace MakeItEasy
{
    /**
     * Looks up property values.
     * 
     * @param <T> type type of object for which the properties apply.
     */

    public interface IPropertyLookup<T>
    {
        /**
         *
         * @param property the property for which a value will be returned
         * @param defaultValue the default value to use if no value can be found
         * @param <V> the type of the value
         * @return the value for the given property, or <var>defaultValue</var> if no value can be found.
         */
        V valueOf<V>(Property<T, object> property, V defaultValue);
    }
}