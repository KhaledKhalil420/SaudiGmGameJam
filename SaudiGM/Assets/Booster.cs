using UnityEngine;

public class Booster : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().CurrentSpeed = 250;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().CurrentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().Speed;
        }
    }
}
