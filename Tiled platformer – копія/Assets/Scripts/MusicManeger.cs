// ���� ��������� ������
// ������ ����������� ������ �� �������� ������ �� ��� �����
// �����'����� ������������ ����� ��� ����� � ���
using UnityEngine;

public class MusicManeger : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float musicFloat, soundEffectsFloat;

    public AudioSource musicAudio;
    public AudioSource[] soundEffectsAudio;

    // ��� �������� ���� ���������� �������� ������������
    private void Awake()
    {
        levelSoundSettings();
    }

    //���������� ���������� �����������
    private void levelSoundSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        // ������������ ���� �������
        musicAudio.volume = musicFloat;

        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
