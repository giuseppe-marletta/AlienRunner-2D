using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame    //gestione dei salvataggi
{
    public static void SavePoints(int points)
    {
        PlayerPrefs.SetInt("POINTS", points);
        PlayerPrefs.Save();
    }

    public static int GetPoints() 
    {
        return PlayerPrefs.GetInt("POINTS");
    }

    public static void SaveMusicVolume( float volume)
    {
        PlayerPrefs.SetFloat("MUSIC", volume);
        PlayerPrefs.Save();
    }

    public static void SaveSoundVolume( float volume)
    {
        PlayerPrefs.SetFloat("SOUND", volume);
        PlayerPrefs.Save();
    }


    public static void SaveResolution(int resolution)
    {
        PlayerPrefs.SetInt("RESOLUTION", resolution);
        PlayerPrefs.Save();
    }

    public static void SaveControls(int control)
    {
        PlayerPrefs.SetInt("CONTROLS",control);
        PlayerPrefs.Save();
    }

    public static int GetControls() 
    {
        return PlayerPrefs.GetInt("CONTROLS");
    }

    public static int GetResolution()
    {
        return PlayerPrefs.GetInt("RESOLUTION");
    }

    public static float GetMusic() 
    {
        return PlayerPrefs.GetFloat("MUSIC");
    }

    public static float GetSound() 
    {
        return PlayerPrefs.GetFloat("SOUND");
    }
    
}
