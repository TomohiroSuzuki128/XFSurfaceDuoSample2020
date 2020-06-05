﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFSurfaceDuoSample2020.Services
{
    public interface IStationDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(string lineID, bool forceRefresh = false);
    }
}
