using System;
using System.IO;
using System.Collections.Generic;

namespace VuetifyIconGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileMaker fM = new FileMaker();

            Console.WriteLine("Please enter desired save path: ");
            fM.savePath = Console.ReadLine();
          
            fM.ReadFile();
        }
    }
}

class Club
{
    public string ClubName
    {
        get; set;
    }

    public string ClubCode
    {
        get; set;
    }

    public string Content
    {
        get; set;
    }

    public Club(string name, string code)
    {
        ClubName = name;
        ClubCode = code;
        //Content = content;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

//Class for Reading txt files and Writing Vue files to user inputed path
class FileMaker
{
    string logoPath;
    string vuePath;
    public string savePath;

    public List<Club> ReadFile()
    {
        List<Club> myClub = new List<Club>();
        string[] fileName = new string[2];
        string[] seperator = {", "};
        string path = "C:\\codeine\\C# projects\\VuetifyIconGenerator\\assets\\input.txt";
       

        if (File.Exists(path))
        {
            using (StreamReader sR = new StreamReader(path))
            {
                while (!sR.EndOfStream)
                { string club = sR.ReadLine();
                    fileName = club.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                    myClub.Add(new Club(fileName[1], fileName[0]));
                }

                sR.Close();
            }
        }

        else
        {
            Console.WriteLine("No File");
        }

        foreach (Club c in myClub)
        {
            logoPath = "C:\\codeine\\C# projects\\VuetifyIconGenerator\\assets\\" + c.ClubCode + ".svg";
            string readContent;
            vuePath = savePath + "\\" + c.ClubCode + ".vue";

            if (File.Exists(logoPath))
            {
                using (StreamReader sR = new StreamReader(logoPath))
                {
                    while (!sR.EndOfStream)
                    {
                        readContent = sR.ReadToEnd();
                        Console.WriteLine(readContent);
                        using (StreamWriter sW = new StreamWriter(vuePath))
                        {
                            sW.WriteLine("<template>\n" + readContent + "\n</template>");
                        }
                    }
                }
            }


        }

        return myClub;
    }

}