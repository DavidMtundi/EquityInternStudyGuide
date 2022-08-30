using Microsoft.AspNetCore.Mvc;
using SG.Data.Entities;
using SG.Data.Entities.SG.Data.Entities;
using SG.Repo;

namespace SG.Web.Controllers
{

    [ApiController]
    [Route("uploads")]
    public class UploadController : ControllerBase
    {
        private readonly IRepository<UploadModel> _repository;
        private readonly IRepository<ContentCreatorModel> _repository1;

        public UploadController(IRepository<UploadModel> repository, IRepository<ContentCreatorModel> repository1)
        {
            this._repository = repository;
            this._repository1 = repository1;
        }
        [HttpPost("add")]
        public IActionResult AddUpload(UploadModel model)
        {
            ContentCreatorModel result = _repository1.GetById(model.ContentCreatorId);
            if (result == null) return BadRequest();
            model.ContentCreatorName = result.WorkEmail!.Remove(result.WorkEmail.Length - 17);
            model.ContentCreatorName.Replace(".", " ");
            _repository.Add(model);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + model.Id, model);
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
        [HttpGet("get-list-from-specific-deparment/{deparmentname}")]
        public IActionResult GetFromDepartment(String deparmentname)
        {
            String deparment = deparmentname.ToUpper();
            var result = _repository.GetAll().ToList().Where(value => value.Department.ToUpper() == deparment);
            return Ok(result);

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
                result.ContentCreatorId = model.ContentCreatorId == Guid.Empty ? result.ContentCreatorId : model.ContentCreatorId;
                result.Content = (model.Content!.Count < 1) ? result.Content : model.Content;
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
