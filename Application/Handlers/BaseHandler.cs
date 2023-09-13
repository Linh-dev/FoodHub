using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Common.Handlers;
public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly ICommonService _commonService;
    public BaseHandler(ICommonService commonService)
    {
        _commonService = commonService;
    }
    public IMapper Mapper => _commonService.Mapper;
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
