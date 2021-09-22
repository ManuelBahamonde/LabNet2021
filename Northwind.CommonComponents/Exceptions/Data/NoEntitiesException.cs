namespace Northwind.CommonComponents.Exceptions
{
    public class NoEntitiesException : CustomDataException
    {
        public NoEntitiesException() : base("No hay entidades cargadas. Antes de realizar esta accion, se debe crear al menos una entidad.") { } 
    }
}
