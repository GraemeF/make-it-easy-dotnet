using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeItEasy
{

/**
 * Makes objects of a given type with a specified initial state.
 *
 * @param <T> the type of object to make
 */
public class Maker<T> : IPropertyLookup<T> {
    private readonly IInstantiator<T> instantiator;
    private readonly Dictionary<Property<T, object>, Object> values;

    /**
     * Creates a Maker for objects of a given type with a given initial state.
     * 
     * @param instantiator creates the new objects
     * @param propertyValues define the initial state of the new objects
     */
    public Maker(IInstantiator<T> instantiator, params PropertyValue<T, object>[] propertyValues) {
        this.instantiator = instantiator;
        this.values = new Dictionary<Property<T, object>, object>();
        setPropertyValues(propertyValues);
    }

    private Maker(Maker<T> that, params PropertyValue<T, object>[] propertyValues) {
        this.instantiator = that.instantiator;
        this.values = new Dictionary<Property<T,object>, Object>(that.values);
        setPropertyValues(propertyValues);
    }

    private void setPropertyValues(PropertyValue<T, object>[] propertyValues) {
        foreach (var propertyValue in propertyValues) {
            values[propertyValue.property]= propertyValue.value;
        }
    }

    /**
     * Makes a new object.
     *
     * The {@link com.natpryce.makeiteasy.MakeItEasy#make(Maker) MakeItEasy.make} method
     * is syntactic sugar to make calls to this method read more naturally in most
     * contexts.
     *
     * @return a new object
     */
    public T make() {
        return instantiator.instantiate(this);
    }

    /**
     * Returns a new Maker for the same type of object and with the same initial state
     * except where overridden by the given <var>propertyValues</var>.
     *
     * @param propertyValues those initial properties of the new Make that will differ from this Maker
     * @return a new Maker
     */
    public Maker<T> but(params PropertyValue<T, object>[] propertyValues) {
        return new Maker<T>(this, propertyValues);
    }
    
    public V valueOf<V>(Property<T, object> property, V defaultValue) {
        if (values.ContainsKey(property)) {
            return (V)values[property];
        }
        else {
            return defaultValue;
        }
    }
}
}
