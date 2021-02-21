using System.Collections.Generic;

public class SpellManager
{
    static protected Dictionary<string, ISpell> spellDict = new Dictionary<string, ISpell>();

    static public ISpell GetSpell(string spellInput)
    {
        ISpell result;

        if (!spellDict.TryGetValue(spellInput, out result) || !result.IsEnabled)
        {
            return null;
        }

        return result;
    }

    static public void RegisterSpell(ISpell spell, string spellCode)
    {
        spellDict[spellCode] = spell;
    }
}
