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
        [HttpPost("add")]
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
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"The id {id} cannot be found ");
        }
        [HttpPatch("update/{id}")]
        public IActionResult Update(ContentCreatorModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.WorkEmail = String.IsNullOrEmpty(model.WorkEmail) ? result.WorkEmail : model.WorkEmail;
                result.Department = String.IsNullOrEmpty(model.Department) ? result.Department : model.Department;
                result.DateModified = DateTime.Now;
                result.Role = string.IsNullOrEmpty(model.Role) ? result.Role : model.Role;
                _repository.Update(result);
                return Ok(result);


            }
            return NotFound($"The id {id} cannot be found ");
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                _repository.Delete(id);
                return Ok($"Content Creator with id {id} cannot be found");
            }
            return NotFound($"The id {id} cannot be found ");
        }
    }
}
