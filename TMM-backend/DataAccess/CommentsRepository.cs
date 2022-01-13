using System;
using System.Collections.Generic;
using System.Linq;
using TMM_backend.Models;

namespace TMM_backend.DataAccess
{
    public class CommentsRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments.OrderByDescending(c => c.Date).ToList<Comment>();
        }

        public bool Create(Comment comment)
        {
            if (comment.Email.Length < 3 ||
                comment.Message.Length < 3 ||
                comment.Name.Length < 3 ||
                comment.Title.Length < 3)
            {
                return false;
            }

            _dbContext.Comments.Add(comment);

            if (_dbContext.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            var comm = _dbContext.Comments.FirstOrDefault(c => c.Id == id);
            if (comm == null)
            {
                return false;
            }
            return Delete(comm);
        }

        public bool Delete(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            var changes = _dbContext.SaveChanges();
            if (changes == 0)
                return false;
            return true;
        }
    }
}
