using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHbar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 0)
        {
            Destroy(gameObject);
        }

        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}