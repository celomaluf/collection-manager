using CollectionManager.Models;
using CollectionManager.Models.dto;
using CollectionManager.Models.entity.common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollectionManager.Controllers
{
    public class CollectionController : ApiController
    {
        // GET: api/Collection
        public IHttpActionResult Get()
        {
            CollectionDTO.Start();
            return Ok(CollectionDTO.Collections);
        }

        // POST: api/Collection
        public IHttpActionResult Post([FromBody]Collection collection)
        {
            bool isInsert = collection.CdCollection < 1;
            bool _resultRN001 = isInsert ?  
                                CollectionDTO.InsertCollection(collection) :
                                    CollectionDTO.UpdateCollection(collection);
            String message = _resultRN001 ?
                "Coleção " + (isInsert ? " inserida" : " atualizada") + " com sucesso." :
                    "Esta coleção já existe nessa localização.";
                       
            return Ok(new Object[] { _resultRN001, message });
        }

        // DELETE: api/Collection/5
        public IHttpActionResult Delete([FromBody] int cdCollection)
        {
            bool IsDeleted = CollectionDTO.DeleteCollection(cdCollection);

            String message = IsDeleted ? 
                    "Coleção excluída com sucesso." :
                        "Não foi possível excluir a coleção.";
            return Ok(new Object[] { IsDeleted, message });

        }
    }
}
