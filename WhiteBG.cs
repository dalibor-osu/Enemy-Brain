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
            sprite.ScaleVec(1729231, ScreenScale * 1100, ScreenScale * 600);
            sprite.Fade(OsbEasing.In, 1729231, 1733102, 0, 1);
            sprite.Fade(1733102, 1783424, 1, 1);
            
        }
    }
}
