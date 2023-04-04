namespace Models.FinalProject;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Element { get; set; }
    public bool IsEvolve { get; set; }
    public string Abilities { get; set; }
    public int Hp { get; set; }
    public int AttackPoint { get; set; }
    public int DeffensePoint { get; set; }
    public int SpAttack { get; set; }
    public int SpDeffense { get; set; }
    public int Speed { get; set; }
}