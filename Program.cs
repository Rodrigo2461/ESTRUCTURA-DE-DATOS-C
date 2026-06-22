/*
 * Realizado por Miguel Cahuasqui
 * MIGUEL ANTONIO PALMA LIOCA
 * JHON MICHAEL PANTA BUSTE
 * UNIVERSIDAD UEA 
 * ESTRUCTURA DE DATOS
 */

using System;

namespace AgendaTelefonica
{
    // 1. Estructura de Datos Obligatoria: Struct
    // Se utiliza un struct en lugar de una clase para Contacto porque un struct es un tipo por valor, 
    // lo que significa que se almacena en la memoria Stack (pila) en lugar del Heap. 
    // Al ser una estructura de datos ligera y simple, resulta mas eficiente en memoria y acceso.
    public struct Contacto
    {
        public string Nombre;
        public string Telefono;
        public string Correo;
        public string Categoria; 
    }

    // 2. Arquitectura Obligatoria: Clase Agenda (Logica de negocio)
    public class Agenda
    {
        // 2. Estructura de Datos Obligatoria: Arreglo clasico
        // Un arreglo es una estructura estatica de tamano fijo.
        private Contacto[] contactos;
        
        // Control manual de elementos
        private int indiceActual;

        public Agenda()
        {
            contactos = new Contacto[2]; // Inicializamos pequeño para probar el redimensionamiento
            indiceActual = 0;
        }

        public void AgregarContacto(Contacto nuevoContacto)
        {
            // Logica manual para controlar la capacidad del arreglo.
            if (indiceActual == contactos.Length)
            {
                RedimensionarArreglo();
            }

            contactos[indiceActual] = nuevoContacto;
            indiceActual++;
        }

        private void RedimensionarArreglo()
        {
            int nuevoTamano = contactos.Length * 2;
            Contacto[] nuevoArreglo = new Contacto[nuevoTamano];

            for (int i = 0; i < contactos.Length; i++)
            {
                nuevoArreglo[i] = contactos[i];
            }

            contactos = nuevoArreglo;
        }

        public void MostrarContactos()
        {
            Console.WriteLine("Lista de Contactos:");
            for (int i = 0; i < indiceActual; i++)
            {
                Console.WriteLine($"- {contactos[i].Nombre} | {contactos[i].Telefono} | {contactos[i].Correo} | {contactos[i].Categoria}");
            }
        }

        public void BuscarContacto(string nombre)
        {
            bool encontrado = false;
            for (int i = 0; i < indiceActual; i++)
            {
                if (contactos[i].Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Contacto Encontrado: {contactos[i].Nombre} | {contactos[i].Telefono} | {contactos[i].Correo}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
    }

    // 1. Arquitectura Obligatoria: Clase Program principal
    class Program
    {
        static void Main(string[] args)
        {
            Agenda miAgenda = new Agenda();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n=== MENÚ DE AGENDA TELEFÓNICA ===");
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Mostrar todos los Contactos");
                Console.WriteLine("3. Consultar Contacto por Nombre");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Contacto nuevoContacto = new Contacto();
                            Console.WriteLine("\n[Agregando nuevo contacto]");
                            Console.Write("Ingrese el Nombre: ");
                            nuevoContacto.Nombre = Console.ReadLine() ?? "";
                            Console.Write("Ingrese el Teléfono: ");
                            nuevoContacto.Telefono = Console.ReadLine() ?? "";
                            Console.Write("Ingrese el Correo: ");
                            nuevoContacto.Correo = Console.ReadLine() ?? "";
                            Console.Write("Ingrese la Categoría (Ej. Trabajo, Familia): ");
                            nuevoContacto.Categoria = Console.ReadLine() ?? "";
                            
                            miAgenda.AgregarContacto(nuevoContacto);
                            Console.WriteLine("=> Contacto agregado exitosamente.");
                            break;
                        case 2:
                            Console.WriteLine("\n[Listando contactos]");
                            miAgenda.MostrarContactos();
                            break;
                        case 3:
                            Console.WriteLine("\n[Buscando contacto]");
                            Console.Write("Ingrese el nombre exacto a consultar: ");
                            string nombre = Console.ReadLine() ?? "";
                            miAgenda.BuscarContacto(nombre);
                            break;
                        case 4:
                            Console.WriteLine("Saliendo de la agenda...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número.");
                    opcion = 0;
                }
            } while (opcion != 4);
        }
    }
}
