namespace StarshipResupply.Domain.Model.Starship
{
    /// <summary>
    /// The hours use to calculation (abbreviated by a multiple of 24).
    /// </summary>
    public enum Hours
    {
        Unkwnow = 0,
        InDay = 24,
        InMonth = 720,
        InWeek = 168,
        InYear = 8760
    }
}