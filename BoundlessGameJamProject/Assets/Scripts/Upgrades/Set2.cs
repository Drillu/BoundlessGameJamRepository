using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Set2 : MonoBehaviour
{
    // Start is called before the first frame update
    Button me;

    void Start()
    {
        me = gameObject.GetComponent<Button>();
        me.onClick.AddListener(upgr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void upgr()
    {
        SceneManager.LoadScene(3);
    }
}
