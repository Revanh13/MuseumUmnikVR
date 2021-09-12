using System.Collections;
using UnityEngine;

public class ObjectRestorer : MonoBehaviour
{
    public float speed = 5f;
    
    private Vector3 startPos;
    private Vector3 startSize;
    private Quaternion startRot;

    private bool restore = false;
    private bool restoreCoroutine = false;

    private int countPickUp = 0;
    
    void Start()
    {
        startPos = GetComponent<Transform>().position;
        startSize = GetComponent<Transform>().localScale;
        startRot = GetComponent<Transform>().rotation;
    }

    private void Update()
    {
        if (countPickUp == 0) restore = true;

        if (restore)
        {
            if (!restoreCoroutine)
            {
                StartCoroutine(Restore());
                restoreCoroutine = true;
            }
            transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * speed);
            transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, Time.deltaTime* speed);
        }
    }

    public void Attach()
    {
        countPickUp++;
    }

    public void Detach()
    {
        countPickUp--;
    }

    private IEnumerator Restore()
    {
        yield return new WaitForSeconds(1f);
        restore = false;
        restoreCoroutine = false;
    }
}
