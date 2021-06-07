using AutoMapper;
using ERP_API.DTOs;
using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using ERP_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;


        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(await _customerRepository.GetAllCustomersAsync());
        }

        public async Task<CustomerDTO> GetCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            var discountsList = new Dictionary<SubscriptionDTO, List<AppliedDiscountDTO>>();

            foreach (var sub in customer.CustomerSubscriptions)
            {
                var appliedDiscountsList = new List<AppliedDiscountDTO>();
                foreach (var discount in sub.SubscriptionDiscounts)
                {
                    double appliedDiscount = default(double);
                    switch (discount.Discount.DiscountType)
                    {
                        case "PerCent": //these values should be an enum
                            appliedDiscount = sub.Subscription.SubscriptionPrice * (discount.Discount.DiscountValue.Value / 100);
                            break;
                        case "Value":
                            appliedDiscount = sub.Subscription.SubscriptionPrice - discount.Discount.DiscountValue.Value;
                            break;
                    }
                    appliedDiscountsList.Add(new AppliedDiscountDTO
                    {
                        Discount = _mapper.Map<DiscountDTO>(discount.Discount),
                        AppliedDiscount = appliedDiscount
                    });
                    discountsList.Add(_mapper.Map<SubscriptionDTO>(sub.Subscription), appliedDiscountsList);
                }
            }

            var customerDto = _mapper.Map<CustomerDTO>(customer);
            customerDto.AppliedDiscounts = discountsList;

            return customerDto;
        }

        public async Task<int> AddCustomerAsync(CustomerDTO customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var customers = _mapper.Map<Customer>(customer);

            customers.CustomerSubscriptions = new List<CustomerSubscription>{
                    new CustomerSubscription()
                    {
                        Customer = customers,
                        SubscriptionId = (int)customer.SubscriptionId,
                        SubscriptionDiscounts = new List<SubscriptionDiscount>
                        {
                            new SubscriptionDiscount()
                            {
                                DiscountId = customer.DiscountId
                            }
                        }
                    }
                };

            var savedCustomerId = await _customerRepository.AddcustomerAsync(customers);

            return savedCustomerId;
        }

        public async Task<int> UpdateCustomerAsync(CustomerDTO customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            return await _customerRepository.UpdateCustomerAsync(_mapper.Map<Customer>(customer));
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            if (customerId <= default(int))
            {
                throw new ArgumentNullException(nameof(customerId));
            }

            await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}