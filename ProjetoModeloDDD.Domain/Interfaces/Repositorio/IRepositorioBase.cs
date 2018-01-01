﻿using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity> where  TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
