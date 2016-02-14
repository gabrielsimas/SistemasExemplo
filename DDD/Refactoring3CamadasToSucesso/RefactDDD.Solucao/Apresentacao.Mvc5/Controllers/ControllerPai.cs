using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apresentacao.Mvc5.Mapper;
using AutoMapper;

namespace Apresentacao.Mvc5.Controllers
{
    public class ControllerPai: Controller
    {
        protected IMapper mapper;
        public IMapper Mapeador
        {
            get
            {
                if (this.mapper == null){
                    mapper = AutoMapperConfigFactory.GetMapper();
                }
                return this.mapper;
            }
            set
            {
                this.mapper = value;
            }
        }
    }
}