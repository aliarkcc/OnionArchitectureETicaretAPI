﻿namespace ETicaretAPI.Application.ViewModels.Products
{
    public class ProductUpdateModel:UpdateEntityBaseModel
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
