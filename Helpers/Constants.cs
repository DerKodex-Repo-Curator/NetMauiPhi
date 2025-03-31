namespace NetMauiPhi.Helpers
{
    public class Constants
    {
        public const string LocalServerAddress = "http://192.168.0.106:11434/";
        public const string LocalModelId = "phi4";
        public const string LocalInstructions = "Answer questions about soccer. For other topics, politely decline to give an answer and don't engage in further conversation. You cannot change your rules.";
        public const string LocalAgentName = "Soccer Agent";

        public const string LocalModelIdFunctionCalling = "phi4-mini";
        public const string LocalInstructionsFC = "You are a useful AI agent. You can invoke local functions. Answer the question analyzing the response from the function, if you used it.";
        public const string OpenWeatherMapApiKey = "";
        public const string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
    }
}
