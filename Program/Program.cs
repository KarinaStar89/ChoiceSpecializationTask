// Задача: Написать программу, которая из имеющегося массива строк формирует новый массив из строк, длина которых меньше, либо равна 3 символам. 
//Первоначальный массив можно ввести с клавиатуры, либо задать на старте выполнения алгоритма. 
//При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

// Примеры:
// [“Hello”, “2”, “world”, “:-)”] → [“2”, “:-)”]
// [“1234”, “1567”, “-2”, “computer science”] → [“-2”]
// [“Russia”, “Denmark”, “Kazan”] → []

string[] staticArray = new string[] { "234", "1567", "-2", "computer science" };
string[] initArray = new string[0];

var textMsg = $"Берем заранее подготовленный программой массив строк(нажмите клавишу 'y'), либо будем добавлять строки самостоятельно(нажмите клавишу 'n')? Если хотите выйти из программы нажмите 'q'";
Console.WriteLine(textMsg);
string? command = Console.ReadLine();
while (command != null && (command != "y" && command != "n" && command != "q"))
{
    Console.WriteLine("Допустимые команды y или n или q");
    Console.WriteLine(textMsg);
    command = Console.ReadLine();
}

if (command == "q")
{
    return;
}

if (command == "y")
{
    foreach (var item in staticArray)
    {
        initArray.Append(item);
    }
}

if (command == "n")
{
    Console.WriteLine("Введите строку");
    var item = Console.ReadLine();
    initArray.Append(item);
}
string[] filterArray = FilterArray(initArray);
string strFilterArray = PrintArray(filterArray);

Console.WriteLine($"Первоначальный массив: {initArray}");
Console.WriteLine($"Массив со строками с длинной меньшими либо равными 3 : {strFilterArray}");

string[] FilterArray(string[] array)
{
    string[] result = new string[0];
    for (int i = 0; i < array.Length; ++i)
    {
        if (array[i].Length <= 3)
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