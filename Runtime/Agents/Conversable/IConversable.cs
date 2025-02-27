namespace Cohort.Agents.Conversable
{
    public interface IConversable<TContent> where TContent : IContent
    {
        IRole.Type Role { get; set; }
        TContent Content { get; set; }
    }
}
