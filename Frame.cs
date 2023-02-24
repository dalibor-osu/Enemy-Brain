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
    public class Frame : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("Frame");
            var sprite = layer.CreateSprite("sb/frame.png");
            sprite.Scale(365, 1783424, ScreenScale, ScreenScale);
            sprite.Fade(365, 1);
        }
    }
}
