using EduzcaServer.Models;
using Microsoft.AspNetCore.Mvc;
using EduzcaServer.Services.Course;
using EduzcaServer.Services.Course.DTO;


namespace EduzcaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService) : ControllerBase
    {
        private readonly ICourseService _courseService = courseService;

        #region CREATE
        [HttpPost]
        public async Task<ActionResult<CourseEntity>> Create(CreateCourseDTO course)
        {
          CourseEntity courseData = await _courseService.Create(course);
            
          return Ok(courseData);
        }
        #endregion

        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<CourseEntity>> Update(UpdateCourseDTO course)
        {
            await _courseService.Update(course);

            return Ok(course);
        }
        #endregion

        #region FIND 
        [HttpGet]
        public async Task<ActionResult<List<CourseEntity>>> FindAll()
        {
            List<CourseEntity> courses = await _courseService.FindAll();

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CourseEntity>>> FindOne(int id)
        {
            CourseEntity course = await _courseService.FindOne(id);

            return Ok(course);
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CourseEntity>>> Delete(int id)
        {
             await _courseService.Delete(id);

            return Ok();
        }
        #endregion
    }
}
