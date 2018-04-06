using System;
using System.Runtime.Serialization;
using System.Text;
using Vueling.Common.Logic;

namespace Vueling.DataAccess.DAO
{
    [Serializable]
    public class DataTypeNotImplementedException : NotImplementedException
    {
        public override string Message { get; }
        public DataTypeNotImplementedException(DataTypeAccess dataTypeAccess)
        {
            Message = string.Concat("Data type access ", dataTypeAccess.ToString() , "not implemented!!, returning default dataAccesType");

        }
        public DataTypeNotImplementedException()
        {
            Message = "Data type access not implemented!!, returning default dataAccesType"";
        }
    }
}