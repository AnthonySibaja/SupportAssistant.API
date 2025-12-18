using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using SupportAssistant.API.Interfaces;

namespace SupportAssistant.API.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public OpenAIService(IConfiguration config)
        {
            _config = config;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _config["OpenAI:ApiKey"]);
        }

        public async Task<(string response, string category, string priority)>
            GetSupportResponseAsync(string message)
        {
            var prompt = $"""
Eres un asistente de soporte técnico profesional.
Responde paso a paso y en español.
Clasifica el problema (software, hardware, red).
Indica prioridad (Baja, Media, Alta).

Problema del usuario:
{message}
""";

            var requestBody = new
            {
                model = _config["OpenAI:Model"],
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                content
            );

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            var aiText = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            // Versión simple (luego se puede mejorar)
            return (aiText!, "General", "Media");
        }
    }
}
