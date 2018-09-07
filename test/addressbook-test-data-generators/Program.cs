﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            //StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];
            if (type == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(BaseTest.GenerateRandomString(10))
                    {
                        Header = BaseTest.GenerateRandomString(10),
                        Footer = BaseTest.GenerateRandomString(10)
                    });
                }
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);

                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }

                    else
                    if (format == "xml")
                    {
                        WriteGroupsToXmFile(groups, writer);

                    }
                    else
                    if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);

                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();

                }
                

            }
            else
            {
                
                if (type == "contacts")
                {
                    
                    List<ContactData> contact = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        contact.Add(new ContactData(BaseTest.GenerateRandomString(10))
                        {
                            Lastname = BaseTest.GenerateRandomString(10),
                            Address = BaseTest.GenerateRandomString(10),
                            Email =BaseTest.GenerateRandomString(10),
                            FaxFone = BaseTest.GenerateRandomString(10)
                        });
                    }
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "xml")
                    {
                        WriteContactsToXmFile(contact, writer);

                    }
                    else
                       if (format == "json")
                    {
                        WriteContactJsonFile(contact, writer);

                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format" + format);
                    }
                    writer.Close();
                }
            }   

        }

        private static void WriteContactJsonFile(List<ContactData> contact,StreamWriter writer)
        {
           
            writer.Write(JsonConvert.SerializeObject(contact, Newtonsoft.Json.Formatting.Indented));
        }

        private static void WriteContactsToXmFile(List<ContactData> contact, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contact); 
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {        
                Excel.Application app = new Excel.Application();
                app.Visible = true;
                Excel.Workbook wb = app.Workbooks.Add();
                Excel.Worksheet sheet = wb.ActiveSheet;
                int row = 1;

                foreach (GroupData group in groups)
                {
                    sheet.Cells[row, 1] = group.Name;
                    sheet.Cells[row, 2] = group.Header;
                    sheet.Cells[row, 3] = group.Footer;
                    row++;
                }
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
                File.Delete(fullPath);
                wb.SaveAs(fullPath);
                wb.Close();
                app.Visible = false;
                app.Quit();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void WriteGroupsToXmFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

        }
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {

            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

    }   
}
