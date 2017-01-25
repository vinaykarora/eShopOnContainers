﻿using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using System;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class OrderItem
        : Entity
    {
        private string _productName;
        private string _pictureUrl;
        private int _orderId;
        private decimal _unitPrice;
        private decimal _discount;
        private int _units;

        public int ProductId { get; private set; }


        protected OrderItem() { }

        public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, int units = 1)
        {
            if (units <= 0)
            {
                throw new ArgumentNullException("Invalid number of units");
            }

            if ((unitPrice * units) < discount)
            {
                throw new ArgumentException("The total of order item is lower than applied discount");
            }

            ProductId = productId;

            _productName = productName;
            _unitPrice = unitPrice;
            _discount = discount;
            _units = units;
        }

        public void SetPictureUri(string pictureUri)
        {
            if (!String.IsNullOrWhiteSpace(pictureUri))
            {
                _pictureUrl = pictureUri;
            }
        }

        public decimal GetCurrentDiscount()
        {
            return _discount;
        }

        public void SetNewDiscount(decimal discount)
        {
            if (discount < 0)
            {
                throw new ArgumentException("Discount is not valid");
            }

            _discount = discount;
        }

        public void AddUnits(int units)
        {
            if (units < 0)
            {
                throw new ArgumentException("Invalid units");
            }

            _units += units;
        }
    }
}
