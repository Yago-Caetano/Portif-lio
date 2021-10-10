using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class TagsProjetoDAO : PadraoDAO<TagsProjectModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(TagsProjectModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[2];
            parametros[0] = new MySqlParameter("_idProjeto", model.idProjeto);
            parametros[1] = new MySqlParameter("_idTag", model.idTag);

            return parametros;
        }

        protected override TagsProjectModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            TagsProjectModel Model = new TagsProjectModel();
            Model.idProjeto= registro["idProjeto"].ToString();
            Model.idTag = registro["idTag"].ToString();
            
            return Model;
        }

        protected override void SetTabela()
        {
             Tabela = "tbTagsProjeto";
        }

         public List<TagsProjectModel> RecuperarTagsPorProjeto(string idProjeto)
        {
             var p = new MySqlParameter[]
            {
                new MySqlParameter("_idProjeto", idProjeto)
            };
            
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta_tbTagsProjeto", p);
            List<TagsProjectModel> lista = new List<TagsProjectModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }

        
        public void RemoverTagsPeloProjeto(string idProjeto)
        {
            var p = new MySqlParameter[]
            {
                 new MySqlParameter("_idProjeto",idProjeto),
            };
            HelperDAO.ExecutaProc("spDelete_tbTagsProjeto", p);
        
        }

    }

}