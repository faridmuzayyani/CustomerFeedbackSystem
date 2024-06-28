using FeedbackReview.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackReview.DAL
{
    public class FeedbackEF : IFeedback
    {
        private readonly CustomerFeedbackDBContext _dbContext;

        public FeedbackEF(CustomerFeedbackDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Feedback Add(Feedback entity)
        {
            try
            {
                _dbContext.Feedbacks.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var feedback = _dbContext.Feedbacks.Find(id);
                if (feedback != null)
                {
                    _dbContext.Feedbacks.Remove(feedback);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Feedback not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting feedback: " + ex.Message);
            }
        }

        public IEnumerable<Feedback> GetAll()
        {
            //var results = _dbContext.Feedbacks.ToList();
            //return results;
            return _dbContext.Feedbacks.Include(f => f.Customer).ToList();
        }

        public Feedback GetById(int id)
        {
            var result = (from f in _dbContext.Feedbacks
                          where f.FeedbackId == id
                          select f).FirstOrDefault();
            return result;
		}

        public Feedback Update(Feedback entity)
        {
            _dbContext.Feedbacks.Update(entity);
            _dbContext.SaveChanges();
            _dbContext.Entry(entity).Reload();			
            return entity;
        }
    }
}
