using System.Collections.Generic;
using ApplicationDataPortal.Core.Models;

namespace ApplicationDataPortal.Repositories
{
    public interface IPromotionsRepository
    {
        IEnumerable<Promotions> GetPromotions();
        Promotions GetPromotion(int id);
        void DeletePromotion(int id);
        int GetNumberOfPromotionsOnDisplayType(int id);
    }
}