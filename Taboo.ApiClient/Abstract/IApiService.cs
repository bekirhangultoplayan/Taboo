using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.Data;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;

namespace Taboo.ApiClient.Abstract
{
    public interface IApiService
    {
        Task<ResponseWrapper<GameResponseModel>> CreateGame(GameAddRequestModel model);
        Task<ResponseWrapper<WordResponseModel>> AddWord(WordAddRequestModel model);
        Task<ResponseWrapper<List<WordResponseModel>>> AddWords(List<WordAddRequestModel> model);
        Task<ResponseWrapper<bool>> SetOutWord(OutWordRequestModel model);
        Task<ResponseWrapper<WordResponseModel>> GetRandomWord(RandomWordRequestModel model);
    }
}
