﻿namespace MakeItEasy
{
/**
 * The value of a property.
 *
 * @param <T> the type of object that has the property
 * @param <V> the type of the value of the property
 */
    
    public class PropertyValue<T, V>
    {
        /**
     * The property
     */
        public readonly Property<T, V> property;

        /**
     * The property's value
     */
        public readonly V value;

        public PropertyValue(Property<T, V> property, V value)
        {
            this.property = property;
            this.value = value;
        }
    }
}