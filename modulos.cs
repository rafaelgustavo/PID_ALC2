using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace PID_ALCii
{
    class modulos
    {
        public static string[] arquivosValidos = new string[3];
        public static string[] arquivos()
        {
            Console.WriteLine("Arquivo de INSCRITOS!!");
            arquivosValidos[0] = validarArquivo();
            Console.WriteLine("Arquivo de RESULTADOS!!");
            arquivosValidos[1] = validarArquivo();
            Console.WriteLine("Arquivo de APROVADOS!!");
            arquivosValidos[2] = validarArquivo();
            return arquivosValidos;
        }
        static string validarArquivo()
        {
            string path;
            Console.Write("Nome do arquivo (caminho completo): ");
            path = Console.ReadLine();
            while (!File.Exists(path) && path.Trim() != "")
            {
                Console.Clear();
                Console.WriteLine("Arquivo invalido!!");
                Console.Write("Deseja criar o arquivo? (s/n)");
                string resp = Console.ReadLine();
                if (resp.ToLower() == "s")
                {
                    int ponto = path.IndexOf(".");
                    if (ponto > 0)
                    {
                        path = path.Substring(0, ponto);
                    }
                    File.Create(path + ".txt");
                    path += ".txt";
                }
                else
                {
                    Console.Write("Nome do arquivo (caminho completo): ");
                    path = Console.ReadLine();
                }
            }
            return path;
        }
        public static void salvaInscritos(string[,] inscritos, string caminho)
        {
            //INSCRITOS
            StreamWriter gravaInscritos = new StreamWriter(caminho, true);
            for (int i = 0; i < inscritos.GetLength(0); i++)
            {
                string linha = "";
                for (int j = 0; j < inscritos.GetLength(1); j++)
                {
                    linha += inscritos[i, j] + "|";
                }
                gravaInscritos.WriteLine(linha.Remove(linha.Length - 1));
            }
            gravaInscritos.Close();
        }
        /// <summary>
        /// Função que salva no arquivo texto o resultado da matriz RESULTADO
        /// </summary>
        /// <param name="resultados">Matriz que contem os valores</param>
        public static void salvaResultado(string[,] resultados)
        {
            //RESULTADO
            StreamWriter gravaInscritos = new StreamWriter(arquivosValidos[1], true);
            for (int i = 0; i < resultados.GetLength(0); i++)
            {
                string linha = "";
                for (int j = 0; j < resultados.GetLength(1); j++)
                {
                    linha += resultados[i, j] + "|";
                }
                gravaInscritos.WriteLine(linha);
            }
            gravaInscritos.Close();
        }
        public static string[,] leInscritos()
        {
            StreamReader leitura = new StreamReader(arquivosValidos[0]);
            string[,] retorna = new string[0, 0];
            //Da para deixar o tamanho fixo
            int tamanho;
            //
            while (!leitura.EndOfStream)
            {
                string[] vetLinha = leitura.ReadLine().Split('|');
                tamanho = vetLinha.Length;
                string[,] Temp = new string[(retorna.GetLength(0) + 1), tamanho];
                Array.Copy(retorna, Temp, retorna.Length);
                retorna = Temp;
                for (int i = 0; i < vetLinha.Length; i++)
                {
                    retorna[retorna.GetLength(0) - 1, i] = vetLinha[i];
                }
            }
            leitura.Close();
            return retorna;
        }
        public static void ordena(ref string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(0); j++)
                {
                    if (matriz[i, 0].CompareTo(matriz[j, 0]) < 0)
                    {
                        //Codigo para ordenar...
                    }
                }
            }
        }
    }
}
