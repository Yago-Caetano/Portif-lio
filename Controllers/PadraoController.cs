using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Portifolio_backend.Models;
using Portifolio_backend.DAO;

namespace Portifolio_backend.Controllers
{
    public class PadraoController<T> : Controller where T : PadraoViewModel
    {

        protected PadraoDAO<T> DAO { get; set; }
        protected string NomeViewIndex { get; set; } = "index";
        protected string NomeViewForm { get; set; } = "form";
        protected bool GeraProximoId { get; set; }


        public virtual IActionResult Create()
        {
            try
            {
                T model = Activator.CreateInstance(typeof(T)) as T;
                return View(NomeViewForm, model);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Data);
            }
        }

        public virtual async Task<IActionResult> Save (T model,bool checkIdBeforeInsertion = true)
        {
            string retornoSucesso = "Cadastrado com sucesso";
            string retornoFalha = "Falha no cadastro";
            try
            {
                //ValidateData(model, Operacao);
                var resultado=DAO.Insert(model,checkIdBeforeInsertion);
                if (resultado == false)
                    throw new Exception("Erro ao cadastrar!");
                return Ok(retornoSucesso);
            }
            catch (Exception erro)
            {
                //return Content(retornoFalha);
                return BadRequest(retornoFalha);
            }
        }

        public virtual async Task<IActionResult> ToRecover(string id = null)
        {
            try
            {
                if (id == null)
                {
                    var modelList = DAO.Listagem();
                    return Ok(JsonSerializer.Serialize(modelList));
                }
                else
                {
                    var model = DAO.Consulta(id);
                    return Ok(JsonSerializer.Serialize(model));
                }
            }
            catch(Exception e)
            {
                return NotFound("Não foi possivel recuperar a informação");
            
            }
        }

        protected virtual void ValidateData(T model, string operacao)
        {
            ModelState.Clear();

            if (operacao == "I" && DAO.Consulta(model.id) != null)
                ModelState.AddModelError("Id", "Código já está em uso!");
            if (operacao == "A" && DAO.Consulta(model.id) == null)
                ModelState.AddModelError("Id", "Este registro não existe!");
        }


        public virtual async Task<IActionResult> Edit(string id,T newModel)
        {
            try
            {
                var model = DAO.Consulta(id);
                if (model == null)
                    return NotFound("Dado não econtrado");
                else
                {
                    newModel.id = id;
                    DAO.Update(newModel);
                    return Ok("Dado editado");
                }
            }
            catch (Exception erro)
            {
                return BadRequest("Não foi possível editar o registro");
            }
        }

        public virtual async Task<IActionResult> Delete(string id)
        {
            try
            {
                DAO.Delete(id);
                return Ok("Dado deletado");
            }
            catch (Exception erro)
            {
                return NotFound("Dado não encontrado.");
                
            }
        }
    }
}
