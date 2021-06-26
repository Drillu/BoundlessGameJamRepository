using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Set : MonoBehaviour
{
    public Button[] btns;

    // Start is called before the first frame update
    void Start()
    {
        btns[0].GetComponent<Button>().onClick.AddListener(Menu);
        btns[1].GetComponent<Button>().onClick.AddListener(PlayAgain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Menu()
    {
        SceneManager.LoadScene(1);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }
}
