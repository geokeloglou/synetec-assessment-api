namespace SynetecAssessmentApi.Domain
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }

    public abstract class Entity : IBaseEntity
    {
        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
