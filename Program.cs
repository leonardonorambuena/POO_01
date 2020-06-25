using System;
using System.Collections.Generic;

namespace POO_01
{
    class Program
    {
        static void Main(string[] args)
        {
             // mantenedor -> CRUD
             // Create -> Insertar o registrar, persistir los datos
             // Read -> Leer, Obtener la información
             // Update -> Modificar un registro
             // Delete -> Elimina un registro (No es muy utilizada)
            pintarMenu();
            
            

            
        }

        
        static void pintarMenu()
        {
            Menu menu = new Menu();
            int opt = 0;

            while (opt != menu.Salir)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------");
                foreach(string op in menu.opciones)
                {
                    Console.WriteLine(op);
                }
                Console.WriteLine("-------------------------------------");
                try 
                {
                    opt = int.Parse(Console.ReadLine());

                    switch(opt)
                    {
                        case 1:
                            menu.registrarCategoria();
                            break;
                        case 2:
                            menu.listarCategorias();
                            break;
                        case 3:
                            menu.registrarProducto();
                            break;
                        case 4:
                            menu.listarProductos();
                            break;
                        case 5:
                            menu.modificarProducto();
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Debe ingresar solo números");
                    Console.ReadKey();
                }
                

            }

           
        }

        
    }
}
