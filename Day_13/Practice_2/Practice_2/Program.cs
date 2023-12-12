using Practice_2;

string vehicleType = GetTypeInput();

Vehicle vehicle = CreateObject(vehicleType);

Vehicle CreateObject(string type)
{
    switch(type)
    {
        case "Combat":
            return new Combat();
        case "Consumer":
            return new Consumer();
        case "Public":
            return new Public();
        case "Sport":
            return new Sport();
        default:
            return null;
    }
}
string GetTypeInput()
{
    Console.WriteLine("Choose type of vehicle:");

    for (int i = 1; i <= 4; i++)
    {
        VehicleTypes currentType = (VehicleTypes)i;
        Console.WriteLine($"{i}. {currentType}");
    }

    int typeIndex;
    bool typeInput = false;

    do
    {
        int.TryParse(Console.ReadLine(), out typeIndex);
    } while (typeInput != true && (typeIndex <= 0 || typeIndex > 4));

    VehicleTypes chosenType = (VehicleTypes)typeIndex;

    return chosenType.ToString();
}
enum VehicleTypes
{
    Combat = 1,
    Consumer,
    Public,
    Sport
}