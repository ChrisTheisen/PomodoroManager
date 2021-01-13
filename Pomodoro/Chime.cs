using System;
using System.Collections.Generic;
using System.Threading;

namespace Pomodoro
{
    public class Chime
    {
        public List<Note> Notes { get; set; }

        private Thread _thread;

        public Chime()
        {
            Notes = ScaleDown;
        }

        public Chime(Prefab prefab)
        {
            Notes = MapPrefab(prefab);
        }

        public Chime(List<Note> notes)
        {
            Notes = notes;
        }

        public static readonly decimal A = 55;
        public static readonly decimal AB = 58.2705m;
        public static readonly decimal B = 61.7354m;
        public static readonly decimal C = 65.4064m;
        public static readonly decimal CD = 69.2957m;
        public static readonly decimal D = 73.4162m;
        public static readonly decimal DE = 77.7817m;
        public static readonly decimal E = 82.4069m;
        public static readonly decimal F = 87.3071m;
        public static readonly decimal FG = 92.4986m;
        public static readonly decimal G = 97.9989m;
        public static readonly decimal GA = 103.826m;

        public static readonly int whole = 1024;
        public static readonly int half = 512;
        public static readonly int quarter = 256;
        public static readonly int eighth = 128;
        public static readonly int sixteenth = 64;

        public void PlaySynchronous()
        {
            PlayNotes();
        }

        public void Play()
        {
            //Do the noises in a different thread so it doesn't stop the timer.
            if (_thread != null && _thread.IsAlive) { _thread.Abort(); }

            _thread = new Thread(() => PlayNotes());
            _thread.Start();
        }

        private void PlayNotes()
        {
            for (var i = 0; i < Notes.Count; i++)
            {
                if (Notes[i].IsRest)
                {
                    Thread.Sleep(Notes[i].Duration);
                }
                else
                {
                    Console.Beep(Notes[i].Frequency, Notes[i].Duration);
                }
            }
        }

        public void End()
        {
            if (_thread != null && _thread.IsAlive) { _thread.Abort(); }
        }

        public enum Prefab { ScaleUp, ScaleDown, Happy, Bear, Bride, Twinkle, Elise, Jaws, Custom }

        private static List<Note> MapPrefab(Prefab prefab)
        {
            switch (prefab)
            {
                case Prefab.Bear:
                    return Bear;
                case Prefab.ScaleUp:
                    return ScaleUp;
                case Prefab.ScaleDown:
                    return ScaleDown;
                case Prefab.Happy:
                    return Happy;
                case Prefab.Bride:
                    return Bride;
                case Prefab.Twinkle:
                    return Twinkle;
                case Prefab.Elise:
                    return Elise;
                case Prefab.Jaws:
                    return Jaws;
                default:
                    return null;
            }
        }



        public static readonly List<Note> ScaleUp = new List<Note>
        {
            new Note((int)(A * 4), sixteenth),
            new Note((int)(B * 4), sixteenth),
            new Note((int)(C * 4), sixteenth),
            new Note((int)(D * 4), sixteenth),
            new Note((int)(E * 4), sixteenth),
            new Note((int)(F * 4), sixteenth),
            new Note((int)(G * 4), sixteenth),
            new Note((int)(A * 8), sixteenth)
        };

        public static readonly List<Note> ScaleDown = new List<Note>
        {
            new Note((int)(A * 8), sixteenth),
            new Note((int)(G * 4), sixteenth),
            new Note((int)(F * 4), sixteenth),
            new Note((int)(E * 4), sixteenth),
            new Note((int)(D * 4), sixteenth),
            new Note((int)(C * 4), sixteenth),
            new Note((int)(B * 4), sixteenth),
            new Note((int)(A * 4), sixteenth)
        };

        public static readonly List<Note> Happy = new List<Note>
        {
            new Note((int)(C * 2), eighth+sixteenth),
            new Note((int)(C * 2), sixteenth),
            new Note((int)(D * 2), quarter),
            new Note((int)(C * 2), quarter),
            new Note((int)(F * 2), quarter),
            new Note((int)(E * 2), half)
        };

        public static readonly List<Note> Bear = new List<Note>
        {
            new Note((int)(C * 4), eighth),
            new Note((int)(E * 4), quarter),
            new Note((int)(E * 4), eighth),
            new Note((int)(E * 4), eighth),
            new Note((int)(D * 4), eighth),
            new Note((int)(E * 4), eighth),
            new Note((int)(F * 4), quarter+eighth),
            new Note((int)(E * 4), quarter)
        };

        public static readonly List<Note> Bride = new List<Note>
        {
            new Note((int)(G * 2), quarter),
            new Note((int)(C * 4), eighth),
            new Note((int)(C * 4), sixteenth),
            new Note((int)(C * 4), quarter),
            new Note((int)(G * 2), quarter),
            new Note((int)(D * 4), eighth),
            new Note((int)(B * 4), sixteenth),
            new Note((int)(C * 4), quarter)
        };

        public static readonly List<Note> Twinkle = new List<Note>
        {
            new Note((int)(C * 2), quarter),
            new Note((int)(C * 2), quarter),
            new Note((int)(G * 2), quarter),
            new Note((int)(G * 2), quarter),
            new Note((int)(A * 4), quarter),
            new Note((int)(A * 4), quarter),
            new Note((int)(G * 2), quarter)
        };

        public static readonly List<Note> Elise = new List<Note>
        {
            new Note((int)(E * 8), sixteenth),
            new Note((int)(DE * 8), sixteenth),
            new Note((int)(E * 8), sixteenth),
            new Note((int)(DE * 8), sixteenth),
            new Note((int)(E * 8), sixteenth),
            new Note((int)(B * 8), sixteenth),
            new Note((int)(D * 8), sixteenth),
            new Note((int)(C * 8), sixteenth),
            new Note((int)(A * 8), eighth)
        };

        public static readonly List<Note> Jaws = new List<Note>
        {
            new Note((int)(D), half),
            new Note((int)(DE), eighth),
            new Note(true, half),
            new Note((int)(D), half),
            new Note((int)(DE), eighth),
            new Note(true, half),
            new Note((int)(D), quarter),
            new Note((int)(DE), eighth),
            new Note(true, quarter),
            new Note((int)(D), quarter),
            new Note((int)(DE), eighth),
            new Note(true, quarter),
            new Note((int)(D), eighth),
            new Note((int)(DE), eighth),
            new Note((int)(D), eighth),
            new Note((int)(DE), eighth),
        };
    }

    public class Note
    {
        public Note(int frequency, int duration)
        {
            Frequency = frequency;
            Duration = duration;
            IsRest = false;
        }

        public Note(bool isRest, int duration)
        {
            Frequency = 440;
            Duration = duration;
            IsRest = isRest;
        }


        public bool IsRest { get; set; }

        public int Frequency
        {
            get { return frequency; }
            set { frequency = Math.Min(32767, Math.Max(37, value)); }
        }
        private int frequency;


        public int Duration
        {
            get { return duration; }
            set { duration = Math.Min(Chime.whole, Math.Max(0, value)); }
        }
        private int duration;
    }
}
