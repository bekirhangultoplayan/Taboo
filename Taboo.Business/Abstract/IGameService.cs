using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;

namespace Taboo.Business.Abstract
{
    public interface IGameService
    {
        Task<GameResponseModel> Add(GameAddRequestModel game);
    }
}
