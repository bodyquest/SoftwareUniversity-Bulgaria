﻿namespace SIS.MvcFramework.Mapping
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Reflection;

    public static class ModelMapper
    {
        public static TDestination ProjectTo <TDestination>(object origin)
        { 
            var destinationInstance = (TDestination)Activator.CreateInstance(typeof(TDestination));

            foreach (var originProperty in origin.GetType().GetProperties())
            {
                string propertyName = originProperty.Name;
                PropertyInfo destinationProperty = destinationInstance
                    .GetType()
                    .GetProperty(propertyName);

                if (destinationProperty != null)
                {
                    if (destinationProperty.PropertyType == typeof(string))
                    {
                        destinationProperty.SetValue(destinationInstance, originProperty.GetValue(origin).ToString());
                    }
                    else
                    {
                        destinationProperty.SetValue(destinationInstance, originProperty.GetValue(origin));
                    }
                }
            }

            return destinationInstance;
        }
    }
}
