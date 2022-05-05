using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taboo.Business.Abstract;
using Taboo.Data.RequestModel;
using Taboo.Data.ResponseModel;
using Taboo.Entity.DataTransfer.Storage;

namespace Taboo.Business.Concrete
{
    public class GameManager : IGameService
    {
        private readonly DataTransferStorageDbContext _dataTransferStorageDbContext;

        public GameManager(DataTransferStorageDbContext dataTransferStorageDbContext)
        {
            _dataTransferStorageDbContext = dataTransferStorageDbContext;
        }
        public async Task<GameResponseModel> Add(GameAddRequestModel game)
        {
            try
            {
                GameStorageEntity entity = new GameStorageEntity
                {
                    Name = game.Name,
                };
                _dataTransferStorageDbContext.TBL_Game.Add(entity);
                await _dataTransferStorageDbContext.SaveChangesAsync();

                return new GameResponseModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
