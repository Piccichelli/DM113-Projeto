using DM113_AtendimentoMedico.Model;
using System.ServiceModel;

namespace DM113_AtendimentoMedico.Service
{
    [ServiceContract]
    public interface IConsultaService
    {
        [OperationContract]
        ConsultaItem[] GetConsultas(); // READ (listar todas)

        [OperationContract]
        ConsultaItem GetConsultaPorId(int id); // READ (buscar por id)

        [OperationContract]
        void CreateConsultaItem(ConsultaItem item); // CREATE

        [OperationContract]
        void UpdateConsultaItem(ConsultaItem item); // UPDATE

        [OperationContract]
        void DeleteConsultaItem(int id); // DELETE
    }
    public class ConsultaService : IConsultaService
    {
        private static List<ConsultaItem> consultas = new List<ConsultaItem>();

        public ConsultaItem[] GetConsultas()
        {
            return consultas.ToArray();
        }

        public ConsultaItem GetConsultaPorId(int id)
        {
            var item = consultas.FirstOrDefault(c => c.Id == id);
            if(item == null)
            {
                throw new FaultException($"Consulta de Id: {id} não encontrada.");
            }
            return item;
        }

        public void CreateConsultaItem(ConsultaItem item)
        {
            item.Id = consultas.Count + 1;
            consultas.Add(item);
        }

        public void UpdateConsultaItem(ConsultaItem item)
        {
            var existente = consultas.FirstOrDefault(c => c.Id == item.Id);
            if (existente == null)
            {
                throw new FaultException($"Consulta com id: {item.Id} não encontrada.");
            }

            existente.Data = item.Data;
            existente.Cliente.Telefone = item.Cliente.Telefone;
            existente.Cliente.Email = item.Cliente.Email;
        }

        public void DeleteConsultaItem(int id)
        {
            var item = consultas.FirstOrDefault(c => c.Id == id);
            if (item == null)
            {
                throw new FaultException($"Consulta de Id: {id} não encontrada.");
            }

            consultas.Remove(item);
            
        }
    }
}
