using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using Entidades;

namespace Negocio
{
    public class NPersona
    {
        public List<Persona> ListarPersonas()
        {
            DPersona dPersona = new DPersona();
            var personas = dPersona.Listar();
            return personas;
        }

        public List<Persona> ListarPersonasPorNombre(string nombre)
        {
            DPersona dPersona = new DPersona();
            var personas = dPersona.Listar();
            var personasFiltradas = personas.Where(p => p.Nombres.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
            return personasFiltradas;
        }

        public void RegistrarPersona(Persona persona)
        {
            DPersona dPersona = new DPersona();
            dPersona.Crear(persona);
        }

        public void ActualizarPersona(Persona persona)
        {
            DPersona dPersona = new DPersona();
            dPersona.Actualizar(persona);
        }

        public void EliminarPersona(int idPersona)
        {
            DPersona dPersona = new DPersona();
            dPersona.Eliminar(idPersona);
        }
    }
}