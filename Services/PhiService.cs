using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Ollama;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using NetMauiPhi.Helpers;
using NetMauiPhi.Plugins;
using OllamaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable SKEXP0070
#pragma warning disable SKEXP0110
#pragma warning disable SKEXP0010

namespace NetMauiPhi.Services
{
    public class PhiService : IPhiService
    {
        Kernel kernel, kernelWeather;
        ChatCompletionAgent agent;
        ChatHistory chatHistory;
        KernelArguments args;
        IChatCompletionService chatCompletionService;
        ChatCompletionAgent agentFC;
        AgentGroupChat chatFC;
        OllamaPromptExecutionSettings settings;

        public PhiService()
        {
            var localEndpoint = new Uri(Constants.LocalServerAddress);

            var builder = Kernel.CreateBuilder();
            builder.AddOllamaChatCompletion(Constants.LocalModelId, localEndpoint);

            kernel = builder.Build();

            agent = new ChatCompletionAgent()
            {
                Instructions = Constants.LocalInstructions,
                Name = "Soccer Agent",
                Kernel = kernel
            };
            
            chatHistory = new ChatHistory();

            var builderWeather = Kernel.CreateBuilder();
            builderWeather.Services.AddOllamaChatCompletion(Constants.LocalModelIdFunctionCalling, localEndpoint);

            builderWeather.Plugins.AddFromType<CityWeatherPlugin>();
            kernelWeather = builderWeather.Build();

            chatCompletionService = kernelWeather.GetRequiredService<IChatCompletionService>();

            settings = new OllamaPromptExecutionSettings 
            { 
                FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
            };

            args = new KernelArguments(settings);

            /*
            var modelIdFC = Constants.LocalModelIdFunctionCalling;
            var baseUrlFC = Constants.LocalServerAddress;

            var httpClientFC = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(2)
            };

            var builderFC = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(modelId: modelIdFC!, 
                    apiKey: null, 
                    endpoint: new Uri(baseUrlFC!), 
                    httpClient: httpClientFC);
            var kernelFC = builder.Build();

            var hostNameFC = "AI Assistant";
            var hostInstructionsFC = Constants.LocalInstructionsFC;

            var settingsFC = new OpenAIPromptExecutionSettings()
            {
                Temperature = 0.1,
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
            };

            agentFC = new ChatCompletionAgent()
            {
                Instructions = hostInstructionsFC,
                Name = hostNameFC,
                Kernel = kernelFC,
                Arguments = new(settingsFC),
            };

            KernelPlugin weatherPluginFC = KernelPluginFactory.CreateFromType<CityWeatherPlugin>();
            agentFC.Kernel.Plugins.Add(weatherPluginFC);

            chatFC = new();
            */
        }

        public async Task<string> AskSoccerAgent(string prompt)
        {
            var userMessage = new ChatMessageContent(
                AuthorRole.User, prompt);

            chatHistory.Add(userMessage);

            await foreach(var response in agent.InvokeAsync(chatHistory))
            {
                chatHistory.Add(response);
                return response.Content;
            }

            return string.Empty;
        }

        public async Task<string> AskAIAgent(string prompt)
        {
            
            var chatResult = await 
                chatCompletionService
                    .GetChatMessageContentAsync(prompt, settings, kernelWeather);

            return chatResult.Content;
            
            /*
            chatFC.AddChatMessage(
                new ChatMessageContent(AuthorRole.User, prompt));

            var output = string.Empty;

            await foreach (ChatMessageContent content in chatFC.InvokeAsync(agentFC))
            {
                output += content.Content;
            }

            return output;
            */
        }
    }
}
