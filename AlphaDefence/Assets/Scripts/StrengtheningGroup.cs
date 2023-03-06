using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengtheningGroup : StrengtheningPool
{
    [SerializeField] float minTime, maxTime;
    [SerializeField] int minOutSt, maxOutSt;

    private PositioningInCircle pin;
    private Coroutine coroutine;
    void Start()
    {
        Create();
        pin = new PositioningInCircle(transform.parent.GetComponent<SphereCollider>().radius);            
    }
    void Update()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Positioning());
        }        
    }
    IEnumerator Positioning()
    {
        float rand = Random.Range(minTime, maxTime);

        yield return new WaitForSeconds(rand);
        coroutine = null;
        OutSt();
    }

    private void OutSt()
    {
        GameObject st;
        int randSize = Random.Range(minOutSt, maxOutSt);
        for(int i = 0; i < randSize; i++)
        {
            st = Out(Random.Range(0,inPool.Count-1));
            st.transform.localPosition = pin.Positioning();
        }

    }

}
