using System.Text;
using System.Reflection;

namespace ConsoleUI
{
    public static class GenericTextFileProcessor
    {
        // specify a generic list which accepts any form of class
        // where = limiter. T could be anything i.e. object, int, string. We limit T to an object with properties and an empty constructor. 
        public static List<T> LoadFromTextFile<T>(string filepath) where T : class, new()
        {
            // T is infered from the method
            var lines = System.IO.File.ReadAllLines(filepath).ToList();

            List<T> output = new List<T>(); // accepts generic objects in the list 
            // Create a new object of type T, to get the properties during runtime.
            T entry = new T(); // this is linked to where T : new(). without the above, this line throws a compile time error
            var props_cols = entry.GetType().GetProperties(); // Reflection : look at the object properties during runtime 

            // Check if we have one header row and one data row
            if(lines.Count < 2)
                throw new IndexOutOfRangeException("No data to read");

            // Split columns by delimiter
            var header = lines[0].Split(',');

            // Remove header row for for loop
            lines.RemoveAt(0);

            // loop every line
            foreach (var row in lines)
            {
                entry = new T();

                // Split rows into individual columns. Now the index of this row matches the index of the header so the FirstName column header lines up with the FirstName value in the row
                var vals = row.Split(',');

                // Loops through each header entry so we can compare this against the list of columns from reflection. Once we get the matching coulmn, "SetValue" method sets the value in the entry class 
                for(var i = 0; i < header.Length; i++){
                    foreach (var prop in props_cols)
                    {
                        if(prop.Name == header[i])
                            prop.SetValue(entry, Convert.ChangeType(vals[i], prop.PropertyType));
                    }
                }

                output.Add(entry);

            }

            return output;
        }

        public static void SaveToTextFile<T>(List<T> Data, string filepath) where T : class, new()
        {
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();

            if(Data == null || Data.Count < 2)
                throw new ArgumentNullException("No data was passed to SaveToTextFile");

            var prop_cols = new T().GetType().GetProperties();

            // Loop through each column and get the name so it can comma seperate it as the header
            foreach (PropertyInfo prop in prop_cols)
            {
                line.Append(prop.Name);
                line.Append(",");
            }

            // Add header to first line + remove the last comma
            lines.Add(line.ToString().Substring(0, line.Length -1));

            foreach (var row in Data)
            {
                line = new StringBuilder();
                foreach (var prop in prop_cols)
                {
                    line.Append(prop.GetValue(row)); // from row = the object, get the value of the property and add to string
                    line.Append(",");
                }

                lines.Add(line.ToString().Substring(0, line.Length -1));
            }

            System.IO.File.WriteAllLines(filepath, lines);

        }
    }
    
}