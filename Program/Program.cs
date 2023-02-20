// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
//Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

string[] staticArray = new string[] { "234", "1567", "-2", "computer science" };
string[] initArray = new string[0];
string[] tempArray = new string[0];

var textMsg = $"Берем заранее подготовленный программой массив строк(нажмите клавишу 'y'), либо будем добавлять строки самостоятельно(нажмите клавишу 'n')? Если хотите выйти из программы нажмите 'q'";
Console.WriteLine(textMsg);
string? command = Console.ReadLine();
command = ValidCmd(command);

if (command == "q")
{
    return;
}

if (command == "y")
{
    initArray = new string[staticArray.Length];
    Array.Copy(staticArray, initArray, staticArray.Length);
}

if (command == "n")
{
    Console.WriteLine("Необходимо добавить строку?");
    var strCommand = Console.ReadLine();
    strCommand = ValidCmd(strCommand);
    int i = 0;
    //string[] tempArray = new string[i + 1];
    while (strCommand != "n")
    {
        if (strCommand == "y")
        {
            initArray = new string[i + 1];
            Array.Copy(tempArray, initArray, tempArray.Length);

            Console.WriteLine("Введите строку");
            string? newStr = Console.ReadLine();
            initArray[i] = newStr;
            i++;

            tempArray = new string[i + 1];
            Array.Copy(initArray, tempArray, initArray.Length);

            Console.WriteLine("Необходимо добавить строку?");
            strCommand = Console.ReadLine();
            strCommand = ValidCmd(strCommand);
        }
        if (strCommand == "q")
        {
            return;
        }
        if (strCommand == "n")
        {
            break;
        }
    }
}

string[] filterArray = FilterArray(initArray);
string strInitArray = PrintArray(initArray);
string strFilterArray = PrintArray(filterArray);

Console.WriteLine($"Первоначальный массив: {strInitArray}");
Console.WriteLine($"Массив со строками с длинной меньшими либо равными 3 : {strFilterArray}");

// void AddToArray(string[] sourse, string[] temp, int i, string value)
// {
//     sourse = new string[i + 1];
//     Array.Copy(temp, sourse, temp.Length);

//     Console.WriteLine("Введите строку");
//     //string? newStr = Console.ReadLine();
//     sourse[i] = value;
//     i++;

//     temp = new string[i + 1];
//     Array.Copy(initArray, temp, initArray.Length);
// }

string ValidCmd(string? command)
{
    while (command != null && (command != "y" && command != "n" && command != "q"))
    {
        Console.WriteLine("Допустимые команды y или n или q");
        command = Console.ReadLine();
    }
    return command;
}

string[] FilterArray(string[] array)
{
    string[] tempArray = new string[0];
    string[] result = new string[0];
    int j = 0; 
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != null && array[i].Length <= 3)
        {
            Array.Copy(tempArray, result, tempArray.Length);
            result = new string[j + 1];
             
            result[j] = array[i];
             Console.WriteLine($"array[{j}] {result[j]}");
            tempArray = new string[j + 1];
            Array.Copy(result, tempArray, result.Length);
            j++;
        }
    }
   Console.WriteLine($"result {result.Length}");
    return result;
}

string PrintArray(string[] array)
{
    string result = "";
    for (var i = 0; i < array.Length; i++)
    {
        if (result != "")
        {
            result = $"{result}, {array[i]}";
        }
        else
        {
            result = $"{array[i]}";
        }
    }
    return $"[{result}]";
}