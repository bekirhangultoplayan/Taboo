using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.ApiClient.Abstract;
using Taboo.Data;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;

namespace Taboo.ApiClient.Concrete
{
    public class ApiManager : IApiService
    {
        private readonly IHttpUtilService _httpUtilService;

        public ApiManager(IHttpUtilService httpUtilService)
        {
            _httpUtilService = httpUtilService;
        }

        public async Task<ResponseWrapper<WordResponseModel>> AddWord(WordAddRequestModel model)
        {
            var result = await _httpUtilService.Post<ResponseWrapper<WordResponseModel>>("Taboo/addWord", model);
            return result;
        }

        public async Task<ResponseWrapper<List<WordResponseModel>>> AddWords(List<WordAddRequestModel> model)
        {
            var result = await _httpUtilService.Post<ResponseWrapper<List<WordResponseModel>>>("Taboo/addWords", model);
            return result;
        }

        public async Task<ResponseWrapper<GameResponseModel>> CreateGame(GameAddRequestModel model)
        {
            var result = await _httpUtilService.Post<ResponseWrapper<GameResponseModel>>("Taboo/createGame", model);
            return result;
        }

        public async Task<ResponseWrapper<WordResponseModel>> GetRandomWord(RandomWordRequestModel model)
        {
            var result = await _httpUtilService.Post<ResponseWrapper<WordResponseModel>>("Taboo/getRandomWord", model);
            return result;
        }

        public async Task<ResponseWrapper<bool>> SetOutWord(OutWordRequestModel model)
        {
            var result = await _httpUtilService.Post<ResponseWrapper<bool>>("Taboo/outWord", model);
            return result;
        }
    }
}
