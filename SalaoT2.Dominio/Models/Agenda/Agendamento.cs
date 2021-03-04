using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaoT2.Dominio
{
    public class Agendamento : IEntity
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public ServicoSolicitado ServicoSolicitado { get; set; }
        public DateTime? DtAgendamento { get; set; }
        public DateTime DataChegada { get; set; }
        public string Anotacao { get; set; }
        public StatusAgenda Status { get; set; }

        public enum StatusAgenda
        {
            ARealizar,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            NaoCompareceu,
            CanceladoPeloSalao,
            Pendente
        }

        internal void IncluirAgendamento(int id, Cliente cliente,
            ServicoSolicitado servicoParaAgendar,
            DateTime dtAgendamento, string anotacao = "")
        {
                Id = id;
                Cliente = cliente;
                ServicoSolicitado = servicoParaAgendar;
                DtAgendamento = dtAgendamento;
                Anotacao = anotacao;
            Status = StatusAgenda.ARealizar;
        }

        internal void AlterarAgendamento(Cliente cliente, ServicoSolicitado servicoParaAgendar,
            DateTime dtAgendamento, string anotacao = "")
        {
            servicoParaAgendar.Status = ServicoSolicitado.StatusServico.Reagendado;
            Cliente = cliente;
            ServicoSolicitado = servicoParaAgendar;
            DtAgendamento = dtAgendamento;
            Anotacao = anotacao;
        }
    }
}
