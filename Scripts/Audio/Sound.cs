using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //Indica que uma classe ou uma estrutura pode ser iniciada
public class Sound {

	public string name;
	public AudioClip clip;
	[Range(0f, 1f)]
	public float volume;  //Criar volume e Range define a mesma
	[Range(.0f, 3f)]
	public float pitch;
	[HideInInspector] // Faz com que uma variável não apareça no inspetor mas seja iniciada
	public AudioSource source;

	
}
