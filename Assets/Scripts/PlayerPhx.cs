using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhx : MonoBehaviour
{
	public PlayerMgr player;
	Vector3 eulerRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
		player.position = transform.localPosition;
		player = GetComponentInParent<PlayerMgr>();
    }

    // Update is called once per frame
    void Update()
    {
		// adjust speed
		if (Utils.Approximation(player.speed, player.desiredSpeed))
			player.speed = player.desiredSpeed;
		else if (player.speed < player.desiredSpeed)
			player.speed += player.acceleration * Time.deltaTime;
		else if (player.speed > player.desiredSpeed)
			player.speed -= player.acceleration * Time.deltaTime;
		player.speed = Utils.Clamp(player.speed, player.minSpeed, player.maxSpeed);

		// adjust position/rotation
		player.velocity.x = Mathf.Sin(player.heading * Mathf.Deg2Rad) * player.speed;
		player.velocity.z = Mathf.Cos(player.heading * Mathf.Deg2Rad) * player.speed;

		player.position += player.velocity * Time.deltaTime;

		transform.localPosition = player.position;

		eulerRotation.y = player.heading;
		transform.localEulerAngles = eulerRotation;
    }
}