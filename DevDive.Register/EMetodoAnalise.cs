using System.ComponentModel;

namespace DevDive.Register
{
    public enum EMetodoAnalise
    {
        [Description("Visual")]
        Visual = 0,
        [Description("Ph Eur. 7th")]
        PhEur7th = 1,
        [Description("Organoleptic")]
        Organoleptic = 2,
        [Description("ICP-MS")]
        ICPMS = 3,

    }
}