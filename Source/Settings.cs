﻿using UnityEngine;
using Verse;

namespace BackupPower
{
	public class Settings : ModSettings
    {
        public int UpdateInterval = GenTicks.TicksPerRealSecond;
        public int MinimumOnTime = GenTicks.TicksPerRealSecond * 10;

		public void DoWindowContents(Rect canvas)
		{
			var options = new Listing_Standard();
			options.Begin(canvas);
            options.Label( I18n.Settings_UpdateInterval( (float)UpdateInterval / GenTicks.TicksPerRealSecond, 1f ), 
                           tooltip: I18n.Settings_UpdateInterval_Tooltip );
            UpdateInterval = (int) options.Slider( (float)UpdateInterval / GenTicks.TicksPerRealSecond, 1, 60 ) *
                             GenTicks.TicksPerRealSecond;

            options.Label( I18n.Settings_MinimumOnTime( (float) MinimumOnTime / GenTicks.TicksPerRealSecond, 10 ),
                           tooltip: I18n.Settings_MinimumOnTime_Tooltip );
            MinimumOnTime = (int) options.Slider( (float) MinimumOnTime / GenTicks.TicksPerRealSecond, 0, 60 ) *
                             GenTicks.TicksPerRealSecond;
            options.End();
		}
		
		public override void ExposeData()
        {
            Scribe_Values.Look( ref UpdateInterval, "updateInterval", GenTicks.TicksPerRealSecond );
            Scribe_Values.Look( ref MinimumOnTime, "minimumOnTime", GenTicks.TicksPerRealSecond * 10 );
        }
	}
}