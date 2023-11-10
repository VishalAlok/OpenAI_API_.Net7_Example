using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;

namespace OpenAI_API_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            OpenAIMethod();
        }
        public static void OpenAIMethod()
        {
            var key = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            var endpoint = "https://myopenai-rnd.openai.azure.com/";
            var deployment = "gpt35";

            OpenAIClient aiClient = new(new Uri(endpoint), new Azure.AzureKeyCredential(key));

            var prompt = $"which is the 2nd tallest mountain in the world ?";

            ChatCompletionsOptions chatOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System,"You are  a helpful AI Bot."),
                    new ChatMessage(ChatRole.User,prompt)
                    
                },
                DeploymentName = deployment
            };

            ChatCompletions responseCompletion = aiClient.GetChatCompletions(chatOptions);
            string response = responseCompletion.Choices[0].Message.Content;
            Console.WriteLine(response);
        }
    }

}
