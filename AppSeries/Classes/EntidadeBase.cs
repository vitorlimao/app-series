namespace AppSeries
{
    public abstract class EntidadesBases
    {
        public int id { get; protected set; }
        public string titulo { get; set; }

        public string genero { get; set; }
        public int Ano { get; set; }

    }
}