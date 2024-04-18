using Microsoft.AspNetCore.Mvc;
using Entities;
using Services.Class;
using Services.Class.DTO;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(IClassService classService) : ControllerBase
    {
        private readonly IClassService _classService = classService;

        #region CREATE
        [HttpPost]
        public async Task<ActionResult<ClassEntity>> Create(CreateClassDTO classData)
        {
            try
            {
                ClassEntity createdClass = await _classService.Create(classData);

                return Ok(createdClass);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<CourseEntity>> Update(UpdateClassDTO classData)
        {
            try
            {
                await _classService.Update(classData);

                return Ok(classData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region FIND 

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassEntity>> FindOne(int id)
        {
            try
            {
                ClassEntity classData = await _classService.FindOne(id);

                return Ok(classData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _classService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

    }
}
