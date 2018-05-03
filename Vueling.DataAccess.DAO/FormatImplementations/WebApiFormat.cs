using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.DAO.Interfaces;

namespace Vueling.DataAccess.DAO.FormatImplementations
{
    public class WebApiFormat<T> : IFormat<T>, IConnection<T> where T : IVuelingModelObject
    {
        private HttpClient client;
        private IVuelingLogger log;

        public WebApiFormat(HttpClient client, IVuelingLogger log)
        {
            this.client = WebClientConfig.InitClient(client);
            this.log = log;
            this.log.Init(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public T Add(T entity)
        {
            try
            {
                var response = Task.FromResult(client.PutAsJsonAsync("api/UsuarioAsync/SetAsync",entity))
                    .GetAwaiter()
                    .GetResult();

                return Task.FromResult(response.Result.Content.ReadAsAsync<T>()
                    .GetAwaiter()
                    .GetResult())
                    .Result;
            }
            catch (Exception ex)
            {
                this.log.Error(ex);
                throw;
            }
        }

        public int DeleteByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            try
            {
                var response = Task.FromResult(client.GetAsync("api/UsuarioAsync/GetAsync")
                .GetAwaiter()
                .GetResult());

                return Task.FromResult(response.Result.Content.ReadAsAsync<List<T>>()
                    .GetAwaiter()
                    .GetResult())
                    .Result;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                throw;
            }
        }

        public T GetByGUID(Guid guid)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataTypeAccess GetFormat()
        {
            throw new NotImplementedException();
        }

        public Student InitCache()
        {
            
            var response = Task.FromResult(client.GetAsync("api/UsuarioAsync/GetAsync")
                .GetAwaiter()
                .GetResult()).Result;

            var result = Task.FromResult(response.Content.ReadAsAsync<Student>()
                .GetAwaiter()
                .GetResult())
                .Result;

            return result;
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
