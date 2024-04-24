using Entities;
using Repositories;
using Services.Course.DTO;


namespace Services.Course
{
    public class CourseFeedbackService(
        ICourseRepository courseRepository,
        IUserRepository userRepository,
        ICourseFeedbackRepository courseFeedbackRepository
        ) : ICourseFeedbackService
    {

        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ICourseFeedbackRepository _courseFeedbackRepository = courseFeedbackRepository;


        #region CREATE
        public async Task<CourseFeedbackEntity> Create(CreateCourseFeedbackDTO feedback)
        {
            #region VALIDATIONS
            if (feedback.Grade < 0 || feedback.Grade > 5)
                throw new Exception("A Nota deve estar entre 0 e 5.");

            await _courseFeedbackRepository.CanAddFeedback(feedback.CourseId, feedback.UserId);
            await _userRepository.FindOne(feedback.UserId);
            CourseEntity course = await _courseRepository.FindOne(feedback.CourseId);
            #endregion

            #region UPDATE COURSE GRADE
            int newTotalFeedbacks = course.TotalFeedbacks + 1;
            float gradeAvg = (course.GradeAvg * course.TotalFeedbacks + feedback.Grade) / (newTotalFeedbacks);

            course.TotalFeedbacks = newTotalFeedbacks;
            course.GradeAvg = gradeAvg;
            #endregion

            //save feedback and update course
            CourseFeedbackEntity feedbackData = new()
            {
                CourseId = feedback.CourseId,
                UserId = feedback.UserId,
                Grade = feedback.Grade,
                Commentary = feedback.Commentary
            };

            await _courseFeedbackRepository.Create(feedbackData);
            await _courseRepository.Update(course);

            return feedbackData;
        }
        #endregion


        #region UPDATE
        public async Task<CourseFeedbackEntity> Update(UpdateCourseFeedbackDTO feedback)
        {
            CourseFeedbackEntity feedbackData = await _courseFeedbackRepository.FindOne(feedback.Id);

            feedbackData.Grade = feedback.Grade;
            feedbackData.Commentary = feedback.Commentary;


            #region UPDATE COURSE GRADE
            CourseEntity course = await _courseRepository.FindOne(feedbackData.CourseId);
            
            float gradeAvg = (course.GradeAvg * course.TotalFeedbacks + feedback.Grade) / (course.TotalFeedbacks);

            course.GradeAvg = gradeAvg;
            #endregion

            await _courseFeedbackRepository.Update(feedbackData);

            return feedbackData;
        }
        #endregion



        #region FIND
        public async Task<CourseFeedbackEntity> FindOne(int id)
        {
            CourseFeedbackEntity feedback = await _courseFeedbackRepository.FindOne(id);

            return feedback;
        }

        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            await _courseFeedbackRepository.Delete(id);
        }
        #endregion


    }
    #region INTERFACE
    public interface ICourseFeedbackService
    {
        public Task<CourseFeedbackEntity> Create(CreateCourseFeedbackDTO feedback);
        public Task<CourseFeedbackEntity> Update(UpdateCourseFeedbackDTO feedback);
        public Task<CourseFeedbackEntity> FindOne(int id);
        public Task Delete(int id);
    }
    #endregion
}
