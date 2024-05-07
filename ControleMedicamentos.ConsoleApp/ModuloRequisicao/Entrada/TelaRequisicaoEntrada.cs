using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaFornecedor telaFornecedor = null;
        public TelaMedicamento telaMedicamento = null;

        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioMedicamento repositorioMedicamento = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            ArrayList erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuAdicionar = entidade.AdicionarMedicamento();

            if (!conseguiuAdicionar)
            {
                ExibirMensagem("Não foi possivel adicionar medicamentos.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                "Id", "Medicamento", "Fornecedor", "Data de Requisição", "Quantidade"
            );

            ArrayList requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    requisicao.Id,
                    requisicao.Medicamento.Nome,
                    requisicao.Fornecedor.Nome,
                    requisicao.DataRequisicao.ToShortDateString(),
                    requisicao.QuantidadeAdicionada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamentos";

            telaMedicamento.VisualizarRegistros(false);


            Console.Write("Digite o nome do medicamento requisitado: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, lote, dataValidade);


            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();

            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.repositorio = repositorioFornecedor;
            telaFornecedor.tipoEntidade = "Fornecedores";
            telaFornecedor.CadastrarEntidadeTeste();


            telaFornecedor.VisualizarRegistros(false);

            Console.Write("Digite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.Write("Digite a quantidade para o pedido: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada(medicamento, fornecedorSelecionado, quantidade);

            return novaRequisicao;
        }
    }
}
