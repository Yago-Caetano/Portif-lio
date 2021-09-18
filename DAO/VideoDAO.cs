using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class VideoDAO : PadraoDAO<VideoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(VideoModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[2];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_link", model.Link);

            return parametros;
        }

        protected override VideoModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            VideoModel Model = new VideoModel();
            Model.id= registro["id"].ToString();
            Model.Link = registro["link"].ToString();
            
            return Model;
        }

        protected override void SetTabela()
        {
             Tabela = "tbVideos";
        }


    }

}