using EduzcaServer.Models;
using EduzcaServer.Repositories;
using EduzcaServer.Services.Course.DTO;

namespace EduzcaServer.Services.Course
{
    public class CourseService(ICourseRepository courseRepository, IUserRepository userRepository): ICourseService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;
        private readonly IUserRepository _userRepository = userRepository;

        #region CREATE
        public async Task<CourseEntity> Create(CreateCourseDTO course)
        {
            await _userRepository.FindOne(course.OwnerId);

            CourseEntity courseData = new()
            {
               Name = course.Name,
               TumbnailUrl = course.TumbnailUrl,
               OwnerId = course.OwnerId,
               Description = course.Description,
            };

             await _courseRepository.Create(courseData);

            return courseData;
        }
        #endregion

        #region UPDATE
        public async Task<CourseEntity> Update(UpdateCourseDTO course)
        {
            CourseEntity courseData = await _courseRepository.FindOne(course.Id);
            courseData.Name = course.Name;
            courseData.TumbnailUrl = course.TumbnailUrl;
            courseData.IsPublished = course.IsPublished;
            courseData.Description = course.Description;


            await _courseRepository.Update(courseData);

            return courseData;
        }
        #endregion

        #region FIND
        public async Task<List<CourseEntity>> FindAll()
        {
            List<CourseEntity> courses = await _courseRepository.FindAll() ;

            return courses;
        }

        public async Task<CourseEntity> FindOne(int id)
        {
            CourseEntity course = await _courseRepository.FindOne(id);

            return course;
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            await _courseRepository.Delete(id);
        }
        #endregion
    }

    #region INTERFACE
    public interface ICourseService
    {
        public Task<CourseEntity> Create(CreateCourseDTO course);
        public Task<CourseEntity> Update(UpdateCourseDTO course);
        public Task<List<CourseEntity>> FindAll();
        public Task<CourseEntity> FindOne(int id);
        public Task Delete(int id);
    }
    #endregion
}
