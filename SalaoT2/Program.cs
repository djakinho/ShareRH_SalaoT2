﻿using SalaoT2.Dominio;
using System.Linq;
using System;
using System.IO;
using System.Collections.Generic;

namespace SalaoT2
{
    class Program
    {
        static void Main(string[] args)
        {

            MinhaBaseClientes bc = IncluirMeusClientes();
            //MinhaBaseServicos bs = IncluirMeusServicos();
            //MinhaBaseFuncionarios bf = IncluirMeusFuncionarios(bs);

            //----------------------------------------------------------------------------------\\
            ServicoSolicitado servicoSolicitado = new ServicoSolicitado();
            //servicoSolicitado.IncluirServicoSolicitado(1, bs.Servicos[0], bf.Funcionarios[0]);

            ServicoSolicitado servicoSolicitado1 = new ServicoSolicitado();
            //servicoSolicitado1.IncluirServicoSolicitado(2, bs.Servicos[1], bf.Funcionarios[1]);

            //ServicoSolicitado servicoSolicitadoNovo = new ServicoSolicitado();
            //servicoSolicitadoNovo.IncluirServicoSolicitado();

            //----------------------------------------------------------------------------------\\
            MinhaBaseAgendamento ba = new MinhaBaseAgendamento();
            Console.WriteLine(ba.AgendarServicos(1, bc.Clientes[0], servicoSolicitado, DateTime.Today));
            Console.WriteLine(ba.AgendarServicos(2, bc.Clientes[1], servicoSolicitado1, DateTime.Today.AddHours(2)));

            //----------------------------------------------------------------------------------\\
            Financeiro financeiro = new Financeiro();
            financeiro.Incluir(1, ba.Agendamentos[0]);

            Financeiro financeiro1 = new Financeiro();
            financeiro1.Incluir(2, ba.Agendamentos[1]);


            MinhaBaseFincanceira baseFin = new MinhaBaseFincanceira();
            baseFin.IncluirFinanceiro(financeiro);
            baseFin.IncluirFinanceiro(financeiro1);


            Console.WriteLine(baseFin.Financas[0].RetornoServico(ba.Agendamentos[0]));
            Console.WriteLine(baseFin.Financas[1].RetornoServico(ba.Agendamentos[1]));
            //----------------------------------------------------------------------------------\\
            Console.WriteLine(ba.AlterarAgendamentoBase(ba.Agendamentos[0], bc.Clientes[0], servicoSolicitado, DateTime.Today.AddHours(5)));

            //----------------------------------------------------------------------------------\\
            baseFin.Financas[0].Agendamento.Status = Agendamento.StatusAgenda.Realizado;
            baseFin.Financas[1].Agendamento.Status = Agendamento.StatusAgenda.Realizado;

            //----------------------------------------------------------------------------------\\
            Console.WriteLine(baseFin.Financas[0].RetornoServico(ba.Agendamentos[0]));
            Console.WriteLine(baseFin.Financas[0].RetornoTotalFuncionario(ba.Agendamentos[0]));
            Console.WriteLine(baseFin.Financas[1].RetornoServico(ba.Agendamentos[1]));
            Console.WriteLine(baseFin.Financas[1].RetornoTotalFuncionario(ba.Agendamentos[1]));

            //----------------------------------------------------------------------------------\\
            Console.WriteLine(baseFin.RetornoTotalFinancas());
        }

        static MinhaBaseClientes IncluirMeusClientes()
        {
            Cliente c1 = new Cliente();
            c1.Incluir(1, "Thamirys", "999999999", "12345678901");

            Cliente c2 = new Cliente();
            c2.Incluir(2, "Thaise", "999999998", "12345678902");

            MinhaBaseClientes bc = new MinhaBaseClientes();
            bc.Incluir(c1);
            bc.Incluir(c2);

            var c3 = new Cliente();
            c3.Incluir(3, "Maria", "999999997", "12345678903");

            var c4 = new Cliente();
            c4.Incluir(4, "Joana", "999999996", "12345678904");

            bc.IncluirLista(c3, c4);

            return bc;
        }

        //static MinhaBaseServicos IncluirMeusServicos()
        //{
        //    Servico s1 = new Servico();
        //    s1.Incluir(1, "Corte de Cabelo", 59, 130);

        //    Servico s5 = new Servico();
        //    s5.Incluir(1, "Corte de Cabelo", 59, 130);

        //    Servico s2 = new Servico();
        //    s2.Incluir(2, "Manicure", 59, 20);

        //    Servico s3 = new Servico();
        //    s3.Incluir(3, "Pedicure", 59, 30);

        //    Servico s4 = new Servico();
        //    s4.Incluir(4, "Limpeza de pele", 59, 100);

        //    MinhaBaseServicos bs = new MinhaBaseServicos();
        //    bs.Incluir(s1);
        //    bs.Incluir(s2);
        //    bs.Incluir(s3);
        //    bs.Incluir(s4);
        //    bs.Incluir(s5);

        //    return bs;
        //}

        //static MinhaBaseFuncionarios IncluirMeusFuncionarios(MinhaBaseServicos baseDeServico)
        //{
        //    Funcionario f1 = new Funcionario();
        //    Endereco e1 = new Endereco();
        //    e1.Incluir(1, "Rua dos bobos", "12345-010", "Vila dos Devs", "São Paulo", "SP", "0", string.Empty);

        //    f1.Incluir("Maria", "999999999", e1, Funcionario.CargoFunc.Cabelereira);

        //    Funcionario f2 = new Funcionario();
        //    f2.Incluir("Rosana", "999999998", e1, Funcionario.CargoFunc.Manicure);

        //    Funcionario f3 = new Funcionario();
        //    f3.Incluir("Joana", "999999997", e1, Funcionario.CargoFunc.Esteticista);

        //    MinhaBaseFuncionarios bf = new MinhaBaseFuncionarios();
        //    bf.Incluir(f1);
        //    bf.Incluir(f2);
        //    bf.Incluir(f3);


        //    bf.IncluirServicoDeUmFuncionario(1, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 1));
        //    bf.IncluirServicoDeUmFuncionario(2, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 2));
        //    bf.IncluirServicoDeUmFuncionario(2, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 3));
        //    bf.IncluirServicoDeUmFuncionario(3, baseDeServico.Servicos.FirstOrDefault(x => x.Id == 4));

        //    return bf;
        //}

    }
}
