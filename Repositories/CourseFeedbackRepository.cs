using EduzcaServer.Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CourseFeedbackRepository(DBContext dbContext) : ICourseFeedbackRepository
    {
        private readonly DBContext _dbContext = dbContext;

        #region CREATE
        public async Task<CourseFeedbackEntity> Create(CourseFeedbackEntity feedback)
        {
            await _dbContext.CourseFeedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();

            return feedback;
        }
        #endregion

        #region UPDATE
        public async Task<CourseFeedbackEntity> Update(CourseFeedbackEntity feedback)
        {
            _dbContext.Update(feedback);
            await _dbContext.SaveChangesAsync();

            return feedback;
        }
        #endregion

        #region FIND
    
        public async Task<CourseFeedbackEntity> FindOne(int id)
        {
            CourseFeedbackEntity? feedback = await _dbContext.CourseFeedbacks.FirstOrDefaultAsync(feedback => feedback.Id == id);

            return feedback ?? throw new Exception("Feedback não encontrado na base de dados.");
        }

        public async Task CanAddFeedback(int courseId, int userId)
        {
            CourseFeedbackEntity? feedback = await _dbContext.CourseFeedbacks.FirstOrDefaultAsync(feedback => feedback.CourseId == courseId && feedback.UserId == userId);

            if(feedback != null) throw new Exception("Você já possuí um feedback neste curso.");
        }

        #endregion

        #region DELETE
        public async Task Delete(int id)
        {
            CourseFeedbackEntity feedback = await FindOne(id);

            _dbContext.Remove(feedback);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

    }
    
    #region INTERFACE
    public interface ICourseFeedbackRepository
    {
        public Task<CourseFeedbackEntity> Create(CourseFeedbackEntity feedback);
        public Task<CourseFeedbackEntity> Update(CourseFeedbackEntity feedback);
        public Task<CourseFeedbackEntity> FindOne(int id);
        public Task CanAddFeedback(int courseId, int userId);
        public Task Delete(int id);
    }
    #endregion
}
