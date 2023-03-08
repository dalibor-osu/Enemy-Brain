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
        private int firstStartTime = 56178;

        private int[] hardBeatTimes = { };
        private int[] pauseTimes = { };
        double beatDuration;
        double hardScale = 1.05;	

        public override void Generate()
        {
            base.Generate();

            if (HardBeatTimes != "")
            {
                string[] hardbeatTimesStr = HardBeatTimes.Split(',');
                hardBeatTimes = new int[hardbeatTimesStr.Length];

                for (int i = 0; i < hardbeatTimesStr.Length; i++)
                {
                    hardBeatTimes[i] = int.Parse(hardbeatTimesStr[i].Trim());
                }
            }

            if (StopAnimationTimes != "")
            {
                string[] stopAnimationTimesStr = StopAnimationTimes.Split(',');
                pauseTimes = new int[stopAnimationTimesStr.Length];

                for (int i = 0; i < stopAnimationTimesStr.Length; i++)
                {
                    pauseTimes[i] = int.Parse(stopAnimationTimesStr[i].Trim());
                }
            }
            
            beatDuration = GetBeatDuration(Beatmap, StartTime);

            logo.Fade(StartTime, EndTime - beatDuration * 3, 1, 1);
            logo.Scale(OsbEasing.OutBack, StartTime, StartTime + GetBeatDuration(Beatmap, StartTime), 0, ScreenScale * scale);
            logo.RandomMovement(StartTime, EndTime, beatDuration * 4, new Vector2(10, 10), ScreenMiddle, OsbEasing.InOutSine);

            DnBBeat(logo, 57574 - firstStartTime + StartTime, 75713 - firstStartTime + StartTime, pauseTimes);


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
            ghost.Move(StartTime, sprite.PositionAt(StartTime));
        }
    }
}
