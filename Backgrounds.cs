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
    public class Backgrounds : StoryboardObjectGeneratorExtended
    {
        private int[] times = {365, 253378, 394331, 617763, 754562, 947120, 1137555, 1457370, 1651812, 1783424};
        public override void Generate()
        {
            var layer = GetLayer("Backgrounds");
		    List<OsbSprite> sprites = new List<OsbSprite>();

            for (int i = 1; i <= 9; i++)
            {
                sprites.Add(layer.CreateSprite("sb/bgs/" + i + ".png"));
            }

            for (int i = 0; i < 9; i++)
            {
                OsbSprite sprite = sprites[i];
                sprite.Scale(times[i], ScreenScale);

                if (i == 0)
                {
                    sprite.Fade(times[i], 1);
                    sprite.Fade(times[i + 1] + 5000, 0);
                    continue;
                }

                sprite.Fade(times[i] - 5000, times[i] + 5000, 0, 1);
                sprite.Fade(times[i + 1] + 5000, 0);
            }
        }
    }
}
