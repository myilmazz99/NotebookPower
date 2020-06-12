using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Order : IEntity
    {
        public Order()
        {
            Status = OrderStatus.Onay_Bekliyor;
            OrderDate = DateTime.Now;
        }

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }

        //Payment API
    }

    public enum OrderStatus
    {
        Tamamlandı,
        Kargoda,
        [Display(Name = "Onay Bekliyor")]
        Onay_Bekliyor
    }
}
