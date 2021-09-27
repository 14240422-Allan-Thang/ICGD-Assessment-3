using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private List<Tween> activeTweens = new List<Tween>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activeTweens.Count != 0)
        {
            for (int i = 0; i < activeTweens.Count; i++)
            {
                if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) > 0.1f)
                {
                    float t = activeTweens[i].Time / activeTweens[i].Duration;
                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, t);
                    activeTweens[i].Time += Time.deltaTime;
                }
                if (Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos) <= 0.1f)
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    activeTweens.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TweenExists(Transform target)
    {
        for (int i = 0; i < activeTweens.Count; i++)
        {
            if (target == activeTweens[i].Target)
            {
                return true;
            }
        }
        return false;
    }
}
