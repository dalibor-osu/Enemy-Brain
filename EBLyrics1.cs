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
    public class EBLyrics1 : EBLyrics
    {
        public override void Generate()
        {
		    base.Generate();
            foreach (Line line in lines)
            {
                List<OsbSprite> letters = new List<OsbSprite>();
                int letterCount = line.Text.Length;
                Vector2 initialPos = new Vector2(GetInitialX(letterCount, offset), 240);
                int index = 0;

                foreach (var letter in line.Text)
                {
                    if (letter == ' ') 
                    {
                        index++;
                        continue;
                    }

                    letters.Add(
                        layer.CreateSprite(
                            "sb/letters/" + char.ToLower(letter) + (char.IsLower(letter) ? "" : "_c") + ".png", 
                            OsbOrigin.Centre,
                            new Vector2(initialPos.X + offset * index, initialPos.Y)));
                    
                    index++;
                }


                foreach (var letterSprite in letters)
                {
                    double transitionDuration = GetBeatDuration(Beatmap, line.StartTime);

                    letterSprite.Fade(OsbEasing.Out, line.StartTime, line.StartTime + transitionDuration, 0, 1);
                    letterSprite.Fade(line.StartTime + transitionDuration, line.EndTime - transitionDuration, 1, 1);
                    letterSprite.Fade(OsbEasing.In, line.EndTime - transitionDuration, line.EndTime, 1, 0);

                    letterSprite.MoveY(OsbEasing.Out, line.StartTime, line.StartTime + transitionDuration, 220, 240);
                    letterSprite.MoveY(OsbEasing.In, line.EndTime - transitionDuration, line.EndTime, 240, 260);

                    letterSprite.Color(line.StartTime, Color);
                    letterSprite.Scale(line.StartTime, ScreenScale * scale);
                    index++;
                }
            }
        }
    }
}
