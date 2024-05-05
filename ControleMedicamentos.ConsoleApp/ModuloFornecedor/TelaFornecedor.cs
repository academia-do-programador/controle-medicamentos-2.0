using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFornecedor : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Fornecedor...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CNPJ"
            );

            EntidadeBase[] fornecedorCadastrados = repositorio.SelecionarTodos();

            foreach (Fornecedor fornecedor in fornecedorCadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.Cnpj
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do fornecedor: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CNPJ do fornecedor: ");
            string cnpj = Console.ReadLine();

            Fornecedor novoFornecedor = new Fornecedor(nome, telefone,cnpj);

            return novoFornecedor;
        }

        public void CadastrarEntidadeTeste()
        {
            Fornecedor fornecedor = new Fornecedor("Alexandre Rech", "49 1111-9521", "12321313122");

            repositorio.Cadastrar(fornecedor);
        }
    }
}
