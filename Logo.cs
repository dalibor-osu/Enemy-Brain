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
using StorybrewCommon.Animations;

namespace StorybrewScripts
{
    public class Logo : StoryboardObjectGeneratorExtended
    {
        [Group("Timing")]
        [Configurable] public int StartTime = 0;
        [Configurable] public int EndTime = 0;

        [Group("Other")]
        [Configurable] public string SpritePath = "sb/logo.png";
        [Configurable] public Color4 Color = Color4.White;
        [Configurable] public Vector2 SpriteScale = new Vector2(1, 1);
        [Configurable] public float MinimalScale = 0.1f;


        private int BarCount = 2;
        private int BeatDivisor = 1/8;
        private OsbEasing FftEasing = OsbEasing.InExpo;
        private int FrequencyCutOff = 16000;
        private int LogScale = 600;
        private double Tolerance = 0.2;

        public override void Generate()
        {
		    if (StartTime == EndTime && Beatmap.HitObjects.FirstOrDefault() != null)
            {
                StartTime = (int)Beatmap.HitObjects.First().StartTime;
                EndTime = (int)Beatmap.HitObjects.Last().EndTime;
            }
            
            EndTime = Math.Min(EndTime, (int)AudioDuration);
            StartTime = Math.Min(StartTime, EndTime);
            var bitmap = GetMapsetBitmap(SpritePath);


            var heightKeyframes = new KeyframedValue<float>[BarCount];
            for (var i = 0; i < BarCount; i++)
                heightKeyframes[i] = new KeyframedValue<float>(null);

            var fftTimeStep = Beatmap.GetTimingPointAt(StartTime).BeatDuration / BeatDivisor;
            var fftOffset = fftTimeStep * 0.2;
            for (var time = (double)StartTime; time < EndTime; time += fftTimeStep)
            {
                var fft = GetFft(time + fftOffset, BarCount, null, FftEasing, FrequencyCutOff);
                for (var i = 0; i < BarCount; i++)
                {
                    var scale = (float)Math.Log10(1 + fft[i] * LogScale) * SpriteScale.Y / bitmap.Height;
                    if (scale < MinimalScale) scale = MinimalScale;

                    heightKeyframes[i].Add(time, scale);
                }
            }

            var layer = GetLayer("Logo");

            for (var i = 0; i < BarCount; i++)
            {
                var keyframes = heightKeyframes[i];
                keyframes.Simplify1dKeyframes(Tolerance, h => h);

                var bar = layer.CreateSprite(SpritePath);
                bar.CommandSplitThreshold = 300;

                var hasScale = false;
                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        hasScale = true;
                        bar.Scale(start.Time, end.Time, start.Value, end.Value);
                    },
                    MinimalScale,
                    s => (float)Math.Round(s, 2)
                );
                if (!hasScale) bar.ScaleVec(StartTime, SpriteScale.X, MinimalScale);
            }
        }
    }
}
