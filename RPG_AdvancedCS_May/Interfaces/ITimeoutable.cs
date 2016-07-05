namespace RPG_AdvancedCS_May.Interfaces
{
    public interface ITimeoutable
    {
        int MaxLifespanInMS { get; set; }
        int CurrentLifespanInMS { get; set; }

        bool HasTimedOut { get; set; }
    }
}
