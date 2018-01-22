using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAspNetCore2MVC.Models
{
    public class PieDbRepository : IPieRepository
    {
        private AppDbContext m_AppDbContext;

        public PieDbRepository(AppDbContext context)
        {
            m_AppDbContext = context;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return m_AppDbContext.Pies;
        }

        public Pie GetPieById(int pieId)
        {
            return m_AppDbContext.Pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
