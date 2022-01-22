using AppSeries.Classes;

namespace AppSeries
{
    class Program
    {
        static SerieRepositorio repositorio =  new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            

            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VizualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();



                }
            }
        }
        private static void ListarSeries ()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();


            if (lista.Count ==0 )
            {
                Console.WriteLine("Nenhuma Série Cadastrada");
            }
            
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}",serie.retornaId(),serie.retornaTitulo());
            }


        }

        private static void InserirSeries ()
        {
            foreach (int i in Enum.GetValues(typeof (Genero)))
            {
                Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaserie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    Ano: entradaAno)                            );
            repositorio.Insere(novaserie);

        }
         

        private static string ObterOpcaoUsuario()
        {
                Console.WriteLine();

            Console.WriteLine("Series ao Seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1 - listar series");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}


