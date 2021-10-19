using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuelAnimation : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public List<Sprite> imageList = new List<Sprite>();
    public float delay = 1.0f;
    public float moveSpeed = 1.0f;

    public AnimationCurve animationCurve;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        //StartCoroutine(Animate());
        //StartCoroutine(Move());
        StartCoroutine(EvalCurve());
    }

    IEnumerator EvalCurve()
    {
        float t = 0.0f;

        while (true)
        {
            t = 0.0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime;
                transform.position = new Vector3(animationCurve.Evaluate(t), 0.0f, 0.0f);
                yield return null;
            }
        }
    }

    IEnumerator Animate()
    {
        int counter = 0;

        while(true)
        {
            spriteRenderer.sprite = imageList[counter];
            yield return new WaitForSeconds(delay);
            counter += 1;

            if(counter > imageList.Count - 1)
            {
                counter = 0;
            }
        }

        Debug.Log("Start Coroutine");
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(2.0f);

        spriteRenderer.color = Color.black;
        Debug.Log("End Courtine");
    }

    IEnumerator Move()
    {
        while(true)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z);
            yield return null;
            if(transform.position.x < -8.0f)
            {
                transform.position = new Vector3(8.0f, transform.position.y, transform.position.z);
            }
        }
    }
}
