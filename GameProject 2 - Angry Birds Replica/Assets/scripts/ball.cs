using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    //making a rigdbody object named rb.
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    //setting the release time of the ball to .15 and making it public so that one can change it through unity editor.
    public float releaseTime = .15f;

    public float maxDragDistance = 2f;

    public GameObject nextBall;

    //makig a boolean isPressed which tells us whether we are pressing the mouse or not.
    private bool isPressed = false;

    void Update()
    {
        //this makes the ball follow the mouse pointer by calculating the co-ordinates and converting it to unity world points to prevent abrupt change.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isPressed)
        {
            if(Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
            else
            {
                rb.position = mousePos;
            }
            
        }
    }

    //making a ON Mouse down function which check if the mouse is clicked or not.
    void OnMouseDown()
    {
        //Debug.Log("Mouse Click!!");
        isPressed = true;
        // this kinematic make us enable the movement of the ball while the mouse is clicked.
        rb.isKinematic = true;
    }

    //making a ON Mouse Up func which tells us that we have released the mouse.
    void OnMouseUp()
    {
        //Debug.Log("Mouse not clicked !!");
        isPressed = false;
        // this kinematic make us divable the movement of the ball while the mouse is clicked.
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    // made a release coroutine to add delay to the release of the ball.
    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        //in releasing the ball, disabing the spring joint so our ball is not attached to the hook. 
        GetComponent<SpringJoint2D>().enabled = false;

        this.enabled = false;

        yield return new WaitForSeconds(5f);

        if(nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            Enemy.EnemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

    }
}
