using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System.Collections;

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

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Medicamento == null)
                erros.Add("O medicamento precisa ser preenchido");

            if (Fornecedor == null)
                erros.Add("O fornecedor precisa ser informado");

            if (QuantidadeAdicionada < 1)
                erros.Add("Por favor informe uma quantidade válida");

            return erros;
        }

        public bool AdicionarMedicamento()
        {
            if (Medicamento.Quantidade < QuantidadeAdicionada)
                return false;

            Medicamento.Quantidade += QuantidadeAdicionada;
            return true;
        }

        public override void AtualizarRegistros(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
