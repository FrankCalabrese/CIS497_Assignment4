/*Frank Calabrese
 * Assignment 4
 * increments score if collides with player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrigger : MonoBehaviour
{
    private UIManager uIManager;

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            uIManager.score++;
        }
    }
}
