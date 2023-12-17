using UnityEngine;

public class Spikeball : MonoBehaviour
{
    public float swingSpeed = 2f; // Spikeball'ýn sallanma hýzý
    public float swingAngle = 30f; // Spikeball'ýn sallanma açýsý
    public float chainLength = 2f; // Zincir uzunluðu

    private float originalRotation;

    public Transform chainStartPoint; // Zincirin baþlangýç noktasý

    void Start()
    {
        originalRotation = transform.rotation.eulerAngles.z;

        // Zinciri baþlangýç noktasýna baðla
        if (chainStartPoint == null)
        {
            Debug.LogError("Zincir baþlangýç noktasý atanmamýþ!");
        }
        else
        {
            ConnectChain();
        }
    }

    void Update()
    {
        // Spikeball'ý sallama hareketini güncelle
        float rotationAmount = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, originalRotation - rotationAmount); // Negatif iþaret ekleyin
    }

    void ConnectChain()
    {
        // Zinciri baþlangýç noktasýna baðla
        DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D>();
        joint.connectedBody = chainStartPoint.GetComponent<Rigidbody2D>();
        joint.distance = chainLength;
        joint.autoConfigureDistance = false;

        // Sprite Renderer ekleyerek görüntü atayýn
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // Ýsterseniz sprite'ý burada atayabilirsiniz
        // spriteRenderer.sprite = yourSprite;
    }
}
