﻿using System;
using System.Collections.Generic;
using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao.Contracts
{
    public interface ISelect<T> where T : IVuelingModelObject
    {
        T GetByGUID(Guid guid);
        List<T> GetAll();
        T GetById(int id);
    }
}