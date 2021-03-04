using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SalaoT2.Dominio.Agendamento;

namespace SalaoT2.Dominio
{
    public class MinhaBaseAgendamento : IEntity
    {
        public List<Agendamento> Agendamentos { get; set; }

        public MinhaBaseAgendamento() => Agendamentos = new List<Agendamento>();

        public string AgendarServicos(int id, Cliente cliente, ServicoSolicitado servicoSolicitado, 
            DateTime dtAgendamento, string anotacao = "")
        {
            if (PermiteAgendar(servicoSolicitado, dtAgendamento))
            {
                return "Esse horário não está livre.";
            }
            else
            {
                Agendamento agendamento = new Agendamento();
                agendamento.IncluirAgendamento(id, cliente, servicoSolicitado, dtAgendamento, anotacao);
                Agendamentos.Add(agendamento);
                return "Agendamento feito com sucesso.";
            }
        }

        public string AlterarAgendamentoBase(Agendamento agendamento, Cliente cliente, ServicoSolicitado servicoParaAgendar,
            DateTime dtAgendamento, string anotacao = "")
        {
            if (PermiteAgendar(servicoParaAgendar, dtAgendamento))
                return "Este horario nao pode ser reagendado";
            else
                agendamento.AlterarAgendamento(cliente, servicoParaAgendar, dtAgendamento);
                return "Reagendamento feito com sucesso.";
        }

        private bool PermiteAgendar(ServicoSolicitado servicoParaAgendar, DateTime dtAgendamento)
        {
            DateTime dataTerminoParaAgendar = dtAgendamento.AddMinutes(servicoParaAgendar.Servico.MinutosParaExecucao);
            return (Agendamentos.Any(a => a.DtAgendamento >= dtAgendamento &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)) &&
                Agendamentos.Any(a => a.DtAgendamento <= dataTerminoParaAgendar &&
                    (a.Status != StatusAgenda.CanceladoPeloSalao || a.Status != StatusAgenda.CanceladoPeloCliente)));
        }
    }
}
