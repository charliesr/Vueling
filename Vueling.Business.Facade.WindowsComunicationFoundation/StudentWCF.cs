using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Vueling.Business.Facade.WindowsComunicationFoundation
{
    [DataContract]
    public class StudentWCF
    {
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string DNI { get; set; }
        [DataMember]
        public DateTime FechaDeNacimiento { get; set; }
        [DataMember]
        public DateTime FechaHoraRegistro { get; set; }
        [DataMember]
        public int Edad { get; set; }
    }
}