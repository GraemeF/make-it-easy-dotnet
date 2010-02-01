namespace MakeItEasy
{
    /// <summary>
    /// An opaque "handle" that represents a property of of some type of object.
    /// </summary>
    /// <remarks>
    /// For example, if a Person object has a name property of type String, that
    /// property would be represented by an instance of Property<Person,String>.
    /// </remarks>
    /// <typeparam name="T">the type of object that has the property</typeparam>
    public class Property<T>
    {
        public static Property<T> newProperty()
        {
            return new Property<T>();
        }
    }
}