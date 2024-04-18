
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BabyYoda
{
    internal class ChatAzureEngine
    {
        private HttpClient httpClient { get; set; }
        private string OPENAI_KEY = ""; // Add  OpenAI key
        private string OPENAI_MODEL = "text-davinci-003";
        private string API_ENDPOINT = "[^1^][1]"; // OpenAI API endpoint
    }
}
