using System;

namespace SalaoT2.Dominio
{
    public class Turno : IEntity
    {
        public int Id { get; set; }
        public DateTime EntradaManha => Convert.ToDateTime("08:00");

        public DateTime SaidaManha => Convert.ToDateTime("17:00");

        public DateTime EntradaTarde => Convert.ToDateTime("11:00");

        public DateTime SaidaTarde => Convert.ToDateTime("20:00");

        public DateTime EntradaSabado => Convert.ToDateTime("08:00");

        public DateTime SaidaSabado => Convert.ToDateTime("18:00");

        public TurnoFunc TurnoFuncionario { get; set; }

        public enum TurnoFunc
        {
            Manha,
            Tarde
        }
    }
}
