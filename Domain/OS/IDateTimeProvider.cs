﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.OS;
public interface IDateTimeProvider
{
    DateTime Now { get; }

    DateTime UtcNow { get; }

    DateTimeOffset OffsetNow { get; }

    DateTimeOffset OffsetUtcNow { get; }
}