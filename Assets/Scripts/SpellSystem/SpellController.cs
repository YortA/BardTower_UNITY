using UnityEngine;

public class SpellController : MonoBehaviour
{

    // Register the spells in the beginning. If we want to restrict these spells, we can simply remove them from the function (see note under RegisterSpells())
    private void Start()
    {
        RegisterSpells();
    }

    // We want to register available spells. Later on we can "unlock" spells and change this by referencing a spellbook and checking for bool
    public void RegisterSpells()
    {
        SpellManager.RegisterSpell(new OilSpill(), "qweqr");
        SpellManager.RegisterSpell(new Teleport(), "qqrwe");
    }

    // We get our unput and check to see if the spell exists, TRUE=CAST/FALSE=NULL
    public void CastSpell(string GetInput)
    {
        string playerInput = GetInput;
        ISpell mySpell = SpellManager.GetSpell(playerInput);

        if (mySpell == null)
        {
            Debug.Log("Incorrect Spell");
            return;
        }

        mySpell.Cast();
    }
}

// Use an interface to distribute our spell functionality, this makes it easier to work with the manager. Specific spells can have specific
// functions attached to them later (inside Cast() typically)
public interface ISpell
{
    bool IsEnabled { get; set; }
    void Cast();
}

public class OilSpill : ISpell
{
    public bool IsEnabled { get; set; } = false;

    public OilSpill()
    {
        IsEnabled = true;
    }

    public void Cast()
    {
        fireProjectile.projectile.StartCo();
        Debug.Log("====Oil Spill Casted!====");
    }
}
public class Teleport : ISpell
{
    public bool IsEnabled { get; set; } = false;

    public Teleport()
    {
        IsEnabled = true;
    }

    public void Cast()
    {
        Debug.Log("====Teleport Casted!====");
    }
}