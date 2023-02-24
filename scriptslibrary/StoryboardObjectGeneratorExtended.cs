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
    public abstract class StoryboardObjectGeneratorExtended : StoryboardObjectGenerator
    {
        protected static int Width = 1980;
        protected static int Height = 1020; //1,574074
        protected static double ScreenScale = 480.0 / Height;
        protected static double GetBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration;
        protected static double GetHalfBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration / 2;
        protected static double GetQuarterBeatDuration(Beatmap beatmap, int offset) => beatmap.GetTimingPointAt(offset).BeatDuration / 4;
        protected static Vector2 MinimumDimensions = new Vector2(-107, 0);
        protected static Vector2 MaximumDimensions = new Vector2(747, 480);
        protected static Vector2 ScreenMiddle = new Vector2(320, 240);
        protected static double DegToRad(double degrees) => degrees * 0.0174532925;
    }

    public static class AddOns
    {
        public static void Flash(this OsbSprite sprite, double startTime, double duration, double flashPower = 1, double flashFinalState = 0)
        {
            if(duration <= 0) return;

            sprite.Fade(startTime, startTime + duration, flashPower, flashFinalState);
        }

        public static void RandomMovement(this OsbSprite sprite, double startTime, double endTime, double speed, Vector2 maxDistance, Vector2 origin, OsbEasing easing = OsbEasing.None)
        {
            if(startTime >= endTime) return;

            double currentTime = startTime;
            System.Random random = new System.Random();

            while(currentTime < endTime)
            {
                int negative = random.Next(0, 2) == 0 ? 1 : -1;
                float newX = (float)random.NextDouble() * maxDistance.X * negative + origin.X;
                negative = random.Next(0, 2) == 0 ? 1 : -1;
                float newY = (float)random.NextDouble() * maxDistance.Y * negative + origin.Y;
                Vector2 currentPos = sprite.PositionAt(currentTime);

                sprite.Move(easing, currentTime, currentTime + speed, currentPos.X, currentPos.Y, newX, newY);

                currentTime += speed;
            }
            
        }
    }
}