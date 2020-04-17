using ClearAddVsLookupMove.Library.DataSource.DTO_Models;
using ClearAddVsLookupMove.Library.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClearAddVsLookupMove.Library.DataSource.Providers.StringProvider
{
    public class DSCountries : IDSCountries
    {
        Random _rnd = new Random(DateTime.Now.Second);

        public async Task<BaseResponse> GetCountriesAsync()
        {
            BaseResponse response = new BaseResponse();

            // simulate api delay
            await Task.Delay(1000);

            List<DTO_Model_CountryDetails> countrylists = new List<DTO_Model_CountryDetails>();

            string countries_raw = "USA,Spain,Italy,France,Germany,UK,China,Iran,Turkey,Belgium,Netherlands,Switzerland,Brazil,Russia,Portugal,Austria,Israel,Ireland,Sweden,India,S. Korea,Peru,Chile,Japan,Ecuador,Poland,Romania,Norway,Denmark,Australia,Czechia,Pakistan,Saudi Arabia,Philippines,Mexico,Malaysia,Indonesia,UAE,Serbia,Panama,Qatar,Ukraine,Luxembourg,Dominican Republic,Belarus,Singapore,Finland,Colombia,Thailand,South Africa,Egypt,Argentina,Greece,Algeria,Moldova,Morocco,Iceland,Croatia,Bahrain,Hungary,Iraq,Estonia,New Zealand,Kuwait,Kazakhstan,Slovenia,Azerbaijan,Uzbekistan,Bosnia and Herzegovina,Lithuania,Armenia,Hong Kong,Bangladesh,North Macedonia,Cameroon,Slovakia,Oman,Cuba,Tunisia,Afghanistan,Bulgaria,Diamond Princess,Cyprus,Latvia,Andorra,Lebanon,Ghana,Ivory Coast,Costa Rica,Niger,Burkina Faso,Uruguay,Albania,Channel Islands,Kyrgyzstan,Honduras,Jordan,Taiwan,Malta,Réunion,San Marino,Djibouti,Guinea,Bolivia,Nigeria,Mauritius,Palestine,Senegal,Georgia,Montenegro,Vietnam,Isle of Man,DRC,Sri Lanka,Mayotte,Kenya,Venezuela,Faeroe Islands,Guatemala,Paraguay,Martinique,El Salvador,Guadeloupe,Mali,United Arab Emirates,Brunei,Rwanda,Gibraltar,Cambodia,Trinidad and Tobago,Madagascar,Monaco,Aruba,French Guiana,Ethiopia,Liechtenstein,Togo,Jamaica,Barbados,Myanmar,Somalia,Liberia,Bermuda,Gabon,French Polynesia,Uganda,Cayman Islands,Tanzania,Bahamas,Guyana,Zambia,Macao,Equatorial Guinea,Haiti,Puerto Rico,Guinea-Bissau,Benin,Eritrea,Saint Martin,Sudan,Guam,Mongolia,Syria,Mozambique,Libya,Antigua and Barbuda,Chad,Maldives,Angola,Laos,New Caledonia,Belize,Zimbabwe,U.S. Virgin Islands,Dominica,Namibia,Nepal,Malawi,Fiji,Eswatini,Saint Lucia,Curaçao,Grenada,Botswana,St. Vincent Grenadines,Saint Kitts and Nevis,Greenland,CAR,Falkland Islands,Montserrat,Sierra Leone,Seychelles,Suriname,Cabo Verde,Turks and Caicos,Nicaragua,Gambia,Côte d'Ivoire,MS Zaandam,Vatican City,Mauritania,St. Barth,Timor-Leste,Western Sahara,Bhutan,Burundi,Sao Tome and Principe,South Sudan,British Virgin Islands,Anguilla,Central African Republic,Caribbean Netherlands,Faroe Islands,Papua New Guinea,Kosovo,Saint Vincent and the Grenadines,Yemen,Saint Pierre Miquelon,Jersey,Guernsey";

            var countries = countries_raw.Split(',');

            for (int i = 0; i < countries.Length; i++)
            {
                countrylists.Add(new DTO_Model_CountryDetails()
                {
                    id = i + 1,
                    countryname = countries[i],
                    population = _rnd.Next(10000, 900000),
                    total_energy_consumption = _rnd.Next(10000, 900000)
                });
            }

            response.Response = countrylists;
            response.Status = true;
            response.Message = "GetCountriesAsync()";

            return response;
        }
    }
}
