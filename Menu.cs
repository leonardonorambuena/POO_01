using System;
using System.Collections.Generic;
using System.Linq;

public class Menu
{
    public Menu()
    {
        opciones = new List<string>();
        opciones.Add("1- Registrar Categoría");
        opciones.Add("2- Listar Categorías");
        opciones.Add("3- Registrar Producto");
        opciones.Add("4- Listar Productos");
        opciones.Add("5- Modificar Producto");
        opciones.Add("6- Eliminar Producto");
        opciones.Add($"{Salir}- Salir del sistema");
        categorias = new List<Categoria>();
        productos = new List<Producto>();
    }
    public List<string> opciones { get; set; }

    public List<Categoria> categorias { get; set; }

    public List<Producto> productos { get; set; }

    public int Salir = 10;


    public void registrarCategoria()
    {
        Categoria cat = new Categoria();
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Registrar nueva Categoría");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Ingrese el nombre de la categoría");
        cat.Nombre = Console.ReadLine();

        if (categorias.Any(x => x.Nombre.ToUpper() == cat.Nombre.ToUpper()))
        {
            Console.WriteLine("La categoría ya existe");
            Console.ReadKey();
            return;
        }

        categorias.Add(cat);
    }

    public void modificarProducto()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Actualizar Producto");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Ingrese el SKU del producto");
        int sku = int.Parse(Console.ReadLine());

        Producto prod = productos.FirstOrDefault(x => x.SKU == sku);

        if (prod == null)
        {
            Console.WriteLine("Producto no encontrado, imposible actualizar");
            Console.ReadKey();
            return;
        }

        Console.WriteLine($"Nombre Actual ({prod.Nombre}) | Ingrese nuevo nombre");
        prod.Nombre = Console.ReadLine();

        Console.WriteLine($"Precio Actual ({prod.Precio}) | Ingrese nuevo precio");
        prod.Precio = int.Parse(Console.ReadLine());

        Console.WriteLine($"Categoría Actual ({prod.Categoria.Nombre}) | Ingrese nueva categoría");
        string nomCat = Console.ReadLine();
        Categoria cat = categorias.FirstOrDefault(x => x.Nombre == nomCat);
        if (cat == null)
        {
            Console.WriteLine($"No se encontró la categoría, el producto quedó con la categoría {prod.Categoria.Nombre}");
            Console.ReadKey();
            return;
        }

        prod.Categoria = cat;


        
    }

    public void registrarProducto()
    {
        Producto prod = new Producto();
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Registrar nuevo Producto");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Ingrese el SKU del producto");
        prod.SKU = int.Parse(Console.ReadLine());
        if (productos.Any(x => x.SKU == prod.SKU))
        {
            Console.WriteLine("El sku ya se encuentra registrado");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Ingrese el precio del producto");
        prod.Precio = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el nombre del producto");
        prod.Nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la categoría del producto");
        string nomCat = Console.ReadLine();

        if (!categorias.Any(x => x.Nombre.ToUpper() == nomCat.ToUpper()))
        {
            Console.WriteLine("La categoría no existe");
            Console.ReadKey();
            return;
        }
        prod.Categoria = categorias.First(x => x.Nombre.ToUpper() == nomCat.ToUpper());
        productos.Add(prod);
    }

    public void listarProductos()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Productos Registrados");
        Console.WriteLine("-----------------------------------");
        if (productos.Count == 0) {
            Console.WriteLine("No se han registrado productos");
            Console.ReadKey();
            return;
        } 
        foreach (Producto prod in productos) {
            Console.WriteLine($"sku: {prod.SKU} | nombre: {prod.Nombre} | precio: {prod.Precio} | Categoría: {prod.Categoria.Nombre}");
        }

        Console.ReadKey();
    }

    public void listarCategorias()
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Categorías Registradas");
        Console.WriteLine("-----------------------------------");
        if (categorias.Count == 0) {
            Console.WriteLine("No se han registrado categorías");
            Console.ReadKey();
            return;
        } 
        foreach (Categoria cat in categorias) {
            Console.WriteLine(cat.Nombre);
        }

        Console.ReadKey();
    }
}