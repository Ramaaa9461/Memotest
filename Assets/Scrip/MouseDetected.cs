using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetected : MonoBehaviour
{
    public MeshRenderer front;

    private void OnMouseDown()
    {
        transform.rotation = Quaternion.LookRotation(-transform.forward);



        GameManager.instance.AddCard(gameObject);
    }
    
    IEnumerator FadeIn(Vector3 init_Rotation)
    {
        float progress = 0;
        Quaternion final_rotation = Quaternion.Inverse(transform.rotation);

        while (progress <= 1)
        {
            //transform.position = Vector3.Lerp(transform.position, final_rotation, progress);
            progress += Time.deltaTime;
            yield return null;
        }
        transform.rotation = final_rotation;
    }
}
