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
        [HttpPost("add")]
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
        [HttpGet("check-if-email-exists/{email}")]
        public bool CheckIfEmailExists(String email)
        {
            String mail = email.ToUpper();
            var result = _repository.GetAll();
            var value = result.ToList().Find(value => value.WorkEmail!.ToUpper() == mail);
            return value != null ? true : false;

            //  return value != null ? Ok(value) : NotFound($"The id {email} cannot be found ");

        }
        [HttpGet("get-intern-details-from-email/{email}")]
        public IActionResult GetInternDetailsFromMail(String email)
        {
            String mail = email.ToUpper();
            var result = _repository.GetAll();
            var value = result.ToList().Find(value => value.WorkEmail!.ToUpper() == mail);
            return value != null ? Ok(value) : NotFound($"The id {email} cannot be found ");

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
            var result = _repository.GetById(id);
            if (result != null)
            {
                result.WorkEmail = String.IsNullOrEmpty(model.WorkEmail) ? result.WorkEmail : model.WorkEmail;
                result.Department = String.IsNullOrEmpty(model.Department) ? result.Department : model.Department;
                result.DateModified = DateTime.Now;

                // result. = string.IsNullOrEmpty(model.PFNumber) ? result.PFNumber : model.PFNumber;

                result.PFNumber = string.IsNullOrEmpty(model.PFNumber) ? result.PFNumber : model.PFNumber;
                _repository.Update(result);
                return Ok(result);

            }
            return NotFound($"The id {id} cannot be found ");

        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_repository.GetById(id) != null)
            {
                _repository.Delete(id);
                return Ok("Deleted");

            }
            return NotFound($"The id {id} cannot be found ");

        }
    }
}
