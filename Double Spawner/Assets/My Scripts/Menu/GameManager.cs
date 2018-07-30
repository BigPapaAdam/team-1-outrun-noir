using UnityEngine;

public class GameManager
{
    public bool Fullscreen;
    public int Resolutionindex;
    public float Musicvolume;
    public float SFXvolume;
    public string Upkey;
    public string Downkey;
    public string Firekey;

    public string DownKey
    {
        get
        {
            return Downkey;
        }

        set
        {
            Downkey = value;
        }
    }

    public string UpKey
    {
        get
        {
            return Upkey;
        }

        set
        {
            Upkey = value;
        }
    }

    public string FireKey
    {
        get
        {
            return Firekey;
        }

        set
        {
            Firekey = value;
        }
    }

    public bool FullScreen
    {
        get
        {
            return Fullscreen;
        }

        set
        {
            Fullscreen = value;
        }
    }

    public int ResolutionIndex
    {
        get
        {
            return Resolutionindex;
        }

        set
        {
            Resolutionindex = value;
        }
    }

    public float MusicVolume
    {
        get
        {
            return Musicvolume;
        }

        set
        {
            Musicvolume = value;
        }
    }

    public float SFXVolume
    {
        get
        {
            return SFXvolume;
        }

        set
        {
            SFXvolume = value;
        }
    }
}
