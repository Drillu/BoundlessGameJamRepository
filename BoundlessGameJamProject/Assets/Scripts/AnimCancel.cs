using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCancel : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;

    public float delTime;
    void Start()
    {
        StartCoroutine(del());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator del()
    {
        yield return new WaitForSeconds(delTime);
        Destroy(gameObject);
    }
}
