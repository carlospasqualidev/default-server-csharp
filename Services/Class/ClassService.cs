using Entities;
using Repositories;
using Services.Class.DTO;


namespace Services.Class
{
    public class ClassService(IClassRepository classRepository, ICourseRepository courseRepository) : IClassService
    {
        private readonly IClassRepository _classRepository = classRepository;
        private readonly IClassRepository _courseRepository = classRepository;

        #region CREATE
        public async Task<ClassEntity> Create(CreateClassDTO classData)
        {
            await _courseRepository.FindOne(classData.CourseId);

            ClassEntity ClassToCreate = new()
            {
                Name = classData.Name,
                Description = classData.Description,
                CourseId = classData.CourseId,
                Order = classData.Order,
                VideoUrl = classData.VideoUrl,
                Text = classData.Text,
            };

            await _classRepository.Create(ClassToCreate);

            return ClassToCreate;
        }
        #endregion

        #region UPDATE
        public async Task<ClassEntity> Update(UpdateClassDTO classData)
        {
            ClassEntity classDataToUpdate = await _classRepository.FindOne(classData.Id);
            await _courseRepository.FindOne(classData.CourseId);

            classDataToUpdate.Description = classData.Description;
            classDataToUpdate.Name = classData.Name;
            classDataToUpdate.Order = classData.Order;
            classDataToUpdate.VideoUrl = classData.VideoUrl;
            classDataToUpdate.Text = classData.Text;

            await _classRepository.Update(classDataToUpdate);

            return classDataToUpdate;
        }
        #endregion

        #region FIND

        public async Task<ClassEntity> FindOne(int id)
        {
            ClassEntity classData = await _classRepository.FindOne(id);

            return classData;
        }
        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            await _classRepository.Delete(id);
        }
        #endregion  
    }

    #region INTERFACE
    public interface IClassService
    {
        public Task<ClassEntity> Create(CreateClassDTO classData);
        public Task<ClassEntity> Update(UpdateClassDTO classData);
        public Task<ClassEntity> FindOne(int id);
        public Task Delete(int id);
    }
    #endregion
}
