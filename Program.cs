using SistemaMarmoreGranito;

namespace SistemaMarmoreGranito
{
    class Program
    {
        static void Main()
        {
            Database.Initialize();
            Console.WriteLine("Sistema de Mármore & Granito iniciado.");

            bool autenticado = false;

            do
            {
                autenticado = MenuInicial();
            } while (!autenticado);

            MenuPrincipal();
        }

        static bool MenuInicial()
        {
            Console.WriteLine("\n=== MENU INICIAL ===");
            Console.WriteLine("1. Cadastrar Usuário");
            Console.WriteLine("2. Fazer Login");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    CadastrarUsuario();
                    return true;
                case "2":
                    bool autenticado = Login();
                    if (autenticado)
                    {
                        Console.WriteLine("Login realizado com sucesso!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Login ou senha incorretos.");
                        return false;
                    }
                case "0":
                    Console.WriteLine("Encerrando o sistema...");
                    Environment.Exit(0);
                    return false;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    return false;
            }
        }

        static void MenuPrincipal()
        {
            int opcao;

            do
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Cadastrar Usuário");
                Console.WriteLine("2. Cadastrar Bloco");
                Console.WriteLine("3. Cadastrar Chapa");
                Console.WriteLine("4. Realizar Serragem (transformar bloco em chapas)");
                Console.WriteLine("5. Listar Blocos");
                Console.WriteLine("6. Listar Chapas");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                string input = Console.ReadLine();
                Console.Clear();

                if (!int.TryParse(input, out opcao))
                {
                    Console.WriteLine("Opção inválida! Digite um número.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarUsuario();
                        break;
                    case 2:
                        CadastrarBloco();
                        break;
                    case 3:
                        CadastrarChapa();
                        break;
                    case 4:
                        RealizarSerragem();
                        break;
                    case 5:
                        ListarBlocos();
                        break;
                    case 6:
                        ListarChapas();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != 0);
        }

        static void CadastrarUsuario()
        {
            Console.WriteLine("=== Cadastro de Usuário ===");

            Console.Write("Nome completo: ");
            string nomeCompleto = Console.ReadLine();

            Console.Write("Login: ");
            string loginUsuario = Console.ReadLine();

            Console.Write("Senha: ");
            string senhaUsuario = Console.ReadLine();

            using var conexao = Database.GetConnection();
            conexao.Open();


            var comandoVerificacao = conexao.CreateCommand();
            comandoVerificacao.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Login = $login";
            comandoVerificacao.Parameters.AddWithValue("$login", loginUsuario);

            long existe = (long)comandoVerificacao.ExecuteScalar();

            if (existe > 0)
            {
                Console.WriteLine("Erro: Este login já está em uso.");
                return;
            }

            var comandoInsercao = conexao.CreateCommand();
            comandoInsercao.CommandText = @"
                INSERT INTO Usuarios (Nome, Login, Senha)
                VALUES ($nome, $login, $senha);
            ";
            comandoInsercao.Parameters.AddWithValue("$nome", nomeCompleto);
            comandoInsercao.Parameters.AddWithValue("$login", loginUsuario);
            comandoInsercao.Parameters.AddWithValue("$senha", senhaUsuario);

            int resultado = comandoInsercao.ExecuteNonQuery();

            if (resultado > 0)
            {
                Console.WriteLine("Usuário cadastrado com sucesso!");
                MenuPrincipal();

            }
            else
            {
                Console.WriteLine("Erro ao cadastrar o usuário.");
            }
        }

        static void CadastrarBloco()
        {
            Console.WriteLine("=== Cadastro de Bloco ===");

            Console.Write("Código bloco: ");
            string codigoBloco = Console.ReadLine();

            Console.Write("Pedreira de origem: ");
            string pedreiraOrigem = Console.ReadLine();

            Console.Write("Metragem do bloco (em m³): ");
            string metragem = Console.ReadLine();

            Console.Write("Tipo do material: ");
            string tipoMaterial = Console.ReadLine();

            Console.Write("Valor de compra: ");
            string valorCompra = Console.ReadLine();

            Console.Write("Número da nota fiscal: ");
            string notaFiscal = Console.ReadLine();

            using var conexao = Database.GetConnection();
            conexao.Open();

            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Blocos (Codigo, PedreiraOrigem, Metragem, TipoMaterial, ValorCompra, NotaFiscalEntrada)
                VALUES ($codigo, $origem, $metragem, $tipo, $valor, $nota);
            ";

            comando.Parameters.AddWithValue("$codigo", codigoBloco);
            comando.Parameters.AddWithValue("$origem", pedreiraOrigem);
            comando.Parameters.AddWithValue("$metragem", metragem);
            comando.Parameters.AddWithValue("$tipo", tipoMaterial);
            comando.Parameters.AddWithValue("$valor", valorCompra);
            comando.Parameters.AddWithValue("$nota", notaFiscal);

            int resultado = comando.ExecuteNonQuery();

            if (resultado > 0)
            {
                Console.WriteLine("Bloco cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar o bloco.");
            }
        }

        static void CadastrarChapa()
        {
            Console.WriteLine("=== Cadastro de Chapa ===");

            Console.Write("Código do bloco de origem: ");
            string blocoCodigo = Console.ReadLine();

            Console.Write("Tipo do material: ");
            string tipoMaterial = Console.ReadLine();

            Console.Write("Comprimento (em metros): ");
            if (!double.TryParse(Console.ReadLine(), out double comprimento))
            {
                Console.WriteLine("Valor inválido para comprimento.");
                return;
            }

            Console.Write("Largura (em metros): ");
            if (!double.TryParse(Console.ReadLine(), out double largura))
            {
                Console.WriteLine("Valor inválido para largura.");
                return;
            }

            Console.Write("Valor: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                Console.WriteLine("Valor inválido para valor.");
                return;
            }

            using var conexao = Database.GetConnection();
            conexao.Open();


            var comandoVerificaBloco = conexao.CreateCommand();
            comandoVerificaBloco.CommandText = "SELECT COUNT(*) FROM Blocos WHERE Codigo = $codigo";
            comandoVerificaBloco.Parameters.AddWithValue("$codigo", blocoCodigo);

            long existe = (long)comandoVerificaBloco.ExecuteScalar();

            if (existe == 0)
            {
                Console.WriteLine("Bloco não encontrado. Cadastre o bloco antes de cadastrar a chapa.");
                return;
            }

            var comandoInsercao = conexao.CreateCommand();
            comandoInsercao.CommandText = @"
                INSERT INTO Chapas (BlocoCodigo, TipoMaterial, Comprimento, Largura, Valor)
                VALUES ($blocoCodigo, $tipoMaterial, $comprimento, $largura, $valor);
            ";

            comandoInsercao.Parameters.AddWithValue("$blocoCodigo", blocoCodigo);
            comandoInsercao.Parameters.AddWithValue("$tipoMaterial", tipoMaterial);
            comandoInsercao.Parameters.AddWithValue("$comprimento", comprimento);
            comandoInsercao.Parameters.AddWithValue("$largura", largura);
            comandoInsercao.Parameters.AddWithValue("$valor", valor);

            int resultado = comandoInsercao.ExecuteNonQuery();

            if (resultado > 0)
                Console.WriteLine("Chapa cadastrada com sucesso!");
            else
                Console.WriteLine("Erro ao cadastrar a chapa.");
        }

        static void RealizarSerragem()
        {
            Console.Write("Digite o código do bloco a ser serrado: ");
            string codigoBloco = Console.ReadLine();

            using var conexao = Database.GetConnection();
            conexao.Open();

            var comandoBuscaBloco = conexao.CreateCommand();
            comandoBuscaBloco.CommandText = "SELECT Metragem, TipoMaterial FROM Blocos WHERE Codigo = $codigo";
            comandoBuscaBloco.Parameters.AddWithValue("$codigo", codigoBloco);

            using var reader = comandoBuscaBloco.ExecuteReader();

            if (!reader.Read())
            {
                Console.WriteLine("Bloco não encontrado.");
                return;
            }

            double metragem = Convert.ToDouble(reader["Metragem"]);     
            string tipoMaterial = reader["TipoMaterial"].ToString();

            reader.Close();

            Console.Write("Quantas chapas serão produzidas a partir desse bloco? ");
            if (!int.TryParse(Console.ReadLine(), out int quantidadeChapas) || quantidadeChapas <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                return;
            }

            for (int i = 0; i < quantidadeChapas; i++)
            {
                Console.WriteLine($"\nCadastro da chapa {i + 1}:");

                Console.Write("Comprimento (m): ");
                if (!double.TryParse(Console.ReadLine(), out double comprimentoChapa))
                {
                    Console.WriteLine("Valor inválido para comprimento.");
                    return;
                }

                Console.Write("Valor da chapa: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valorChapa))
                {
                    Console.WriteLine("Valor inválido para valor.");
                    return;
                }


                var comandoInsereChapa = conexao.CreateCommand();
                comandoInsereChapa.CommandText = @"
            INSERT INTO Chapas (BlocoCodigo, TipoMaterial, Comprimento, Largura, Valor)
            VALUES ($blocoCodigo, $tipoMaterial, $comprimento, $largura, $valor);
        ";
                comandoInsereChapa.Parameters.AddWithValue("$blocoCodigo", codigoBloco);
                comandoInsereChapa.Parameters.AddWithValue("$tipoMaterial", tipoMaterial);;
                comandoInsereChapa.Parameters.AddWithValue("$valor", valorChapa);

                comandoInsereChapa.ExecuteNonQuery();
            }

            var comandoAtualizaBloco = conexao.CreateCommand();
            comandoAtualizaBloco.CommandText = "UPDATE Blocos SET Serrado = 1 WHERE Codigo = $codigo";
            comandoAtualizaBloco.Parameters.AddWithValue("$codigo", codigoBloco);
            comandoAtualizaBloco.ExecuteNonQuery();

            Console.WriteLine("Serragem realizada com sucesso!");
        }


        static void ListarBlocos()
        {
            Console.WriteLine("=== Lista de Blocos ===");

            using var conexao = Database.GetConnection();
            conexao.Open();

            var comando = conexao.CreateCommand();
            comando.CommandText = "SELECT Codigo, PedreiraOrigem, Metragem, TipoMaterial, ValorCompra, NotaFiscalEntrada FROM Blocos";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Código: {reader["Codigo"]}, Origem: {reader["PedreiraOrigem"]}, Metragem: {reader["Metragem"]}m³, Material: {reader["TipoMaterial"]}, Valor: R${reader["ValorCompra"]}, Nota Fiscal: {reader["NotaFiscalEntrada"]}");
            }
        }

        static void ListarChapas()
        {
            Console.WriteLine("=== Lista de Chapas ===");

            using var conexao = Database.GetConnection();
            conexao.Open();

            var comando = conexao.CreateCommand();
            comando.CommandText = "SELECT Id, BlocoCodigo, TipoMaterial, Comprimento, Largura, Valor FROM Chapas";

            using var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Bloco: {reader["BlocoCodigo"]}, Material: {reader["TipoMaterial"]}, Comprimento: {reader["Comprimento"]}m, Largura: {reader["Largura"]}m, Valor: R${reader["Valor"]}");
            }
        }

        static bool Login()
        {
            Console.WriteLine("=== Login ===");

            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            using var conexao = Database.GetConnection();
            conexao.Open();

            var comando = conexao.CreateCommand();
            comando.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Login = $login AND Senha = $senha";
            comando.Parameters.AddWithValue("$login", login);
            comando.Parameters.AddWithValue("$senha", senha);

            long count = (long)comando.ExecuteScalar();

            return count > 0;
        }
    }
}