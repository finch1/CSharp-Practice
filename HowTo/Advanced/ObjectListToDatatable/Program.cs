using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleUI
{
    class Program{
        static void Main(string[] args)
        {
            ListToDatatableconverter converter = new ListToDatatableconverter();

            // Both work
            DataTable students = converter.ToDataTable(new Student().GenerateStudentList());
            students = converter.ToDataTable<Student>(new Student().GenerateStudentList());
        }
    }

    public class Student
    {
        // An instance property--one copy for each dog
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Subject { get; set; }

        public List<Student> GenerateStudentList()
        {
            return new List<Student>
            {
                new Student{Name = "N1", Age = 5, Subject = "S1"},
                new Student{Name = "N2", Age = 6, Subject = "S2"},
                new Student{Name = "N3", Age = 7, Subject = "S3"},
                new Student{Name = "N4", Age = 8},
            };
        }
    }

    public class ListToDatatableconverter
    {
        public DataTable ToDataTable<T>(List<T> items) // arg = list of ONE type of object
        {
            // T is taken from the list of from the Method Caller
            DataTable dt = new DataTable(typeof(T).Name); // name the Datatable as the object type

            // Add a RowChanged event handler.
            dt.RowChanged += new DataRowChangeEventHandler(Row_Changed);

            // Get all properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance); // fom the object, get its Insatnce and Public properties
            
            // the order of the columns matches the order of the properties in the object blueprint
            foreach (PropertyInfo prop in props)
            {
                // Setting column names from Property Names
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }

            dt.Columns.Add("id", typeof(int));
            // Set the primary key.
            dt.Columns["id"].Unique = true;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["id"] };

            int id = 0;

            foreach (T item in items) // loop list
            {
                var values = new object[props.Length +1]; // create a new row the size of the object properties. +1 for the index col

                int i = 0;
                for(; i < props.Length; i++) // loop the properties
                {
                    // inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null); // Get value from item (object) where the property = prop[i]. i.e. if the prop @ index 0 = Name, then form item Get the Value of Name.
                }

                values[i] = id++; // should add then increment

                dt.Rows.Add(values);
                // dt.AcceptChanges();
            }

            return dt;
        }

        private static void Row_Changed(object sender, DataRowChangeEventArgs e)
        {
            Console.WriteLine("Row_Changed Event: name={0}; action={1}",
                e.Row["name"], e.Action);
        }
    }
    
}