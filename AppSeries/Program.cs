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
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por usar nosso sistema.");
            System.Console.WriteLine("Programa Finalizado!");
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
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",serie.retornaId(),serie.retornaTitulo(),(excluido ? "*Excluido*" : "" ));
            }


        }

        private static Serie cadastrarSerie(int id)
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

            Serie novaserie = new Serie(id: id,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    descricao: entradaDescricao,
                                    Ano: entradaAno);
            return novaserie;
                                     
        }

        private static void InserirSeries ()
        {
            System.Console.WriteLine("Inserir nova serie");
            var novaserie = cadastrarSerie(repositorio.ProximoId());
            repositorio.Insere(novaserie);

        }
        private  static void ExcluirSeries ()
        {
            Console.WriteLine("Digite o id da serie que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
                        
            repositorio.Exclui(id);
            var serie = repositorio.RetornaPorId(id);
            System.Console.WriteLine($"Você excluiu a serie: {serie} ");

        }

        private  static void AtualizarSeries ()
        {

            Console.WriteLine("Digite o id da serie que deseja atualizar: ");
            
            int id = int.Parse(Console.ReadLine());
            var atualizaSerie = cadastrarSerie(id);
            
            repositorio.Atualiza(id, atualizaSerie);
            System.Console.WriteLine($"Você atualizou a serie: {atualizaSerie} ");

        }
         private static void VisualizarSeries ()
        {
            Console.WriteLine("Digite o id da serie que deseja visualizar: ");
            int id = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(id);
            if (serie != null)    
            {
                System.Console.WriteLine(serie);
            }
            else{
                System.Console.WriteLine("O id não possui serie cadastrada, tente novamente");
                VisualizarSeries();
            }
            

            

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


