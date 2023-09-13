using Application.Common.Handlers;
using Application.Common.Interfaces;
using Application.Features.Customers.Services;
using Application.Features.Shops.Commands;
using Application.Features.Shops.Services;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<Response<Customer>>
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }
    }

    public class CreateCustomerCommandHandler : BaseHandler<CreateCustomerCommand, Response<Customer>>
    {
        private readonly ICustomerService _customerService;
        public CreateCustomerCommandHandler(ICommonService commonService, ICustomerService customerService) : base(commonService)
        {
            _customerService = customerService;
        }

        public override async Task<Response<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer() { FullName = request.FullName, DOB = request.DOB, Email = request.Email };
            var result = await _customerService.AddOrUpdateAsync(entity);
            return Response<Customer>.Success(result);
        }
    }
}