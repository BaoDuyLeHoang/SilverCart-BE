using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ProductPromotionRespository : IProductPromotionRepository
    {
        private readonly AppDbContext _context;
        public ProductPromotionRespository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductPromotion>> GetByProductIdAsync(Guid productId)
        {
            return await _context.ProductPromotions.Include(pp => pp.Product)
                .Where(pp => pp.ProductId == productId)
                .ToListAsync();
        }
        public async Task<List<ProductPromotion>> GetByPromotionIdAsync(Guid promotionId)
        {
            return await _context.ProductPromotions.Include(pp => pp.Product)
                .Where(pp => pp.PromotionId == promotionId)
                .ToListAsync();
        }

        public async Task AddAsync(ProductPromotion productPromotion)
        {
            await _context.ProductPromotions.AddAsync(productPromotion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductPromotion productPromotion)
        {
            _context.ProductPromotions.Update(productPromotion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductPromotion productPromotion)
        {
            _context.ProductPromotions.Remove(productPromotion);
            await _context.SaveChangesAsync();
        }
    }
}
