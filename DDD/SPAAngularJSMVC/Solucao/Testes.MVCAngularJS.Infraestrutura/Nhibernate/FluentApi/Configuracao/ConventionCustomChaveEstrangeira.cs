﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Configuracao
{
    public class ConventionCustomChaveEstrangeira : ForeignKeyConvention
    {
        protected override string GetKeyName(FluentNHibernate.Member property, Type type)
        {
            if (property == null)
            {
                return "id" + type.Name;
            }

            return "id" + property.Name;
        }
    }
}
