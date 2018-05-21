using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 TargetPos;

    public float moveSpeed;

    private float shakeTimer;
    private float shakeAmount;

	// Use this for initialization
	void Start () {
        //reikna legd milli spilara og cameru
        //offset = new Vector3(0.0f, 0.0f, -10f);
        
	}
    void Update()
    {
        if(shakeTimer > 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
    }
    private void LateUpdate()
    {
        TargetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp (transform.position, TargetPos,moveSpeed * Time.deltaTime);
    }
    public void StartShake(float time, float amount)
    {
        shakeTimer = time;
        shakeAmount = amount;
    }
}
