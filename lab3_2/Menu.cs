using System;
using System.Collections.Generic;
using System.Text;
using BLL;
using DAL;

namespace lab3_2
{

    public static class Menu
    {
        #region service functions
        private static int SerializationChoice()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1 - BINARY");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - JSON");
            Console.WriteLine("4 - CUSTOM");
            Console.WriteLine("-----------------------------------------");

            string _input = Console.ReadLine();
            int input = int.Parse(_input);
            Console.Clear();
            if (input >= 1 && input <= 4)
            {
                return input;
            }
            else { return -1; }
        }
        private static int SerializationTypeChoice()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Оберіть тип даних які хочете зберегти: ");
            Console.WriteLine("\n1 - Зберегти студентів");
            Console.WriteLine("2 - Зберегти пекарів");
            Console.WriteLine("3 - Зберегти підприємців");
            Console.WriteLine("-----------------------------------------");

            string _input = Console.ReadLine();
            int input = int.Parse(_input);
            Console.Clear();
            if (input >= 1 && input <= 3)
            {
                return input;
            }
            else { return -1; }
        }
        private static int DeSerializationTypeChoice()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Оберіть тип даних які хочете десереалізувати: ");
            Console.WriteLine("\n1 - Десереалізувати студентів");
            Console.WriteLine("2 - Десереалізувати пекарів");
            Console.WriteLine("3 - Десереалізувати підприємців");
            Console.WriteLine("-----------------------------------------");

            string _input = Console.ReadLine();
            int input = int.Parse(_input);
            Console.Clear();
            if (input >= 1 && input <= 3)
            {
                return input;
            }
            else { return -1; }
        }

        private static void OutputStudent(Student student)
        {

            Console.WriteLine("\nName:" + student.Name);
            Console.WriteLine("Surname:" + student.Surname);
            Console.WriteLine("Age:" + student.Age);
            //  Console.WriteLine("BornOn:" + student.dateOfBirth.ToShortDateString());
            Console.WriteLine("ID:" + student.ID);
            Console.WriteLine("Year:" + student.Year);
            Console.WriteLine("StudentTicket:" + student.StudentTicket);
        }
        private static void OutputBaker(Baker baker)
        {
            Console.WriteLine("\nName:" + baker.Name);
            Console.WriteLine("Surname:" + baker.Surname);
            Console.WriteLine("Age:" + baker.Age);
            Console.WriteLine("BornOn:" + baker.dateOfBirth.ToShortDateString());
            Console.WriteLine("ID:" + baker.ID);
        }
        private static void OutputEnt(Entrepreneur entrepreneur)
        {
            Console.WriteLine("\nName:" + entrepreneur.Name);
            Console.WriteLine("Surname:" + entrepreneur.Surname);
            Console.WriteLine("Age:" + entrepreneur.Age);
            //    Console.WriteLine("BornOn:" + entrepreneur.dateOfBirth.ToShortDateString());
            Console.WriteLine("ID:" + entrepreneur.ID);
        }

        public static Student GetStudentByID(int ID, string path, int docType)
        {
            if (docType <= 0 && docType >= 4)
                throw new Exception("Перевірте коректність вводу даних");

            EntityService<List<Student>> ESStudents = new EntityService<List<Student>>(path);
            var listBinData = ESStudents.BinaryDeSerialization();
            var listXMLData = ESStudents.XMLDeSerialization();
            var listJSONData = ESStudents.JSONDeSerialization();
            switch (docType)
            {
                case 1:
                    foreach (var item in listBinData)
                    {
                        if (item.ID == ID)
                        {
                            return item;
                        }
                    }
                    break;
                case 2:
                    foreach (var item in listXMLData)
                    {
                        if (item.ID == ID)
                        {
                            return item;
                        }
                    }
                    break;
                case 3:
                    foreach (var item in listJSONData)
                    {
                        if (item.ID == ID)
                        {
                            return item;
                        }
                    }
                    break;
                default:
                    break;
            }

            throw new Exception("Не було знайдено жодного збігу за заданим ID");
        }

        private static Student AddStudent()
        {
            Console.Write("Ім'я: "); string inputName = Console.ReadLine();
            Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
            Console.Write("Вік: "); string _inputAge = Console.ReadLine(); int inputAge = int.Parse(_inputAge);
            Console.WriteLine("Дата народження у форматі ----/--/--");
            Console.Write("Рік: "); string _DATEyear = Console.ReadLine(); int DATEyear = int.Parse(_DATEyear);
            Console.Write("Місяць: "); string _DATEmonth = Console.ReadLine(); int DATEmonth = int.Parse(_DATEmonth);
            Console.Write("Дата: "); string _DATEday = Console.ReadLine(); int DATEday = int.Parse(_DATEday);
            DateTime dateTime = new DateTime(DATEyear, DATEmonth, DATEday);
            Console.Write("ID: "); string _inputID = Console.ReadLine(); int inputID = int.Parse(_inputID);
            Console.Write("Курс: "); string _inputYear = Console.ReadLine(); int inputYear = int.Parse(_inputYear);
            Console.Write("Номер квитка: "); string _inputTicket = Console.ReadLine(); int inputTicket = int.Parse(_inputTicket);

            return new Student(inputName, inputSurname, inputAge, inputID, inputYear, inputTicket, dateTime);
        }
        private static Baker AddBaker()
        {
            Console.Write("Ім'я: "); string inputName = Console.ReadLine();
            Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
            Console.Write("Вік: "); string _inputAge = Console.ReadLine(); int inputAge = int.Parse(_inputAge);
            Console.WriteLine("Дата народження у форматі ----/--/--");
            Console.Write("Рік: "); string _DATEyear = Console.ReadLine(); int DATEyear = int.Parse(_DATEyear);
            Console.Write("Місяць: "); string _DATEmonth = Console.ReadLine(); int DATEmonth = int.Parse(_DATEmonth);
            Console.Write("Дата: "); string _DATEday = Console.ReadLine(); int DATEday = int.Parse(_DATEday);
            DateTime dateTime = new DateTime(DATEyear, DATEmonth, DATEday);
            Console.Write("ID: "); string _inputID = Console.ReadLine(); int inputID = int.Parse(_inputID);

            return new Baker(inputName, inputSurname, inputAge, inputID, dateTime);
        }
        private static Entrepreneur AddEntrepreneur()
        {
            Console.Write("Ім'я: "); string inputName = Console.ReadLine();
            Console.Write("Прізвище: "); string inputSurname = Console.ReadLine();
            Console.Write("Вік: "); string _inputAge = Console.ReadLine(); int inputAge = int.Parse(_inputAge);
            Console.WriteLine("Дата народження у форматі ----/--/--");
            Console.Write("Рік: "); string _DATEyear = Console.ReadLine(); int DATEyear = int.Parse(_DATEyear);
            Console.Write("Місяць: "); string _DATEmonth = Console.ReadLine(); int DATEmonth = int.Parse(_DATEmonth);
            Console.Write("Дата: "); string _DATEday = Console.ReadLine(); int DATEday = int.Parse(_DATEday);
            DateTime dateTime = new DateTime(DATEyear, DATEmonth, DATEday);
            Console.Write("Досвід роботи: "); string _inputYear = Console.ReadLine(); int inputYear = int.Parse(_inputYear);
            Console.Write("ID: "); string _inputID = Console.ReadLine(); int inputID = int.Parse(_inputID);

            return new Entrepreneur(inputName, inputSurname, inputAge, inputID, inputYear, dateTime);
        }
        #endregion

        public static void MainMenu()
        {
            try
            {
                bool status = true;
                while (status)
                {
                    Console.WriteLine("\t\tMAIN MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Вивести БД");
                    Console.WriteLine("2 - Додати об'єкт до БД");
                    Console.WriteLine("3 - Видалити БД");
                    Console.WriteLine("4 - Пошук студентів 4 курсу");
                    Console.WriteLine("5 - Закінчити роботу");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);

                    switch (_str)
                    {
                        case 1:
                            {
                                Console.Clear();
                                OutputMenu();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                AppendMenu();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                DeleteMenu();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                GetSpecialStudents();
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            }

                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до MAIN MENU");
                            Console.ReadKey();
                            Console.Clear();
                            status = true;
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
        }
       
        #region service menus
        private static void AppendMenu()
        {
            List<Student> students = new List<Student>();
            List<Baker> bakers = new List<Baker>();
            List<Entrepreneur> entrepreneurs = new List<Entrepreneur>();
            try
            {
                bool status = true;
                while (status)
                {
                    Console.WriteLine("\t\tAPPEND MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Додати студента");
                    Console.WriteLine("2 - Додати пекаря");
                    Console.WriteLine("3 - Додати підприємця");
                    Console.WriteLine("4 - Зберегти дані до БД");
                    Console.WriteLine("5 - Повернутись до MAIN MENU");
                    Console.WriteLine("6 - Закінчити роботу з програмою");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);

                    switch (_str)
                    {
                        case 1:
                            {
                                Console.Clear();
                                students.Add(AddStudent());
                                Console.Clear();
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                bakers.Add(AddBaker());
                                Console.Clear();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                entrepreneurs.Add(AddEntrepreneur());
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                switch (SerializationTypeChoice())
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
                                            EntityService<List<Student>> ESStudentList = new EntityService<List<Student>>(inputPath);
                                            Console.Clear();
                                            switch (SerializationChoice())
                                            {

                                                case 1: ESStudentList.BinarySerialization(students); break;
                                                case 2: ESStudentList.XMLSerialization(students); break;
                                                case 3: ESStudentList.JSONSerialization(students); break;
                                                case 4: ESStudentList.CustomSerialization(students); break;
                                                default:
                                                    Console.WriteLine("Некоректне введення даних!\n\nНатисніть ENTER щоб повернутись до APPEND MENU");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    AppendMenu();
                                                    break;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
                                            EntityService<List<Baker>> ESBakerList = new EntityService<List<Baker>>(inputPath);
                                            Console.Clear();
                                            switch (SerializationChoice())
                                            {
                                                case 1: ESBakerList.BinarySerialization(bakers); break;
                                                case 2: ESBakerList.XMLSerialization(bakers); break;
                                                case 3: ESBakerList.JSONSerialization(bakers); break;
                                                case 4: ESBakerList.CustomSerialization(bakers); break;
                                                default:
                                                    Console.WriteLine("Некоректне введення даних!\n\nНатисніть ENTER щоб повернутись до APPEND MENU");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    AppendMenu();
                                                    break;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
                                            EntityService<List<Entrepreneur>> ESEntrepreneurList = new EntityService<List<Entrepreneur>>(inputPath);
                                            Console.Clear();
                                            switch (SerializationChoice())
                                            {
                                                case 1: ESEntrepreneurList.BinarySerialization(entrepreneurs); break;
                                                case 2: ESEntrepreneurList.XMLSerialization(entrepreneurs); break;
                                                case 3: ESEntrepreneurList.JSONSerialization(entrepreneurs); break;
                                                case 4: ESEntrepreneurList.CustomSerialization(entrepreneurs); break;

                                                default:
                                                    Console.WriteLine("Некоректне введення даних!\n\nНатисніть ENTER щоб повернутись до APPEND MENU");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                    AppendMenu();
                                                    break;
                                            }
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Некоректне введення даних!\n\nНатисніть ENTER щоб повернутись до APPEND MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        AppendMenu();
                                        break;
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.Clear();
                                MainMenu();
                                break;
                            }
                        case 6:
                            {
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до APPENT MENU");
                            Console.ReadKey();
                            Console.Clear();
                            status = true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до APPEND MENU");
                Console.ReadKey();
                Console.Clear();
                AppendMenu();
            }
        }
        private static void DeleteMenu()
        {
            try
            {
                bool status = true;
                while (status)
                {
                    Console.WriteLine("\t\tDELETE MENU");
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("1 - Видалити БД");
                    Console.WriteLine("2 - Повернутись до MAIN MENU");
                    Console.WriteLine("3 - Закінчити роботу");
                    Console.WriteLine("-----------------------------------------");

                    string str = Console.ReadLine();
                    int _str = int.Parse(str);
                    switch (_str)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
                                EntityService<List<object>> ES = new EntityService<List<object>>(inputPath);
                                Console.Clear();
                                switch (SerializationChoice())
                                {
                                    case 1: ES.ClearBinFileData(); break;
                                    case 2: ES.ClearXMLFileData(); break;
                                    case 3: ES.ClearJSONFileData(); break;
                                    case 4: ES.ClearCustomFileData(); break;
                                    default:
                                        Console.WriteLine("Некоректне введення даних!\n\nНатисніть ENTER щоб повернутись до DELETE MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        break;
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                MainMenu();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до DELETE MENU");
                            Console.ReadKey();
                            Console.Clear();
                            status = true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($@"Exception: {e.Message}");
                Console.Write("\nНатисніть ENTER щоб повернутись до DELETE MENU");
                Console.ReadKey();
                Console.Clear();
                DeleteMenu();
            }
        }
        private static void OutputMenu()
        {
            Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
            Console.Clear();
            EntityService<List<Student>> ESStudents = new EntityService<List<Student>>(inputPath);
            EntityService<List<Baker>> ESBakers = new EntityService<List<Baker>>(inputPath);
            EntityService<List<Entrepreneur>> ESEntrepreneur = new EntityService<List<Entrepreneur>>(inputPath);
            if (ESStudents.FileExists())
            {
                try
                {
                    bool status = true;
                    while (status)
                    {
                        switch (SerializationChoice())
                        {
                            case 1:
                                {
                                    Console.Clear();
                                    try
                                    {
                                        switch (DeSerializationTypeChoice())
                                        {
                                            case 1:
                                                foreach (var student in ESStudents.BinaryDeSerialization())
                                                {
                                                    OutputStudent(student);
                                                }
                                                break;
                                            case 2:
                                                foreach (var baker in ESBakers.BinaryDeSerialization())
                                                {
                                                    OutputBaker(baker);
                                                }
                                                break;
                                            case 3:
                                                foreach (var entrepreneur in ESEntrepreneur.BinaryDeSerialization())
                                                {
                                                    OutputEnt(entrepreneur);
                                                }
                                                break;

                                            default:
                                                Console.Clear();
                                                Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Заданий файл не містить даних сутностей!");
                                        Console.Write("\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        OutputMenu();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 2:
                                {
                                    Console.Clear();
                                    try
                                    {
                                        switch (DeSerializationTypeChoice())
                                        {
                                            case 1:
                                                foreach (var student in ESStudents.XMLDeSerialization())
                                                {
                                                    OutputStudent(student);
                                                }
                                                break;
                                            case 2:
                                                foreach (var baker in ESBakers.XMLDeSerialization())
                                                {
                                                    OutputBaker(baker);
                                                }
                                                break;
                                            case 3:
                                                foreach (var entrepreneur in ESEntrepreneur.XMLDeSerialization())
                                                {
                                                    OutputEnt(entrepreneur);
                                                }
                                                break;

                                            default:
                                                Console.Clear();
                                                Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($@"Exception: {e.Message}");
                                        Console.Write("\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        OutputMenu();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 3:
                                {
                                    Console.Clear();
                                    try
                                    {
                                        switch (DeSerializationTypeChoice())
                                        {
                                            case 1:
                                                foreach (var student in ESStudents.JSONDeSerialization())
                                                {
                                                    OutputStudent(student);
                                                }
                                                break;
                                            case 2:
                                                foreach (var baker in ESBakers.JSONDeSerialization())
                                                {
                                                    OutputBaker(baker);
                                                }
                                                break;
                                            case 3:
                                                foreach (var entrepreneur in ESEntrepreneur.JSONDeSerialization())
                                                {
                                                    OutputEnt(entrepreneur);
                                                }
                                                break;

                                            default:
                                                Console.Clear();
                                                Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($@"Exception: {e.Message}");
                                        Console.Write("\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        OutputMenu();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case 4:
                                {
                                    Console.Clear();
                                    try
                                    {
                                        switch (DeSerializationTypeChoice())
                                        {
                                            case 1:
                                                foreach (var student in ESStudents.CustomDeSerialization())
                                                {
                                                    OutputStudent(student);
                                                }
                                                break;
                                            case 2:
                                                foreach (var baker in ESBakers.CustomDeSerialization())
                                                {
                                                    OutputBaker(baker);
                                                }
                                                break;
                                            case 3:
                                                foreach (var entrepreneur in ESEntrepreneur.CustomDeSerialization())
                                                {
                                                    OutputEnt(entrepreneur);
                                                }
                                                break;

                                            default:
                                                Console.Clear();
                                                Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                                Console.ReadKey();
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($@"Exception: {e.Message}");
                                        Console.Write("\nНатисніть ENTER щоб повернутись до OUTPUT MENU");
                                        Console.ReadKey();
                                        Console.Clear();
                                        OutputMenu();
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            default:
                                Console.Clear();
                                Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до MAIN MENU");
                                Console.ReadKey();
                                Console.Clear();
                                MainMenu();
                                status = true;
                                break;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($@"Exception: {e.Message}");
                    Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Exception: Заданий файл не існує");
                Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
        }
        private static void GetSpecialStudents()
        {
            Console.WriteLine("Введіть назву файлу:"); string inputPath = Console.ReadLine();
            Console.Clear();
            EntityService<List<Student>> ESStudents = new EntityService<List<Student>>(inputPath);

            if (ESStudents.FileExists())
            {
                try
                {
                    switch (SerializationChoice())
                    {
                        case 1:
                            foreach (var student in ESStudents.BinaryDeSerialization())
                            {
                                if (student.Year == 4 && (student.dateOfBirth.Month <= 5 && student.dateOfBirth.Month >= 3))
                                {
                                    OutputStudent(student);
                                }
                            }
                            break;
                        case 2:
                            foreach (var student in ESStudents.XMLDeSerialization())
                            {
                                if (student.Year == 4 && (student.dateOfBirth.Month <= 11 && student.dateOfBirth.Month >= 9))
                                {
                                    OutputStudent(student);
                                }
                            }
                            break;
                        case 3:
                            foreach (var student in ESStudents.JSONDeSerialization())
                            {
                                if (student.Year == 4 && (student.dateOfBirth.Month <= 11 && student.dateOfBirth.Month >= 9))
                                {
                                    OutputStudent(student);
                                }
                            }
                            break;
                        case 4:
                            foreach (var student in ESStudents.CustomDeSerialization())
                            {
                                if (student.Year == 4 && (student.dateOfBirth.Month <= 11 && student.dateOfBirth.Month >= 9))
                                {
                                    OutputStudent(student);
                                }
                            }
                            break;
                        default:
                            Console.Clear();
                            Console.Write("Перевірте коректність вводу даних!\n\nНатисніть ENTER щоб повернутись до MAIN MENU");
                            Console.ReadKey();
                            Console.Clear();
                            MainMenu();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($@"Exception: {e.Message}");
                    Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                }
                finally { Console.ReadKey(); Console.Clear(); }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Exception: Заданий файл не існує");
                Console.Write("\nНатисніть ENTER щоб повернутись до MAIN MENU");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }

        }
        #endregion
    }
}

