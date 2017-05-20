using CollectionManager.ElasticSearch;
using CollectionManager.Models;
using CollectionManager.Models.entity;
using System;
using System.Web.Http;

namespace CollectionManager.Controllers
{
    public class CollectionController : ApiController
    {
        private CollectionService service = new CollectionService();

        // GET: api/Collection
        public IHttpActionResult Get()
        {
            return Ok(service.FindAllCollections());
        }

        // POST: api/Collection
        public IHttpActionResult Post([FromBody]Collection collection)
        {
            bool _resultRN001 = service.InsertCollection(collection);
            String message = _resultRN001 ?
                "Coleção inserida com sucesso." :
                    "Esta coleção já existe nessa localização.";
            Object[] output = new Object[] { _resultRN001, message };
            return Ok(output);
        }

        // PUT: api/Collection
        public IHttpActionResult Put(Collection collection)
        {
            bool _resultRN001 = service.UpdateCollection(collection);
            String message = _resultRN001 ?
                "Coleção atualizada com sucesso." :
                    "Esta coleção já existe nessa localização.";
            Object[] output = new Object[] { _resultRN001, message };
            return Ok(output);
        }

        // DELETE: api/Collection/5
        [Route("api/Collection/{cdCollection}")]
        public IHttpActionResult Delete(int cdCollection)
        {
            bool IsDeleted = service.DeleteCollection(cdCollection);
            String message = IsDeleted ?
                    "Coleção excluída com sucesso." :
                        "Não foi possível excluir a coleção.";
            Object [] output = new Object[] { IsDeleted, message };
            return Ok(output);
        }
    }
}
