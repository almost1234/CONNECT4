using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeButton3D : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator buttonAnimation;
    public Animator textAnimation;
    public Animator cameraAnimation;
    public GameObject buttonUI;
    private Button theButton;

    private void Start()
    {
        theButton = gameObject.GetComponent<Button>();
        theButton.onClick.AddListener(delegate
        {
            StartCoroutine(pressedButton());
        });
    }

    public IEnumerator pressedButton() 
    {
        buttonAnimation.SetBool("ButtonClicked", true);
        textAnimation.SetBool("TextClicked", true);
        cameraAnimation.SetBool("cameraClicked", true);
        yield return new WaitForSeconds(4);
        buttonUI.SetActive(true);

    }
    


    // Update is called once per frame
    
}
