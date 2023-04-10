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
    public class Ending : StoryboardObjectGeneratorExtended
    {
        public override void Generate()
        {
		    var layer = GetLayer("Ending");

            var baack = layer.CreateSprite("sb/ending/baack.png");
            var beatmap = layer.CreateSprite("sb/ending/beatmap.png");
            var cutonaito = layer.CreateSprite("sb/ending/cutonaito.png");
            var dalibor = layer.CreateSprite("sb/ending/dalibor.png");
            var fox = layer.CreateSprite("sb/ending/fox.png");
            var hitsounds = layer.CreateSprite("sb/ending/hitsounds.png");
            var kyairie = layer.CreateSprite("sb/ending/kyairie.png");
            var slifer = layer.CreateSprite("sb/ending/slifer.png");
            var thanks = layer.CreateSprite("sb/ending/thanks.png");
            var xizis = layer.CreateSprite("sb/ending/xizis.png");
            var cover = layer.CreateSprite("sb/ending/cover.png");
            var ebes = layer.CreateSprite("sb/ending/ebes.png");

            List<List<OsbSprite>> spriteList = new List<List<OsbSprite>> {
                new List<OsbSprite> {
                    beatmap, dalibor, cutonaito, kyairie, slifer, xizis
                },
                new List<OsbSprite> {
                    hitsounds, baack
                }
            };

            GenerateKilljoys(layer);
            Ebes(ebes, fox, cover);

            double startTime = 1733102 + 15000 - 3000;

            foreach (var list in spriteList)
            {
                foreach (var sprite in list)
                {
                    Scroll(sprite, startTime, ScreenScale * (list.IndexOf(sprite) == 0 ? 1.1 : 0.7));
                    startTime += 1500 + (list.IndexOf(sprite) == 0 ? 1000 : 0);
                }

                startTime += 3000;
            }

            startTime += 3000;

            thanks.Scale(startTime, ScreenScale * 0.7);
            thanks.MoveY(startTime, startTime + GetBeatDuration(Beatmap, 1700199) * 10, 240 + 250, 240);
            thanks.Fade(startTime, 1);
            thanks.Fade(1783424, 0);
        }

        private void Ebes(OsbSprite ebes, OsbSprite fox, OsbSprite cover)
        {
            double startTime = 1733102 - 3000;

            Scroll(fox, startTime, ScreenScale * 0.7);
            Scroll(ebes, startTime + 1700, ScreenScale * 0.7);
            Scroll(cover, startTime + 6000, ScreenScale * 0.3);
        }

        private void Scroll(OsbSprite sprite, double startTime, double scale, int direction = 1, double xOffset = 0)
        {
            sprite.Scale(startTime, scale);
            sprite.MoveX(startTime, 320 + xOffset);
            sprite.MoveY(startTime, startTime + GetBeatDuration(Beatmap, 1700199) * 20, 240 + (250 * direction), 240 - (250 * direction));
            sprite.Fade(startTime, 1);
            sprite.Fade(1783424, 0);
        }

        private void GenerateKilljoys(StoryboardLayer layer)
        {
            double startTime = 1733102 - 3700;
            double endTime = 1779553;
            double offset = 1000;
            double beatDuration = GetBeatDuration(Beatmap, (int)startTime);

            bool odd = false;

            while(startTime < endTime)
            {
                double spriteEndTime = startTime + 16000;
                double currentTime = getWhiteTick(startTime);

                OsbSprite dudeL = layer.CreateSprite("sb/killjoy.png");
                OsbSprite dudeR = layer.CreateSprite("sb/killjoy.png");

                dudeL.Color(startTime, Color4.Black);
                dudeR.Color(startTime, Color4.Black);
                Scroll(dudeL, startTime, ScreenScale * 0.2, -1, -220);
                Scroll(dudeR, startTime, ScreenScale * 0.2, -1, 220);

                int dir = 1;
                while(currentTime < spriteEndTime)
                {
                    dudeL.Rotate(currentTime, DegToRad(20) * dir * (odd ? 1 : -1));
                    dudeR.Rotate(currentTime, DegToRad(20) * dir * (odd ? -1 : 1));
                    dir *= -1;
                    currentTime += beatDuration;
                }    

                startTime += offset;
                odd = !odd;
            }
        }

        private double getWhiteTick(double currentTime)
        {
            double tick = 1733102;
            double previousTick = tick;

            while(tick < previousTick)
            {
                previousTick = tick;
                tick += GetBeatDuration(Beatmap, (int)tick);
            }

            return previousTick;
        }
    }
}
