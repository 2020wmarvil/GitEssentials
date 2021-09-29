using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] float speed = 2000f;
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] float projectileSpeed = 2000f;

	void Update() {
		// movement
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
		GetComponent<Rigidbody>().velocity = input.normalized * speed * Time.deltaTime;

		// random colors
		if (Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),
																Random.Range(0f, 1f),
																Random.Range(0f, 1f),
																0);
		}

		// fire projectiles
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 mouseDir = (mousePos - transform.position);
			mouseDir.z = 0f;
			mouseDir = mouseDir.normalized;

			GameObject projectile = Instantiate(projectilePrefab, transform.position + mouseDir * 2f, Quaternion.identity);
			Vector3 pos = projectile.transform.position;
			pos.z = 0f;
			projectile.transform.position = pos;
			projectile.GetComponent<Rigidbody>().AddForce(mouseDir * projectileSpeed);
		}
	}
}
