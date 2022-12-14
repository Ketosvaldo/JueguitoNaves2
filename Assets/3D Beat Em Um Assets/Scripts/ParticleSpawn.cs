using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    public GameObject Particulas;
    public Transform[] ReferencePoints;

    public void InstantiateParticles(int index)
    {
        GameObject particulaInstanciada = Instantiate(
            Particulas, 
            new Vector3(
                ReferencePoints[index].transform.position.x, 
                ReferencePoints[index].transform.position.y, 
                ReferencePoints[index].transform.position.z), 
                Quaternion.identity
            );
        Destroy(particulaInstanciada, 2f);
    }
}
