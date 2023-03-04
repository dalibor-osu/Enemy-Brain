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
    public abstract class Logo : StoryboardObjectGeneratorExtended
    {
        [Group("Other")]
        [Configurable] public string SpritePath = "sb/logo.png";
        [Configurable] public Color4 Color = Color4.White;

        protected float scale = 0.3f;
        protected int StartTime = 0;
        protected int EndTime = 0;
        protected OsbSprite logo;

        public override void Generate()
        {
            var layer = GetLayer("Logo");
            logo = layer.CreateSprite(SpritePath);
            logo.Color(StartTime, Color);
            logo.Scale(StartTime, ScreenScale * scale);
        }
    }
}
