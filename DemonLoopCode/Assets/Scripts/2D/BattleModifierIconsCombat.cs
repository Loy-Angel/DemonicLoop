using UnityEngine;
using UnityEngine.UI;

// Clase encargada de instanciar y eliminar los iconos de los modificadores de combate.
public class BattleModifierIconsCombat : MonoBehaviour
{
    // Funcion para mostrar un icono de modificador de batalla.
    public void ShowBattleModifierIcon(GameObject character, BattleModifiers battleModifier)
    {
        GameObject iconObject = new(character.name + battleModifier.Icon.name);
        
        Image iconImage = iconObject.AddComponent<Image>();

        iconImage.sprite = battleModifier.Icon;

        iconObject.transform.localScale = new(0.6f,0.6f,1f);

        iconObject.transform.SetParent(character.GetComponent<Stats>().CharFloatingBattleModifierIconSpace.transform);
    }

    // Funcion para eliminar un icono de modificador de batalla.
    public void DeleteBattleModifierIcon(GameObject character, BattleModifiers battleModifier)
    {
        var name = character.name + battleModifier.Icon.name;

        Destroy(GameObject.Find(name));
    }
}
