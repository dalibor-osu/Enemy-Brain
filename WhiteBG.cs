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
    public class WhiteBG : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("WhiteBG");
            var sprite = layer.CreateSprite("sb/pixel.png");
            sprite.ScaleVec(365, ScreenScale * 1100, ScreenScale * 600);
            sprite.Fade(365, 1783424, 1, 1);
            
        }
    }
}
