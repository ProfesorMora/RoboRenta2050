using UnityEngine;

public class ima : MonoBehaviour
{
    // Amplitud del movimiento (qué tan lejos sube y baja)
    public float amplitude = 0.5f;

    // Velocidad del movimiento (qué tan rápido sube y baja)
    public float speed = 1.0f;

    // Posición inicial del objeto
    private Vector3 initialPosition;

    // Start se llama una vez antes del primer frame
    void Start()
    {
        // Guardar la posición inicial del objeto
        initialPosition = transform.position;
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Calcular la nueva posición utilizando una onda sinusoidal
        float offset = Mathf.Sin(Time.time * speed) * amplitude;

        // Actualizar la posición del objeto en el eje Y
        transform.position = new Vector3(
            initialPosition.x, 
            initialPosition.y + offset, 
            initialPosition.z
        );
    }
}
