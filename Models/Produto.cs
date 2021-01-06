using System.Collections.Generic;
using System.IO;

namespace MVC_Console.Models
{
    public class Produto
    {
        public int Codigo { get; set; }
        
        public string Name { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/Produto.csv";
        
        public Produto(){

            //Verificar se a pasta existe
            string pasta = PATH.Split("/")[0];

            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //Verificar se o arquivo existe
            if(!File.Exists(PATH))
            {
                File.Create(PATH);
            }

        }

        public List<Produto> Ler()
        {
            //Armazena os produtos em uma lista
            List<Produto> produtos = new List<Produto>();
            //Lê as linhas do CSV
            string[] linhas = File.ReadAllLines(PATH);

            //Percorremos as linhas do csv
            foreach (string item in linhas)
            {
                
                string[] atributos = item.Split(";");
                //1;JBL;5000,00
                // [0] = 1
                // [1] = JBL
                // [2] = 5000,00

                // Passamos para um objeto do tipo Produto
                Produto prod    = new Produto();
                prod.Codigo     = int.Parse(atributos[0] );
                prod.Name       = atributos[1];
                prod.Preco      = float.Parse(atributos[2]);
                produtos.Add(prod);

            }

            return produtos;
        }
    }
}