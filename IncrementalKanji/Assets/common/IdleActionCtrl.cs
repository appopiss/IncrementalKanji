using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class IdleActionCtrl : BASE {

    /// <summary>
    /// IIdleActionを実装しているComponentを入れる。
    /// </summary>
    public void Add(Component component)
    {
        IdleLists.Add(new IdleObject(component));
    }

    public class IdleObject
    {
        public IIdleAction IdleInterface;
        public GameObject gameObject;
        public IdleObject(Component IdleComponent)
        {
            if (IdleComponent is IIdleAction)
            {
                this.IdleInterface = IdleComponent as IIdleAction;
                this.gameObject = IdleComponent.gameObject;
            }
        }
    }
    public List<IdleObject> IdleLists;

	// Use this for initialization
	void Awake () {
		StartBASE();
        IdleLists = new List<IdleObject>();
        var components = FindObjectsOfInterface<IIdleAction>();
        if (components.Count != 0) {
            foreach (Component component in components)
            {
                IdleLists.Add(new IdleObject(component));
            }
        }
	}

	// Use this for initialization
	void Start () {
        StartCoroutine(RoopCor());
	}
	
	IEnumerator RoopCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(main.tick);

            if (IdleLists.Count != 0)
            {
                IdleLists.RemoveAll((IdleObject obj) => obj.gameObject == null);
                foreach (IdleObject obj in IdleLists)
                {
                    if (obj.gameObject != null)
                    {
                        obj.IdleInterface.IdleAction();
                    }
                }
            }
        }
    }
}
