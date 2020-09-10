using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BASE;

public class Hoge_PassiveEffect : AnonymousAddSingle_LevelEffect, IPassiveEffect
{
    public Hoge_PassiveEffect(ICalculateMethod method) : base("Hoge", 1, main.passiveEffectContainer.hoge_effect_add, method) { }
}