namespace NotesManager.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using NotesManager.Models;
    using AutoFixture;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/application")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private static IEnumerable<Document> documents = new Fixture().CreateMany<Document>(3);
        public DocumentController()
        {

        }

        [HttpGet]
        [Route("{applicationId}/document")]
        public IActionResult Get()
        {
            return Ok(documents);
        }

        [HttpGet]
        [Route("{applicationId}/document/{documentId}")]
        public IActionResult GetById([FromRoute] string applicationId, [FromRoute] string documentId)
        {
            var doc = documents.FirstOrDefault(_ => _.DocumentId == documentId);
            return Ok(doc);
        }

        [HttpDelete]
        [Route("{applicationId}/document/{documentId}")]
        public IActionResult DeleteById([FromRoute] string applicationId, [FromRoute] string documentId)
        {
            var doc = documents.FirstOrDefault(_ => _.DocumentId == documentId);
            documents.ToList().Remove(doc);
            return NoContent();
        }

        [HttpPost]
        [Route("{applicationId}/document")]
        public IActionResult Create([FromRoute] string applicationId,
        [FromBody] Document document)
        {
            documents.ToList().Add(document);
            return Ok(document);
        }
    }
}