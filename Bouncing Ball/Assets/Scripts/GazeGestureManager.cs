using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{

    public static GazeGestureManager Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    // Use this for initialization
    void Start()
    {
        Instance = this;

        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        InitBall();

        recognizer = new GestureRecognizer();
        recognizer.Tapped += (e) => OnTapped();

        recognizer.StartCapturingGestures();
    }

    public void OnTapped()
    {
        if (Instance.gameObject.GetComponent<Rigidbody>().useGravity)
        {
            Instance.gameObject.GetComponent<Rigidbody>().useGravity = false;
            InitBall();
        }
        else
            Instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void OnReset()
    {
        Instance.gameObject.GetComponent<Rigidbody>().useGravity = false;
        InitBall();
    }

    public void OnForward()
    {
        System.Diagnostics.Debug.WriteLine("Forward");
        var ballPosition = Instance.GetComponent<Transform>().position;
        ballPosition.z += 1;
        Instance.GetComponent<Transform>().position = ballPosition;
    }

    public void OnBackward()
    {
        System.Diagnostics.Debug.WriteLine("Backward");
        var ballPosition = Instance.GetComponent<Transform>().position;
        ballPosition.z -= 1;
        Instance.GetComponent<Transform>().position = ballPosition;
    }

    public void OnMove()
    {
        Instance.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void InitBall()
    {
        Instance.gameObject.GetComponent<Transform>().position = Camera.main.transform.position + (Camera.main.transform.forward * 2f);
        Instance.gameObject.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Instance.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Instance.gameObject.GetComponent<Rigidbody>().rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
}
