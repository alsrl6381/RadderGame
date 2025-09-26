using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    private Joint nextJoint;
    private Joint previousJoint;
    private bool isEnable;
    private Image img;

    private Button button;

    private void Start()
    {
        isEnable = false;
        img = GetComponent<Image>();

        img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);

        button = GetComponent<Button>();
        button.onClick.AddListener(() => LineActivate());
    }


    public void SetJoint(Joint next, Joint prev)
    {
        nextJoint = next;
        previousJoint = prev;
    }
    public void LineActivate()
    {
        bool nb = nextJoint.IsConnected();
        bool pb = previousJoint.IsConnected();

        if (!nb && !pb)
        {
            nextJoint.SetNextJoint(previousJoint);
            previousJoint.SetNextJoint(nextJoint);

            isEnable = true;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);

            nextJoint.Connect();
            previousJoint.Connect();
        }
        else
        {
            Debug.Log("이미 연결되어 있는 다리가 있습니다.");
        }
    }
    
}
