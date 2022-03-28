using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonMon
{
    // Maybe?
    // Each monmon has its own timer based on dexterity - high dex means they make moves faster
    // auto attack happens if player hasn't selected a move before their turn timer resets
    void AutoAttack();
    void Attack();
    void Defend();
    void TakeDamage(float damage);
    void HealSelf();


}
