using System.Runtime.Serialization;
using System.ServiceModel;

namespace DM113_AtendimentoMedico.Model
{
    [DataContract]
    public class ConsultaItem
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public required DateTime Data { get; set; }
        [DataMember]
        public required ClienteModel Cliente { get; set; }
    }
}
