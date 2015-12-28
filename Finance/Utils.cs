using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using Finance.models;
namespace Finance
{
    class Utils
    {

        public static void deleteFile(string filename)
        {
            File.Delete(filename);
        }

        public static void save<T> (T obj, string filename )
        {
            
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fstream = new FileStream(filename, FileMode.Append);

            formatter.Serialize(fstream, obj);

            fstream.Close();
            
        }

        public static List<FinanceCategoryData.Data> retreiveAll(int category)
        {

            List<FinanceCategoryData.Data> list = new List<FinanceCategoryData.Data>();
            try
            {
                FileStream fstream = new FileStream(category + ".dat", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
              

                while (fstream.Position != fstream.Length)
                {
                    FinanceCategoryData.Data data = (FinanceCategoryData.Data)formatter.Deserialize(fstream);
                    list.Add(data);
                }
                fstream.Close();
                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Eror while reading data. Cause: " + ex);
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Eror while reading data. Cause: " + ex);
            }
            return list;
        }

    }
}
