using UnityEngine;

public class Spikeball : MonoBehaviour
{
    public float swingSpeed = 2f; // Spikeball'�n sallanma h�z�
    public float swingAngle = 30f; // Spikeball'�n sallanma a��s�
    public float chainLength = 2f; // Zincir uzunlu�u

    private float originalRotation;

    public Transform chainStartPoint; // Zincirin ba�lang�� noktas�

    void Start()
    {
        originalRotation = transform.rotation.eulerAngles.z;

        // Zinciri ba�lang�� noktas�na ba�la
        if (chainStartPoint == null)
        {
            Debug.LogError("Zincir ba�lang�� noktas� atanmam��!");
        }
        else
        {
            ConnectChain();
        }
    }

    void Update()
    {
        // Spikeball'� sallama hareketini g�ncelle
        float rotationAmount = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.rotation = Quaternion.Euler(0, 0, originalRotation - rotationAmount); // Negatif i�aret ekleyin
    }

    void ConnectChain()
    {
        // Zinciri ba�lang�� noktas�na ba�la
        DistanceJoint2D joint = gameObject.AddComponent<DistanceJoint2D>();
        joint.connectedBody = chainStartPoint.GetComponent<Rigidbody2D>();
        joint.distance = chainLength;
        joint.autoConfigureDistance = false;

        // Sprite Renderer ekleyerek g�r�nt� atay�n
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // �sterseniz sprite'� burada atayabilirsiniz
        // spriteRenderer.sprite = yourSprite;
    }
}
