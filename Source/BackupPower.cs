﻿using Verse;
using UnityEngine;

namespace BackupPower
{
	public class BackupPower : Mod
	{
		public static Settings Settings { get; private set; }
		public BackupPower(ModContentPack content) : base(content)
		{
			// initialize settings
			Settings = GetSettings<Settings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			base.DoSettingsWindowContents(inRect);
			GetSettings<Settings>().DoWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "Backup Power";
		}
	}
}