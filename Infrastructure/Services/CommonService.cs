using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;

namespace Infrastructure.Services;

public class CommonService : ICommonService
{
    protected readonly IMapper _mapper;
    public CommonService(
        IMapper mapper)
    {
        _mapper = mapper;

    }

    public IMapper Mapper => _mapper;


}