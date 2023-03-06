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
    public class Names : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("Names");
            var tape0 = layer.CreateSprite("sb/tape0.png", OsbOrigin.Centre);
            var tape1 = layer.CreateSprite("sb/tape1.png", OsbOrigin.Centre);
            
            tape0.Move(17, 97, 117);
            tape0.Rotate(17, DegToRad(-25));
            tape0.Fade(17, 1783424, 0.7, 0.7);
            tape0.Scale(17, ScreenScale * 0.8);

            tape1.Move(17, 550, 360);
            tape1.Rotate(17, DegToRad(-35));
            tape1.Fade(17, 1783424, 0.7, 0.7);
            tape1.Scale(17, ScreenScale * 0.8);
        }
    }
}
