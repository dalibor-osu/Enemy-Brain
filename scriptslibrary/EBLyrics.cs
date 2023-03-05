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
using System.IO;

namespace StorybrewScripts
{
    public abstract class EBLyrics : StoryboardObjectGeneratorExtended
    {
        [Group("Other")]
        [Configurable] public string Song = "Enemy Brain";
        [Configurable] public Color4 Color = Color4.Black;

        protected float scale = 0.25f;
        protected List<Line> lines = new List<Line>();
        protected StoryboardLayer layer;
        protected float offset = 10f;

        public override void Generate()
        {
            layer = GetLayer("Lyrics: " + Song);
            string lyrics = "";

            using (var stream = OpenProjectFile("lyrics/" + Song + ".txt"))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                lyrics = reader.ReadToEnd();
            }

            string[] linesText = lyrics.Split('\n');

            for (int i = 0; i < linesText.Length; i++)
            {
                if (!linesText[i].Contains('#')) continue;

                string[] props = linesText[i].Split('#');
                if (props.Length < 2) continue;

                string text = props[0];
                int startTime = int.Parse(props[1]);
                int endTime = props.Length == 3 ? int.Parse(props[2]) : int.Parse(linesText[i + 1].Split('#')[1]);

                lines.Add(new Line(text, startTime, endTime));
            }
        }

        protected float GetInitialX(int letterCount, float offset) =>
            320 - ((int)(letterCount / 2)) * offset + (letterCount == 0 ? offset * 0.5f : 0);
    }
}
