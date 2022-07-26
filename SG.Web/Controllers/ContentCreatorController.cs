using Microsoft.AspNetCore.Mvc;
using SG.Data.Entities.SG.Data.Entities;
using SG.Repo;

namespace SG.Web.Controllers
{
    [ApiController]
    [Route("content-creator")]
    public class ContentCreatorController : ControllerBase
    {
        private readonly IRepository<ContentCreatorModel> _repository;

        public ContentCreatorController(IRepository<ContentCreatorModel> repository)
        {
            this._repository = repository;
        }
        [HttpPost("add-creator")]
        public IActionResult AddCreator(ContentCreatorModel model)
        {
            _repository.Add(model);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + model.Id, model);
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Not Found");
        }
        [HttpPatch("update")]
        public IActionResult Update(ContentCreatorModel model)
        {

            _repository.Update(model);
            return Ok(model);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Guid id)
        {
            _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}
