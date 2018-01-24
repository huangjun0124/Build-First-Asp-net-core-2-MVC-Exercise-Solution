using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetCore2MVC.Models
{
    public class FeedBackDbRepository:IFeedBackRepository
    {
        private AppDbContext m_DbContext;
        public FeedBackDbRepository(AppDbContext context)
        {
            m_DbContext = context;
        }

        public void AddFeedBack(FeedBack feedBack)
        {
            m_DbContext.FeedBacks.Add(feedBack);
            m_DbContext.SaveChanges();
        }
    }
}
