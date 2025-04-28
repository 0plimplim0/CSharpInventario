// Autor: Yoporolo
// Proyecto: Sistema de inventario
// Descripcion: Un sistema de inventario en consola c:

class objeto
{
    public string nombre;
    public int cantidad = 0;

    public static objeto newObjeto(string nombre)
    {
        objeto nuevoObjeto = new objeto();
        nuevoObjeto.nombre = nombre;
        return nuevoObjeto;
    }
}

class inventario
{   
    public static List<objeto> listaItems = new List<objeto>();
    public static int items = 0;

    public static void showItems()
    {
        Console.Clear();
        Console.WriteLine("Sistema de inventario | Items");
        foreach (objeto item in listaItems)
        {
            Console.WriteLine($"\nNombre: {item.nombre}\nCantidad: {item.cantidad}");
        }
        Console.Write("\nPresiona ENTER para volver.");
        Console.ReadLine();
    }

    public static void AgregarObjeto()
    {
        Console.Write("Nombre del item: ");
        string nombre = Console.ReadLine();
        objeto item = objeto.newObjeto(nombre);
        listaItems.Add(item);
        Console.WriteLine("El item se ha agregado correctamente.");
    }

    public static void EliminarObjeto()
    {
        Console.Write("Nombre del item: ");
        string nombre = Console.ReadLine();
        foreach(objeto item in listaItems)
        {
            if (item.nombre == nombre)
            {
                listaItems.Remove(item);
                Console.WriteLine("El item se ha eliminado correctamente.");
                return;
            }
        }
        Console.WriteLine("No hay ningún item con ese nombre.");

    }

    public static void EditarObjeto()
    {
        Console.Write("Nombre del item: ");
        string nombre = Console.ReadLine();

        foreach (objeto item in listaItems)
        {
            if (item.nombre == nombre)
            {
                Console.Write("Nueva cantidad: ");
                string cant = Console.ReadLine();
                try 
                {
                    int newCant = Convert.ToInt32(cant);
                    item.cantidad = newCant;
                    Console.WriteLine("Cantidad modificada correctamente.");
                }
                catch
                {
                    Console.WriteLine("Cantidad inválida.");
                }
                return;
            }
        }
        Console.WriteLine("No hay ningún item con ese nombre.");
    }

    public static void menuPrincipal()
    {
        bool ejecutando = true;
        while (ejecutando)
        {
            Console.Clear();
            Console.WriteLine("Sistema de inventario");
            Console.WriteLine("\nComandos:\n1. Agregar item\n2. Eliminar item\n3. Editar item (cantidad)\n4. Ver items\n5. Salir\n");
            Console.Write("Comando: ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    inventario.AgregarObjeto();
                    break;
                case "2":
                    inventario.EliminarObjeto();
                    break;
                case "3":
                    inventario.EditarObjeto();
                    break;
                case "4":
                    inventario.showItems();
                    break;
                case "5":
                    Console.WriteLine("Saliendo...");
                    ejecutando = false;
                    continue;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            Thread.Sleep(1000);
        }
    }
}

class Program
{
    static void Main()
    {
        inventario.menuPrincipal();
    }
}