using Microsoft.AspNetCore.Mvc;
using Entities;
using Services.Course;
using Services.Course.DTO;


namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;

        #region CREATE
        [HttpPost]
        public async Task<ActionResult<CourseEntity>> Create(CreateCourseDTO course)
        {
            try
            {
                CourseEntity courseData = await _courseService.Create(course);

                return Ok(courseData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<CourseEntity>> Update(UpdateCourseDTO course)
        {
            try
            {
                CourseEntity courseData = await _courseService.Update(course);

                return Ok(courseData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region FIND 
        [HttpGet]
        public async Task<ActionResult<List<CourseEntity>>> FindAll()
        {
            try
            {
                List<CourseEntity> courses = await _courseService.FindAll();

                return Ok(courses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CourseEntity>>> FindOne(int id)
        {
            try
            {
                CourseEntity course = await _courseService.FindOne(id);

                return Ok(course);
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
                await _courseService.Delete(id);

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
