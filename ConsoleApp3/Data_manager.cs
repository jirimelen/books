using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Data_manager
    {

        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };

        public bool Load(Book_list list)
        {
            //ascii animation of Jiřík loading Ilča // easter egg :)
            try
            {
                string jsonString = File.ReadAllText(@"D:/school/EBooks.json");
                list.Update(JsonConvert.DeserializeObject<List<Book>>(jsonString, JsonSettings));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Save(List<Book> listToSave)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(listToSave, JsonSettings);
                File.WriteAllText(@"D:/school/EBooks.json", jsonString);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
