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
            Console.WriteLine("Estructura base de Agenda iniciada.");
        }
    }
}
