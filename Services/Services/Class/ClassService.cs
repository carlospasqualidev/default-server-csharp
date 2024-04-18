using EduzcaServer.Entities;
using EduzcaServer.Repositories;


namespace EduzcaServer.Services.Class
{
    public class ClassService(IClassRepository classRepository): IClassService
    {
        private readonly IClassRepository _classRepository = classRepository;

        #region CREATE
        public async Task<ClassEntity> Create(ClassEntity classData)
        {
            await _classRepository.FindOne(classData.Id);

            //find last class of the course for increment order

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

            return classData;
        }
        #endregion

        #region UPDATE
        public async Task<ClassEntity> Update(ClassEntity classData)
        {
            ClassEntity classDataToUpdate = await _classRepository.FindOne(classData.Id);

            classDataToUpdate.Description = classData.Description;
            classDataToUpdate.Name = classData.Name;
            classDataToUpdate.Order = classData.Order;
            classDataToUpdate.VideoUrl = classData.VideoUrl;
            classDataToUpdate.Text = classData.Text;

            await _classRepository.Update(classData);

            return classData;
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
        public Task<ClassEntity> Create(ClassEntity classData);
        public Task<ClassEntity> Update(ClassEntity classData);
        public Task<ClassEntity> FindOne(int id);
        public Task Delete(int id);
    }
    #endregion
}
