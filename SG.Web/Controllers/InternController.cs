using Microsoft.AspNetCore.Mvc;
using SG.Data.Entities;
using SG.Repo;

namespace SG.Web.Controllers
{

    [ApiController]
    [Route("intern")]
    public class InternController : ControllerBase
    {
        private readonly IRepository<InternModel> _repository;

        public InternController(IRepository<InternModel> repository)
        {
            this._repository = repository;
        }
        [HttpPost("add-intern")]
        public IActionResult AddLearningMaterial(InternModel model)
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
            return NotFound("Not Found");
        }
        [HttpPatch("update/{id}")]
        public IActionResult Update(InternModel model, Guid id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound("The Id is not found");
            }

            _repository.Update(model);
            return Ok(model);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound("The Id is not found");

            }
            _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}
