namespace oop_gaponenkoo
{
    public enum ValjamakseTyyp
    {
        Palk,
        Toetus
    }

    public interface ITooline
    {
        ValjamakseTyyp ValjamakseTyyp { get; set; }
        double ArvutaPalk();
    }
}
