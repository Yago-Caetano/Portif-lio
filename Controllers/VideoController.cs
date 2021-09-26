using Portifolio_backend.Models;
using Portifolio_backend.DAO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portifolio_backend.Controllers{

            public class VideoController : PadraoController<VideoModel>
            {
                public VideoController(){DAO = new VideoDAO();}

            public override async Task<IActionResult> Save(VideoModel model,bool checkIdBeforeInsertion = true)
            {
                return base.Save(model,checkIdBeforeInsertion).Result;
            }
            
            }

}