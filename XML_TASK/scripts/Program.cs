using Microsoft.AspNetCore.Http;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace series
{

   


    class Program
    {


        //convert object data to xml string 
        public static string Serialize(object dataToSerialize)
        {
            if (dataToSerialize == null) return null;

            using (StringWriter stringwriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(dataToSerialize.GetType());
                serializer.Serialize(stringwriter, dataToSerialize);
                return stringwriter.ToString();
            }
        }

        static void Main(string[] args)
        {

       
            

                       
                        XmlSerializer serializer = new XmlSerializer(typeof(Employees));
                        using (TextReader reader = new StringReader(System.IO.File.ReadAllText("Employees.xml"))) //read from xml file
                        {
                            Employees result = (Employees)serializer.Deserialize(reader); //put all xml data in an object
                Console.WriteLine(result.Employee[1].name); //print the name of second employee as OBJECT
                Console.WriteLine(Program.Serialize(result)); //print all xml data from object
                        }
       


        }
    }
}