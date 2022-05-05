using Microsoft.EntityFrameworkCore;
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
    public class WordManager : IWordService
    {
        private readonly DataTransferStorageDbContext _dataTransferStorageDbContext;

        public WordManager(DataTransferStorageDbContext dataTransferStorageDbContext)
        {
            _dataTransferStorageDbContext = dataTransferStorageDbContext;
        }
        public async Task<WordResponseModel> GetById(int id)
        {
            var data = _dataTransferStorageDbContext.TBL_Word.Where(x => x.Id == id).Include(s => s.ForbiddenWords).FirstOrDefault();
            List<ForbiddenWordResponseModel> forbiddenWords = new List<ForbiddenWordResponseModel>();
            if (data != null)
            {
                foreach (var item in data.ForbiddenWords)
                {
                    forbiddenWords.Add(new ForbiddenWordResponseModel
                    {
                        Id = item.Id,
                        Word = item.ForbiddenWord
                    });
                }
            }
            WordResponseModel result = new WordResponseModel
            {
                Id = data.Id,
                Word = data.Word,
                ForbiddenWords = forbiddenWords
            };
            return result;

        }
        public async Task<WordResponseModel> Add(WordAddRequestModel word)
        {
            try
            {
                WordStorageEntity entity = new WordStorageEntity
                {
                    Word = word.Word,
                };
                _dataTransferStorageDbContext.TBL_Word.Add(entity);
                await _dataTransferStorageDbContext.SaveChangesAsync();
                if (entity.Id > 0)
                {
                    foreach (var item in word.ForbiddenWords)
                    {
                        ForbiddenWordStorageEntity wordStorageEntity = new ForbiddenWordStorageEntity
                        {
                            WordId = entity.Id,
                            ForbiddenWord = item.Word
                        };
                        _dataTransferStorageDbContext.TBL_ForbiddenWord.Add(wordStorageEntity);
                        await _dataTransferStorageDbContext.SaveChangesAsync();
                    }

                }
                return await GetById(entity.Id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<WordResponseModel>> Add(List<WordAddRequestModel> word)
        {
            List<WordStorageEntity> entity = new List<WordStorageEntity>();
            foreach (var item in word)
            {
                List<ForbiddenWordStorageEntity> forbiddenWords = new List<ForbiddenWordStorageEntity>();
                foreach (var item2 in item.ForbiddenWords)
                {
                    var ss = new ForbiddenWordStorageEntity();
                    ss.ForbiddenWord = item2.Word;
                    forbiddenWords.Add(ss);
                }
                entity.Add(new WordStorageEntity
                {
                    Word = item.Word,
                    ForbiddenWords = forbiddenWords
                });
            }

            _dataTransferStorageDbContext.TBL_Word.AddRange(entity);
            await _dataTransferStorageDbContext.SaveChangesAsync();

            return null;
        }
        public async Task<WordResponseModel> GetRandomWord(RandomWordRequestModel model)
        {
            
            Random rnd = new Random();
            var outWordIds = _dataTransferStorageDbContext.TBL_OutWord.Where(x => x.GameId == model.GameId).Select(x => x.WordId).ToList();
            List<WordStorageEntity> result = _dataTransferStorageDbContext.TBL_Word.Where(x => !outWordIds.Contains(x.Id)).ToList();
            

            var data = result.OrderBy(item => rnd.Next()).FirstOrDefault();

            return await GetById(data.Id);
        }

        public async Task<bool> SetOutWord(OutWordRequestModel model)
        {
            OutWordStorageEntity entity = new OutWordStorageEntity { GameId = model.GameId, WordId = model.WordId };
            _dataTransferStorageDbContext.TBL_OutWord.Add(entity);
            await _dataTransferStorageDbContext.SaveChangesAsync();
            return true;
        }
    }
}
