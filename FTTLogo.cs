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
		    base.Generate();
            
            logo.StartLoopGroup(287664, 15);
            logo.MoveY(OsbEasing.InOutSine, 0, GetBeatDuration(Beatmap, StartTime) * 8, 250, 230);
            logo.MoveY(OsbEasing.InOutSine, GetBeatDuration(Beatmap, StartTime) * 8, GetBeatDuration(Beatmap, StartTime) * 16, 230, 250);
            logo.EndGroup();

            logo.Color(394331, 401950, logo.ColorAt(394331), Color4.RoyalBlue);

            logo.Fade(287664, 288616, 0, 1);
            logo.Fade(400997, 402902, 1, 0);
        }
    }
}
