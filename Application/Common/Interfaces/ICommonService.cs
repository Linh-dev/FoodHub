using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Common.Interfaces;
public interface ICommonService
{
    IMapper Mapper { get; }

}
