using CollectionManager.Models.dto;
using CollectionManager.Models.entity;
using Nest;
using System;
using System.Web.Http;

namespace CollectionManager.Controllers
{
    public class CollectionController : ApiController
    {
        //Create an ElasticClient with the following settings
        private ElasticClient NestClient()
        {
            var node = new Uri("http://locahost:9200/");
            var settings = new ConnectionSettings(node).DefaultIndex("collection-manager-index");
            var client = new ElasticClient(settings);
            return client;
        }

        // GET: api/Collection
        public IHttpActionResult Get()
        {
            //Data initialization
            CollectionDTO.Start(true);

            //Nest
            NestClient().Index("Http_Get");
            NestClient().Index(CollectionDTO.Collections);
            return Ok(CollectionDTO.Collections);
        }

        // POST: api/Collection
        public IHttpActionResult Post([FromBody]Collection collection)
        {
            bool isInsert = collection.CdCollection < 1;

            // Nest
            NestClient().Index(new Object[]{ "Http.Post." +  (isInsert ? "Insert" : "Update"), collection});

            bool _resultRN001 = isInsert ?  
                                CollectionDTO.InsertCollection(collection) :
                                    CollectionDTO.UpdateCollection(collection);
            String message = _resultRN001 ?
                "Coleção " + (isInsert ? " inserida" : " atualizada") + " com sucesso." :
                    "Esta coleção já existe nessa localização.";

            Object[] output = new Object[] { _resultRN001, message };

            // Nest
            NestClient().Index(output);
            return Ok(output );
        }

        // DELETE: api/Collection/5
        [Route("api/Collection/{cdCollection}")]
        public IHttpActionResult Delete(int cdCollection)
        {
            // Nest
            NestClient().Index(new String[] { "Http_Delete.", "cdCollection=" + cdCollection });

            bool IsDeleted = CollectionDTO.DeleteCollection((int) cdCollection);

            String message = IsDeleted ?
                    "Coleção excluída com sucesso." :
                        "Não foi possível excluir a coleção.";

            Object [] output = new Object[] { IsDeleted, message };

            // Nest
            NestClient().Index(output);
            return Ok(output);
        }
    }
}
