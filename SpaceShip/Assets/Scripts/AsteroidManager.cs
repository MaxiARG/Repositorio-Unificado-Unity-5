using UnityEngine;
using System.Collections;

public class AsteroidManager : MonoBehaviour {
	public Asteroid asteroid;
	int gridSpacing=26;
	int asteroidsPerAxis=10;


	void Start () {
		placeAsteroids ();	
	}

	void placeAsteroids(){
		for (int x = 0; x < asteroidsPerAxis; x++) {
			for (int y=0; y<asteroidsPerAxis; y++){
				for (int z=0; z<asteroidsPerAxis; z++){
					InstantiateAsteroids (x, y, z);
				}
			}
		}
	}

	void InstantiateAsteroids(int x, int y, int z){
		Instantiate (asteroid,
					new Vector3 (transform.position.x + x*gridSpacing+ Random.Range(-gridSpacing/2,gridSpacing/2), transform.position.y + y*gridSpacing+ Random.Range(-gridSpacing/2,gridSpacing/2), transform.position.z + z*gridSpacing+ Random.Range(-gridSpacing/2,gridSpacing/2)),
					Quaternion.identity);
		
	}

}
