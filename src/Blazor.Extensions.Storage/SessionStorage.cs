using Blazor.Extensions.Storage.Interfaces;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Extensions.Storage
{
    public class SessionStorage : IStorage
    {
        private readonly IJSRuntime runtime;

        public Task<int> Length() => this.runtime.InvokeAsync<int>(MethodNames.LENGTH_METHOD, StorageTypeNames.SESSION_STORAGE);

        public Task Clear() => this.runtime.InvokeAsync<object>(MethodNames.CLEAR_METHOD, StorageTypeNames.SESSION_STORAGE);

        public SessionStorage(IJSRuntime runtime)
        {
            this.runtime = runtime;
        }

        public Task<TItem> GetItem<TItem>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeAsync<TItem>(MethodNames.GET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
        }

        public Task<string> Key(int index) => this.runtime.InvokeAsync<string>(MethodNames.KEY_METHOD, StorageTypeNames.SESSION_STORAGE, index);

        public Task RemoveItem(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeAsync<object>(MethodNames.REMOVE_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key);
        }

        public Task SetItem<TItem>(string key, TItem item)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            return this.runtime.InvokeAsync<TItem>(MethodNames.SET_ITEM_METHOD, StorageTypeNames.SESSION_STORAGE, key, item);
        }
    }
}
