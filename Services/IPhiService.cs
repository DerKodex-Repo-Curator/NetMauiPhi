namespace NetMauiPhi.Services
{
    public interface IPhiService
    {
        Task<string> AskSoccerAgent(string prompt);
        Task<string> AskAIAgent(string prompt);
    }
}
