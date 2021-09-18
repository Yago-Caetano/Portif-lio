using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class ProjetoDAO : PadraoDAO<ProjetoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(ProjetoModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[4];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_Nome", model.Nome);
            parametros[2] = new MySqlParameter("_Descricao", model.Descricao);
            parametros[3] = new MySqlParameter("_idTag",model.idTag);

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

    }

}