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
        public double TotalPrice { get; set; }
        public string UserId { get; set; }
        //Address
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressHeader { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressDescription { get; set; }
    }

    public enum OrderStatus
    {
        Tamamlandı,
        Kargoda,
        [Display(Name = "Onay Bekliyor")]
        Onay_Bekliyor
    }
}
