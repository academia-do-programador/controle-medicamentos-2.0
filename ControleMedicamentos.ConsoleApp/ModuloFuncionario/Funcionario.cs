using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Funcionario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];

            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros[contadorErros++] = ("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(CPF.Trim()))
                erros[contadorErros++] = ("O campo \"CPF\" é obrigatório");

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
