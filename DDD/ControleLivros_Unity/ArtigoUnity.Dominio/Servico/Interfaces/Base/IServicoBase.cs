﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Servico.Interfaces.Base
{
    public interface IServicoBase<T>
    {
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(Nullable<long> id);
        ICollection<T> BuscarTodos();
        T FiltrarUmPor(Func<T, Boolean> lambda);
        ICollection<T> FiltrarVariosPor(Func<T, Boolean> lambda);
        void Dispose();
    }
}
