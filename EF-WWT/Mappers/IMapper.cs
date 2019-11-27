namespace EF_WWT.Mappers
{
    public interface IMapper<T,U>
    {
        T MapSource(U source);
        U MapDestination(T destination);
    }
}
