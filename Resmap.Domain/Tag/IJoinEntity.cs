namespace Resmap.Domain
{
    public interface IJoinEntity<TEntity>
    {
        TEntity Navigation { get; set; }        
    }
}
