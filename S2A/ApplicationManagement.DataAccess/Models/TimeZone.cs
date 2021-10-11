using ApplicationManagement.DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationManagement.DataAccess.Models
{

    public interface ITranslator
    {
        Task<string> GetTranslationAsync(int id);
        string GetTranslation(int id);
    }
  
    public class TranslatorDetail : ITranslator
    {
        private readonly LabelData _labelData;

        public TranslatorDetail(LabelData labelData)
        {
            _labelData = labelData;
        }

        public string GetTranslation(int id)
        {
            return _labelData.GetTranslation(id);  
        }

        public async  Task<string> GetTranslationAsync(int id)
        {
            return await _labelData.GetTranslationAsync(id);
        }
    }
    public class TimeZoneDBModel
    {
        public int Id { get; set; }
        public int Country { get; set; }
        public int ZoneNameLabel { get; set; }
        public int GmtOffset { get; set; }
        public string GmtOffsetName { get; set; }
        public string Abbreviation { get; set; }
        public int TimeZoneNameLabel { get; set; }
    }

    public class LabelDBModel
    {
        public int Code { get; set; }
        public int LanguageId { get; set; }
        public string Translation { get; set; }
    }

    public class LanguageDBModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DescriptionLabel { get; set; }
    }
   

    public class CountryDBModel
    {
        public int Id { get; set; }
        public int NameLabel { get; set; }
        public string ISO3 { get; set; }
        public string Code { get; set; }
        public string ISO2 { get; set; }
        public string PhoneCode { get; set; }
        public int CapitalLabel { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string TLD { get; set; }
        public int NativeLabel { get; set; }
        public int RegionLabel { get; set; }
        public int SubRegionLabel { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }
        public byte Flag { get; set; }
        public string WikiDataId { get; set; }
    }

    public class StateDBModel 
    {
        public int Id { get; set; }
        public int Country { get; set; }
        public int NameLabel { get; set; }
        public string Code { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Type { get; set; }
    }
    public class CityDBModel
    {
        public int Id { get; set; }
        public int State { get; set; }
        public int NameLabel { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

}
