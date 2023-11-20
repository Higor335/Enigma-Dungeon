using UnityEngine;

public class PlayerMovementSound : MonoBehaviour
{
    private AudioSource playerAudioSource;
    public AudioClip playerMovingSound;   // Atribua o som de andar no Inspector

    private void Start()
    {
        // Obtém ou adiciona um AudioSource ao objeto
        playerAudioSource = GetComponent<AudioSource>();
        
        if (playerAudioSource == null)
        {
            // Se não houver um AudioSource no objeto, adiciona um
            playerAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Define o AudioClip para o som de andar
        playerAudioSource.clip = playerMovingSound;
    }

    private void Update()
    {
        // Verifica se o jogador está se movendo
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isMoving = (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);

        // Executa ação com base no movimento
        if (isMoving)
        {
            if (!playerAudioSource.isPlaying)
            {
                // Se o jogador está se movendo e o som não está sendo reproduzido, toca o som de andar
                playerAudioSource.Play();
            }
        }
        else
        {
            // Se o jogador parou de se mover, para o som
            playerAudioSource.Stop();
        }
    }
}
