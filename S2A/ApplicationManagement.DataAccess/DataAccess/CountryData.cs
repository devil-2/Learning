using ApplicationManagement.DataAccess.Internal.DataAccess;
using ApplicationManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DataAccess.DataAccess
{
    public class CountryData
    {
        private readonly string _connectionString;

        public CountryData(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<int> SaveCountry(CountryDBModel dBModel)
        {
            NonTransactionalDataAccess sql = new();
           
            return await sql.ExecuteScalarAsync<CountryDBModel,int>("spAddCountry", dBModel, _connectionString);
        }
        public async Task<int> SaveTimeZone(TimeZoneDBModel dBModel)
        {
            NonTransactionalDataAccess sql = new();

            return await sql.ExecuteScalarAsync<TimeZoneDBModel, int>("spAddTimeZone", dBModel, _connectionString);
        }
        public async Task<int> SaveState(StateDBModel dBModel)
        {
            NonTransactionalDataAccess sql = new();

            return await sql.ExecuteScalarAsync<StateDBModel, int>("spAddState", dBModel, _connectionString);
        }
        public async Task<int> SaveCity(CityDBModel dBModel)
        {
            NonTransactionalDataAccess sql = new();

            return await sql.ExecuteScalarAsync<CityDBModel, int>("spAddCity", dBModel, _connectionString);
        }

        public async Task<List<CountryDBModel>> GetCountry()
        {
            NonTransactionalDataAccess sql = new();
            return await sql.QueryAsync<CountryDBModel>("spGetLanguages",_connectionString);
        }
    }

    public class LanguageData
    {
        private readonly string _connectionString;

        public LanguageData(string connectionString)
        {
            _connectionString = connectionString;
        }
      
        public async Task<List<LanguageDBModel>> GetLanguage()
        {
            NonTransactionalDataAccess sql = new();
            return await sql.QueryAsync<LanguageDBModel>("spGetLanguage", _connectionString);
        }

        public async Task SaveLanguage(LanguageDBModel model)
        {
            NonTransactionalDataAccess sql = new();
            await sql.ExecuteAsync("spAddLanguage", model, _connectionString);
        }
    }

    public class LabelData
    {
        private int _languageId = 2057;
        private readonly string _connectionString;

        public LabelData(int languageId, string connectionString)
        {
            _languageId = languageId;
            _connectionString = connectionString;
        }

        public async Task<string> GetTranslationAsync(int id)
        {
            NonTransactionalDataAccess sql = new();
            var labels = await sql.QueryAsync<LabelDBModel,dynamic>("spGetLabel", new { LabelCode = id, LanguageId = _languageId }, _connectionString);
            var label = labels.FirstOrDefault();
            return label?.Translation ?? "Default";
        }

        public string GetTranslation(int id)
        {
            NonTransactionalDataAccess sql = new();
            var labels = sql.Query<LabelDBModel, dynamic>("spGetLabel", new { LabelCode = id, LanguageId = _languageId }, _connectionString);
            var label = labels.FirstOrDefault();
            return label?.Translation ?? "Default";
        }

        public async Task<int> SaveTranslation(LabelDBModel model)
        {
            NonTransactionalDataAccess sql = new();
            var labelId = await sql.ExecuteScalarAsync<LabelDBModel, int>("spAddLabel", model, _connectionString);
            return labelId;
        }
    }
}
