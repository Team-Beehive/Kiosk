using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskDatabaseFramework
{
    /// <summary>
    /// class for using the database
    /// </summary>
    public class MajorDatabase
    {
        private static string fileIOpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"MajorData.txt";

        Majors majors;

        public MajorDatabase()
        {
            majors = new Majors();
            PrintToFile();
        }

        public void PrintToFile()
        {
            LinkedList<MajorData> majorsData = majors.GetMajorsData();
            string theData = "";
            try
            {
                StreamWriter sw = new StreamWriter(fileIOpath, false, Encoding.ASCII);

                foreach (MajorData majorData in majorsData)
                {
                    theData += "Major_Name_:::  ";
                    theData += majorData.MajorName + "\n";

                    foreach (DegreeData degreeData in majorData.relatedCategories)
                    {
                        theData += "Degree_Name_:::  ";
                        theData += degreeData.degreeName + "\n";

                        theData += "Degree_type_:::  ";
                        foreach (string ofWors in degreeData.type)
                        {
                            theData += ofWors + " ";
                        }
                        theData += "\n";
                        theData += "Degree_about_:::  ";
                        foreach (string ofWors in degreeData.about)
                        {
                            theData += ofWors + " ";
                        }
                        theData += "\n";

                        theData += "Degree_campuses_:::  ";
                        foreach (string ofWors in degreeData.campuses)
                        {
                            theData += ofWors + " ";
                        }
                        theData += "\n\n";
                    }

                    theData += "\n\n\n";
                    sw.WriteLine(theData);
                    theData = "";
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
