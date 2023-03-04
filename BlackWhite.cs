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
    public class BlackWhite : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
            var layer = GetLayer("BlackWhite");

            var black = layer.CreateSprite("sb/pixel.png");
            var white = layer.CreateSprite("sb/pixel.png");
        
            black.Color(-500, Color4.Black);
            black.ScaleVec(-500, 1920 * ScreenScale, 1080 * ScreenScale);
            black.Fade(-500, 365, 1, 1);
            black.Fade(365, 1760, 1, 0);
        }
    }
}
