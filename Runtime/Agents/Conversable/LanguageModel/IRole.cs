namespace Cohort.Agents.Conversable
{
    public interface IRole
    {
        public enum Type
        {
            System = 0,
            User = 1,
            Assistant = 2,
        }
    }
}
