using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.Entrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {

        public Medicamento Medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeAdicionada { get; set; }

        public RequisicaoEntrada(Medicamento medicamentoRequisitado, Fornecedor fornecedorSelecionado, int quantidade)
        {
            Medicamento = medicamentoRequisitado;
            Fornecedor = fornecedorSelecionado;

            DataRequisicao = DateTime.Now;
            QuantidadeAdicionada = quantidade;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Fornecedor == null)
                erros[contadorErros++] = "O fornecedor precisa ser informado";

            if (QuantidadeAdicionada < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public bool AdicionarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeAdicionada)
                return false;

            Medicamento.Quantidade += QuantidadeAdicionada;
            return true;
        }
    }
}
