using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour
{
    [SerializeField]float Duration;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().CurrentSpeed = 250;
            FindObjectOfType<Movement>().HasJumpAbility = true;
            FindObjectOfType<Movement>().CanRun = false;
        }
    }

    IEnumerator AbilityToJumpAfter()
    {
        yield return new WaitForSeconds(Duration);
        FindObjectOfType<Movement>().HasJumpAbility = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Movement>().CanRun = true;
            StartCoroutine(AbilityToJumpAfter());
            GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().CurrentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().Speed;
        }
    }
}
