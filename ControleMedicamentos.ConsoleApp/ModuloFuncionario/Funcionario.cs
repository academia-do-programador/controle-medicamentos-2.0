﻿
/*
 Controle de Funcionário
Registrar Funcionário: O funcionário deverá ser registrado com as seguintes informações: nome, telefone e CPF.
Visualizar Funcionários: Exibe uma lista exibindo detalhes de todos os funcionários registrados.
Editar Funcionário: Oferece a possibilidade de modificar informações de um funcionário cadastrado.
Excluir Funcionário: Permite remover um registro de funcionário do sistema.
*/
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

            if (Nome.Length < 3)
                erros[contadorErros++] = "O Nome do funcionario precisa conter ao menos 3 caracteres";

            if (string.IsNullOrEmpty(Telefone))
                erros[contadorErros++] = "O Telefone precisa ser preenchido";

            if (string.IsNullOrEmpty(CPF))
                erros[contadorErros++] = "O CPF precisa ser preenchido";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
