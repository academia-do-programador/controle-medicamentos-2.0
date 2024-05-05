using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        public Funcionario funcionario;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Funcionários...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CPF"
            );

            EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CPF do funcionário: ");
            string cpf = Console.ReadLine();

            Funcionario novoFuncionario = new Funcionario(nome, telefone, cpf);

            return novoFuncionario;
        }

        public void CadastrarEntidadeTeste()
        {
            Funcionario funcionario = new Funcionario("Roberto mesas", "49 4002-8922", "111.222.333-44");

            repositorio.Cadastrar(funcionario);
        }
    }
}
