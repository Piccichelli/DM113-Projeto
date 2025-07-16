using System.Runtime.Serialization;
using System.ServiceModel;

namespace DM113_AtendimentoMédico.Model
{
    [DataContract]
    public class ConsultaItem
    {
        [DataMember]
        public required DateTime Data { get; set; }
        [DataMember]
        public required string NomeCliente { get; set; }
        [DataMember]
        public required string CelularCliente { get; set; }

    }
}
