namespace ValidationAttributes.Utilities
{
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            //get all properties
            PropertyInfo[] propInfos = obj
                .GetType()
                .GetProperties();

            //for each property we get the custom attributes, our validation attributes. We put them in one array of MyValidationAttribute
            foreach (PropertyInfo property in propInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                // we check if they are valid; we get the value for the current object
                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
