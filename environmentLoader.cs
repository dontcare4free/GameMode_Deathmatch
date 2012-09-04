// By Treynolds416, modified for GM_DM by Nullable

if (!isObject(environmentFakeClient))
    new AiConnection(environmentFakeClient) {
        bl_id = 888888;
        isAdmin = true;
        isSuperAdmin = true;
    };
function environmentFakeClient::hasPermission(%this) {
    return true;
}


function loadEnvironmentFromFile(%filePath) {
    %prefix = "$EnvGuiServer::";
    %prefixLen = strLen(%prefix);

    %file = new FileObject();
    %file.openForRead(%filePath);
    while(!%file.isEOF()) {
        %line = %file.readLine();

        %pref = getWord(%line,0);
        if (getSubStr(%pref, 0, %prefixLen) !$= %prefix) // Only care about the records starting with $EnvGuiServer::
            continue;
        %pref = getSubStr(%pref, %prefixLen, strLen(%pref)); // Cut off $EnvGuiServer::

        %value = getWords(%line, 1);
        
        %sPref = getWord($AdvGameEnvPref[%pref],0);
        if(%sPref !$= "") {
            %count = $EnvGuiServer["::" @ %sPref @ "Count"];
            for(%i=0;%i<%count;%i++) {
                    %idx = $EnvGuiServer["::" @ %sPref @  %i];
                    if(%idx $= %value) {
                            %value = %i;
                            %pref = %sPref @ getWord($AdvGameEnvPref[%pref],1);
                            %i = %count + 1;
                    }
            }
            if(%i == %count) {
                    error("loadEnvironmentFromFile() - Material \'" @ %value @ "\' not found");
                    continue;
            }
        }
        serverCmdEnvGui_setVar(environmentFakeClient, %pref, %value);//publicClient,%pref,%value);
    }
    %file.close();
    %file.delete();
}

$AdvGameEnvPref[SunFlareTopTexture] = "SunFlare TopIdx";
$AdvGameEnvPref[SunFlareBottomTexture] = "SunFlare BottomIdx";

$AdvGameEnvPref[SkyFile] = "Sky Idx";
$AdvGameEnvPref[WaterFile] = "Water Idx";
$AdvGameEnvPref[GroundFile] = "Ground Idx";
$AdvGameEnvPref[SunFlareTopTexture] = "SunFlare TopIdx";
$AdvGameEnvPref[SunFlareBottomTexture] = "SunFlare BottomIdx";
$AdvGameEnvPref[DayCycle] = "DayCycle Idx";
