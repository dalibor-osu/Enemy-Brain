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
    public class Intro : StoryboardObjectGeneratorExtended
    {
        [Configurable] public Color4 Color = Color4.Black;
        private float offset = 13f;
        private float scale = 0.35f;
        private StoryboardLayer layer;

        private double beatDuration;
        private double logoOpacity = 0.05;

        public override void Generate()
        {
            layer = GetLayer("Intro");
            beatDuration = Beatmap.GetTimingPointAt(1760).BeatDuration;

		    string foxStr = "Fox Stevenson";
            string ebStr = "Enemy Brain Entertainment Suite EP";
            string beatmap = "Beatmap by";
            string mappers = "Dalibor, CutoNaito, Slifer, Kyairie";
            string hitsounds = "Hitsounds by";
            string hitsounder = "Baack";
            
            DrawLine(GenerateLine(foxStr, 220), 1760, 5248);
            DrawLine(GenerateLine(ebStr, 260), 3155, 5248);

            DrawInfo(GenerateLine(beatmap, 220 - 55), 5946, 10132);
            DrawInfo(GenerateLine(mappers, 260 - 55), 6644, 10132);

            DrawInfo(GenerateLine(hitsounds, 220 + 55), 8039, 10132);
            DrawInfo(GenerateLine(hitsounder, 260 + 55), 8737, 10132);

            var logo = layer.CreateSprite("sb/logo.png");
            logo.Color(17, Color4.Black);
            logo.Scale(17, ScreenScale * 0.79);
            logo.Fade(17, 10132, logoOpacity, logoOpacity);
            logo.Fade(10132, 10132 + beatDuration * 2, logoOpacity, 0);

        }

        private void DrawInfo(List<OsbSprite> letters, int startTime, int endTime)
        {
            int timeOffset = 35;
            
            for (int i = 0; i < letters.Count; i++)
            {
                OsbSprite letter = letters[i];

                letter.Fade(startTime + timeOffset * i, startTime + timeOffset * i + beatDuration, 0, 1);
                letter.Fade(startTime + timeOffset * i + beatDuration, endTime, 1, 1);
                letter.Fade(endTime, endTime + beatDuration * 2, 1, 0);

                letter.Scale(startTime + timeOffset * i, ScreenScale * scale);

                letter.Color(startTime + timeOffset * i, Color);                
            }
        }

        private void DrawLine(List<OsbSprite> letters, int startTime, int endTime)
        {
            int timeOffset = 35;
            
            for (int i = 0; i < letters.Count; i++)
            {
                OsbSprite letter = letters[i];

                letter.Fade(startTime + timeOffset * i, startTime + timeOffset * i + beatDuration, 0, 1);
                letter.Fade(startTime + timeOffset * i + beatDuration, endTime, 1, 1);
                letter.Fade(endTime, endTime + beatDuration * 2, 1, 0);

                letter.Scale(startTime + timeOffset * i, ScreenScale * scale);

                letter.Color(startTime + timeOffset * i, Color);                
            }
        }

        private List<OsbSprite> GenerateLine(string line, float yOffest)
        {
            List<OsbSprite> letters = new List<OsbSprite>();
            int letterCount = line.Length;
            Vector2 initialPos = new Vector2(GetInitialX(letterCount, offset), yOffest);
            int index = 0;

            foreach (var letter in line)
            {
                if (letter == ' ') 
                {
                    index++;
                    continue;
                }
                string letterString = letter.ToString();

                if (letter == ',') letterString = "comma";

                letters.Add(
                    layer.CreateSprite(
                        "sb/letters/" + letterString.ToLower() + (char.IsLower(letter) ? "" : "_c") + ".png", 
                        OsbOrigin.Centre,
                        new Vector2(initialPos.X + offset * index, initialPos.Y)));
                
                index++;
            }

            return letters;
        }

        private float GetInitialX(int letterCount, float offset) =>
            320 - ((int)(letterCount / 2)) * offset + (letterCount % 2 == 0 ? offset * 0.5f : 0);
    }
}
