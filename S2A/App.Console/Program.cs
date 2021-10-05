using ApplicationManagement.DataAccess.DataAccess;
using System;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationManagement.DataAccess.Models;

namespace AppConsole
{
    public class Language
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                LabelData label = new(2057, "Data Source=.\\SQL2014; DataBase=Translation;Integrated Security=True; MultipleActiveResultSets=true;");
                LanguageData data = new("Data Source=.\\SQL2014; DataBase=Translation;Integrated Security=True; MultipleActiveResultSets=true;");
                CountryData countrydt = new("Data Source=.\\SQL2014; DataBase=ApplicationManagement;Integrated Security=True; MultipleActiveResultSets=true;");
                var txtCountry = File.ReadAllText(@"C:\Users\A377272\source\repos\Learning\Learning\Learning\S2A\countries+states+cities.json");
                var txtLanguage = File.ReadAllText(@"C:\Users\A377272\source\repos\Learning\Learning\Learning\S2A\languages.json");
                //var countries = JsonSerializer.Deserialize<List<Root>>(txtCountry);
               // var languageList = await data.GetLanguage();
                //await SaveCountry(label, countrydt, countries, languageList);
                //var languages = JsonSerializer.Deserialize<List<Language>>(txtLanguage);
                // await SaveLanguage(label, data, languages);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static async Task SaveCountry(LabelData label, CountryData countrydt, List<Root> countries, List<LanguageDBModel> languageList)
        {
            foreach (var cntry in countries)
            {
                var country = new CountryDBModel
                {
                    ISO3 = cntry.iso3,
                    ISO2 = cntry.iso2,
                    Code = cntry.numeric_code,
                    PhoneCode = cntry.phone_code,
                    Currency = cntry.currency,
                    Symbol = cntry.currency_symbol,
                    TLD = cntry.tld,
                    Latitude = cntry.latitude,
                    Longitude = cntry.longitude,
                    Emoji = cntry.emoji,
                    EmojiU = cntry.emojiU
                };

                var lblName = new LabelDBModel { LanguageId = 2057, Translation = cntry.name };
                var lblCapital = new LabelDBModel { LanguageId = 2057, Translation = cntry.capital };
                var lblNative = new LabelDBModel { LanguageId = 2057, Translation = cntry.native };
                var lblRegion = new LabelDBModel { LanguageId = 2057, Translation = cntry.region };
                var lblSubRegion = new LabelDBModel { LanguageId = 2057, Translation = cntry.subregion };
                country.NameLabel = await label.SaveTranslation(lblName);
                country.CapitalLabel = await label.SaveTranslation(lblCapital);
                country.NativeLabel = await label.SaveTranslation(lblNative);
                country.RegionLabel = await label.SaveTranslation(lblRegion);
                country.SubRegionLabel = await label.SaveTranslation(lblSubRegion);
                country.Id = await countrydt.SaveCountry(country);
                var tp = cntry.translations.GetType();
                foreach (var pr in tp.GetProperties())
                {
                    var lang = languageList.Where(x => x.Code.EndsWith(pr.Name));
                    var trans = pr.GetValue(tp).ToString();
                    foreach (var l in lang)
                    {
                        await label.SaveTranslation(new LabelDBModel {Code = country.NameLabel, LanguageId = l.DescriptionLabel, Translation = trans });
                    }
                }
                await SaveTimeZones(label, countrydt, cntry, country);
                await SaveState(label, countrydt, cntry, country);

            }
        }

        private static async Task SaveTimeZones(LabelData label, CountryData countrydt, Root cntry, CountryDBModel country)
        {
            foreach (var tz in cntry.timezones)
            {
                var tZone = new TimeZoneDBModel
                {
                    CountryId = country.Id,
                    GmtOffset = tz.gmtOffset,
                    GmtOffsetName = tz.gmtOffsetName,
                    Abbreviation = tz.abbreviation
                };

                var lblZone = new LabelDBModel { LanguageId = 2057, Translation = tz.zoneName };
                var lblTimeZone = new LabelDBModel { LanguageId = 2057, Translation = tz.tzName };
                tZone.ZoneNameLabel = await label.SaveTranslation(lblZone);
                tZone.TimeZoneNameLabel = await label.SaveTranslation(lblTimeZone);
                await countrydt.SaveTimeZone(tZone);
            }
        }

        private static async Task SaveState(LabelData label, CountryData countrydt, Root cntry, CountryDBModel country)
        {
            foreach (var st in cntry.states)
            {
                var state = new StateDBModel
                {
                    CountryId = country.Id,
                    Code = st.state_code,
                    Latitude = st.latitude,
                    Longitude = st.longitude,
                    Type = st.type
                };
                var lblStateName = new LabelDBModel { LanguageId = 2057, Translation = st.name };

                state.NameLabel = await label.SaveTranslation(lblStateName);
                state.Id = await countrydt.SaveState(state);

                await SaveCity(label, countrydt, st, state, lblStateName);
            }
        }

        private static async Task SaveCity(LabelData label, CountryData countrydt, State st, StateDBModel state, LabelDBModel lblStateName)
        {
            foreach (var ct in st.cities)
            {
                var city = new CityDBModel
                {
                    Stateid = state.Id,
                    Latitude = ct.latitude,
                    Longitude = ct.longitude
                };
                var lblCityName = new LabelDBModel { LanguageId = 2057, Translation = ct.name };
                city.NameLabel = await label.SaveTranslation(lblStateName);
                await countrydt.SaveState(state);
            }
        }

        private static async Task SaveLanguage(LabelData label, LanguageData data, List<Language> languages)
        {
            foreach (var lang in languages)
            {
                var lbl = new LabelDBModel { LanguageId = 2057, Translation = lang.Name };
                var lng = new LanguageDBModel { Id = lang.Id, Code = lang.Code };
                lng.DescriptionLabel = await label.SaveTranslation(lbl);
                if (lng.DescriptionLabel > 0) await data.SaveLanguage(lng);
            }
        }
    }
    public class TimeZoneModel
    {
        public int Id { get; set; }
        public int ZoneNameLabel { get; init; }
        public string GmtOffset { get; set; }
        public string GmtOffsetName { get; set; }
        public string Abbreviation { get; set; }
        public string TimeZoneNameLabel { get; set; }
    }
    public class CountryModel
    {
        public int Id { get; set; }
        public string ISO3 { get; set; }
        public string Numeric_code { get; set; }
        public string ISO2 { get; set; }
        public string Phone_Code { get; set; }
        public int CapitalLabel { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string TLD { get; set; }
        public decimal NativeLabel { get; set; }
        public decimal RegionLabel { get; set; }
        public decimal SubRegionLabel { get; set; }
        public TimeZoneModel TimeZone { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Emoji { get; set; }
        public string EmojiU { get; set; }
        public string WikiDataId { get; set; }

        public string Name { get; set; }
        public string Capital { get; set; }
        public string Native { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public IEnumerable<StateModel> States { get; set; }
    }

    public class StateModel
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int NameLabel { get; set; }
        public string Code { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Type { get; set; }
        public IEnumerable<CityModel> Cities { get; set; }
    }
    public class CityModel
    {
        public int Id { get; set; }
        public int Stateid { get; set; }
        public int NameLabel { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }


    public class Timezone
    {
        public string zoneName { get; set; }
        public int gmtOffset { get; set; }
        public string gmtOffsetName { get; set; }
        public string abbreviation { get; set; }
        public string tzName { get; set; }
    }
    public class Translations
    {
        public string kr { get; set; }
        public string br { get; set; }
        public string pt { get; set; }
        public string nl { get; set; }
        public string hr { get; set; }
        public string fa { get; set; }
        public string de { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        public string it { get; set; }
        public string cn { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state_code { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string type { get; set; }
        public List<City> cities { get; set; }
    }
    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public string iso2 { get; set; }
        public string numeric_code { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string currency_symbol { get; set; }
        public string tld { get; set; }
        public string native { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public List<Timezone> timezones { get; set; }
        public Translations translations { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string emoji { get; set; }
        public string emojiU { get; set; }
        public List<State> states { get; set; }
    }
}
