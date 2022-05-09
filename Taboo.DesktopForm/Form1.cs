using Taboo.ApiClient.Abstract;
using Taboo.Data.ResponseModel;

namespace Taboo.DesktopForm
{
    public partial class Form1 : Form
    {
        private int _gameId;
        private int _wordId;
        private readonly IApiService _apiService;
        public Form1(IApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
          
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await TimerSetup();
        }
        private async Task GetWord()
        {
            var result = await (_apiService.GetRandomWord(new Data.RequestModel.RandomWordRequestModel
            {
                GameId = _gameId
            }));
            if (result.IsResponseSuccessfull && result.Response != null)
            {
                _wordId = result.Response.Id;
                lblWord.Text = result.Response.Word;
                await AddOption(result.Response.ForbiddenWords);
            }
        }
        private async Task AddOption(List<ForbiddenWordResponseModel> model)
        {
            int count = panel1.Controls.OfType<Label>().ToList().Count;
            for (int index = 0; index < count; index++)
            {
                panel1.Controls.Remove(panel1.Controls.Find("lblForbiddenWord" + (index + 1), true)[0]);
            }
            int i = 0;
            foreach (var item in model)
            {
                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(10, 35 + (35 * i));
                lbl.Name = "lblForbiddenWord" + (i + 1);
                lbl.Size = new System.Drawing.Size(100, 20);
                lbl.Text = item.Word;
                panel1.Controls.Add(lbl);
                i++;
            }
        }

        private async void btnPas_Click(object sender, EventArgs e)
        {
            await GetWord();
        }

        private async void btnTrue_Click(object sender, EventArgs e)
        {
            lblPuan.Text = (int.Parse(lblPuan.Text) + 1).ToString();
            await SetOutWord();
            await GetWord();
        }

        private async void btnFalse_Click(object sender, EventArgs e)
        {
            lblPuan.Text = (int.Parse(lblPuan.Text) - 1).ToString();
            await SetOutWord();
            await GetWord();
        }
        private async Task SetOutWord()
        {
            var result = await (_apiService.SetOutWord(new Data.RequestModel.OutWordRequestModel
            {
                GameId = _gameId,
                WordId = _wordId,
            }));
        }
        private async Task RefreshGame()
        {
            if (_gameId == 0)
            {
                await NewGame();
            }
            counter = 60;
            lblTimer.Text = counter.ToString();
            lblPuan.Text = "0";
            timer1.Stop();
            timer1.Start();
            await SetOutWord();
            await GetWord();

        }
        private int counter = 60;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
                timer1.Stop();
            lblTimer.Text = counter.ToString();
        }

        private async void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await NewGame();
        }
        private async Task NewGame()
        {
            timer1.Interval = 1000;
            timer1.Stop(); 
            counter = 60; 
            lblTimer.Text = counter.ToString();
            lblPuan.Text = "0";
            var result = await (_apiService.CreateGame(new Data.RequestModel.GameAddRequestModel
            {
                Name = Guid.NewGuid().ToString()
            }));
            if (result.IsResponseSuccessfull && result.Response != null)
            {
                _gameId = result.Response.Id;
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            await RefreshGame();
        }
        private System.Windows.Forms.Timer timer1;
        private async Task TimerSetup()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
             
        }

       
    }
}