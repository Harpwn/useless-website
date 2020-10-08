using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using UselessCore.Model;

namespace UselessCore.Services
{
    public abstract class Service
    {
        protected UselessContext Context;
        protected IMemoryCache Cache;
        protected IMapper Mapper;

        public Service(UselessContext context, IMemoryCache cache, IMapper mapper)
        {
            Context = context;
            Cache = cache;
            Mapper = mapper;
        }
    }
}
