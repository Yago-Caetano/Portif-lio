using Portifolio_backend.Models;
using System.Collections.Generic;

namespace Portifolio_backend.Models
{
    public class ProjetoModel : PadraoViewModel{ 

    public string Nome {get;set;} 

    public string Descricao {get;set;} 

    public string idTag {get;set;}

    public List<FotoModel> Fotos {get;set;}

    public List<VideoModel> Videos {get;set;}

    
    }

}