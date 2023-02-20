// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
//Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

string[] staticArray = new string[] { "234", "1567", "-2", "computer science" };
string[] initArray= new string[0];

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
    foreach (var item in staticArray)
    {
        initArray.Append(item);
    }
}

if (command == "n")
{
    Console.WriteLine("Необходимо добавить строку?");
    var strCommand = Console.ReadLine();
    strCommand = ValidCmd(strCommand);
    int i = 0;
    //string[] tempArray = new string[i + 1];
     Console.WriteLine($"{strCommand} strCommand");
    while (strCommand != "n")
    {
        Console.WriteLine($"{command} strCommand");
        if (strCommand == "y")
        {         
            
            //Array.Copy(tempArray, initArray, tempArray.Length);

            Console.WriteLine("Введите строку");
            string? newStr = Console.ReadLine();
            initArray.Append(newStr);
           
            //Array.Copy(initArray, tempArray, initArray.Length);
            i++;

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

string ValidCmd(string? command)
{
    while (command != null && (command != "y" && command != "n" && command != "q"))
    {
        Console.WriteLine("Допустимые команды y или n или q");
        
        Console.WriteLine(textMsg);
        command = Console.ReadLine();
    }
    return command;
}

string[] FilterArray(string[] array)
{
    string[] result = new string[array.Length];
    for (int i = 0; i < array.Length; ++i)
    {
        if (array[i] != null && array[i].Length <= 3)
        {
            result.Append(array[i]);
        }
    }

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