

namespace AppSeries
{
    public class Serie : EntidadesBases
    {
        //atributos

        
        public Genero Genero { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }
        public int ano { get; set; }

        private  bool   Excluido{ get; set; }

        //metodos

        public Serie(int id,Genero genero, string titulo, string descricao, int Ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero" + this.Genero + Environment.NewLine;
            retorno += "Titulo" + this.Titulo + Environment.NewLine;
            retorno += "Descricao" + this.Descricao + Environment.NewLine;
            retorno += "Ano" + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }

    
    
}