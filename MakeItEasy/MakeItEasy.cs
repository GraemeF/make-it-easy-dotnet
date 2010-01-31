using System.Collections.Generic;

namespace MakeItEasy
{
/**
 * Syntactic sugar for using Make It Easy test-data builders.
 */

    public class MakeItEasyBuilders
    {
        public static Maker<T> a<T>(IInstantiator<T> instantiator, params PropertyValue<T, object>[] propertyProviders)
        {
            return new Maker<T>(instantiator, propertyProviders);
        }

        public static Maker<T> an<T>(IInstantiator<T> instantiator, params PropertyValue<T, object>[] propertyProviders)
        {
            return new Maker<T>(instantiator, propertyProviders);
        }

        public static PropertyValue<T, V> with<T, V>(Property<T, V> property, V value)
        {
            return new PropertyValue<T, V>(property, value);
        }

        public static PropertyValue<T, V> with<T, V>(V value, Property<T, V> property)
        {
            return new PropertyValue<T, V>(property, value);
        }

        public static PropertyValue<T, V> with<T, V>(Property<T, V> property, Maker<V> valueMaker)
        {
            return new PropertyValue<T, V>(property, valueMaker.make());
        }

        public static PropertyValue<T, V> with<T, V>(Maker<V> valueMaker, Property<T, V> property)
        {
            return new PropertyValue<T, V>(property, valueMaker.make());
        }

        public static T make<T>(Maker<T> maker)
        {
            return maker.make();
        }

        public static List<T> listOf<T>(params Maker<T>[] makers)
        {
            return fill(new List<T>(), makers);
        }

        public static ICollection<T> setOf<T>(params Maker<T>[] makers)
        {
            return fill(new HashSet<T>(), makers);
        }

        private static C fill<T, C>(C collection, params Maker<T>[] makers) where C : ICollection<T>
        {
            foreach (var maker in makers)
            {
                collection.Add(maker.make());
            }
            return collection;
        }
    }
}