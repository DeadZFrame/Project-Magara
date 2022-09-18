using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Environment
{
    public class Patrol : MonoBehaviour
    {
        private Image Image => GetComponent<Image>();

        private Color _tempColor;

        private void Start()
        {
            /*var ımageColor = Image.color;
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
            }*/

            StartCoroutine(FindDestination());
        }

        private IEnumerator FindDestination()
        {
            var randX = Random.Range(-900, 900);
            var randY = Random.Range(-100, -450);
        
            var pos = gameObject.GetComponent<RectTransform>();
            var dest = new Vector3(randX, randY);

            StartCoroutine(Anim(1f));
            
            while (pos.transform.position != dest)
            {
                pos.anchoredPosition = Vector2.Lerp(pos.anchoredPosition, dest, .05f);
                yield return null;
            }
        }

        private IEnumerator Anim(float time)
        {
            yield return new WaitForSeconds(time);
            UIManager.Instance.referance.GetComponent<Animator>().enabled = true;
        }

        private IEnumerator IncreaseAlpha()
        {
            var color = Image.color.a;
            while (color != 1)
            {
                Image.color = Color.Lerp(Image.color, _tempColor, 0.05f);
                yield return null;
            }

            StartCoroutine(ReduceAlpha());
        }

        private IEnumerator ReduceAlpha()
        {
            var color = Image.color.a;
            while (color != 0)
            {
                Image.color = Color.Lerp(Image.color, new Color(1f, 1f, 1f, 0f), 0.05f);
                yield return null;
            }
        
            StartCoroutine(IncreaseAlpha());
        }
    }
}
