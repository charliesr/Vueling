using System;
using System.Reflection;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public static class FormatFactory<T> where T : IVuelingModelObject
        {
            public static IFormat<T> GetFormat(DataTypeAccess dataTypeAccess)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var typeString = string.Concat(assembly.GetName().Name, ".Formats.", dataTypeAccess.ToString().Substring(0, 1).ToUpper(), dataTypeAccess.ToString().Substring(1), "Format`1");
                var type = assembly.GetType(typeString);
                return (IFormat<T>)Activator.CreateInstance(type.MakeGenericType(typeof(T)));
            }
        }
    }
