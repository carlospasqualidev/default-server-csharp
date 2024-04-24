using Microsoft.AspNetCore.Mvc;
using Services.Course;
using Entities;
using Services.Course.DTO;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseFeedbackController(ICourseFeedbackService courseFeedbackService) : ControllerBase
    {
        private readonly ICourseFeedbackService _courseFeedbackService = courseFeedbackService;

        #region CREATE
        [HttpPost]
        public async Task<ActionResult<CourseFeedbackEntity>> Create(CreateCourseFeedbackDTO feedback)
        {
            try
            {
                CourseFeedbackEntity feedbacKData = await _courseFeedbackService.Create(feedback);

                return Ok(feedbacKData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion


        #region UPDATE
        [HttpPut]
        public async Task<ActionResult<CourseFeedbackEntity>> Update(UpdateCourseFeedbackDTO feedback)
        {
            try
            {
                CourseFeedbackEntity feedbacKData = await _courseFeedbackService.Update(feedback);

                return Ok(feedbacKData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        #endregion

        #region FIND 
        [HttpGet("{id}")]
        public async Task<ActionResult<List<CourseFeedbackEntity>>> FindOne(int id)
        {
            try
            {
                CourseFeedbackEntity feedbackData = await _courseFeedbackService.FindOne(id);

                return Ok(feedbackData);
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
                await _courseFeedbackService.Delete(id);

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
