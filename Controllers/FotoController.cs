using Portifolio_backend.Models;
using Portifolio_backend.DAO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portifolio_backend.Controllers{

            public class FotoController : PadraoController<FotoModel>
            {
                public FotoController(){DAO = new FotoDAO();}

            public override async Task<IActionResult> Save(FotoModel model)
            {
                return base.Save(model).Result;
            }
            
            public async Task<IActionResult> getPhotosbyProject(string idProject)
            {
                var data = new FotoDAO().RecuperarFotoPorProjeto(idProject);
                return Ok(data);
            }



}