namespace XmlDemos
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            //1. Reading the XML doc
            XDocument document = XDocument.Load(@"../../../Data/cars.xml");

            //2. Gettings the Root Element
            XElement root = document.Root;

            //3. Get All Elements of the Root Element
            //var cars = root.Elements();

            //4. Get the Root Element Attributes
            var attributes = root.Attributes();

            //5. Add New XElement
            //document.Root.Add(new XElement("car", new XElement("make", "Audi")));
            //document.Save(@"../../../Data/cars_demo.xml");


            //foreach (var car in cars)
            //{
            //    //6. Remove element from the car
            //    car.SetElementValue("make", null);

            //    7. Remove all elements from the car
            //    car.RemoveAll();

            //    //Console.WriteLine($"{car.Element("make").Value} {car.Element("model").Value}");
            //}

            //document.Save(@"../../../Data/cars_modified.xml");

            //8. Parse each Car from the XML document into a Collection of <Car>
            var cars = root.Elements().Select(x => new Car
            {
                Make = x.Element("make").Value,
                Model = x.Element("model").Value,
                TravelledDistance = long.Parse(x.Element("travelled-distance").Value),
            });


            //*******************************//
            // Creating XML with XElement
            XDocument settings = new XDocument();
            settings.Add
                (
                    new XElement("settings", "Test")
                ); // the first element we add, is considered the Rooot Element !!!
            settings.Save(@"../../../Data/settings.xml");

            //9. Serialize any object to file
            var serializer = new XmlSerializer(typeof(Car));

            var books = new List<Book>
            {
                new Book("The Little Prince", "Exupery"),
                new Book("Istanbul", "Pamuk")
            };

            XmlSerializer xmlSerializer = new XmlSerializer(books.GetType());

            using (var writer = new StreamWriter(@"../../../Data/books_new.xml"))
            {
                xmlSerializer.Serialize(writer, books);
            }

            //10. Deserialize
            XmlSerializer carSerializer = new XmlSerializer(
                typeof(List<Car>), 
                new XmlRootAttribute("cars"));

            using var reader = new StreamReader(@"../../../Data/cars.xml");
            var carsXml = (List<Car>)carSerializer.Deserialize(reader);

            foreach (var car in carsXml.Where(x => x.Make == "Opel"))
            {
                Console.WriteLine(car);
            }

            //11. Binary Serializer
            //Add Attribute [Seralizable] on the class that will be Serialized/Deserialized
            //Serialize
            BinaryFormatter biFormatter = new BinaryFormatter();
            biFormatter.Serialize(File.OpenWrite(@"../../../Data/books.bin"), books);

            //Deserialize
            var booksObjList = (List<Book>)biFormatter.Deserialize(File.OpenRead(@"../../../Data/books.bin"));

        }

        [XmlType("cars")]
        public class XmlCar
        {
            [XmlArray]
            public IEnumerable<Car> Cars { get; set; }
        }

        [XmlType("car")]
        public class Car
        {
            [XmlElement("make")]
            public string Make { get; set; }

            [XmlElement("model")]
            public string Model { get; set; }

            [XmlElement("travelled-distance")]
            public long TravelledDistance { get; set; }

            public override string ToString()
            {
                return $"{ this.Make} {this.Model}";
            }
        }

        public class Book
        {
            public Book()
            {
            }

            public Book(string title, string author)
            {
                this.Title = title;
                this.Author = author;
            }

            public string Title { get; set; }

            public string  Author { get; set; }
        }
    }
}
