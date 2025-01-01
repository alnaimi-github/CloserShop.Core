using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;

var githubPipeline = new GithubPipeline
{
    Name = "CloserShop Build",

    OnEvents = new Events
    {
        Push = new PushEvent
        {
            Branches = new string[] { "main" }
        },

        PullRequest = new PullRequestEvent
        {
            Branches = new string[] { "main" }
        }
    },

    Jobs = new Dictionary<string, Job>
    {
        ["build"] = new Job
        {
            RunsOn = BuildMachines.WindowsLatest,

            Steps = new List<GithubTask>
            {
                new CheckoutTaskV2
                {
                    Name = "Checking out Code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Installing .NET",

                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                        DotNetVersion = "9.0.x"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Building Project(s)"
                },

                new TestTask
                {
                    Name = "Running Tests"
                }
            }
        }
    }
};

var adotNetClient = new ADotNetClient();
adotNetClient.SerializeAndWriteToFile(
    githubPipeline,
    path: "../../../../.github/workflows/Api.yml");