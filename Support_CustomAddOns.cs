// By Greek2Me
// http://forum.blockland.us/index.php?topic=204740.msg5660718#msg5660718
// Slightly modified by Nullable


package DM_Support_CustomAddOns
{
	function forceRequiredAddOn(%addon)
	{
		if($GameModeArg $= "Add-Ons/GameMode_Deathmatch/gamemode.txt")
		{
			%old = $gameModeArg;
			$gameModeArg = "";
			%parent = parent::forceRequiredAddOn(%addon);
			$gameModeArg = %old;
			return %parent;
		}
		else
		{
			return parent::forceRequiredAddOn(%addon);
		}
	}
};
activatePackage(DM_Support_CustomAddOns);
