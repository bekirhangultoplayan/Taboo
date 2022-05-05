using Newtonsoft.Json;
using Taboo.Business.Abstract;
using Taboo.Data.RequestModel;
namespace Taboo.AddedWord
{
    public partial class Form1 : Form
    {
        private readonly IWordService _wordService;
        public Form1(IWordService wordService)
        {
            InitializeComponent();
            _wordService = wordService;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<WordAddRequestModel> list = new List<WordAddRequestModel>();
            string[] lines = System.IO.File.ReadAllLines(@"D:\word1.json");
            int index = 0; 
            var kelime = "";
            string[] icerik = new string[5];
            foreach (string line in lines)
            {               
                if (line.EndsWith("\": ["))
                {
                    var start = line.IndexOf("\"");
                    var end = line.LastIndexOf("\"");
                    var word = line.Substring(start + 1, end - start - 1);

                    kelime = word;
                    
                }
                else if (line.EndsWith("\",") || line.EndsWith("\""))
                {
                    var start = line.IndexOf("\"");
                    var end = line.LastIndexOf("\"");
                    var word = line.Substring(start + 1, end - start - 1);
                    icerik[index] = word;
                    index++;
                }

                if (index == 5)
                {
                    List<ForbiddenWordAddRequestModel> forbiddenWords = new List<ForbiddenWordAddRequestModel>();
                    for (int i = 0; i < icerik.Length; i++)
                    {
                        forbiddenWords.Add(new ForbiddenWordAddRequestModel { Word = icerik[i] });
                    }
                    list.Add(new WordAddRequestModel { Word = kelime, ForbiddenWords = forbiddenWords });
                    index = 0;
                }
            }
            await _wordService.Add(list);

            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string lines = System.IO.File.ReadAllText(@"D:\word2.json");
            List<Temperatures> model = JsonConvert.DeserializeObject<List<Temperatures>>(lines);
            List<WordAddRequestModel> list = new List<WordAddRequestModel>();

            foreach (var item in model)
            {
                List<ForbiddenWordAddRequestModel> forbiddenWords = new List<ForbiddenWordAddRequestModel>();
                foreach (var item2 in item.Tabu)
                {
                    forbiddenWords.Add(new ForbiddenWordAddRequestModel { Word = item2.ToUpper() });
                }
                list.Add(new WordAddRequestModel { Word = item.Word.ToUpper(), ForbiddenWords = forbiddenWords });
            }
            await _wordService.Add(list);
        }
    }
    public partial class Temperatures
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("tabu")]
        public List<string> Tabu { get; set; }
    }
}