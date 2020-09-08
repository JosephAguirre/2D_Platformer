using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }
    }

    void Die()
    {
        if (SceneManager.GetActiveScene().name == ("level1"))
        {
            SceneManager.LoadScene(1);
        }

        if (SceneManager.GetActiveScene().name == ("level2"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
