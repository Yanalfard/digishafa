using System.Collections.Generic;
using DigiShafa.Models.Regular;

namespace DigiShafa.Repositories.Api
{
    public interface IConfigRepo
    {
        TblConfig AddConfig(TblConfig config);
        bool DeleteConfig(int id);
        bool UpdateConfig(TblConfig config, int logId);
        List<TblConfig> SelectAllConfigs();
        TblConfig SelectConfigById(int id);
        TblConfig SelectConfigByTellNo(string tellNo);

    }
}