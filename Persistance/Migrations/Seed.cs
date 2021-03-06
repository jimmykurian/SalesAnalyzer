﻿using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Persistance.Migrations
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.States.Any())
            {
                var states = new List<State>
                {
                    new State {Name="Alabama"},
                    new State {Name="Alaska"},
                    new State {Name="American Samoa "},
                    new State {Name="Arizona"},
                    new State {Name="Arkansas"},
                    new State {Name="California"},
                    new State {Name="Colorado"},
                    new State {Name="Connecticut"},
                    new State {Name="Delaware"},
                    new State {Name="District of Columbia"},
                    new State {Name="Florida"},
                    new State {Name="Georgia"},
                    new State {Name="Guam"},
                    new State {Name="Hawaii"},
                    new State {Name="Idaho"},
                    new State {Name="Illinois"},
                    new State {Name="Indiana"},
                    new State {Name="Iowa"},
                    new State {Name="Kansas"},
                    new State {Name="Kentucky"},
                    new State {Name="Louisiana"},
                    new State {Name="Maine"},
                    new State {Name="Maryland"},
                    new State {Name="Massachusetts"},
                    new State {Name="Michigan"},
                    new State {Name="Minnesota"},
                    new State {Name="Mississippi"},
                    new State {Name="Missouri"},
                    new State {Name="Montana"},
                    new State {Name="Nebraska"},
                    new State {Name="Nevada"},
                    new State {Name="New Hampshire"},
                    new State {Name="New Jersey"},
                    new State {Name="New Mexico"},
                    new State {Name="New York"},
                    new State {Name="North Carolina"},
                    new State {Name="North Dakota"},
                    new State {Name="Northern Mariana Islands "},
                    new State {Name="Ohio"},
                    new State {Name="Oklahoma"},
                    new State {Name="Oregon"},
                    new State {Name="Pennsylvania"},
                    new State {Name="Puerto Rico"},
                    new State {Name="Rhode Island"},
                    new State {Name="South Carolina"},
                    new State {Name="South Dakota"},
                    new State {Name="Tennessee"},
                    new State {Name="Texas"},
                    new State {Name="United States Minor Outlying Islands "},
                    new State {Name="Utah"},
                    new State {Name="Vermont"},
                    new State {Name="Virgin Islands, U.S."},
                    new State {Name="Virginia"},
                    new State {Name="Washington"},
                    new State {Name="West Virginia"},
                    new State {Name="Wisconsin"},
                    new State {Name="Wyoming"},
                };

                context.States.AddRange(states);
                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {
                var countries = new List<Country>
                {
                    new Country {Name="Afghanistan"},
                    new Country {Name="Albania"},
                    new Country {Name="Algeria"},
                    new Country {Name="American Samoa"},
                    new Country {Name="Andorra"},
                    new Country {Name="Angola"},
                    new Country {Name="Anguilla"},
                    new Country {Name="Antarctica"},
                    new Country {Name="Antigua and Barbuda"},
                    new Country {Name="Argentina"},
                    new Country {Name="Armenia"},
                    new Country {Name="Aruba"},
                    new Country {Name="Australia"},
                    new Country {Name="Austria"},
                    new Country {Name="Azerbaijan"},
                    new Country {Name="Bahamas"},
                    new Country {Name="Bahrain"},
                    new Country {Name="Bangladesh"},
                    new Country {Name="Barbados"},
                    new Country {Name="Belarus"},
                    new Country {Name="Belgium"},
                    new Country {Name="Belize"},
                    new Country {Name="Benin"},
                    new Country {Name="Bermuda"},
                    new Country {Name="Bhutan"},
                    new Country {Name="Bolivia"},
                    new Country {Name="Bonaire, Sint Eustatius and Saba"},
                    new Country {Name="Bosnia and Herzegovina"},
                    new Country {Name="Botswana"},
                    new Country {Name="Bouvet Island"},
                    new Country {Name="Brazil"},
                    new Country {Name="British Indian Ocean Territory"},
                    new Country {Name="Brunei Darussalam"},
                    new Country {Name="Bulgaria"},
                    new Country {Name="Burkina Faso"},
                    new Country {Name="Burundi"},
                    new Country {Name="Cabo Verde"},
                    new Country {Name="Cambodia"},
                    new Country {Name="Cameroon"},
                    new Country {Name="Canada"},
                    new Country {Name="Cayman Islands"},
                    new Country {Name="Central African Republic"},
                    new Country {Name="Chad"},
                    new Country {Name="Chile"},
                    new Country {Name="China"},
                    new Country {Name="Christmas Island"},
                    new Country {Name="Cocos (Keeling) Islands"},
                    new Country {Name="Colombia"},
                    new Country {Name="Comoros"},
                    new Country {Name="Congo"},
                    new Country {Name="Cook Islands"},
                    new Country {Name="Costa Rica"},
                    new Country {Name="Croatia"},
                    new Country {Name="Cuba"},
                    new Country {Name="Curaçao"},
                    new Country {Name="Cyprus"},
                    new Country {Name="Czechia"},
                    new Country {Name="Côte d'Ivoire"},
                    new Country {Name="Denmark"},
                    new Country {Name="Djibouti"},
                    new Country {Name="Dominica"},
                    new Country {Name="Dominican Republic"},
                    new Country {Name="Ecuador"},
                    new Country {Name="Egypt"},
                    new Country {Name="El Salvador"},
                    new Country {Name="Equatorial Guinea"},
                    new Country {Name="Eritrea"},
                    new Country {Name="Estonia"},
                    new Country {Name="Eswatini"},
                    new Country {Name="Ethiopia"},
                    new Country {Name="Falkland Islands"},
                    new Country {Name="Faroe Islands"},
                    new Country {Name="Fiji"},
                    new Country {Name="Finland"},
                    new Country {Name="France"},
                    new Country {Name="French Guiana"},
                    new Country {Name="French Polynesia"},
                    new Country {Name="French Southern Territories"},
                    new Country {Name="Gabon"},
                    new Country {Name="Gambia"},
                    new Country {Name="Georgia"},
                    new Country {Name="Germany"},
                    new Country {Name="Ghana"},
                    new Country {Name="Gibraltar"},
                    new Country {Name="Greece"},
                    new Country {Name="Greenland"},
                    new Country {Name="Grenada"},
                    new Country {Name="Guadeloupe"},
                    new Country {Name="Guam"},
                    new Country {Name="Guatemala"},
                    new Country {Name="Guernsey"},
                    new Country {Name="Guinea"},
                    new Country {Name="Guinea-Bissau"},
                    new Country {Name="Guyana"},
                    new Country {Name="Haiti"},
                    new Country {Name="Heard Island and McDonald Islands"},
                    new Country {Name="Holy See"},
                    new Country {Name="Honduras"},
                    new Country {Name="Hong Kong"},
                    new Country {Name="Hungary"},
                    new Country {Name="Iceland"},
                    new Country {Name="India"},
                    new Country {Name="Indonesia"},
                    new Country {Name="Iran"},
                    new Country {Name="Iraq"},
                    new Country {Name="Ireland"},
                    new Country {Name="Isle of Man"},
                    new Country {Name="Israel"},
                    new Country {Name="Italy"},
                    new Country {Name="Jamaica"},
                    new Country {Name="Japan"},
                    new Country {Name="Jersey"},
                    new Country {Name="Jordan"},
                    new Country {Name="Kazakhstan"},
                    new Country {Name="Kenya"},
                    new Country {Name="Kiribati"},
                    new Country {Name="Korea (the Democratic People's Republic of)"},
                    new Country {Name="Korea (the Republic of)"},
                    new Country {Name="Kuwait"},
                    new Country {Name="Kyrgyzstan"},
                    new Country {Name="Lao People's Democratic Republic"},
                    new Country {Name="Latvia"},
                    new Country {Name="Lebanon"},
                    new Country {Name="Lesotho"},
                    new Country {Name="Liberia"},
                    new Country {Name="Libya"},
                    new Country {Name="Liechtenstein"},
                    new Country {Name="Lithuania"},
                    new Country {Name="Luxembourg"},
                    new Country {Name="Macao"},
                    new Country {Name="Madagascar"},
                    new Country {Name="Malawi"},
                    new Country {Name="Malaysia"},
                    new Country {Name="Maldives"},
                    new Country {Name="Mali"},
                    new Country {Name="Malta"},
                    new Country {Name="Marshall Islands"},
                    new Country {Name="Martinique"},
                    new Country {Name="Mauritania"},
                    new Country {Name="Mauritius"},
                    new Country {Name="Mayotte"},
                    new Country {Name="Mexico"},
                    new Country {Name="Micronesia"},
                    new Country {Name="Moldova"},
                    new Country {Name="Monaco"},
                    new Country {Name="Mongolia"},
                    new Country {Name="Montenegro"},
                    new Country {Name="Montserrat"},
                    new Country {Name="Morocco"},
                    new Country {Name="Mozambique"},
                    new Country {Name="Myanmar"},
                    new Country {Name="Namibia"},
                    new Country {Name="Nauru"},
                    new Country {Name="Nepal"},
                    new Country {Name="Netherlands"},
                    new Country {Name="New Caledonia"},
                    new Country {Name="New Zealand"},
                    new Country {Name="Nicaragua"},
                    new Country {Name="Niger"},
                    new Country {Name="Nigeria"},
                    new Country {Name="Niue"},
                    new Country {Name="Norfolk Island"},
                    new Country {Name="Northern Mariana Islands"},
                    new Country {Name="Norway"},
                    new Country {Name="Oman"},
                    new Country {Name="Pakistan"},
                    new Country {Name="Palau"},
                    new Country {Name="Palestine, State of"},
                    new Country {Name="Panama"},
                    new Country {Name="Papua New Guinea"},
                    new Country {Name="Paraguay"},
                    new Country {Name="Peru"},
                    new Country {Name="Philippines"},
                    new Country {Name="Pitcairn"},
                    new Country {Name="Poland"},
                    new Country {Name="Portugal"},
                    new Country {Name="Puerto Rico"},
                    new Country {Name="Qatar"},
                    new Country {Name="Republic of North Macedonia"},
                    new Country {Name="Romania"},
                    new Country {Name="Russian Federation"},
                    new Country {Name="Rwanda"},
                    new Country {Name="Réunion"},
                    new Country {Name="Saint Barthélemy"},
                    new Country {Name="Saint Helena, Ascension and Tristan da Cunha"},
                    new Country {Name="Saint Kitts and Nevis"},
                    new Country {Name="Saint Lucia"},
                    new Country {Name="Saint Martin (French part)"},
                    new Country {Name="Saint Pierre and Miquelon"},
                    new Country {Name="Saint Vincent and the Grenadines"},
                    new Country {Name="Samoa"},
                    new Country {Name="San Marino"},
                    new Country {Name="Sao Tome and Principe"},
                    new Country {Name="Saudi Arabia"},
                    new Country {Name="Senegal"},
                    new Country {Name="Serbia"},
                    new Country {Name="Seychelles"},
                    new Country {Name="Sierra Leone"},
                    new Country {Name="Singapore"},
                    new Country {Name="Sint Maarten (Dutch part)"},
                    new Country {Name="Slovakia"},
                    new Country {Name="Slovenia"},
                    new Country {Name="Solomon Islands"},
                    new Country {Name="Somalia"},
                    new Country {Name="South Africa"},
                    new Country {Name="South Georgia and the South Sandwich Islands"},
                    new Country {Name="South Sudan"},
                    new Country {Name="Spain"},
                    new Country {Name="Sri Lanka"},
                    new Country {Name="Sudan"},
                    new Country {Name="Suriname"},
                    new Country {Name="Svalbard and Jan Mayen"},
                    new Country {Name="Sweden"},
                    new Country {Name="Switzerland"},
                    new Country {Name="Syrian Arab Republic"},
                    new Country {Name="Taiwan"},
                    new Country {Name="Tajikistan"},
                    new Country {Name="Tanzania"},
                    new Country {Name="Thailand"},
                    new Country {Name="Timor-Leste"},
                    new Country {Name="Togo"},
                    new Country {Name="Tokelau"},
                    new Country {Name="Tonga"},
                    new Country {Name="Trinidad and Tobago"},
                    new Country {Name="Tunisia"},
                    new Country {Name="Turkey"},
                    new Country {Name="Turkmenistan"},
                    new Country {Name="Turks and Caicos Islands"},
                    new Country {Name="Tuvalu"},
                    new Country {Name="Uganda"},
                    new Country {Name="Ukraine"},
                    new Country {Name="United Arab Emirates"},
                    new Country {Name="United Kingdom of Great Britain and Northern Ireland"},
                    new Country {Name="United States Minor Outlying Islands"},
                    new Country {Name="United States of America"},
                    new Country {Name="Uruguay"},
                    new Country {Name="Uzbekistan"},
                    new Country {Name="Vanuatu"},
                    new Country {Name="Venezuela"},
                    new Country {Name="Viet Nam"},
                    new Country {Name="Virgin Islands (British)"},
                    new Country {Name="Virgin Islands (U.S.)"},
                    new Country {Name="Wallis and Futuna"},
                    new Country {Name="Western Sahara"},
                    new Country {Name="Yemen"},
                    new Country {Name="Zambia"},
                    new Country {Name="Zimbabwe"},
                };

                context.Countries.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}
