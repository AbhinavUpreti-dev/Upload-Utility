using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Upload_Utility.Business
{
    public class ReadGoogleSheets
    {
        private readonly string SheetURL = "";
        public ReadGoogleSheets(string sheetUrl)
        {
            SheetURL = sheetUrl;
        }

        private string GetToken()
        {
            return "1GB-8c9ILWyWrQzT-7rQ9Un4X3W4-EyLLxXxMTp4d5KY";
        }
        public string[] ReadFromGoogleSheets(string path, string tokenPath)
        {

            var rowData = new List<string>();

            try
            {
                string[] Scopes = { SheetsService.Scope.Spreadsheets };
                var ApplicationName = "Google Sheets API .NET Quickstart";
                UserCredential credential;
                // Load client secrets.
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    /* The file token.json stores the user's access and refresh tokens, and is created
                     automatically when the authorization flow completes for the first time. */
                    
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(tokenPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + tokenPath);
                }

                // Create Google Sheets API service.
                var service = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });

                // Define request parameters.
                var spreadsheetId = "1GB-8c9ILWyWrQzT-7rQ9Un4X3W4-EyLLxXxMTp4d5KY";
                var range = "Personal Information!A2:F";
                SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

                // Prints the names and majors of students in a sample spreadsheet:
                // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;
                if (values == null || values.Count == 0)
                {
                    Console.WriteLine("No data found.");
                    return new string[0];
                }
                Console.WriteLine("Name, Major");
                foreach (var row in values)
                {
                    var rowValues = string.Join("|", row);
                    rowData.Add(rowValues);
                    // Print columns A and E, which correspond to indices 0 and 4.
                    Console.WriteLine("{0}, {1}", row[0], row[4]);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return rowData.ToArray();

        }
    }
}
