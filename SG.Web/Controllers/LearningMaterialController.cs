using Microsoft.AspNetCore.Mvc;
using SG.Data.Entities;
using SG.Repo;

namespace SG.Web.Controllers
{

    [ApiController]
    [Route("learning-material")]
    public class LearningMaterialController : ControllerBase
    {
        private readonly IRepository<LearningMaterialModel> _repository;

        public LearningMaterialController(IRepository<LearningMaterialModel> repository)
        {
            this._repository = repository;
        }
        [HttpPost("add-learning-material")]
        public IActionResult AddLearningMaterial(LearningMaterialModel model)
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
        public IActionResult Update(LearningMaterialModel model, Guid id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                result.WorkEmail = String.IsNullOrEmpty(model.WorkEmail) ? result.WorkEmail : model.WorkEmail;
                result.DateModified = DateTime.Now;

                result.InternId = String.IsNullOrEmpty(model.InternId.ToString()) ? result.InternId : model.InternId;
                result.IsChecked = model.IsChecked;
                result.UploadModelId = String.IsNullOrEmpty(model.UploadModelId.ToString()) ? result.UploadModelId : model.UploadModelId;
                _repository.Update(result);
                return Ok(result);

            }

            // _repository.Update(model);
            return NotFound($"The id {id} cannot be found ");
        }
        [HttpDelete("delete")]
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
