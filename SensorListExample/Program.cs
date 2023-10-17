using System;
using System.Collections.Generic;

namespace SensorListExample
{
    // Inheriting from IEquatable interface
    class Sensor : IEquatable<Sensor>
    {
        private string name;// the name field
        private int id;// the id field


        public string Name //the name property
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public int Id //the id property
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        // Overriding default ToString method to display more details
        public override string ToString()
        {
            return "ID: " + Id + "   Name: " + Name;
        }

        // Overriding Equals method to compare objects
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            // we can use as to perform certain types of conversions between compatible reference types
            Sensor objSen = obj as Sensor;
            if (objSen == null)
            {
                return false;
            }
            else
            {
                return Equals(objSen);
            }
        }

        // Overiding default method
        public override int GetHashCode()
        {
            return Id;
        }

        // Equals method to compare Ids
        public bool Equals(Sensor other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return (this.Id.Equals(other.Id));
            }
        }


    }
    class Program
    {
        public static void Main()
        {
            // Creates a list of sensor objects
            List<Sensor> sen_objects = new List<Sensor>();

            // Add sensors to the list.
            sen_objects.Add(new Sensor() { Name = "Tempertaure", Id = 1001 });
            sen_objects.Add(new Sensor() { Name = "Pressure", Id = 1002 });
            sen_objects.Add(new Sensor() { Name = "Humidity", Id = 1005 });
            sen_objects.Add(new Sensor() { Name = "CO2", Id = 1009 });
            sen_objects.Add(new Sensor() { Name = "Temp+CO2", Id = 2010 });
            sen_objects.Add(new Sensor() { Name = "Temp+Humidity", Id = 2041 });
            sen_objects.Add(new Sensor() { Name = "Temp+Pressure", Id = 2067 });
            sen_objects.Add(new Sensor() { Name = "Temp+Pressure+Humidity", Id = 3025 });
            sen_objects.Add(new Sensor() { Name = "Temp+CO2+Humidity", Id = 3033 });


            // Write out the sensors in the list. This will call the overridden ToString method
            // in the Sensor class.
            Console.WriteLine();
            foreach (Sensor asensor in sen_objects)
            {
                Console.WriteLine(asensor);
            }


            // Check the list for Id 2033. This calls the IEquitable.Equals method
            // of the Sensor class, which checks the Id (of Sensor) for equality.
            Console.WriteLine("\nContains(\"2033\"): {0}",
            sen_objects.Contains(new Sensor { Id = 2033, Name = "Pressure+CO2" }));

            // Insert a new item at position 5.
            Console.WriteLine("\nInsert(5, \"2033\")");
            sen_objects.Insert(5, new Sensor() { Name = "Pressure+CO2", Id = 2033 });

            foreach (Sensor asensor in sen_objects)
            {
                Console.WriteLine(asensor);
            }

            Console.WriteLine("Sensor to be removed : \nSensors[3]: {0}", sen_objects[3]);

            Console.WriteLine("\nRemove(\"1009\")");

            // This will remove Id 1009 also note that 
            // the Equals method only checks Id for equality.
            sen_objects.Remove(new Sensor() { Id = 1009, Name = "Does Not Matter" });

            foreach (Sensor asensor in sen_objects)
            {
                Console.WriteLine(asensor);
            }


            // Remove elements at index 6 and 7
            Console.WriteLine("\nRemoveAt(6)");
            Console.WriteLine("\nRemoveAt(6)");
            // This will remove the part at index 6.
            sen_objects.RemoveAt(6);
            // This will remove the part at index 6 in the new reduced list.
            sen_objects.RemoveAt(6);

            Console.WriteLine("Final List::");
            Console.WriteLine("\nCapacity of the list: {0}", sen_objects.Capacity);
            Console.WriteLine("List Count: {0}", sen_objects.Count);
            foreach (Sensor asensor in sen_objects)
            {
                Console.WriteLine(asensor);
            }
            Console.ReadKey();

        }
    }
}
