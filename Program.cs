/*1- Com os comandos aprendidos em Python, elabore um código
simulando um ERP simples, que contenha todas as etapas
desse exemplo de fluxo de pedido. Você deve iniciar o código
hoje, e finalizá-lo e enviá-lo amanhã.*/
class Program
{
    static string? codigo{get;set;}
    static string? produto{get;set;}
    static double preco{get;set;}
    static int? unidade{get;set;}
    static int? cpf{get;set;}
    //Estruturar a classe Estoque 
    class Estoque
    {
        //Variáveis
        string? separador=new string('-',62);
        public string? Codigo{get;set;}
        public string? Produto{get;set;}
        public double? Preco{get;set;}
        public int? Unidade{get;set;}
        //Construtores
        public Estoque()
        {}
        public Estoque(string? codigo,string? produto,double? preco)
        {
            Codigo=codigo;
            Produto=produto;
            Preco=preco;
        }
        public Estoque(string? codigo,string? produto,double? preco,int? unidade):this(codigo,produto,preco)
        {
            Unidade=unidade;
        }
        //Imprimir dados do produto
        public void DadosProduto()
        {
            Console.WriteLine($"{separador}\nCódigo do produto:                             {codigo}\nNome do produto:                               {produto}\nPreço do produto:                              {preco:c}\nNúmero de unidades do produto:                 {unidade}\n{separador}");
            Console.ReadKey();
        }        
    }   
    //Estruturar a classe Cliente
    class Cliente
    {
        //Variáveis
        string? separador=new string('-',62);
        public string? Nome{get;set;}
        public int? CPF{get;set;}
        //Construtor
        public Cliente()
        {}
        public Cliente(string? nome,int? cpf)
        {
            Nome=nome;
            CPF=cpf;
        }
        //Imprimir dados do cliente
        public void DadosCliente()
        {
            Console.WriteLine($"{separador}\nNome do cliente:                              {Nome}\nCPF do cliente:                               {CPF}\n{separador}");
            Console.ReadKey();
        }        
    }

    //Corpo do programa
    public static void Main()
    {
        string? separador=new string('-',62),opcao,opcaoestoque,opcaounidade,opcaocliente,nome,Preco,digitarunidade,digitarcpf;
        Estoque estoque;
        Cliente cliente;        
        Console.WriteLine($"{separador}\nBem vindos ao gerenciamento do mercado Berimbau\n{separador}");
        Menu();
        //Menu inicial
        void Menu()
        {
            Console.WriteLine("Gerenciar estoque, gerenciar clientes ou sair?");
            opcao=Console.ReadLine();
            if(opcao.ToLower().Trim()=="estoque")
            {
                PerguntarEstoque();
            }
            else if(opcao.ToLower().Trim()=="clientes")
            {
                PerguntarCliente();                               
            }
            else if(opcao.ToLower().Trim()=="sair")
            {   
                Console.WriteLine(separador);
                LimparTela();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Inserção incorreta, favor reinserir.");
                Menu();
            } 
        }
        //Perguntar se deseja repor estoque de um produto, ou cadastrar um novo        
        void PerguntarEstoque()
        {
            Console.WriteLine("Cadastrar produto ou repor estoque?");
            opcaoestoque=Console.ReadLine();
            if(opcaoestoque.ToLower().Trim()=="cadastrar")
            {
                CodigoProduto();
            }
            else if(opcaoestoque.ToLower().Trim()=="repor")
            {
                ReporProduto();                                                  
            }
            else
            {
                Console.WriteLine("Opção incorreta, de volta ao menu inicial.");                
                Menu();
            }
        }
        //Cadastrar produto no estoque
        void CodigoProduto()
        {
            Console.WriteLine("Código do produto");
            codigo=Console.ReadLine();
            bool? validarcodigo=codigo.Length==5&&codigo.All(char.IsDigit);
            if(validarcodigo==false)
            {
                Console.WriteLine("Código do produto com menos ou mais de cinco digitos, em branco ou com caracteres, favor reinserir.");
                CodigoProduto();
            }
            else
            {
                NomeProduto();
            }            
        }
        void NomeProduto()
        {
            Console.WriteLine("Nome do produto");
            produto=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(produto)||produto.Length<2)
            {
                Console.WriteLine("Nome do produto em branco ou com menos de dois caracteres, favor reinserir.");
                NomeProduto();
            }
            else
            {
                PrecoProduto();
            }            
        }
        void PrecoProduto()
        {
            Console.WriteLine("Preço do produto");
            Preco=Console.ReadLine();            
            if(string.IsNullOrWhiteSpace(Preco)||Preco.All(char.IsLetter)||Preco=="0")
            {
                Console.WriteLine("Preço do produto em branco ou com caracteres, favor reinserir.");
                PrecoProduto();
            }
            else
            {
                double.TryParse(Preco,out double preco);
                PerguntarUnidadeProduto();
            }            
        }
        void PerguntarUnidadeProduto()
        {
            Console.WriteLine("Possui estoque?");
            opcaounidade=Console.ReadLine();
            if(opcaounidade.ToLower().Trim()=="sim")
            {
                InserirUnidadeProduto();                                            
            }
            else
            {
                estoque=new Estoque(codigo,produto,preco);
                estoque.DadosProduto();
                RecomecarEstoque();
            }
        }
        void InserirUnidadeProduto()
        {
            Console.WriteLine("Unidades do produto");
            digitarunidade=Console.ReadLine();
            bool? validarunidade=string.IsNullOrWhiteSpace(digitarunidade)||digitarunidade.All(char.IsDigit);
            if(validarunidade==false)
            {
                Console.WriteLine("Unidades do produto em branco ou com caracteres, favor reinserir.");
                InserirUnidadeProduto();
            }
            else
            {
                int.TryParse(digitarunidade,out int unidade);
                estoque=new Estoque(codigo,produto,preco,unidade);
                estoque.DadosProduto();
                RecomecarEstoque();                
            }                        
        }
        //Reposição do produto
        void ReporProduto()
        {
            Console.WriteLine("Unidades do produto");
            digitarunidade=Console.ReadLine();
            bool validarunidade=string.IsNullOrWhiteSpace(digitarunidade)||digitarunidade.All(char.IsDigit);
            if(validarunidade==false)
            {
                Console.WriteLine("Unidades do produto em branco ou com caracteres, favor reinserir.");
                ReporProduto();
            }
            else
            {
                int.TryParse(digitarunidade,out int unidade);
                estoque=new Estoque();
                estoque.DadosProduto();
                RecomecarEstoque();
            }       
        }
        //Perguntar se deseja recomeçar todo o processo de gerenciamento de estoque
        void RecomecarEstoque()
        {
            Console.WriteLine("Recomeçar?");
            opcaounidade=Console.ReadLine();
            if(opcaounidade.ToLower().Trim()=="sim")
            {
                PerguntarEstoque();                            
            }
            else
            {
                Menu();
            }
        }
        //Perguntar se deseja alterar os dados de um cliente, ou cadastrar um novo
        void PerguntarCliente()
        {
            Console.WriteLine("Cadastrar ou alterar dados de cliente?");
            opcaocliente=Console.ReadLine();
            if(opcaocliente.ToLower().Trim()=="cadastrar")
            {  
                NomeCliente();
            }
            else if(opcaocliente.ToLower().Trim()=="alterar")
            {
                AlterarCliente();
            }
            else
            {
                Console.WriteLine("Opção incorreta, de volta ao menu inicial.");                
                Menu();
            }
        }
        //Inserir dados do cliente
        void NomeCliente()
        {
            Console.WriteLine("Nome do cliente");
            nome=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nome)||nome.Length<3)
            {
                Console.WriteLine("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.");
                NomeCliente();
            }
            else
            {
                CPFCliente();
            }
        }
        void CPFCliente()
        {
            Console.WriteLine("CPF do cliente");
            digitarcpf=Console.ReadLine();
            bool? validarcpf=digitarcpf.Length==11&&digitarcpf.All(char.IsDigit);
            if(validarcpf==false)
            {
                Console.WriteLine("CPF do cliente com menos ou mais de onze digitos, em branco ou com caracteres, favor reinserir.");
                CPFCliente();
            }
            else
            {
                int.TryParse(digitarcpf,out int cpf);
                cliente=new Cliente(nome,cpf);
                cliente.DadosCliente();
                RecomecarCliente(); 
            }            
        }
        //Alterar dados do cliente
        void AlterarCliente()
        {
            Console.WriteLine("Alterar nome do cliente");
            nome=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(nome)||nome.Length<3)
            {
                Console.WriteLine("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.");
                NomeCliente();
            }
            else
            {
                Cliente cliente=new Cliente();
                cliente.DadosCliente();
                RecomecarCliente(); 
            }
        }
        
        //Perguntar se deseja recomeçar todo o processo de gerenciamento de clientes
        void RecomecarCliente()
        {
            Console.WriteLine("Recomeçar?");
            opcaocliente=Console.ReadLine();
            if(opcaocliente.ToLower().Trim()=="sim")
            {
                PerguntarCliente();                             
            }
            else
            {
                Menu();
            }
        }       
        //Função para limpar a tela
        void LimparTela()
        {
            Console.ReadKey();
            Console.Clear();
        }        
    }         
}