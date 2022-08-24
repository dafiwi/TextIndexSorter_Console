using System;
using System.IO;

namespace TextIndexSorter
{
    internal class Program
    {
        static string textInput;
        static char separator = ',';
        static string[] textIndex;
        static StringSplitOptions options;

        static string fileName = @".\SortedTextIndex";
        static string fileType = ".txt";
        static string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        static void Main(string[] args)
        {
            Console.WriteLine("Text Index Sorter");
            EnterTextIndex();
            SpecifyDelimiter();
            SortTextIndex();
            ShowSortedTextIndex();
            ChooseFileType();
            ChooseSortedTextIndexFormatAndSaveFile();            
            QuitProgram();
        }

        static void EnterTextIndex()
        {
            Console.WriteLine("\nPlease enter your text index here: ");
            textInput = Console.ReadLine();
        }

        static void SpecifyDelimiter()
        {
            Console.WriteLine("\nThe standard text delimiter is comma. Do you want to change the delimiter character? y/n");
            char delimiterInput = Console.ReadKey().KeyChar;

            if (delimiterInput == 'y')
            {
                Console.WriteLine("\n\nPlease enter your desired delimiter character: ");
                separator = Console.ReadKey().KeyChar;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nYou changed the delimiter character to " + separator);
            }
        }

        static void SortTextIndex()
        {
            Console.ForegroundColor = ConsoleColor.White;
            textIndex = textInput.Split(separator, options = StringSplitOptions.TrimEntries);
            Array.Sort(textIndex);
        }

        static void ShowSortedTextIndex()
        {
            Console.WriteLine("\n\nHere is your text index sorted in alphabetical order:\n");
            foreach (string bulletPoint in textIndex)
            {
                Console.WriteLine(bulletPoint);
            }
        }

        static void ChooseFileType()
        {
            Console.WriteLine($"\nThe standard file type is {fileType.Substring(1)}. Do you want to change the file type? y/n");
            char fileTypeInput = Console.ReadKey().KeyChar;

            if (fileTypeInput == 'y')
            {
                Console.WriteLine("\nWhich file type do you choose?\n");
                Console.WriteLine("1 .txt");
                Console.WriteLine("2 .rtf");
                char fileTypeChoice = Console.ReadKey().KeyChar;

                switch (fileTypeChoice)
                {
                    case '1':
                        fileType = ".txt";
                        break;
                    case '2':
                        fileType = ".rtf";
                        break;
                    default:
                        fileType = ".txt";
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nYou chose {fileType.Substring(1)} as your file type.");
            }
        }

        static void ChooseSortedTextIndexFormatAndSaveFile()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nWhat will be the name of the file with the sorted text index? (Press Enter to skip)");
            string fileNameChoice = Console.ReadLine();

            if (String.IsNullOrEmpty(fileNameChoice))
            {
                Console.WriteLine($"\nYou didn't choose a file name. The standard file name is {fileName.Substring(2)}.");
            }
            else
            {
                fileName = ".\\" + fileNameChoice;
                Console.WriteLine($"\nYou chose {fileName.Substring(2)} as your file name.");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nHow do you want to save your sorted text index?\n");
            Console.WriteLine("1 Line by line as shown in the console");
            Console.WriteLine("2 Line by line and separated with commas");
            Console.WriteLine("3 Keyword after keyword in a paragraph and separated with commas");
            char textIndexFormatChoice = Console.ReadKey().KeyChar;

            switch (textIndexFormatChoice)
            {
                case '1':
                    using (StreamWriter file = new StreamWriter(filePath + fileName + fileType))
                    {
                        foreach (string bulletPoint in textIndex)
                        {
                            file.WriteLine(bulletPoint);
                        }
                    }
                    break;
                case '2':
                    using (StreamWriter file = new StreamWriter(filePath + fileName + fileType))
                    {
                        int index = 0;
                        int lastBulletpoint = textIndex.Length - 1;

                        foreach (string bulletPoint in textIndex)
                        {
                            if (index == lastBulletpoint)
                            {
                                file.WriteLine(bulletPoint);
                            }
                            else
                            {
                                file.WriteLine(bulletPoint + ", ");
                            }
                            index++;
                        }
                    }
                    break;
                case '3':
                    using (StreamWriter file = new StreamWriter(filePath + fileName + fileType))
                    {
                        int index = 0;
                        int lastBulletpoint = textIndex.Length - 1;

                        foreach (string bulletPoint in textIndex)
                        {
                            if (index == lastBulletpoint)
                            {
                                file.Write(bulletPoint);
                            }
                            else
                            {
                                file.Write(bulletPoint + ", ");                                
                            }
                            index++;
                        }
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: You pressed a wrong button and didn't choose a text index format.");
                    QuitProgram();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nThe sorted text index was successfully saved on your desktop as a {fileType.Substring(1)} file with the name {fileName.Substring(2)}.");
        }        

        static void QuitProgram()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPlease press any key to quit the program.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}