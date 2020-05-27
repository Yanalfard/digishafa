using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiShafa.Models.Regular;
using DigiShafa.Repositories.Impl;
using DigiShafa.Services.Api;

namespace DigiShafa.Services.Impl
{
    public class ConfigService : IConfigService
    {
        public TblConfig AddConfig(TblConfig config)
        {
            return (TblConfig)new ConfigRepo().AddConfig(config);
        }
        public bool DeleteConfig(int id)
        {
            return new ConfigRepo().DeleteConfig(id);
        }
        public bool UpdateConfig(TblConfig config, int logId)
        {
            return new ConfigRepo().UpdateConfig(config, logId);
        }
        public List<TblConfig> SelectAllConfigs()
        {
            return new ConfigRepo().SelectAllConfigs();
        }
        public TblConfig SelectConfigById(int id)
        {
            return (TblConfig)new ConfigRepo().SelectConfigById(id);
        }
        public TblConfig SelectConfigByTellNo(string tellNo)
        {
            return new ConfigRepo().SelectConfigByTellNo(tellNo);
        }

    }
}