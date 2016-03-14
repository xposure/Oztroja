using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Oztroja
{
    public class Sound
    {
        private static Random random = new Random();
        public static SoundEffect die;
        public static SoundEffect chop1, chop2;
        public static SoundEffect enemy1, enemy2;
        public static SoundEffect footstep1, footstep2;
        public static SoundEffect fruit1, fruit2;
        public static SoundEffect soda1, soda2;
        public static SoundEffect music;
        public static SoundEffectInstance musicLoop;

        public static void Initialize(ContentManager content)
        {
            die = content.Load<SoundEffect>("Assets/Audio/scavengers_die");
            chop1 = content.Load<SoundEffect>("Assets/Audio/scavengers_chop1");
            chop2 = content.Load<SoundEffect>("Assets/Audio/scavengers_chop2");
            enemy1 = content.Load<SoundEffect>("Assets/Audio/scavengers_enemy1");
            enemy2 = content.Load<SoundEffect>("Assets/Audio/scavengers_enemy2");
            footstep1 = content.Load<SoundEffect>("Assets/Audio/scavengers_footstep1");
            footstep2 = content.Load<SoundEffect>("Assets/Audio/scavengers_footstep2");
            fruit1 = content.Load<SoundEffect>("Assets/Audio/scavengers_fruit1");
            fruit2 = content.Load<SoundEffect>("Assets/Audio/scavengers_fruit2");
            soda1 = content.Load<SoundEffect>("Assets/Audio/scavengers_soda1");
            soda2 = content.Load<SoundEffect>("Assets/Audio/scavengers_soda2");

            music = content.Load<SoundEffect>("Assets/Audio/scavengers_music");
            musicLoop = music.CreateInstance();
            musicLoop.IsLooped = true;
        }

        public static void PlayRandom(params SoundEffect[] effects)
        {
            var idx = random.Next(0, effects.Length);
            var effect = effects[idx];
            var pitch = random.Next(-Config.PITCH_SPREAD, Config.PITCH_SPREAD + 1) / 10000f;
            effect.Play(1f, pitch, 0f);

            System.Diagnostics.Debug.WriteLine($"{pitch}");
        }
    }
}
