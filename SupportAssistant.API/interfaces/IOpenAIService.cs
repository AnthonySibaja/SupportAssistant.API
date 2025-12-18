namespace SupportAssistant.API.Interfaces
{
    public interface IOpenAIService
    {
        Task<(string response, string category, string priority)> 
            GetSupportResponseAsync(string message);
    }
}
