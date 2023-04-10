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
    public class Fox : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("Fox");
            var fox = layer.CreateSprite("sb/fox.png");

            fox.Fade(0, 1788423, 1, 1);
            fox.Scale(0, ScreenScale * 0.85);
            
        }
    }
}
