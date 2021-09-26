using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class TagDAO : PadraoDAO<TagModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(TagModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[2];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_Nome", model.Nome);

            return parametros;
        }

        protected override TagModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            TagModel Model = new TagModel();
            Model.id= registro["id"].ToString();
            Model.Nome = registro["Nome"].ToString();
            
            return Model;
        }

        protected override void SetTabela()
        {
            Tabela = "tbTags";
        }


    }

}