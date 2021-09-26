using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class VideoDAO : PadraoDAO<VideoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(VideoModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[3];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_link", model.Link);
            parametros[2] = new MySqlParameter("_idProjeto",model.IdProjeto);

            return parametros;
        }

        protected override VideoModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            VideoModel Model = new VideoModel();
            Model.id= registro["id"].ToString();
            Model.Link = registro["link"].ToString();
            Model.IdProjeto = registro["idProjeto"].ToString();

            return Model;
        }

        protected override void SetTabela()
        {
             Tabela = "tbVideos";
        }

        public List<VideoModel> RecuperarVideoPorProjeto(string idProjeto)
        {
             var p = new MySqlParameter[]
            {
                new MySqlParameter("_idProjeto", idProjeto)
            };
            
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta_tbVideoProjeto", p);
            List<VideoModel> lista = new List<VideoModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }


    }

}