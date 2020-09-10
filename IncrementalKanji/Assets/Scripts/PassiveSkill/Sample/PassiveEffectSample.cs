using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEffectSample : MonoBehaviour
{
    public static List<_Ally> allies = new List<_Ally>()
    {
        new _Ally(1, new Hoge_PassiveEffect(new LinearMethod(0, 0, 1))),
        new _Ally(2, new Hoge_PassiveEffect(new LinearMethod(0, 0, 1))),
        new _Ally(3, new Hoge_PassiveEffect(new LinearMethod(0, 0, 1))),
    };

    public class _Ally
    {
        public _Ally(long level, params IPassiveEffect[] effects)
        {
            this.level = level;
            this.effects.AddRange(effects);
        }
        public long level;
        public List<IPassiveEffect> effects = new List<IPassiveEffect>();
    }
}
