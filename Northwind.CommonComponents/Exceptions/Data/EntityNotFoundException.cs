namespace Northwind.CommonComponents.Exceptions
{
    public class EntityNotFoundException : CustomDataException
    {
        public EntityNotFoundException() : base($"La operacion no se pudo realizar ya que no se encontro la entidad especificada.") { }
    }
}
