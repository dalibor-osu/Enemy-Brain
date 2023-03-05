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
            var balls = layer.CreateSprite("sb/balls.png");

            fog0.Fade(257188, 259093, 0, 0.4);
            fog0.Scale(257188, ScreenScale * 7);
            fog0.Color(257188, Color4.Yellow);
            fog0.MoveX(257188, 401950, 100, 450);
            fog0.Fade(400997, 402902, 0.4, 0);
            fog0.Rotate(257188, 402902, 0, 8);

            fog1.Fade(257188, 259093, 0, 0.4);
            fog1.Scale(257188, ScreenScale * 7);
            fog1.Color(257188, Color4.Green);
            fog1.MoveX(257188, 401950, 390, 100);
            fog1.Fade(400997, 402902, 0.4, 0);
            fog1.Rotate(257188, 402902, 0, -5);

            balls.Scale(287664, ScreenScale);
            balls.Fade(287664, 288735, 0, 0.1);
            balls.Rotate(287664, 402902, 0, 5);
            balls.Color(287664, Color4.Black);
            balls.Fade(400997, 402902, 0.1, 0);
        }
    }
}
