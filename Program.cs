class Program
{      
    //Estruturar a classe Estoque 
    class Estoque
    {
        //Variáveis
        string separador=new string('-',62);
        public string Codigo{get;set;}
        public string Produto{get;set;}
        public double Preco{get;set;}
        public int Unidade{get;set;}        
        //Imprimir dados do produto
        public void DadosProduto()
        {
            Console.WriteLine($"{separador}\nCódigo do produto:                             {Codigo}\nNome do produto:                               {Produto}\nPreço do produto:                              {Preco.ToString("C")}\nNúmero de unidades do produto:                 {Unidade}\n{separador}");
            Console.ReadKey();
        }        
    }   
    //Estruturar a classe Cliente
    class Cliente
    {
        //Variáveis
        string separador=new string('-',62);
        public string Nome{get;set;}
        public string CPF{get;set;}
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
        string separador=new string('-',62),opcao,opcaoestoque,opcaounidade,opcaocliente,codigo,produto,digitarpreco,digitarunidade,cpf;
        Estoque estoque=new Estoque();
        Cliente cliente=new Cliente();
        Console.WriteLine($"{separador}\nBem vindos ao gerenciamento do mercado Berimbau\n{separador}");
        Menu();
        //Menu inicial
        void Menu()
        {
            Console.WriteLine("Gerenciar estoque, gerenciar clientes ou sair?");
            opcao=Console.ReadLine();            
            if(opcao.ToLower().Trim()=="estoque")
            {
                Console.WriteLine("\n");
                PerguntarEstoque();
            }
            else if(opcao.ToLower().Trim()=="clientes")
            {
                Console.WriteLine("\n");
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
                Console.WriteLine("Entrada incorreta, favor reinserir.\n");
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
                Console.WriteLine("\n");
                CodigoProduto();
            }
            else if(opcaoestoque.ToLower().Trim()=="repor")
            {
                Console.WriteLine("\n");
                ReporProduto();                                                  
            }
            else
            {
                Console.WriteLine("Opção incorreta, de volta ao menu inicial.\n");                
                Menu();
            }
        }
        //Cadastrar produto no estoque
        void CodigoProduto()
        {            
            Console.WriteLine("Código do produto");
            codigo=Console.ReadLine();
            bool validarcodigo=codigo.Length==5&&codigo.All(char.IsDigit);
            if(validarcodigo==false)
            {
                Console.WriteLine("Código do produto com menos ou mais de cinco digitos, em branco ou com caracteres, favor reinserir.\n");
                CodigoProduto();
            }
            else
            {
                Console.WriteLine("\n");
                estoque.Codigo+=codigo;
                NomeProduto();
            }            
        }
        void NomeProduto()
        {
            Console.WriteLine("Nome do produto");
            produto=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(produto)||produto.Length<2)
            {
                Console.WriteLine("Nome do produto em branco ou com menos de dois caracteres, favor reinserir.\n");
                NomeProduto();
            }
            else
            {
                Console.WriteLine("\n");
                estoque.Produto+=produto;
                PrecoProduto();
            }            
        }
        void PrecoProduto()
        {
            Console.WriteLine("Preço do produto");
            digitarpreco=Console.ReadLine();            
            if(string.IsNullOrWhiteSpace(digitarpreco)||digitarpreco.All(char.IsLetter)||digitarpreco=="0")
            {
                Console.WriteLine("Preço do produto em branco ou com caracteres, favor reinserir.\n");
                PrecoProduto();
            }
            else
            {
                Console.WriteLine("\n");
                double.TryParse(digitarpreco,out double preco);
                estoque.Preco+=preco;
                PerguntarUnidadeProduto();
            }            
        }
        void PerguntarUnidadeProduto()
        {
            Console.WriteLine("Possui estoque?");
            opcaounidade=Console.ReadLine();
            if(opcaounidade.ToLower().Trim()=="sim")
            {
                Console.WriteLine("\n");
                InserirUnidadeProduto();                                            
            }
            else
            {
                estoque.DadosProduto();
                RecomecarEstoque();
            }
        }
        void InserirUnidadeProduto()
        {
            Console.WriteLine("Unidades do produto");
            digitarunidade=Console.ReadLine();
            bool validarunidade=string.IsNullOrWhiteSpace(digitarunidade)||digitarunidade.All(char.IsDigit);
            if(validarunidade==false)
            {
                Console.WriteLine("Unidades do produto em branco ou com caracteres, favor reinserir.\n");
                InserirUnidadeProduto();
            }
            else
            {
                int.TryParse(digitarunidade,out int unidade);
                estoque.Unidade+=unidade;
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
                Console.WriteLine("Unidades do produto em branco ou com caracteres, favor reinserir.\n");
                ReporProduto();
            }
            else
            {
                int.TryParse(digitarunidade,out int reporunidade);
                estoque.Unidade+=reporunidade;
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
                Console.WriteLine("\n");
                PerguntarEstoque();                            
            }
            else
            {
                Console.WriteLine("\n");
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
                Console.WriteLine("\n");
                NomeCliente();
            }
            else if(opcaocliente.ToLower().Trim()=="alterar")
            {
                Console.WriteLine("\n");
                AlterarCliente();
            }
            else
            {
                Console.WriteLine("Opção incorreta, de volta ao menu inicial.\n");                
                Menu();
            }
        }
        //Inserir dados do cliente
        void NomeCliente()
        {
            Console.WriteLine("Nome do cliente");
            cliente.Nome=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(cliente.Nome)||cliente.Nome.Length<3)
            {
                Console.WriteLine("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.\n");
                NomeCliente();
            }
            else
            {
                Console.WriteLine("\n");
                CPFCliente();
            }
        }
        void CPFCliente()
        {
            Console.WriteLine("CPF do cliente");
            cpf=Console.ReadLine();
            bool validarcpf=cpf.Length==11&&cpf.All(char.IsDigit);
            if(validarcpf==false)
            {
                Console.WriteLine("CPF do cliente com menos ou mais de onze digitos, em branco ou com caracteres, favor reinserir.\n");
                CPFCliente();
            }
            else
            {
                cliente.CPF+=cpf;
                cliente.DadosCliente();
                RecomecarCliente(); 
            }            
        }
        //Alterar dados do cliente
        void AlterarCliente()
        {
            Console.WriteLine("Alterar nome do cliente");
            cliente.Nome=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(cliente.Nome)||cliente.Nome.Length<3)
            {
                Console.WriteLine("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.\n");
                NomeCliente();
            }
            else
            {
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
                Console.WriteLine("\n");
                PerguntarCliente();                             
            }
            else
            {
                Console.WriteLine("\n");
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