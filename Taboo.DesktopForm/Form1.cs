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

        private async void btnNewGame_Click(object sender, EventArgs e)
        {
            lblPuan.Text = "0";
            var result = await (_apiService.CreateGame(new Data.RequestModel.GameAddRequestModel
            {
                Name = Guid.NewGuid().ToString()
            }));
            if (result.IsResponseSuccessfull && result.Response != null)
            {
                _gameId = result.Response.Id;
                await GetWord();
            }
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
            var result = await (_apiService.SetOutWord(new Data.RequestModel.OutWordRequestModel
            {
                GameId = _gameId,
                WordId = _wordId,
            }));
            await GetWord();
        }

        private async void btnFalse_Click(object sender, EventArgs e)
        {
            lblPuan.Text = (int.Parse(lblPuan.Text) - 1).ToString();
            var result = await (_apiService.SetOutWord(new Data.RequestModel.OutWordRequestModel
            {
                GameId = _gameId,
                WordId = _wordId,
            }));
            await GetWord();
        }
    }
}