using System;
using System.Threading.Tasks;
using Octokit;

namespace GitPocket.Business.Test.Mocks
{
    public class MockUsersClient : Mock<IUsersClient>, IUsersClient
    {
        public Task<User> Get(string login)
        {
            throw new NotImplementedException();
        }

        public Task<User> Current()
        {
            var mockBuilder = methods["Current"] as MockBuilder<Task<User>>;
            return mockBuilder.Execution();
        }

        public Task<User> Update(UserUpdate user)
        {
            throw new NotImplementedException();
        }

        public IUserEmailsClient Email { get; private set; }

        public IUserKeysClient Keys { get; private set; }

        public IFollowersClient Followers { get; private set; }
    }
}