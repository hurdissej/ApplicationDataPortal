using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using ApplicationDataPortal.Core.Models;
using ApplicationDataPortal.Core.Models.AccountModels;
using AutoMapper.Mappers;
using WebGrease.Activities;

namespace ApplicationDataPortal.Repositories
{
    public class PromotionsRepository : IPromotionsRepository
    {
        private readonly IApplicationDbContext _context;

        public PromotionsRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Promotions> GetPromotions()
        {
            var result = _context.Promotions
                .Include(d => d.DisplayTypes)
                .ToList();

            return result;
        }

        public Promotions GetPromotion(int id)
        {
            return _context.Promotions
                .Include(d => d.DisplayTypes)
                .SingleOrDefault(d => d.Id == id);
        }

        public int GetNumberOfPromotionsOnDisplayType(int id)
        {
            var result = _context.Promotions
                .Where(d => d.DisplayTypesId == id)
                .ToList()
                .Count;

            return result;

        }

        public void DeletePromotion(int id)
        {
            _context.Promotions.Remove(GetPromotion(id));
        }

    }
}