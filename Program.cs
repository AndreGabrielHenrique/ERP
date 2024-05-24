using System.Collections.Generic;
namespace ERP
{
    class Program
    {
        //Estruturar a classe Estoque 
        class Estoque
        {
            //Variáveis
            private List<double> Codigo{get;set;}=new List<double>();
            private List<string> Produto{get;set;}=new List<string>();
            private List<double> Preco{get;set;}=new List<double>();
            private List<int> Unidade{get;set;}=new List<int>();
            //Adicionar produto ao estoque
            public void EntradaProduto()
            {
                CodigoProduto();
                NomeProduto();
                PrecoProduto();
                UnidadeProduto();
            }
            public void CodigoProduto()
            {
                Console.WriteLine("Código do produto");
                string digitarcodigo=Console.ReadLine();
                bool validarcodigo=digitarcodigo.Length==5&&digitarcodigo.All(char.IsDigit);
                if(validarcodigo==false)
                {
                    Console.WriteLine("Código com menos ou mais de cinco digitos, em branco ou com caracteres, favor reinserir.");
                    CodigoProduto();
                }
                double.TryParse(digitarcodigo,out double codigo);
                Codigo.Add(codigo);
            }
            public void NomeProduto()
            {
                Console.WriteLine("Nome do produto");
                string produto=Console.ReadLine();
                if(string.IsNullOrWhiteSpace(produto)||produto.Length<2)
                {
                    Console.WriteLine("Nome do produto em branco ou com menos de dois caracteres, favor reinserir.");
                    NomeProduto();
                }
                Produto.Add(produto);
            }
            public void PrecoProduto()
            {
                Console.WriteLine("Preço do produto");
                string digitarpreco=Console.ReadLine();
                bool validarpreco=string.IsNullOrWhiteSpace(digitarpreco)&&digitarpreco.All(char.IsDigit);
                if(validarpreco==false)
                {
                    Console.WriteLine("Preço em branco ou com caracteres, favor reinserir.");
                    PrecoProduto();
                }
                double.TryParse(digitarpreco,out double preco);
                Preco.Add(preco);
            }
            public void UnidadeProduto()
            {
                Console.WriteLine("Unidades do produto");
                string digitarunidade=Console.ReadLine();
                bool validarunidade=string.IsNullOrWhiteSpace(digitarunidade)&&digitarunidade.All(char.IsDigit);
                if(validarunidade==false)
                {
                    Console.WriteLine("Unidades em branco ou com caracteres, favor reinserir.");
                    UnidadeProduto();
                }
                int.TryParse(digitarunidade,out int unidade);
                Unidade.Add(unidade);
            }
            //Reposição do produto
            public void ReporProduto(int unidade)
            {
                Unidade.Add(unidade);
            }        
        }
        //Estruturar a classe Cliente
        class Cliente
        {
            //Variáveis
            public string Nome{get;set;}
            private int CPF{get;set;}
            //Construtor
            public Cliente(string nome,int cpf)
            {
                Nome=nome;
                CPF=cpf;
            }
            //Inserir dados do cliente
            public void EntradaCliente()
            {
                NomeCliente();
                CPFCliente();
            }
            public void NomeCliente()
            {
                Console.WriteLine("Nome do cliente");
                Nome=Console.ReadLine();
                if(string.IsNullOrWhiteSpace(Nome)||Nome.Length<3)
                {
                    Console.WriteLine("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.");
                    NomeCliente();
                }
            }
            public void CPFCliente()
            {
                Console.WriteLine("Digite o CPF");
                string digitarcpf=Console.ReadLine();
                bool validarcpf=digitarcpf.Length==11&&digitarcpf.All(char.IsDigit);
                if(validarcpf==false)
                {
                    Console.WriteLine("CPF com menos ou mais de onze digitos, em branco ou com caracteres, favor reinserir.");
                    CPFCliente();
                }
                int.TryParse(digitarcpf,out int CPF);
            }
            //Imprimir nome do cliente na fatura
            private void DadosCliente()
            {
                Console.WriteLine($"Nome do cliente:        {Nome}\nCPF:        {CPF}");
            }
            public void ImprimirDadosCliente()
            {
                EntradaCliente();
                DadosCliente();
            }
        }
        //Corpo do programa
        static void Main(string[] args)
        {

            //Função para limpar a tela
            void LimparTela()
            {
                Console.ReadKey();
                Console.Clear();
            }
            //Função que recomeça todo o processo
            void Recomecar()
            {
                Console.WriteLine("Deseja recomeçar?");
                string escolha=Console.ReadLine();
                if(escolha.ToLower().Trim()=="sim")
                {
                    
                    LimparTela();
                    
                    
                }
                else
                {
                    Console.WriteLine("Obrigado, tenha um bom dia.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
        }
    }
}