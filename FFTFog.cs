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
    public class FFTFog : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("FFT Fog");
            
            var fog0 = layer.CreateSprite("sb/fog/0.png");
            var fog1 = layer.CreateSprite("sb/fog/1.png");

            fog0.Fade(257188, 259093, 0, 1);
            fog0.Scale(257188, ScreenScale * 2);
        }
    }
}
