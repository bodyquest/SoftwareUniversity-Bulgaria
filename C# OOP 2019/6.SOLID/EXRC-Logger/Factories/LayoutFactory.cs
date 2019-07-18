namespace EXRC_Logger.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using EXRC_Logger.Exceptions;
    using EXRC_Logger.Models.Interfaces;

    public class LayoutFactory
    {
        public ILayout GetLayout (string type)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type typeToCreate = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == type);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);
            return layout;
        }
    }
}
