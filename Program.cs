using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace PID_ALCii
{
    class Program
    {
        //static string[,] Inscricoes = new string[0, 18];
        static string[,] Inscricoes = null;

        static string Menu()
        {
            string Leitura;
            Console.Clear();
            Console.WriteLine("+-----------------------------------------------------+");
            Console.WriteLine("|                                                     |");
            Console.WriteLine("|        Sistema de Inscrição para Vestibular         |");
            Console.WriteLine("|  Digite o número da opção desejada ou X para sair:  |");
            Console.WriteLine("|                                                     |");
            Console.WriteLine("| 1 - Inscrição                                       |");
            Console.WriteLine("| 2 - Consulta                                        |");
            Console.WriteLine("| 3 - Sobre                                           |");
            Console.WriteLine("+-----------------------------------------------------+");
            Console.SetCursorPosition(52, 2);
            Leitura = ReadOpcao();
            
            return Leitura;
        }

        static string ReadOpcao()
        {
            string Opcao = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    int Opc;

                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        if (int.TryParse(Info.KeyChar.ToString(), out Opc))
                        {
                            if (Opcao.Length < 1)
                            {
                                switch (Opc)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                        Console.Write(Info.KeyChar);
                                        Opcao += Info.KeyChar;
                                        break;
                                }
                            }
                        }
                    }
                    else
                        if (Opcao.Length < 1)
                        {
                            Opcao = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Opcao))
                    {
                        //remove o último caracter da string
                        Opcao = Opcao.Substring(0, Opcao.Length - 1);
                        //pega a posição do cursos
                        int pos = Console.CursorLeft;
                        //posiciona o cursor
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        //coloca um espaço
                        Console.Write(" ");
                        //volta um espaço
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Opcao;
        }

        static string TrataCampo(string Campo)
        {
            if (Campo.Length > 25)
                Campo = Campo.Substring(0, 22) + "...";
            else
            {
                while (Campo.Length < 25)
                {
                    Campo += " ";
                }
            }

            return Campo;
        }

        static string ReadString()
        {
            string Valor = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString() != "\0")
                    {
                        Valor += Info.KeyChar;

                        if (Valor.Length < 24)
                        {
                            Console.Write(Info.KeyChar);
                        }
                        else
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);

                            Console.Write(Valor.Substring(Valor.Length - 24, 24));
                            Console.SetCursorPosition(50, Console.CursorTop);
                        }
                    }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Valor))
                    {
                        Valor = Valor.Substring(0, Valor.Length - 1);

                        int pos = Console.CursorLeft;

                        if (Valor.Length > 24)
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write(Valor.Substring(Valor.Length - 24, 24));

                            Console.SetCursorPosition(50, Console.CursorTop);
                            Console.Write(" ");

                            Console.SetCursorPosition(50, Console.CursorTop);
                        }
                        else
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write(Valor);
                            Console.SetCursorPosition(26 + Valor.Length, Console.CursorTop);
                        }
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Valor;
        }

        static string ReadData()
        {
            string Data = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        int Caracter;

                        if (int.TryParse(Info.KeyChar.ToString(), out Caracter))
                        {
                            if (Data.Length < 10)
                            {
                                switch (Data.Length)
                                {
                                    case 2:
                                    case 5:
                                        Data += "/";
                                        Console.Write("/");
                                        break;
                                }

                                Data += Info.KeyChar;
                                Console.Write(Info.KeyChar);
                            }
                        }
                    }
                    else
                        if (Data.Length < 1)
                        {
                            Data = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Data))
                    {
                        Data = Data.Substring(0, Data.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Data;
        }

        static string ReadCPF()
        {
            string CPF = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        int Caracter;

                        if (int.TryParse(Info.KeyChar.ToString(), out Caracter))
                        {
                            if (CPF.Length < 14)
                            {
                                switch (CPF.Length)
                                {
                                    case 3:
                                    case 7:
                                        CPF += ".";
                                        Console.Write(".");
                                        break;
                                    case 11:
                                        CPF += "-";
                                        Console.Write("-");
                                        break;
                                }

                                CPF += Info.KeyChar;
                                Console.Write(Info.KeyChar);
                            }
                        }
                    }
                    else
                        if (CPF.Length < 1)
                        {
                            CPF = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(CPF))
                    {
                        CPF = CPF.Substring(0, CPF.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return CPF;
        }

        static string ReadTel()
        {
            string Tel = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        int Caracter;

                        if (int.TryParse(Info.KeyChar.ToString(), out Caracter))
                        {
                            if (Tel.Length < 14)
                            {
                                switch (Tel.Length)
                                {
                                    case 0:
                                        Tel = "(";
                                        Console.Write("(");
                                        break;
                                    case 3:
                                        Tel += ") ";
                                        Console.Write(") ");
                                        break;
                                    case 9:
                                        Tel += "-";
                                        Console.Write("-");
                                        break;
                                }

                                Tel += Info.KeyChar;
                                Console.Write(Info.KeyChar);
                            }
                        }
                    }
                    else
                        if (Tel.Length < 1)
                        {
                            Tel = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Tel))
                    {
                        // remove one character from the list of password characters
                        Tel = Tel.Substring(0, Tel.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Tel;
        }

        static string ReadCel()
        {
            string Cel = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        int Caracter;

                        if (int.TryParse(Info.KeyChar.ToString(), out Caracter))
                        {
                            if (Cel.Length < 3)
                            {
                                switch (Cel.Length)
                                {
                                    case 0:
                                        Cel = "(";
                                        Console.Write("(");
                                        break;
                                }

                                Cel += Info.KeyChar;
                                Console.Write(Info.KeyChar);
                            }
                            else
                            {
                                if (Cel.Substring(0, 3) == "(11")
                                {
                                    if (Cel.Length < 15)
                                    {
                                        switch (Cel.Length)
                                        {
                                            case 3:
                                                Cel += ") ";
                                                Console.Write(") ");
                                                break;
                                            case 10:
                                                Cel += "-";
                                                Console.Write("-");
                                                break;
                                        }

                                        Cel += Info.KeyChar;
                                        Console.Write(Info.KeyChar);
                                    }
                                }
                                else
                                {
                                    if (Cel.Length < 14)
                                    {
                                        switch (Cel.Length)
                                        {
                                            case 3:
                                                Cel += ") ";
                                                Console.Write(") ");
                                                break;
                                            case 9:
                                                Cel += "-";
                                                Console.Write("-");
                                                break;
                                        }

                                        Cel += Info.KeyChar;
                                        Console.Write(Info.KeyChar);
                                    }
                                }
                            }
                        }
                    }
                    else
                        if (Cel.Length < 1)
                        {
                            Cel = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Cel))
                    {
                        Cel = Cel.Substring(0, Cel.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Cel;
        }

        static string ReadInt()
        {
            string Valor = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    int Num;

                    if (int.TryParse(Info.KeyChar.ToString(), out Num))
                    {
                        Valor += Info.KeyChar;

                        if (Valor.Length < 24)
                        {
                            Console.Write(Info.KeyChar);
                        }
                        else
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);

                            Console.Write(Valor.Substring(Valor.Length - 24, 24));
                            Console.SetCursorPosition(50, Console.CursorTop);
                        }
                    }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Valor))
                    {
                        Valor = Valor.Substring(0, Valor.Length - 1);
                        int pos = Console.CursorLeft;

                        if (Valor.Length > 24)
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write(Valor.Substring(Valor.Length - 24, 24));

                            Console.SetCursorPosition(50, Console.CursorTop);
                            Console.Write(" ");
                            Console.SetCursorPosition(50, Console.CursorTop);
                        }
                        else
                        {
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write("                         ");
                            Console.SetCursorPosition(26, Console.CursorTop);
                            Console.Write(Valor);
                            Console.SetCursorPosition(26 + Valor.Length, Console.CursorTop);
                        }
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Valor;
        }

        static string ReadOpcaoCurso()
        {
            string Opcao = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    int Opc;

                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        if (int.TryParse(Info.KeyChar.ToString(), out Opc))
                        {
                            if (Opcao.Length < 1)
                            {
                                switch (Opc)
                                {
                                    case 1:
                                        Console.Write("Ciência da Computação");
                                        Opcao = "Ciência da Computação";
                                        break;
                                    case 2:
                                        Console.Write("Sistemas de Informação");
                                        Opcao = "Sistemas de Informação";
                                        break;
                                    case 3:
                                        Console.Write("Administração");
                                        Opcao = "Administração";
                                        break;
                                    case 4:
                                        Console.Write("Contabilidade");
                                        Opcao = "Contabilidade";
                                        break;
                                }
                            }
                        }
                    }
                    else
                        if (Opcao.Length < 1)
                        {
                            Opcao = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Opcao))
                    {
                        Opcao = "";
                        Console.SetCursorPosition(26, Console.CursorTop);
                        Console.Write("                         ");
                        Console.SetCursorPosition(26, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Opcao;
        }

        static string ReadEstado()
        {
            string Valor = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    int Vlr;

                    if (!int.TryParse(Info.KeyChar.ToString(), out Vlr))
                    {
                        if (Valor.Length < 2)
                        {
                            Valor += Info.KeyChar.ToString().ToUpper();
                            Console.Write(Info.KeyChar.ToString().ToUpper());
                        }
                    }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Valor))
                    {
                        Valor = Valor.Substring(0, Valor.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Valor;
        }

        static string ReadCEP()
        {
            string CEP = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        int Caracter;

                        if (int.TryParse(Info.KeyChar.ToString(), out Caracter))
                        {
                            if (CEP.Length < 9)
                            {
                                switch (CEP.Length)
                                {
                                    case 5:
                                        CEP += "-";
                                        Console.Write("-");
                                        break;
                                }

                                CEP += Info.KeyChar;
                                Console.Write(Info.KeyChar);
                            }
                        }
                    }
                    else
                        if (CEP.Length < 1)
                        {
                            CEP = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(CEP))
                    {
                        CEP = CEP.Substring(0, CEP.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return CEP;
        }

        static string ReadConfimar()
        {
            string Opcao = "";
            ConsoleKeyInfo Info = Console.ReadKey(true);
            while (Info.Key != ConsoleKey.Enter)
            {
                if (Info.Key != ConsoleKey.Backspace)
                {
                    if (Info.KeyChar.ToString().ToLower() != "x")
                    {
                        if (Opcao.Length < 1)
                        {
                            if (Info.KeyChar.ToString().ToUpper() == "S" || Info.KeyChar.ToString().ToUpper() == "N")
                            {
                                    Console.Write(Info.KeyChar.ToString().ToUpper());
                                    Opcao += Info.KeyChar.ToString().ToUpper();
                            }
                        }
                    }
                    else
                        if (Opcao.Length < 1)
                        {
                            Opcao = "x";
                            Console.Write("x");
                        }
                }
                else if (Info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(Opcao))
                    {
                        Opcao = Opcao.Substring(0, Opcao.Length - 1);
                        int pos = Console.CursorLeft;
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                Info = Console.ReadKey(true);
            }

            return Opcao;
        }

        static void TelaInscricao(
            string Nome,
            string Nascimento,
            string CPF,
            string RG,
            string OrgaoEmissor,
            string Email,
            string Tel,
            string Cel,
            string Conclusao,
            string Op1,
            string Op2,
            string Endereco,
            string Numero,
            string Bairro,
            string Cidade,
            string UF,
            string CEP
        )
        {
            Console.Clear();

            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|                Ficha de Inscrição                |");
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|Nome                    :" + TrataCampo(Nome) + "|");
            Console.WriteLine("|Data de Nascimento      :" + TrataCampo(Nascimento) + "|");
            Console.WriteLine("|CPF                     :" + TrataCampo(CPF) + "|");
            Console.WriteLine("|RG                      :" + TrataCampo(RG) + "|");
            Console.WriteLine("|Orgão Emissor           :" + TrataCampo(OrgaoEmissor) + "|");
            Console.WriteLine("|E-mail                  :" + TrataCampo(Email) + "|");
            Console.WriteLine("|Tel. Residencial        :" + TrataCampo(Tel) + "|");
            Console.WriteLine("|Tel. Celular            :" + TrataCampo(Cel) + "|");
            Console.WriteLine("|Ano de conclusão 2º grau:" + TrataCampo(Conclusao) + "|");
            Console.WriteLine("|Opção 1                 :" + TrataCampo(Op1) + "|");
            Console.WriteLine("|Opção 2                 :" + TrataCampo(Op2) + "|");
            Console.WriteLine("|Endereço                :" + TrataCampo(Endereco) + "|");
            Console.WriteLine("|Número                  :" + TrataCampo(Numero) + "|");
            Console.WriteLine("|Bairro                  :" + TrataCampo(Bairro) + "|");
            Console.WriteLine("|Cidade                  :" + TrataCampo(Cidade) + "|");
            Console.WriteLine("|UF                      :" + TrataCampo(UF) + "|");
            Console.WriteLine("|CEP                     :" + TrataCampo(CEP) + "|");
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("Informação: Digite x para sair.");
        }

        static void Inscricao()
        {
            string Nome = "",
                   Nascimento = "",
                   CPF = "",
                   RG = "",
                   OrgaoEmissor = "",
                   Email = "",
                   Tel = "",
                   Cel = "",
                   Conclusao = "",
                   Op1 = "",
                   Op2 = "",
                   Endereco = "",
                   Numero = "",
                   Bairro = "",
                   Cidade = "",
                   UF = "",
                   CEP = "";

            //Desenha o formulário vazio
            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta nome
            Console.SetCursorPosition(26, 3);
            Nome = ReadString();

            if (Nome != "x")
            {
                while (Nome.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um nome!");

                    Console.SetCursorPosition(26, 3);
                    Nome = ReadString();

                    if (Nome == "x")
                        return;
                }
            }
            else
                return;

            //Desenha a Tela com o campo nome preenchido
            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta data de nascimento
            Console.SetCursorPosition(26, 4);
            Nascimento = ReadData();

            if (Nascimento != "x")
            {
                while (Nascimento.Trim() == "" || !ValidaData(Nascimento))
                {
                    TelaInscricao(Nome, "", CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);

                    if (Nascimento.Trim() == "")
                        Console.Write("Erro: Digite uma data!");
                    else
                        Console.Write("Erro: Digite uma data válida!");

                    Console.SetCursorPosition(26, 4);
                    Nascimento = ReadData();

                    if (Nascimento == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta o CPF
            Console.SetCursorPosition(26, 5);
            CPF = ReadCPF();

            if (CPF != "x")
            {
                while (CPF.Trim() == "" || !ValidaCPF(CPF))
                {
                    TelaInscricao(Nome, Nascimento, "", RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);

                    if (CPF.Trim() == "")
                        Console.Write("Erro: Digite uma CPF!");
                    else
                        Console.Write("Erro: Digite um CPF válido!");

                    Console.SetCursorPosition(26, 5);
                    CPF = ReadCPF();

                    if (CPF == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta o RG
            Console.SetCursorPosition(26, 6);
            RG = ReadString();

            if (RG != "x")
            {
                while (RG.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, "", OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um RG!");

                    Console.SetCursorPosition(26, 6);
                    RG = ReadString();

                    if (RG == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta o Órgão Emissor
            Console.SetCursorPosition(26, 7);
            OrgaoEmissor = ReadString();

            if (OrgaoEmissor != "x")
            {
                while (OrgaoEmissor.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, "", Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um Órgão Emissor!");

                    Console.SetCursorPosition(26, 7);
                    OrgaoEmissor = ReadString();

                    if (OrgaoEmissor == "x")
                        return;
                }
            }
            else
                return;

            OrgaoEmissor = OrgaoEmissor.ToUpper();
            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta E-mail
            Console.SetCursorPosition(26, 8);
            Email = ReadString();

            if (Email != "x")
            {
                while (Email.Trim() == "" || !ValidaEmail(Email))
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, "", Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);

                    if (Email.Trim() == "")
                        Console.Write("Erro: Digite um E-mail!");
                    else
                        Console.Write("Erro: Digite um E-mail válido!");

                    Console.SetCursorPosition(26, 8);
                    Email = ReadString();

                    if (Email == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta Tel
            Console.SetCursorPosition(26, 9);
            Tel = ReadTel();

            if (Tel != "x")
            {
                while (Tel.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, "", Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um Telefone!");

                    Console.SetCursorPosition(26, 9);
                    Tel = ReadTel();

                    if (Tel == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta Cel
            Console.SetCursorPosition(26, 10);
            Cel = ReadCel();

            if (Cel != "x")
            {
                while (Cel.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, "", Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    if (Cel.Trim() == "")
                        Console.Write("Erro: Digite um Celular!");
                    else
                    {
                        if (Cel.Length < 3)
                            Console.Write("Erro: Digite um Celular válido!");
                        else
                            if (Cel.Substring(0, 3) == "(11")
                            {
                                if (Cel.Length < 15)
                                    Console.Write("Erro: Digite um Celular válido!");
                            }
                            else
                            {
                                if (Cel.Length < 14)
                                    Console.Write("Erro: Digite um Celular válido!");
                            }
                    }

                    Console.SetCursorPosition(26, 10);
                    Cel = ReadCel();

                    if (Cel == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta Conclusão do Ensino Médio
            Console.SetCursorPosition(26, 11);
            Conclusao = ReadInt();

            if (Conclusao != "x")
            {
                while (Conclusao.Trim() == "" || Conclusao.Length > 11 || !ValidaCEM(Convert.ToInt32(Conclusao)))
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, "", Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);

                    if (Conclusao.Trim() == "")
                        Console.Write("Erro: Digite o ano de conclusão do ensino médio!");
                    else
                        Console.Write("Erro: Digite um ano de conclusão do ensino médio válido!");

                    Console.SetCursorPosition(26, 11);
                    Conclusao = ReadInt();

                    if (Conclusao == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, "", Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|1: Ciência da Computação|2: Sistemas de Informação|");
            Console.WriteLine("|3: Administração        |4: Contabilidade         |");
            Console.WriteLine("+--------------------------------------------------+");

            //Pergunta Opção de Curso 1
            Console.SetCursorPosition(26, 12);
            Op1 = ReadOpcaoCurso();

            if (Op1 != "x")
            {
                while (Op1.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, "", Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);
                    Console.SetCursorPosition(0, 23);
                    Console.WriteLine("+--------------------------------------------------+");
                    Console.WriteLine("|1: Ciência da Computação|2: Sistemas de Informação|");
                    Console.WriteLine("|3: Administração        |4: Contabilidade         |");
                    Console.WriteLine("+--------------------------------------------------+");

                    Console.SetCursorPosition(0, 22);

                    if (Op1.Trim() == "")
                        Console.Write("Erro: Digite uma opção de curso!");

                    Console.SetCursorPosition(26, 12);
                    Op1 = ReadOpcaoCurso();

                    if (Op1 == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, "", Endereco, Numero, Bairro, Cidade, UF, CEP);
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|1: Ciência da Computação|2: Sistemas de Informação|");
            Console.WriteLine("|3: Administração        |4: Contabilidade         |");
            Console.WriteLine("+--------------------------------------------------+");

            //Pergunta Opção de Curso 2
            Console.SetCursorPosition(26, 13);
            Op2 = ReadOpcaoCurso();

            if (Op2 != "x")
            {
                while (Op2.Trim() == "" || Op2 == Op1)
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, "", Endereco, Numero, Bairro, Cidade, UF, CEP);
                    Console.SetCursorPosition(0, 23);
                    Console.WriteLine("+--------------------------------------------------+");
                    Console.WriteLine("|1: Ciência da Computação|2: Sistemas de Informação|");
                    Console.WriteLine("|3: Administração        |4: Contabilidade         |");
                    Console.WriteLine("+--------------------------------------------------+");

                    Console.SetCursorPosition(0, 22);

                    if (Op2.Trim() == "")
                        Console.Write("Erro: Digite uma opção de curso!");
                    else
                        Console.Write("Erro: Digite uma opção de curso diferente da primeira opção!");

                    Console.SetCursorPosition(26, 13);
                    Op2 = ReadOpcaoCurso();

                    if (Op2 == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta o Endereço
            Console.SetCursorPosition(26, 14);
            Endereco = ReadString();

            if (Endereco != "x")
            {
                while (Endereco.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, "", Numero, Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um Endereço!");

                    Console.SetCursorPosition(26, 14);
                    Endereco = ReadString();

                    if (Endereco == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta Número
            Console.SetCursorPosition(26, 15);
            Numero = ReadInt();

            if (Numero != "x")
            {
                while (Numero.Trim() == "" || Numero.Length > 11)
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, "", Bairro, Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);

                    if (Numero.Trim() == "")
                        Console.Write("Erro: Digite um número!");
                    else
                        Console.Write("Erro: Digite um número válido!");

                    Console.SetCursorPosition(26, 15);
                    Numero = ReadInt();

                    if (Numero == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta o Bairro
            Console.SetCursorPosition(26, 16);
            Bairro = ReadString();

            if (Bairro != "x")
            {
                while (Bairro.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, "", Cidade, UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um Bairro!");

                    Console.SetCursorPosition(26, 16);
                    Bairro = ReadString();

                    if (Bairro == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta a Cidade
            Console.SetCursorPosition(26, 17);
            Cidade = ReadString();

            if (Cidade != "x")
            {
                while (Cidade.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, "", UF, CEP);

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite uma Cidade!");

                    Console.SetCursorPosition(26, 17);
                    Cidade = ReadString();

                    if (Cidade == "x")
                        return;
                }
            }
            else
                return;

            TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, CEP);

            //Pergunta o Estado
            Console.SetCursorPosition(26, 18);
            UF = ReadEstado();

            if (UF != "x")
            {
                while (UF.Trim() == "" || !ValidaEstado(UF))
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, "", CEP);

                    Console.SetCursorPosition(0, 22);
                    if (UF.Trim() == "")
                        Console.Write("Erro: Digite um estado!");
                    else
                        Console.Write("Erro: Este estado não existe!");

                    Console.SetCursorPosition(26, 18);
                    UF = ReadEstado();

                    if (UF == "x")
                        return;
                }
            }
            else
                return;

            //Pergunta CEP
            Console.SetCursorPosition(26, 19);
            CEP = ReadCEP();

            if (CEP != "x")
            {
                while (CEP.Trim() == "")
                {
                    TelaInscricao(Nome, Nascimento, CPF, RG, OrgaoEmissor, Email, Tel, Cel, Conclusao, Op1, Op2, Endereco, Numero, Bairro, Cidade, UF, "");

                    Console.SetCursorPosition(0, 22);
                    Console.Write("Erro: Digite um CEP!");

                    Console.SetCursorPosition(26, 19);
                    CEP = ReadCEP();

                    if (CEP == "x")
                        return;
                }
            }
            else
                return;

            string confirmado = "";

            while (confirmado == "")
            {
                Console.SetCursorPosition(0, 21);
                Console.Write("                               ");
                Console.SetCursorPosition(0, 21);
                Console.Write("Confirmar a Inscrição? (S/N): ");
                confirmado = ReadConfimar();

                if (confirmado == "S")
                {
                    string[,] Temp = new string[(Inscricoes.GetLength(0) + 1), 18];
                    Array.Copy(Inscricoes, Temp, Inscricoes.Length);
                    Inscricoes = Temp;

                    Inscricoes[Inscricoes.GetLength(0) - 1, 0] = Nome;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 1] = Nascimento;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 2] = CPF;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 3] = RG;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 4] = OrgaoEmissor;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 5] = Email;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 6] = Tel;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 7] = Cel;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 8] = Conclusao;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 9] = Op1;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 10] = Op2;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 11] = Endereco;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 12] = Numero;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 13] = Bairro;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 14] = Cidade;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 15] = UF;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 16] = CEP;
                    Inscricoes[Inscricoes.GetLength(0) - 1, 17] = Protocolo();
                    string caminho = modulos.arquivosValidos[0];
                    modulos.salvaInscritos(Inscricoes, caminho);

                    Console.WriteLine("\nProtocolo de inscriçao nº " + Inscricoes[Inscricoes.GetLength(0) - 1, 17]);

                    Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void Consulta()
        {
            string Pesquisa = "";

            while (Pesquisa != "x")
            {
                Console.Clear();

                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("|                          CONSULTAR                         |");
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("|Digite x para sair.                                         |");
                Console.WriteLine("+------------------------------------------------------------+");
                Console.WriteLine("Palavras chaves:");
                Console.SetCursorPosition(17, 5);
                Pesquisa = Console.ReadLine();

                if (Pesquisa != "x")
                {
                    if (Pesquisa.Trim() == "")
                    {
                        //crio o array pra pegar os nomes
                        string[] Ordem = new string[Inscricoes.GetLength(0)];

                        //percorro o array de inscriçoes pegando os nomes
                        for (int i = 0; i < Inscricoes.GetLength(0); i++)
                        {
                            Ordem[i] = Inscricoes[i, 0];
                        }

                        //coloco em ordem alfabética
                        Array.Sort(Ordem);

                        //mostro quantos foram encontrados
                        Console.WriteLine("\n(" + Ordem.Length + ") Resultados\n");

                        //mostro o resultado
                        for (int i = 0; i < Ordem.Length; i++)
                            Console.WriteLine(Ordem[i]);
                    }
                    else
                    {
                        string[] Palavras = Pesquisa.Split(' ');
                        string Resultados = "";

                        //percorro o array de inscriçoes pegando os nomes
                        for (int i = 0; i < Inscricoes.GetLength(0); i++)
                        {
                            int Ocorrencias = 0;

                            //percorro linha por linha das incrições procurando
                            //pelas palavras chaves se encontrar eu conto mais
                            //uma ocorrência
                            for (int p = 0; p < Palavras.Length; p++)
                            {
                                if (RetiraAcentos(Inscricoes[i, 0]).ToUpper().IndexOf(RetiraAcentos(Palavras[p]).ToUpper()) > -1)
                                    Ocorrencias++;
                            }

                            //se for encontrada todas as palavras chaves
                            //pego a posição que foi encontrada a palavra chave
                            if (Ocorrencias == Palavras.Length)
                                Resultados += Convert.ToString(i) + ",";
                        }

                        //se encontrou algum registro retiro a ultima virgula
                        if (Resultados != "")
                        {
                            Resultados = Resultados.Substring(0, Resultados.Length - 1);
                            //crio o array pra pegar os nomes
                            string[] Ordem = Resultados.Split(',');

                            //substituo os indices pelos nomes
                            for (int i = 0; i < Ordem.Length; i++)
                                Ordem[i] = Inscricoes[Convert.ToInt32(Ordem[i]), 0];

                            //coloco em ordem alfabética
                            Array.Sort(Ordem);

                            //mostro quantos foram encontrados
                            Console.WriteLine("\n(" + Ordem.Length + ") Resultados\n");

                            //mostro o resultado
                            for (int i = 0; i < Ordem.Length; i++)
                                Console.WriteLine(Ordem[i]);
                        }
                        else
                            Console.WriteLine("\nNenhum resultado foi encontrado.");
                    }

                    string confirmado;
                    Console.Write("\nDeseja realizar outra pesquisa? (S/N): ");
                    confirmado = ReadConfimar();

                    if (confirmado == "N")
                        return;
                }
                else
                    return;
            }
        }

        static void Sobre()
        {
            Console.Clear();

            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|                      GRUPO 2                     |");
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("|                                                  |");
            Console.WriteLine("+--------------------------------------------------+");

            string[] nomes = {"Alexandre dos Santos Lima", "Anderson Almino Moreira", "Frank Dantas Cunha", "Rafael Gustavo de Lima Vieira"};

            for (int i = 0; i < nomes.Length; i++)
            {
                Console.SetCursorPosition(1, 3 + i);

                for (int l = 0; l < nomes[i].Length; l++)
                {
                    Console.Write(nomes[i][l]);
                    System.Threading.Thread.Sleep(80);
                }
            }

            Console.SetCursorPosition(0, 8);
            Console.ReadKey();
        }

        static string Protocolo()
        {
            string ano = DateTime.Now.ToString("yyyyMMddHHmmss");
            //string ano = "20120821101537";
            int[] pesos = { 7, 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0, protocolo, resto;

            for (int i = 0; i < pesos.Length; i++)
                soma += Convert.ToInt32(ano[i].ToString()) * pesos[i];

            protocolo = soma % 11;
            resto = 11 - protocolo;

            if (protocolo < 2)
                resto = 0;

            return ano + " - " + resto;
        }

        static bool ValidaData(string Data)
        {
            string[] data = Data.Split('/');
            int dia, mes, ano;

            if (int.TryParse(data[0], out dia) && int.TryParse(data[1], out mes) && int.TryParse(data[2], out ano))
            {
                if (Convert.ToInt32(data[0]) > 0 && Convert.ToInt32(data[1]) > 0 && Convert.ToInt32(data[2]) > 0 && Convert.ToInt32(data[0]) <= 31 && Convert.ToInt32(data[1]) <= 12)
                {
                    switch (mes)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            if (dia > 31)
                                return false;
                            else
                                return true;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (dia > 30)
                                return false;
                            else
                                return true;
                        case 2:
                            if (ano % 4 == 0 && ano % 100 != 0 && ano % 400 != 0)
                            {
                                if (dia <= 29)
                                    return true;
                                else
                                    return false;
                            }
                            else
                            {
                                if (dia > 28)
                                    return false;
                                else
                                    return true;
                            }
                    }
                }
                else
                    return false;
            }
            return false;
        }

        static string RetiraAcentos(string Texto)
        {
            string Acentos =    "ÄÅÁÂÀÃÉÊËÈÍÎÏÌÖÓÔÒÕÜÚÛÇÝÑäåáâàãéêëèíîïìöóôòõüúûçýÿñ";
            string SemAcentos = "AAAAAAEEEEIIIIOOOOOUUUCYNaaaaaaeeeeiiiiooooouuucyyn";

            for (int i = 0; i < Texto.Length; i++)
            {
                for (int pos = 0; pos < Acentos.Length; pos++)
                {
                    Texto = Texto.Replace(Acentos[pos].ToString(), SemAcentos[pos].ToString());
                }
            }

            return Texto;
        }

        static bool ValidaCEM(int Ano)
        {
            if ((Ano >= 1900) && (Ano <= DateTime.Now.Year - 10))
                return true;
            else
                return false;
        }

        static bool ValidaCPF(string vrCPF)
        {

            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

 

            if (valor.Length != 11)

                return false;

 

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

 

            if (igual || valor == "12345678909")

                return false;

 

            int[] numeros = new int[11];

 

            for (int i = 0; i < 11; i++)

              numeros[i] = int.Parse(

                valor[i].ToString());

 

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

 

            int resultado = soma % 11;

 

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;

 

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

 

            resultado = soma % 11;

 

            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                    return false;

 

            return true;

        }

        static bool ValidaEmail(string Email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(Email))
                return true;
            else
                return false;
        }

        static bool ValidaEstado(string Estado)
        {
            string[] UF = { "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO" };

            for (int i = 0; i < 27; i++)
			{
			    if (Estado == UF[i])
                    return true;
			}

            return false;
        }

        static void Main(string[] args)
        {
            string Opcao;
            modulos.arquivos();
            Inscricoes = modulos.leInscritos();
            Opcao = Menu();
            while (Opcao != "x")
            {
                int opc;
                if (int.TryParse(Opcao, out opc))
                {
                    switch (opc)
                    {
                        case 1:
                            Inscricao();
                            break;
                        case 2:
                            Consulta();
                            break;
                        case 3:
                            Sobre();
                            break;
                        default:
                            Console.SetCursorPosition(0, 8);
                            Console.Write("Erro: Digite uma opção válida!");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, 8);
                    Console.Write("Erro: Digite uma opção válida!");
                    Console.ReadKey();
                }
                Opcao = Menu();
            }
        }
    }
}