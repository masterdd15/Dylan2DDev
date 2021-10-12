using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleMouseScript : MonoBehaviour
{

    Camera mainCamera;
    
    public TextMeshProUGUI clickText;

    private int points = 0;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void ClickCheck()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

            if(ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<SampleClickCircle>().ChangeColor(0);

                points += 1;
                clickText.text = "Clicks: " + points;
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<SampleClickCircle>().ChangeColor(1);

                points -= 1;
                clickText.text = $"Clicks: {points}";
            }
        }
    }

    private void Update()
    {
        ClickCheck();
    }
}
