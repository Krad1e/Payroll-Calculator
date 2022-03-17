using System;
using System.IO;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            mainLoop(); //function call for main program
        }
    static void mainLoop()  //main program
        {
            string fileName = "";       //initialize blank fileName for user entry
            bool Entry = true;          
        do
        {
            if(Entry)
            {
                Entry = false;
            }
            else
            {
                Console.WriteLine("\nInvalid filename. Please enter a filename that is in your current directory.\n");      //print invalid filename if nonexistent
            }
            Console.WriteLine("Please enter your name:");                                                                   //prompt user to enter name
            string userName = Console.ReadLine();                                                                           //read userName 
            Console.WriteLine("\nPlease enter payroll file to be processed:");                                              //prompt user to enter filename
            fileName = Console.ReadLine();
            fileName = checkFileName(fileName);                                                                             //function call to check for .csv file
            Console.WriteLine($"\nHello {userName}\n");
            Console.WriteLine($"Welcome to the payroll processing application.\n");                                     
            Console.WriteLine("-----------------------------------------------\n");
        }
        while (fileName.Length > 0 && !File.Exists(fileName));
        Entry = true;
         {
         StreamReader fileReader = new StreamReader($"{fileName}");
            List<float> hoursWorked = new List<float>();
           while(!fileReader.EndOfStream)
           {
               string LineOfData = fileReader.ReadLine();
               string[] data = LineOfData.Split(",");
               string firstName = data[0];
               string lastName = data[1];
               int hours = int.Parse(data[2]);
               float payRate = float.Parse(data[3]);
               float totalPay = hours * payRate;
               hoursWorked.Add(totalPay);
               Console.WriteLine($"{firstName} {lastName}: ${totalPay:0.00}");
           }
           int numEmp = hoursWorked.Count; 
           float sum = 0;
           float max = float.MinValue;
           float min = float.MaxValue;
            foreach (float item in hoursWorked)
            {
                sum += item;

                if (item >= max)
                {
                    max = item;
                }

                if(item <= min)
                {
                    min = item;
                }
            }
            float avg = sum/numEmp;
    
    StreamWriter sw = new StreamWriter("salarySummary.txt");                        //create & write salarySummary file
    sw.WriteLine("Payroll Summary");                                                //write to file payroll 
    sw.WriteLine("---------------");                                                
    sw.WriteLine("Number of Employees paid: "+numEmp);                              //write total number of employees paid
    sw.WriteLine("Total Pay: $"+ sum);                                              //write total pay 
    sw.WriteLine("Average Pay: $" + avg);                                           //write average pay
    sw.WriteLine("Maximum Pay: $" + max);                                           //write max pay
    sw.WriteLine("Minimum Pay: $" + min);                                           //write min pay
    sw.Close();                                                                     //close streamwriter
        }
    Console.WriteLine("\nThe salarySummary.txt file was successfully written.");    //print success message to console
    Console.WriteLine("\nGoodbye!");                                                //print goodbye
    }      

//function to check for .csv and append if non-existent
        static string checkFileName(string fileName){
            if(fileName.EndsWith(".csv")){
                return fileName;
            }
            else{
                return fileName + ".csv";
            }
        } 
    }
}
