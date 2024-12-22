using Game;
using Patchwork;
using Onyx;
using UnityEngine;
using Game.GameData;

namespace lukeee_g_DisableScreenShake
{
    [ModifiesType]
    public class Lukeee_gGameEquipment : Game.Equipment
    {
        [ModifiesMember("HasEquipmentSlot")]
        public bool HasEquipmentSlot(EquipmentSlot slot)
        {
            // Commented the check for the character race Godlike
            //CharacterStats component = base.GetComponent<CharacterStats>();
            //if (slot == EquipmentSlot.Head)
            //{
            //    return !component || component.CharacterRace != Race.Godlike;
            //}
            if (slot == EquipmentSlot.Pet)
            {
                StatusEffectManager component2 = base.GetComponent<StatusEffectManager>();
                return base.GetComponent<Player>() || GameState.Instance.UnlockPets || component2.HasStatusEffectByType(StatusEffectType.AllowPetSlot);
            }
            return true;
        }
    }
}
