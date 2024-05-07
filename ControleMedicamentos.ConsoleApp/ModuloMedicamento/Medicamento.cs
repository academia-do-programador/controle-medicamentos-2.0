using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class Medicamento : EntidadeBase
    {
        public Medicamento(string nome, string descricao, string lote, DateTime dataValidade)
        {
            Nome = nome;
            Descricao = descricao;
            Lote = lote;
            DataValidade = dataValidade;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Lote { get; set; }
        private DateTime DataValidade { get; set; }
        public Fornecedor fornecedor { get; set; }
        public int Quantidade { get; set; } = 5;

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Descricao.Trim()))
                erros.Add("O campo \"descrição\" é obrigatório");

            if (string.IsNullOrEmpty(Lote.Trim()))
                erros.Add("O campo \"lote\" é obrigatório");

            DateTime hoje = DateTime.Now.Date;

            if (DataValidade < hoje)
                erros.Add("O campo \"data de validade\" não pode ser menor que a data atual");

            return erros;
        }

        public override void AtualizarRegistros(EntidadeBase novoRegistro)
        {
            Medicamento novasIndormações = (Medicamento)novoRegistro;

            this.Nome = novasIndormações.Nome;
            this.Descricao = novasIndormações.Descricao;
            this.Lote = novasIndormações .Lote; 
            this.DataValidade = novasIndormações.DataValidade;
            this.fornecedor = novasIndormações.fornecedor;
            this.Quantidade = novasIndormações.Quantidade;
        }
    }
}
