using Microsoft.AspNetCore.Mvc;
using SG.Data.Entities;
using SG.Repo;

namespace SG.Web.Controllers
{

    [ApiController]
    [Route("uploads")]
    public class UploadController : ControllerBase
    {
        private readonly IRepository<UploadModel> _repository;

        public UploadController(IRepository<UploadModel> repository)
        {
            this._repository = repository;
        }
        [HttpPost("add-uploads")]
        public IActionResult AddLearningMaterial(UploadModel model)
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
        public IActionResult Update(UploadModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.Summary = String.IsNullOrEmpty(model.Summary) ? result.Summary : model.Summary;
                result.DateModified = DateTime.Now;
                result.Department = String.IsNullOrEmpty(model.Department) ? result.Department : model.Department;

                result.Duration = String.IsNullOrEmpty(model.Duration.ToString()) ? result.Duration : model.Duration;
                result.ContentCreatorId = String.IsNullOrEmpty(model.ContentCreatorId.ToString()) ? result.ContentCreatorId : model.ContentCreatorId;
                result.Content = String.IsNullOrEmpty(model.Content) ? result.Content : model.Content;
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
