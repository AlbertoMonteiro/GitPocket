using System.Threading.Tasks;
using Octokit;

namespace GitPocket.Business.Test.Mocks
{
    public class MockGitHubClient : IGitHubClient
    {
        public MockGitHubClient()
        {
            var mockUsersClient = new MockUsersClient();
            mockUsersClient.MockSome(x => x.Current()).Returns(() =>
            {
                var taskCompletionSource = new TaskCompletionSource<User>();
                taskCompletionSource.SetResult(new User());
                return taskCompletionSource.Task;
            });
            User = mockUsersClient;
        }

        public IConnection Connection { get; private set; }

        public IAuthorizationsClient Authorization { get; private set; }

        public IActivitiesClient Activity { get; private set; }

        public IIssuesClient Issue { get; private set; }

        public IMiscellaneousClient Miscellaneous { get; private set; }

        public IOauthClient Oauth { get; private set; }

        public IOrganizationsClient Organization { get; private set; }

        public IPullRequestsClient PullRequest { get; private set; }

        public IRepositoriesClient Repository { get; private set; }

        public IGistsClient Gist { get; private set; }

        public IReleasesClient Release { get; private set; }

        public ISshKeysClient SshKey { get; private set; }

        public IUsersClient User { get; private set; }

        public INotificationsClient Notification { get; private set; }

        public IGitDatabaseClient GitDatabase { get; private set; }

        public ISearchClient Search { get; private set; }
    }
}