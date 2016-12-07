using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;
using System.Configuration;

namespace UATLogin.DataAccess
{
    class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
           // var fileName = "C:\\dev\\UATLogin\\UATLogin\\DataAccess\\TestData.xlsx";  //ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static User GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<User>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
       
        }
    }
