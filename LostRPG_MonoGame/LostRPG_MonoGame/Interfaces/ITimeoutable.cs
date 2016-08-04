namespace LostRPG_MonoGame.Interfaces
{
    public interface ITimeoutable
    {
        int MaxLifespanInMS { get; set; }
        int CurrentLifespanInMS { get; set; }

        bool HasTimedOut { get; set; }
    }
}
