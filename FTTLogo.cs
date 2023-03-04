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
    public class FTTLogo : Logo
    {
        public override void Generate()
        {
            StartTime = 287664;
            EndTime = 379093;
		    base.Generate();
            
            logo.StartLoopGroup(287664, 15);
            logo.MoveY(OsbEasing.InOutSine, 0, GetBeatDuration(Beatmap, StartTime) * 8, 250, 230);
            logo.MoveY(OsbEasing.InOutSine, GetBeatDuration(Beatmap, StartTime) * 8, GetBeatDuration(Beatmap, StartTime) * 16, 230, 250);
            logo.EndGroup();
        }
    }
}
