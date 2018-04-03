using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.DAO
{
    public static class FormatFactory<T> where T : IVuelingModelObject
    {
        public static IFormat<T> GetFormat(Enums.DataTypeAccess dataAccesType)
        {
            switch (dataAccesType)
            {   
                case Enums.DataTypeAccess.txt:
                    return new TxtFormat<T>();
                case Enums.DataTypeAccess.json:
                    return new JsonFormat<T>();
                case Enums.DataTypeAccess.xml:
                    return new XmlFormat<T>();
                default:
                    return null;
            }
        }

    }
}
