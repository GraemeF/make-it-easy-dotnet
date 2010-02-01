using System;
using System.Collections.Generic;

namespace MakeItEasy
{
    /// <summary>
    /// Makes objects of a given type with a specified initial state.
    /// </summary>
    /// <typeparam name="T">the type of object to make</typeparam>
    public class Maker<T> : IPropertyLookup<T>
    {
        private readonly IInstantiator<T> instantiator;
        private readonly Dictionary<Property<T, object>, Object> values;

        /// <summary>
        /// Creates a Maker for objects of a given type with a given initial state.
        /// </summary>
        /// <param name="instantiator">creates the new objects</param>
        /// <param name="propertyValues">define the initial state of the new objects</param>
        public Maker(IInstantiator<T> instantiator, params PropertyValue<T, object>[] propertyValues)
        {
            this.instantiator = instantiator;
            values = new Dictionary<Property<T, object>, object>();
            setPropertyValues(propertyValues);
        }

        private Maker(Maker<T> that, params PropertyValue<T, object>[] propertyValues)
        {
            instantiator = that.instantiator;
            values = new Dictionary<Property<T, object>, Object>(that.values);
            setPropertyValues(propertyValues);
        }

        #region IPropertyLookup<T> Members

        public V valueOf<V>(Property<T, object> property, V defaultValue)
        {
            if (values.ContainsKey(property))
            {
                return (V) values[property];
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion

        private void setPropertyValues(PropertyValue<T, object>[] propertyValues)
        {
            foreach (var propertyValue in propertyValues)
            {
                values[propertyValue.property] = propertyValue.value;
            }
        }

        /// <summary>
        /// Makes a new object.
        /// </summary>
        /// <remarks>
        /// The {@link com.natpryce.makeiteasy.MakeItEasy#make(Maker) MakeItEasy.make} method
        /// is syntactic sugar to make calls to this method read more naturally in most
        /// contexts.
        /// </remarks>
        /// <returns>a new object</returns>
        public T make()
        {
            return instantiator.instantiate(this);
        }

        /// <summary>
        /// Returns a new Maker for the same type of object and with the same initial state
        /// except where overridden by the given <var>propertyValues</var>.
        /// </summary>
        /// <param name="propertyValues">those initial properties of the new Make that will differ from this Maker</param>
        /// <returns>a new Maker</returns>
        public Maker<T> but(params PropertyValue<T, object>[] propertyValues)
        {
            return new Maker<T>(this, propertyValues);
        }
    }
}