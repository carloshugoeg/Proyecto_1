using Proyecto_1;

Estacionamiento estacionamiento = new Estacionamiento();
estacionamiento.IngresarEspacios();
do
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("-----APARTA PARQUEOS LA LANDIVAR------");
    Console.ResetColor();
    estacionamiento.VerEspacios();
    Console.WriteLine("\nSELECCIONE UNA OPCION");
    Console.WriteLine("     1. Registro de Vehiculos");
    Console.WriteLine("     2. Retiro de Vehiculos");
    Console.WriteLine("     3. Visualizacion de vehiculos estacionados");
    Console.WriteLine("     4. Salir");
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            estacionamiento.IngresarVehiculo(); break;
        case "2":
            estacionamiento.RetirarVehiculo();break;
        case "3":
            estacionamiento.VerVehiculos(); break;
            case "4": Environment.Exit(0); break;
    }
}while(true);
