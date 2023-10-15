using System.Reflection;

namespace recipeOf_ESO_web
{
    public static class Tools
    {

        //copy elements of BO to DO and vice versa
        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())//loop on all the properties in the new object
            {

                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);//check if there is property with the same name in the source object and get it
                if (propFrom == null)
                    continue;

                var value = propFrom.GetValue(from, null);//get the value of the prperty
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);//insert the value to the suitable property
            }
        }
        public static object CopyPropertiesToNew<S>(this S from, Type type)//get the typy we want to copy to 
        {
            object to = Activator.CreateInstance(type); // new object of the Type
            from.CopyPropertiesTo(to);//copy all value of properties with the same name to the new object
            return to;
        }

        public static void CopyPropertiesToIEnumerable<T, S>(this IEnumerable<S> from, List<T> to)
            where T : new()
        {
            foreach (S s in from)
            {
                T t = new T();
                s.CopyPropertiesTo(t);
                to.Add(t);
            }
        }
    }
}
