using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class EBSpecialLyrics : StoryboardObjectGeneratorExtended
    {
        [Configurable] public Color4 Color = Color4.Black;
        StoryboardLayer layer;
        float offset = 35;
        float scale = 1;
    
        public override void Generate()
        {
		    layer = GetLayer("SpecialLyrics");
            Yeah(55481);
        }

        private void Yeah(int time)
        {
            var y = layer.CreateSprite("sb/letters/y_c.png", OsbOrigin.Centre);
            var e = layer.CreateSprite("sb/letters/e_c.png", OsbOrigin.Centre);
            var a = layer.CreateSprite("sb/letters/a_c.png", OsbOrigin.Centre);
            var h = layer.CreateSprite("sb/letters/h_c.png", OsbOrigin.Centre);

            double beatDuration = GetBeatDuration(Beatmap, time);
            double timeOffset = beatDuration / 4;

            List<OsbSprite> letters = new List<OsbSprite>{y, e, a, h};
            float initialX = GetInitialX(letters.Count, offset);
            float initialY = 300;
            float fade = 0.2f;

            for (int i = 0; i < letters.Count; i++)
            {
                OsbSprite letter = letters[i];
                letter.Color(time + timeOffset * i, Color);
                letter.Scale(time + timeOffset * i, ScreenScale * scale);
                letter.Move(OsbEasing.OutBack, time + timeOffset * i, time + beatDuration + timeOffset * i, initialX + offset * i, initialY, initialX + offset * i, ScreenMiddle.Y);
                letter.Fade(time + timeOffset * i, time + beatDuration / 2 + timeOffset * i, 0, fade);
                letter.Fade(time + beatDuration + timeOffset * i, 56091, fade, fade);
                letter.Fade(56091, 56178, fade, 0);
            }

        }

        private float GetInitialX(int letterCount, float offset) =>
            320 - ((int)(letterCount / 2)) * offset + (letterCount % 2 == 0 ? offset * 0.5f : 0);
    }
}
