using Entities.Dtos;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services.PaymentService.Iyzico
{
    public class HandlePayment
    {
        public Payment CreatePayment(OrderDto dto)
        {
            Options options = new Options
            {
                ApiKey = Keys.API_KEY,
                SecretKey = Keys.SECRET_KEY,
                BaseUrl = "https://sandbox-api.iyzipay.com"
            };

            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = dto.TotalPrice.ToString().Replace(",", "."),
                PaidPrice = dto.TotalPrice.ToString().Replace(",", "."),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = dto.CardHolderName,
                CardNumber = dto.CardNumber,
                ExpireMonth = dto.ExpireMonth,
                ExpireYear = "20" + dto.ExpireYear,
                Cvc = dto.SecurityNumber
            };
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer
            {
                Id = dto.UserId,
                Name = dto.FullName.Split(" ")[0],
                Surname = dto.FullName.Split(" ").Last(),
                GsmNumber = dto.PhoneNumber,
                Email = dto.Email,
                IdentityNumber = "74300864791",
                RegistrationAddress = dto.AddressDescription,
                Ip = "85.34.78.112",
                City = dto.City,
                Country = "Turkey"
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = dto.FullName,
                City = dto.City,
                Country = "Turkey",
                Description = dto.AddressDescription
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = dto.FullName,
                City = dto.City,
                Country = "Turkey",
                Description = dto.AddressDescription
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in dto.CartItems)
            {
                BasketItem basketItem = new BasketItem();
                basketItem.Id = item.Product.Id.ToString();
                basketItem.Name = item.Product.ProductName;
                basketItem.Category1 = "Notebook";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = Math.Round(item.ProductQuantity * item.Product.NewPrice, 3, MidpointRounding.AwayFromZero).ToString().Replace(",",".");
                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            return payment;
        }
    }
}
