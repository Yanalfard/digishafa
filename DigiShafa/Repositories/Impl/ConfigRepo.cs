using System.Collections.Generic;
using System.Linq;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Api;
using DigiShafa.Utilities;

namespace DigiShafa.Repositories.Impl
{
    public class ConfigRepo : IConfigRepo
    {
        public TblConfig AddConfig(TblConfig config)
        {
            return (TblConfig)new MainProvider().Add(config);
        }
        public bool DeleteConfig(int id)
        {
            return new MainProvider().Delete(MainProvider.Tables.TblConfig, id);
        }
        public bool UpdateConfig(TblConfig config, int logId)
        {
            return new MainProvider().Update(config, logId);
        }
        public List<TblConfig> SelectAllConfigs()
        {
            return new MainProvider().SelectAll(MainProvider.Tables.TblConfig).Cast<TblConfig>().ToList();
        }
        public TblConfig SelectConfigById(int id)
        {
            return (TblConfig)new MainProvider().SelectById(MainProvider.Tables.TblConfig, id);
        }
        public TblConfig SelectConfigByTellNo(string tellNo)
        {
            return new MainProvider().SelectConfigByTellNo(tellNo);
        }

    }
}