using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;



            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamentos";

            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisiçãos";



            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();

            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.repositorio = repositorioFuncionario;
            telaFuncionario.tipoEntidade = "Funcionários";



            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada();

            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada();
            telaRequisicaoEntrada.repositorio = repositorioRequisicaoEntrada;
            telaRequisicaoEntrada.tipoEntidade = "Requisiçãos";

            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();

            TelaFornecedor telaFornecedor = new TelaFornecedor();
            telaFornecedor.repositorio = repositorioFornecedor;
            telaFornecedor.tipoEntidade = "Fornecedores";

            telaPaciente.CadastrarEntidadeTeste();
            telaFornecedor.CadastrarEntidadeTeste();
            telaFuncionario.CadastrarEntidadeTeste();

            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento; 
            
            telaRequisicaoEntrada.repositorioFornecedor = repositorioFornecedor;
            telaRequisicaoEntrada.repositorioMedicamento = repositorioMedicamento;

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaFuncionario;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaRequisicaoSaida;
                
                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaRequisicaoEntrada;

                else if (opcaoPrincipalEscolhida == '6')
                    tela = telaFornecedor;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }
    }
}
