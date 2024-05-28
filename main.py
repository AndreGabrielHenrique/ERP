# 1- Com os comandos aprendidos em Python, elabore um código
# simulando um ERP simples, que contenha todas as etapas
# desse exemplo de fluxo de pedido. Você deve iniciar o código
# hoje, e finalizá-lo e enviá-lo amanhã.

# Estruturar a classe Estoque
class Estoque:
    # Variáveis
    separador = '-' * 62

def __init__():
    Codigo = ""
    Produto = ""
    Preco = 0.0
    Unidade = 0

    # Imprimir dados do produto
    def DadosProduto():
        print(f"{separador}\nCódigo do produto:                             {Codigo}\nNome do produto:                               {Produto}\nPreço do produto:                              {Preco:.2f}\nNúmero de unidades do produto:                 {Unidade}\n{separador}")
        input()

# Estruturar a classe Cliente
class Cliente:
    # Variáveis
    separador = '-' * 62

def __init__():
    Nome = ""
    CPF = ""

    # Imprimir dados do cliente
    def DadosCliente():
        print(f"{separador}\nNome do cliente:                              {Nome}\nCPF do cliente:                               {CPF}\n{separador}")
        input()

# Corpo do programa
class main:
    separador = '-' * 62
    estoque = Estoque()
    cliente = Cliente()

def __init__():
    opcao = ""
    opcaoestoque = ""
    opcaounidade = ""
    opcaocliente = ""
    codigo = ""
    produto = ""
    digitarpreco = ""
    digitarunidade = ""
    cpf = ""    
    print(f"{separador}\nBem vindos ao gerenciamento do mercado Berimbau\n{separador}")
    Menu()

# Menu inicial
def Menu():
    print("Gerenciar estoque, gerenciar clientes ou sair?")
    opcao = input().lower().strip()
    if opcao == "estoque":
        print("\n")
        PerguntarEstoque()
    elif opcao == "clientes":
        print("\n")
        PerguntarCliente()
    elif opcao == "sair":
        print(separador)
        LimparTela()
        exit()
    else:
        print("Entrada incorreta, favor reinserir.\n")
        Menu()

# Perguntar se deseja repor estoque de um produto, ou cadastrar um novo
def PerguntarEstoque():
    print("Cadastrar produto ou repor estoque?")
    opcaoestoque = input().lower().strip()
    if opcaoestoque == "cadastrar":
        print("\n")
        CodigoProduto()
    elif opcaoestoque == "repor":
        print("\n")
        ReporProduto()
    else:
        print("Opção incorreta, de volta ao menu inicial.\n")
        Menu()

# Cadastrar produto no estoque
def CodigoProduto():
    print("Código do produto")
    codigo = input()
    validarcodigo = len(codigo) == 5 and codigo.isdigit()
    if not validarcodigo:
        print("Código do produto com menos ou mais de cinco digitos, em branco ou com caracteres, favor reinserir.\n")
        CodigoProduto()
    else:
        print("\n")
        estoque.Codigo += codigo
        NomeProduto()

def NomeProduto():
    print("Nome do produto")
    produto = input()
    if produto.isspace() or len(produto) < 2:
        print("Nome do produto em branco ou com menos de dois caracteres, favor reinserir.\n")
        NomeProduto()
    else:
        print("\n")
        estoque.Produto += produto
        PrecoProduto()

def PrecoProduto():
    print("Preço do produto")
    digitarpreco = input()
    if digitarpreco.isspace() or digitarpreco.isalpha() or digitarpreco == "0":
        print("Preço do produto em branco ou com caracteres, favor reinserir.\n")
        PrecoProduto()
    else:
        print("\n")
        estoque.Preco += float(digitarpreco)
        PerguntarUnidadeProduto()

def PerguntarUnidadeProduto():
    print("Possui estoque?")
    opcaounidade = input().lower().strip()
    if opcaounidade == "sim":
        print("\n")
        InserirUnidadeProduto()
    else:
        estoque.DadosProduto()
        RecomecarEstoque()

def InserirUnidadeProduto():
    print("Unidades do produto")
    digitarunidade = input()
    validarunidade = digitarunidade.isspace() or digitarunidade.isdigit()
    if not validarunidade:
        print("Unidades do produto em branco ou com caracteres, favor reinserir.\n")
        InserirUnidadeProduto()
    else:
        estoque.Unidade += int(digitarunidade)
        estoque.DadosProduto()
        RecomecarEstoque()

# Reposição do produto
def ReporProduto():
    print("Unidades do produto")
    digitarunidade = input()
    validarunidade = digitarunidade.isspace() or digitarunidade.isdigit()
    if not validarunidade:
        print("Unidades do produto em branco ou com caracteres, favor reinserir.\n")
        ReporProduto()
    else:
        estoque.Unidade += int(digitarunidade)
        estoque.DadosProduto()
        RecomecarEstoque()

# Perguntar se deseja recomeçar todo o processo de gerenciamento de estoque
def RecomecarEstoque():
    print("Recomeçar?")
    opcaounidade = input().lower().strip()
    if opcaounidade == "sim":
        print("\n")
        PerguntarEstoque()
    else:
        print("\n")
        Menu()

# Perguntar se deseja alterar os dados de um cliente, ou cadastrar um novo
def PerguntarCliente():
    print("Cadastrar ou alterar dados de cliente?")
    opcaocliente = input().lower().strip()
    if opcaocliente == "cadastrar":
        print("\n")
        NomeCliente()
    elif opcaocliente == "alterar":
        print("\n")
        AlterarCliente()
    else:
        print("Opção incorreta, de volta ao menu inicial.\n")
        Menu()

# Inserir dados do cliente
def NomeCliente():
    print("Nome do cliente")
    cliente.Nome = input()
    if cliente.Nome.isspace() or len(cliente.Nome) < 3:
        print("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.\n")
        NomeCliente()
    else:
        print("\n")
        CPFCliente()

def CPFCliente():
    print("CPF do cliente")
    cpf = input()
    validarcpf = len(cpf) == 11 and cpf.isdigit()
    if not validarcpf:
        print("CPF do cliente com menos ou mais de onze digitos, em branco ou com caracteres, favor reinserir.\n")
        CPFCliente()
    else:
        cliente.DadosCliente()
        RecomecarCliente()

# Alterar dados do cliente
def AlterarCliente():
    print("Alterar nome do cliente")
    cliente.Nome = input()
    if cliente.Nome.isspace() or len(cliente.Nome) < 3:
        print("Nome do cliente em branco ou com menos de três caracteres, favor reinserir.\n")
        NomeCliente()
    else:
        cliente.DadosCliente()
        RecomecarCliente()

# Perguntar se deseja recomeçar todo o processo de gerenciamento de clientes
def RecomecarCliente():
    print("Recomeçar?")
    opcaocliente = input().lower().strip()
    if opcaocliente == "sim":
        print("\n")
        PerguntarCliente()
    else:
        print("\n")
        Menu()

# Função para limpar a tela
def LimparTela():
    input()
    print("\n" * 100)