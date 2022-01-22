using System.Collections;
using AppSeries.Interface;

namespace AppSeries.Classes
{
    public class SerieRepositorio : Irepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
           public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id]= entidade;
            
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
            
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if (listaSerie.Count()>id){

                return listaSerie [id];
            }
            else
            {
                return null; 
            }
           
            
        }
    }
}