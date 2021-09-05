using System.Data;
using MySqlConnector;
using Portifolio_backend.Models;

namespace Portifolio_backend.DAO
{
    public class FotoDAO : PadraoDAO<FotoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(FotoModel model)
        {
            throw new System.NotImplementedException();
        }

        protected override FotoModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            throw new System.NotImplementedException();
        }

        protected override void SetTabela()
        {
            throw new System.NotImplementedException();
        }


    }

}