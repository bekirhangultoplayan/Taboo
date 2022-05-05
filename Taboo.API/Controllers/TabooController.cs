using Microsoft.AspNetCore.Mvc;
using Taboo.Business.Abstract;
using Taboo.Data;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;

namespace Taboo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabooController : ControllerBase
    {
        private readonly IWordService _wordService;
        private readonly IGameService _gameService;
      

        public TabooController(IWordService wordService, IGameService gameService)
        {
            _wordService = wordService;
            _gameService = gameService;
        }


        [HttpPost]
        [Route("createGame")]
        public async Task<ResponseWrapper<GameResponseModel>> CreateGame([FromBody] GameAddRequestModel model)
        {
            var result = new ResponseWrapper<GameResponseModel> { IsResponseSuccessfull = false };
            try
            {
                var serviceResult = await _gameService.Add(model);
                if (serviceResult == null)
                {
                    result.Message = "Transaction Error";
                }
                else
                {
                    result.IsResponseSuccessfull = true;
                    result.Message = "Transaction Successful";
                    result.Response = serviceResult;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        
        [HttpPost]
        [Route("addWord")]
        public async Task<ResponseWrapper<WordResponseModel>> AddWord([FromBody] WordAddRequestModel model)
        {
            var result = new ResponseWrapper<WordResponseModel> { IsResponseSuccessfull = false };
            try
            {
                var serviceResult = await _wordService.Add(model);
                if (serviceResult == null)
                {
                    result.Message = "Transaction Error";
                }
                else
                {
                    result.IsResponseSuccessfull = true;
                    result.Message = "Transaction Successful";
                    result.Response = serviceResult;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
             
            return result;
        }
        [HttpPost]
        [Route("addWords")]
        public async Task<ResponseWrapper<List<WordResponseModel>>> AddWords([FromBody] List<WordAddRequestModel> model)
        {
            var result = new ResponseWrapper<List<WordResponseModel>> { IsResponseSuccessfull = false };
            try
            {
                var serviceResult = await _wordService.Add(model);
                if (serviceResult == null)
                {
                    result.Message = "Transaction Error";
                }
                else
                {
                    result.IsResponseSuccessfull = true;
                    result.Message = "Transaction Successful";
                    result.Response = serviceResult;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        [HttpPost]
        [Route("outWord")]
        public async Task<ResponseWrapper<bool>> SetOutWord([FromBody] OutWordRequestModel model)
        {
            var result = new ResponseWrapper<bool> { IsResponseSuccessfull = false };
            try
            {
                var serviceResult = await _wordService.SetOutWord(model);
                if (serviceResult == null)
                {
                    result.Message = "Transaction Error";
                }
                else
                {
                    result.IsResponseSuccessfull = true;
                    result.Message = "Transaction Successful";
                    result.Response = serviceResult;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("getRandomWord")]
        public async Task<ResponseWrapper<WordResponseModel>> GetRandomWord([FromBody] RandomWordRequestModel model)
        {
            var result = new ResponseWrapper<WordResponseModel> { IsResponseSuccessfull = false };
            try
            {
                var serviceResult = await _wordService.GetRandomWord(model);
                if (serviceResult == null)
                {
                    result.Message = "Transaction Error";
                }
                else
                {
                    result.IsResponseSuccessfull = true;
                    result.Message = "Transaction Successful";
                    result.Response = serviceResult;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
