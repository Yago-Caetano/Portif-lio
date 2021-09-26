using MySqlConnector;
using Portifolio_backend.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio_backend.DAO
{
    public enum ChavePrimaria { Serial=1,Inteira=2,ChaveEstrangeiraSerial=3};
    public abstract class PadraoDAO<T> where T : PadraoViewModel
    {

        protected PadraoDAO()
        {
            SetTabela();
        }
        protected string Tabela { get; set; }
        protected string Chave { get; set; } = "id"; // valor default
        protected int TentativasIDMax { get; set; } = 5;
        protected int TamanhoID { get; set; } = 50;
        protected string NomeSpListagem { get; set; } = "spListagem";
        protected string NomeSpConsultaID { get; set; } = "spConsultaID";
        protected abstract MySqlParameter[] CriaParametros(T model);
        protected abstract T MontaModel(DataRow registro,bool Simplificado=false);
        protected abstract void SetTabela();

        public virtual Boolean Insert(T model,bool checkIdBeforeInsertion = true, bool getId = false)
        {

                if (checkIdBeforeInsertion && !ConfirmID(model))
                     return false;

                HelperDAO.ExecutaProc("spInsert_" + Tabela, CriaParametros(model), getId);
                return true;

        }
        
        public virtual void Update(T model)
        {
            HelperDAO.ExecutaProc("spUpdate_" + Tabela, CriaParametros(model));
        }

        public virtual void Delete(object id)
        {
            var model = Consulta(id);
            if (model == null)
                throw new Exception($"Objeto {id.ToString()} não existe!");
   
            var p = new MySqlParameter[]
            {
                 new MySqlParameter("id",id),
                 new MySqlParameter("tabela", Tabela)
            };
            HelperDAO.ExecutaProc("spDelete", p);
        }

        public virtual T Consulta(object id,bool Simplificado=false)
        {
            var p = new MySqlParameter[]
            {
                 new MySqlParameter("id", id),
                 new MySqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spConsulta", p);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0], Simplificado);
        }

        /*public virtual int ProximoId()
        {
            var p = new MySqlParameter[]
            {
                new MySqlParameter("tabela", Tabela)
            };
            var tabela = HelperDAO.ExecutaProcSelect("spProximoId", p);
            return Convert.ToInt32(tabela.Rows[0][0]);
        }*/
        public virtual List<T> Listagem()
        {
            var p = new MySqlParameter[]
            {
                new MySqlParameter("tabela", Tabela),
                new MySqlParameter("Ordem", "1") // 1 é o primeiro campo da tabela,
                                // ou seja, a chave primária
            };
            var tabela = HelperDAO.ExecutaProcSelect(NomeSpListagem, p);
            List<T> lista = new List<T>();
            foreach (DataRow registro in tabela.Rows)
            {
                lista.Add(MontaModel(registro));
            }

            return lista;
        }
       
        private string CreateID()
        {
            byte[] randomByte = new byte[16];

            new Random().NextBytes(randomByte);
            
            Guid mGuid = new Guid(randomByte);

            return mGuid.ToString();
        }
        protected bool ConfirmID(T model)
        {
            int tentativas = 0;
            model.id = CreateID();
            /*var table = HelperDAO.ExecutaProcSelect("spVerificaIDusuario",
                 new MySqlParameter[] { new MySqlParameter("idSerial", model.id) });*/

            while
                (HelperDAO.ExecutaProcSelect(NomeSpConsultaID,
                new MySqlParameter[]
                {   new MySqlParameter("tabela",Tabela),
                    new MySqlParameter("idSerial", model.id) } ).Rows.Count != 0 &&
                tentativas <= TentativasIDMax)
            {
                model.id = CreateID();
                tentativas++;
            }
            if (tentativas > TentativasIDMax)
                return false;
            else
                return true;
        }

        public static implicit operator PadraoDAO<T>(FotoDAO v)
        {
            throw new NotImplementedException();
        }
    }
}
