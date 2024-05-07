using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Cnpj.Trim()))
                erros.Add("O campo \"CNPJ\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistros(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }
    }
}
