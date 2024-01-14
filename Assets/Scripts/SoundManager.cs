using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource audioSource;
    public TMP_Dropdown soundDropdown;
    public AudioMixerGroup outputMixerGroup;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (outputMixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = outputMixerGroup;
        }

        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        soundDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> dropdownOptions = new List<TMP_Dropdown.OptionData>();
        foreach (AudioClip sound in sounds)
        {
            dropdownOptions.Add(new TMP_Dropdown.OptionData(sound.name));
        }

        soundDropdown.AddOptions(dropdownOptions);
    }

    public void PlaySelectedSound()
    {
        int selectedSoundIndex = soundDropdown.value;

        if (selectedSoundIndex >= 0 && selectedSoundIndex < sounds.Length)
        {
            audioSource.clip = sounds[selectedSoundIndex];
            audioSource.Play();
        }
    }
}
