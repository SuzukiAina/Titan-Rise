using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    private Animator targetAnimator;
    private AudioSource audioSource;
    public bool hit;
    private float hitValue=0;
    // Start is called before the first frame update
    public UnityEvent hitEvent;
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        targetAnimator.SetFloat("flag",hitValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetAnimator != null)
        {
            if (hit)
            {
                hitValue = Mathf.MoveTowards(hitValue, 1f, Time.deltaTime);
                targetAnimator.SetFloat("flag",hitValue);
            }
            else
            {
                hitValue = Mathf.MoveTowards(hitValue, 0f, Time.deltaTime);
                targetAnimator.SetFloat("flag",hitValue);
            }
        }
    }

    public void Hitted()
    {
        hit = true;
        audioSource.Play();
        StartCoroutine(Wait());
    }

    public void TargetSelfDestroy()
    {
        Destroy(this.gameObject);
    }
    
    public IEnumerator SmoothLerp (Vector3 endTransform,float time)
    {
        Vector3 startingPos  = transform.localPosition;
        Vector3 finalPos = endTransform;
        float elapsedTime = 0f;
         
        while (elapsedTime < time)
        {
            transform.localPosition = Vector3.Lerp(startingPos, finalPos, elapsedTime);
            elapsedTime += Time.deltaTime/time;
            yield return null;
        }

        transform.localPosition = endTransform;
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        hitEvent.Invoke();
    }
}
