using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Neandertalica_DBH
{
    public class SettingsUI : Mod
    {
        public static Settings Settings;

        public SettingsUI(ModContentPack content) : base(content)
        {
            // Load or initialize settings on startup
            Settings = GetSettings<Settings>();
        }

        // Returns the display name of your mod in the Mod Options list
        public override string SettingsCategory()
        {
            return "Water Pit";
        }

        // Draws the UI inside the Mod Options window
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            listing.Label($"Water Use Per Tick: {Settings.WaterPerUse:F3}");
            Settings.WaterPerUse = listing.Slider(Settings.WaterPerUse, 0f, 1f);

            listing.Gap(12f); // Spacing

            listing.Label($"Contamination Percent Per Second: {Settings.ContaminationPercentPerSecond:F2}");
            Settings.ContaminationPercentPerSecond = listing.Slider(Settings.ContaminationPercentPerSecond, 0f, 1f);

            listing.Gap(12f); // Spacing

            listing.Label($"Water Capacity: {Settings.Capacity}");
            IntRange range = new IntRange(Settings.Capacity);
            listing.IntRange(ref range, 1, 1000);
            Settings.Capacity = range.min;

            listing.Gap(12f); // Spacing

            if (listing.ButtonText("Reset"))
            {
                Settings.Reset();
            }

            listing.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
