using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;

namespace Taboo.Business.Abstract
{
    public interface IWordService
    {
        Task<WordResponseModel> GetById(int id);
        Task<WordResponseModel> Add(WordAddRequestModel word); 
        Task<List<WordResponseModel>> Add(List<WordAddRequestModel> word); 
        Task<WordResponseModel> GetRandomWord(RandomWordRequestModel model); 
        Task<bool> SetOutWord(OutWordRequestModel model); 
    }
}
