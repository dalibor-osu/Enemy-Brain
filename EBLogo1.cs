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
    public class EBLogo1 : Logo
    {
        private int[] hardBeatTimes = { 56527, 57051, 57225, 61062, 64551, 64899, 65248, 65597, 65946, 66295, 66644, 72225, 75713,
                                        76062, 76411, 76934, 76673 };
        double beatDuration;
        double hardScale = 1.05;	

        public override void Generate()
        {
            base.Generate();

            beatDuration = GetBeatDuration(Beatmap, StartTime);

            logo.Fade(StartTime, EndTime - beatDuration * 3, 1, 1);
            logo.Scale(OsbEasing.OutBack, StartTime, StartTime + GetBeatDuration(Beatmap, StartTime), 0, ScreenScale * scale);

            DnBBeat(logo, 57574, 75713, new []{64551, 65946});


            foreach (var time in hardBeatTimes)
            {
                HardHit(logo, time);
            }
            
            logo.Scale(OsbEasing.OutSine, EndTime - beatDuration * 4, EndTime - beatDuration * 3, ScreenScale * scale, ScreenScale * scale * 0.5);
            logo.Scale(OsbEasing.InSine, EndTime - beatDuration * 3, EndTime, ScreenScale * scale * 0.5, ScreenScale * 5);
            logo.Fade(EndTime - beatDuration * 3, EndTime, 1, 0);
            logo.Rotate(OsbEasing.InSine, EndTime - beatDuration * 3, EndTime, 0, MathHelper.DegreesToRadians(20));
        }

        private void DnBBeat(OsbSprite sprite, double StartTime, int EndTime, int[] pauseTimes)
        {

            while(StartTime < EndTime)
            {
                if (pauseTimes.Contains((int)Math.Round(StartTime)))
                {
                    StartTime += beatDuration * 4;
                    continue;
                }

                HardHit(sprite, StartTime);
                HardHit(sprite, StartTime + beatDuration);
                HardHit(sprite, StartTime + beatDuration * 2.5);
                HardHit(sprite, StartTime + beatDuration * 3);

                StartTime += beatDuration * 4;
            }
        }

        private void HardHit(OsbSprite sprite, double StartTime)
        {
            sprite.Scale(StartTime, StartTime + beatDuration * 0.5, ScreenScale * scale * hardScale, ScreenScale * scale);

            var ghost = layer.CreateSprite(SpritePath);

            ghost.Color(StartTime, Color);
            ghost.Scale(StartTime, StartTime + beatDuration, ScreenScale * scale * hardScale, ScreenScale * scale * hardScale * 1.2);
            ghost.Fade(StartTime, StartTime + beatDuration * 0.75, 0.3, 0);
        }
    }
}
