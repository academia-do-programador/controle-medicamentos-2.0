using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{
    internal class TelaFornecedor : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Fornecedores...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Nome", "Telefone", "CNPJ"
            );

            EntidadeBase[] fornecedoresCadastrados = repositorio.SelecionarTodos();

            foreach (Fornecedor fornecedor in fornecedoresCadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                    fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.CNPJ
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CNPJ: ");
            string cnpj = Console.ReadLine();

            return new Fornecedor(nome, telefone, cnpj);
        }

        public void CadastrarEntidadeTeste()
        {
            Fornecedor fornecedor = new Fornecedor("Johnson & Johnson", "21 3222-1252", "00.511.320/0001-50");

            repositorio.Cadastrar(fornecedor);
        }
    }
}
