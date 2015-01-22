using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace GitPocket.Business.Test.Mocks
{
    public class MockConnection : IConnection
    {
        public Task<IResponse<string>> GetHtml(Uri uri, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Get<T>(Uri uri, IDictionary<string, string> parameters, string accepts, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Patch(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Patch<T>(Uri uri, object body)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Patch<T>(Uri uri, object body, string accepts)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Post<T>(Uri uri, object body, string accepts, string contentType, Uri baseAddress)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Put<T>(Uri uri, object body)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<T>> Put<T>(Uri uri, object body, string twoFactorAuthenticationCode)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Put(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Delete(Uri uri, object data)
        {
            throw new NotImplementedException();
        }

        public Uri BaseAddress { get; private set; }

        public ICredentialStore CredentialStore { get; private set; }

        public Credentials Credentials { get; set; }
    }
}