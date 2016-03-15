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
        public static SoundEffectInstance die;
        public static SoundEffectInstance chop1, chop2;
        public static SoundEffectInstance enemy1, enemy2;
        public static SoundEffectInstance footstep1, footstep2;
        public static SoundEffectInstance fruit1, fruit2;
        public static SoundEffectInstance soda1, soda2;
        public static SoundEffectInstance music;

        public static void Initialize(ContentManager content)
        {
            die = content.Load<SoundEffect>("Assets/Audio/scavengers_die").CreateInstance();
            chop1 = content.Load<SoundEffect>("Assets/Audio/scavengers_chop1").CreateInstance();
            chop2 = content.Load<SoundEffect>("Assets/Audio/scavengers_chop2").CreateInstance();
            enemy1 = content.Load<SoundEffect>("Assets/Audio/scavengers_enemy1").CreateInstance();
            enemy2 = content.Load<SoundEffect>("Assets/Audio/scavengers_enemy2").CreateInstance();
            footstep1 = content.Load<SoundEffect>("Assets/Audio/scavengers_footstep1").CreateInstance();
            footstep2 = content.Load<SoundEffect>("Assets/Audio/scavengers_footstep2").CreateInstance();
            fruit1 = content.Load<SoundEffect>("Assets/Audio/scavengers_fruit1").CreateInstance();
            fruit2 = content.Load<SoundEffect>("Assets/Audio/scavengers_fruit2").CreateInstance();
            soda1 = content.Load<SoundEffect>("Assets/Audio/scavengers_soda1").CreateInstance();
            soda2 = content.Load<SoundEffect>("Assets/Audio/scavengers_soda2").CreateInstance();

            music = content.Load<SoundEffect>("Assets/Audio/scavengers_music").CreateInstance();
            music.IsLooped = true;
        }

        public static void PlayRandom(params SoundEffectInstance[] effects)
        {
            var idx = random.Next(0, effects.Length);
            var effect = effects[idx];
            var pitch = random.Next(-Config.PITCH_SPREAD, Config.PITCH_SPREAD + 1) / 10000f;
            //effect.Play(0f, 0f, 0f);
            effect.Play();

            //System.Diagnostics.Debug.WriteLine($"{pitch}");
        }
    }
}
