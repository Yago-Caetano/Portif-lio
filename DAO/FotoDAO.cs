using System.Data;
using System;
using MySqlConnector;
using Portifolio_backend.Models;
using System.Collections.Generic;

namespace Portifolio_backend.DAO
{
    public class FotoDAO : PadraoDAO<FotoModel>{ 

    public string Nome {get;set;}

        protected override MySqlParameter[] CriaParametros(FotoModel model)
        {
            MySqlParameter[] parametros = new MySqlParameter[3];

            parametros[0] = new MySqlParameter("_id", model.id);
            parametros[1] = new MySqlParameter("_Foto", model.Foto);
            parametros[2] = new MySqlParameter("_idProjeto", model.IdProjeto);


    
            return parametros;
        }

        protected override FotoModel MontaModel(DataRow registro, bool Simplificado = false)
        {
            FotoModel Model = new FotoModel();
            Model.id= registro["id"].ToString();
            Model.Foto = (byte[]) registro["arquivo_img"];

            return Model;
        }

        protected override void SetTabela()
        {
            Tabela = "tbfoto";
        }

        public List<FotoModel> RecuperarFotoPorProjeto(string idProjeto)
        {
             var p = new MySqlParameter[]
            {
                new MySqlParameter("_idProjeto", idProjeto)
            };
            
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta_tbFotoProjeto", p);
            List<FotoModel> lista = new List<FotoModel>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }

        public void RemoverFotosPeloProjeto(string idProjeto)
        {
            var p = new MySqlParameter[]
            {
                 new MySqlParameter("_idProjeto",idProjeto),
            };
            HelperDAO.ExecutaProc("spDelete_tbFotoProjeto", p);
        
        }

    }

}