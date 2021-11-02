using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBuddy : MonoBehaviour
{

    public float speed = 1.0f;

    Vector2 nextLocation = new Vector2();
    MyGridSystem gridSystem;
    SpriteRenderer spriteRenderer;

    public bool isActive;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    // Setting the grid system & setting isActive to true
    void Start()
    {
        gridSystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<MyGridSystem>();
        isActive = true;
    }

    /// <summary>
    /// While isActive is true, move this gameobject to a new locationm, wait 1 second
    /// 
    /// </summary>
    /// <returns></returns>

    IEnumerator MoveToLocation()
    {
        while(isActive)
        {
            float t = 0.0f;
            nextLocation = gridSystem.GetRandomLocation();
            Vector2 startLocation = transform.position;
            while(t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.position = Vector2.Lerp(startLocation, nextLocation, t);
                yield return null;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
