using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class ProjetoDAO : PadraoDAO<ProjetoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(ProjetoModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[3];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_Nome", model.Nome);
            parametros[2] = new MySqlParameter("_Descricao", model.Descricao);

            return parametros;
        }

        protected override ProjetoModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            ProjetoModel Model = new ProjetoModel();
            Model.id= registro["id"].ToString();
            Model.Nome = registro["Nome"].ToString();
            Model.Descricao = registro["Descricao"].ToString();

            return Model;
        }

        protected override void SetTabela()
        {
            Tabela = "tbProjeto"; 
        }

        public override List<ProjetoModel> Listagem()
        {
            List<ProjetoModel> retLista = base.Listagem();
            foreach(ProjetoModel p in retLista)
            {
                p.Fotos = new FotoDAO().RecuperarFotoPorProjeto((string)p.id);
            }
            return retLista;
        }

        public override ProjetoModel Consulta (object id,bool Simplificado=false)
        {
            ProjetoModel retValue = new ProjetoModel();
            retValue = base.Consulta(id,Simplificado);
            if(retValue != null)
            {
                retValue.Fotos = new FotoDAO().RecuperarFotoPorProjeto((string)retValue.id);

                retValue.Tags = new TagsProjetoDAO().RecuperarTagsPorProjeto((string) retValue.id);

                retValue.Videos = new VideoDAO().RecuperarVideoPorProjeto((string) retValue.id);
            }
            
            return retValue;
        }
        

    }

}