using System;
using System.Collections.Generic;

namespace SalaoT2.Dominio
{
    public class MinhaBaseFincanceira
    {
        public int Id { get; set; }
        public List<Financeiro> Financas { get; set; }


        public MinhaBaseFincanceira() => Financas = new List<Financeiro>();

        public void IncluirFinanceiro(Financeiro financeiro) => Financas.Add(financeiro);

        public string RetornoTotalFinancas()
        {
            decimal total = 0;
            for (int i = 0; i < Financas.Count; i++)
                total += Financas[i].Montante;

            return $"Seu montante ate agora eh de R${total}.";
        }


    }
}
