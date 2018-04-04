    using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public static class FormatFactory<T> where T : IVuelingModelObject
    {
        public static IFormat<T> GetFormat(DataTypeAccess dataAccesType)
        {
            switch (dataAccesType)
            {   
                case DataTypeAccess.txt:
                    return new TxtFormat<T>();
                case DataTypeAccess.json:
                    return new JsonFormat<T>();
                case DataTypeAccess.xml:
                    return new XmlFormat<T>();
                default:
                    return null;
            }
        }

    }
}
