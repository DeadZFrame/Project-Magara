using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    private Image Image => GetComponent<Image>();

    private Color _tempColor;

    private void Start()
    {
        var ımageColor = Image.color;
        _tempColor = ımageColor;

        switch (Random.Range(0, 2))
        {
            case 0 : 
                ımageColor.a = 1f; 
                StartCoroutine(ReduceAlpha());
                break;
            case 1 :
                ımageColor.a = 0f;
                StartCoroutine(IncreaseAlpha());
                break;
        }

        StartCoroutine(FindDestination());
    }

    private IEnumerator FindDestination()
    {
        var dest = new Vector3(Random.value, Random.value);

        while (transform.position != dest)
        {
            var lerp = Vector3.Lerp(transform.GetComponent<RectTransform>().anchoredPosition, dest, 0.05f);
            transform.position = lerp;
            yield return null;
        }
    }
    
    private IEnumerator IncreaseAlpha()
    {
        Image.color = Color.Lerp(Image.color, _tempColor, 0.01f);
        
        if (Image.color.a == 1f)
        {
            yield break;
        }

        yield return null;
        StartCoroutine(ReduceAlpha());
    }

    private IEnumerator ReduceAlpha()
    {
        Image.color = Color.Lerp(Image.color, new Color(1f, 1f, 1f, 0f), 0.01f);
        
        if (Image.color.a == 0)
        {
            yield break;
        }

        yield return null;
        StartCoroutine(IncreaseAlpha());
    }
}
