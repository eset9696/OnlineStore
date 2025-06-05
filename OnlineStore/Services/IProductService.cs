﻿using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductById(int id);
    }
}
