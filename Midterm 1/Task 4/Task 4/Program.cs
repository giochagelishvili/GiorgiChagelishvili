Console.WriteLine("To turn off program type \"exit\" otherwise enter the directory path");

string userInput = "";

while(userInput != "exit")
{
    userInput = Console.ReadLine();

    if (Directory.Exists(userInput) == false)
        Console.WriteLine($"The directory {userInput} doesn't exist.");
    else
    {
        printNames(userInput);
    }
}

void printNames(string path, int directoryIndex = 0)
{
    string[] files = Directory.GetFiles(path);

    foreach(string file in files)
        Console.WriteLine(file);

    string[] directories = Directory.GetDirectories(path);

    if (directoryIndex == directories.Length)
        return;

    if (directories.Length > 0)
        printNames(directories[directoryIndex], directoryIndex + 1);
}