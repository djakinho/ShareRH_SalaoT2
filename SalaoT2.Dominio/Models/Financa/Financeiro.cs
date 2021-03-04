using System.Linq;
namespace SalaoT2.Dominio
{
    public class Financeiro : IEntity
    {
        public int Id { get; set; }
        public Agendamento Agendamento { get; set; }
        public decimal Montante { get; set; }
        public float MargemFuncionario => 0.30F;
        public decimal TotalFuncionario { get; set; }

        public void Incluir(int id, Agendamento agendamento)
        {
            Id = id;
            Agendamento = agendamento;
        }

        public string RetornoServico(Agendamento agendamento)
        {
            if (agendamento.Status == Agendamento.StatusAgenda.Realizado)
            {
                Montante = agendamento.ServicoSolicitado.Servico.Preco -
                    (decimal)((float)agendamento.ServicoSolicitado.Servico.Preco * MargemFuncionario);
                return $"O montante do Salao neste atendimento especifico foi de {Montante}.";
            }
            else
                return "Servico nao realizado / finalizado.";
        }

        public string RetornoTotalFuncionario(Agendamento agendamento)
        {
            TotalFuncionario = agendamento.ServicoSolicitado.Servico.Preco * (decimal)MargemFuncionario;
            return $"Funcionaria(o) {agendamento.ServicoSolicitado.Funcionario.Nome} recebeu R${TotalFuncionario} neste servico.";
        }
    }
}
